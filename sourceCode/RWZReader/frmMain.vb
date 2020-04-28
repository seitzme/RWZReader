Option Strict On

Imports Microsoft.Office.Interop

Public Class frmMain
    Dim f As RulesObjects.RulesExportFile
    Dim rules As BindingSource

    Dim dragSourceIndex As Integer
    Dim dragRows As DataGridViewSelectedRowCollection
    Dim dragSourceRectangle As Rectangle
    Dim dragDestIndex As Integer

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' set up datagrid for display
        dgRules.AutoGenerateColumns = False
        AddHandler dgRules.CellFormatting, AddressOf DataGridViewEnhancements.DatagridView_CellFormatting

    End Sub

    Private Sub cmdOpen_Click(sender As Object, e As EventArgs) Handles cmdOpen.Click
        ' open file
        If dlgOpenFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            f = RulesObjects.RulesExportFile.Parse(dlgOpenFile.FileName)

            ' bind to grid
            dgRules.DataSource = f

            lblRowCount.Text = String.Format("{0} Items", dgRules.Rows.Count)

        End If

    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        ' Save organized file
        If dlgSave.ShowDialog = Windows.Forms.DialogResult.OK Then
            f.Save(dlgSave.FileName)
            MsgBox("Saved.")
        End If

    End Sub

    Private Sub cmdReadFromOutlook_Click(sender As Object, e As EventArgs) Handles cmdReadFromOutlook.Click
        Dim instance As Object
        Dim app As Outlook.ApplicationClass
        Dim fl As Outlook.MAPIFolder
        Dim st As Outlook.StorageItem
        Dim pa As Outlook.PropertyAccessor
        Dim bytes() As Byte

        instance = GetObject([Class]:="Outlook.Application")

        If instance Is Nothing Then
            MsgBox("Outlook is not running,")
            Exit Sub
        End If

        app = DirectCast(instance, Outlook.ApplicationClass)

        fl = app.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox)
        st = fl.GetStorage("IPM.RuleOrganizer", Outlook.OlStorageIdentifierType.olIdentifyByMessageClass)
        pa = st.PropertyAccessor
        bytes = CType(pa.GetProperty("http://schemas.microsoft.com/mapi/proptag/0x68020102"), Byte())
        f = RulesObjects.RulesExportFile.Parse(bytes)

        ' bind to grid
        dgRules.DataSource = f

        lblRowCount.Text = String.Format("{0} Items", dgRules.Rows.Count)

    End Sub

    Private Sub cmdSaveToOutlook_Click(sender As Object, e As EventArgs) Handles cmdSaveToOutlook.Click
        Dim instance As Object
        Dim app As Outlook.ApplicationClass
        Dim fl As Outlook.MAPIFolder
        Dim st As Outlook.StorageItem
        Dim pa As Outlook.PropertyAccessor

        instance = GetObject([Class]:="Outlook.Application")

        If instance Is Nothing Then
            MsgBox("Outlook is not running,")
            Exit Sub
        End If

        app = DirectCast(instance, Outlook.ApplicationClass)

        fl = app.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox)
        st = fl.GetStorage("IPM.RuleOrganizer", Outlook.OlStorageIdentifierType.olIdentifyByMessageClass)
        pa = st.PropertyAccessor
        pa.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x68020102", f.GetBytes)
        st.Save()

        MsgBox("Saved.")

    End Sub

    Private Sub cmdMoveUp_Click(sender As Object, e As EventArgs) Handles cmdMoveUp.Click
        Dim indexes As New List(Of Integer)

        ' Collect the indexes that need moved
        For Each row As DataGridViewRow In dgRules.SelectedRows
            indexes.Add(row.Index)
        Next

        ' If nothing selected, nothing to do
        If indexes.Count = 0 Then Exit Sub

        ' Process the item indexes
        f.ChangeItemIndexes(indexes.ToArray, -1)

        ' highlight the rows using their new indexes
        dgRules.ClearSelection()
        For Each i As Integer In indexes
            If i > 0 Then
                dgRules.Rows(i - 1).Selected = True
            End If
        Next

        ' set the scroll position if items moved off the visiable area
        If indexes.Min < dgRules.FirstDisplayedScrollingRowIndex Then
            dgRules.FirstDisplayedScrollingRowIndex = indexes.Min
        End If

    End Sub

    Private Sub cmdMoveDown_Click(sender As Object, e As EventArgs) Handles cmdMoveDown.Click
        Dim indexes As New List(Of Integer)

        ' Collect indexes
        For Each row As DataGridViewRow In dgRules.SelectedRows
            indexes.Add(row.Index)
        Next

        ' exit if nothing selected
        If indexes.Count = 0 Then Exit Sub

        ' process the indexes
        f.ChangeItemIndexes(indexes.ToArray, 1)

        ' highlight the rows with new indexes
        dgRules.ClearSelection()
        For Each i As Integer In indexes
            If i < dgRules.Rows.Count - 1 Then
                dgRules.Rows(i + 1).Selected = True
            End If
        Next

        ' scroll display to keep last item visible
        If indexes.Max + indexes.Count > dgRules.FirstDisplayedScrollingRowIndex + dgRules.DisplayedRowCount(False) Then
            dgRules.FirstDisplayedScrollingRowIndex = indexes.Max + indexes.Count - dgRules.DisplayedRowCount(False)
        End If

    End Sub

    Private Sub cmdSort_Click(sender As Object, e As EventArgs) Handles cmdSort.Click
        Dim indexes As New List(Of Integer)

        ' Collect the indexes that need moved
        For Each row As DataGridViewRow In dgRules.SelectedRows
            indexes.Add(row.Index)
        Next

        ' If nothing selected, nothing to do
        If indexes.Count = 0 Then Exit Sub

        f.SortAlpha(indexes.ToArray)

        ' highlight the rows using their new indexes
        dgRules.ClearSelection()
        For i = indexes.Min To indexes.Min + indexes.Count - 1
            dgRules.Rows(i).Selected = True
        Next

        ' set the scroll position if items moved off the visiable area
        If indexes.Min < dgRules.FirstDisplayedScrollingRowIndex Then
            dgRules.FirstDisplayedScrollingRowIndex = indexes.Min
        End If

    End Sub

    Private Sub dgRules_DragDrop(sender As Object, e As DragEventArgs) Handles dgRules.DragDrop
        Dim pt As Point

        ' Determine the place to drop the selected items
        pt = dgRules.PointToClient(New Point(e.X, e.Y))
        dragDestIndex = dgRules.HitTest(pt.X, pt.Y).RowIndex

        ' drop in order depending on if dropping higher or lower
        If dragDestIndex <= dragSourceIndex Then
            DropItemsHigher()
        Else
            DropItemsLower()
        End If

    End Sub

    Private Sub dgRules_DragOver(sender As Object, e As DragEventArgs) Handles dgRules.DragOver

        ' Check to be sure items being dropped are datagrid rows
        If e.Data.GetDataPresent("System.Windows.Forms.DataGridViewSelectedRowCollection", True) Then
            e.Effect = DragDropEffects.Move
        End If

    End Sub

    Private Sub dgRules_MouseDown(sender As Object, e As MouseEventArgs) Handles dgRules.MouseDown
        Dim s As Size

        ' store the selected rows and the size of the drag area
        If CBool(e.Button And Windows.Forms.MouseButtons.Left) Then
            dragSourceIndex = dgRules.HitTest(e.X, e.Y).RowIndex
            dragRows = dgRules.SelectedRows

            If dragSourceIndex >= 0 Then
                s = SystemInformation.DragSize
                dragSourceRectangle = New Rectangle(New Point(e.X - (s.Width \ 2), e.Y - (s.Height \ 2)), s)

            Else
                dragSourceRectangle = Rectangle.Empty

            End If ' mouse down on an actual row

        End If ' left button down

    End Sub

    Private Sub dgRules_MouseMove(sender As Object, e As MouseEventArgs) Handles dgRules.MouseMove
        If CBool(e.Button And Windows.Forms.MouseButtons.Left) Then
            If dragSourceRectangle <> Rectangle.Empty AndAlso Not dragSourceRectangle.Contains(e.X, e.Y) Then
                ' Moved out of the drag rectangle
                dgRules.DoDragDrop(dragRows, DragDropEffects.Move)

            End If

        End If ' left button down

    End Sub

    Private Sub DropItemsHigher()
        Dim item As RulesObjects.RuleItem

        If dragDestIndex < 0 Then Exit Sub

        ' reassign the items in order
        For i As Integer = 0 To dragRows.Count - 1
            item = DirectCast(dragRows(i).DataBoundItem, RulesObjects.RuleItem)
            f.Remove(item)
            f.Insert(dragDestIndex, item)
        Next

        ' Highlight items, which are now contiguous
        dgRules.ClearSelection()
        For i As Integer = dragDestIndex To dragDestIndex + dragRows.Count - 1
            dgRules.Rows(i).Selected = True

        Next
    End Sub

    Private Sub DropItemsLower()
        Dim item As RulesObjects.RuleItem

        ' reassign place in order
        For i As Integer = dragRows.Count - 1 To 0 Step -1
            item = DirectCast(dragRows(i).DataBoundItem, RulesObjects.RuleItem)
            f.Remove(item)
            f.Insert(dragDestIndex, item)
        Next

        ' highlight new locations
        dgRules.ClearSelection()
        For i As Integer = dragDestIndex - dragRows.Count + 1 To dragDestIndex
            dgRules.Rows(i).Selected = True

        Next
    End Sub

End Class
