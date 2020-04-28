<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dlgOpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.cmdOpen = New System.Windows.Forms.Button()
        Me.lblRowCount = New System.Windows.Forms.Label()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.dlgSave = New System.Windows.Forms.SaveFileDialog()
        Me.dgRules = New System.Windows.Forms.DataGridView()
        Me.colRuleName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRuleType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdMoveUp = New System.Windows.Forms.Button()
        Me.cmdMoveDown = New System.Windows.Forms.Button()
        Me.cmdSort = New System.Windows.Forms.Button()
        Me.cmdReadFromOutlook = New System.Windows.Forms.Button()
        Me.cmdSaveToOutlook = New System.Windows.Forms.Button()
        CType(Me.dgRules, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dlgOpenFile
        '
        Me.dlgOpenFile.Filter = "RWZ Files|*.rwz|All Files|*.*"
        '
        'cmdOpen
        '
        Me.cmdOpen.Location = New System.Drawing.Point(12, 12)
        Me.cmdOpen.Name = "cmdOpen"
        Me.cmdOpen.Size = New System.Drawing.Size(75, 23)
        Me.cmdOpen.TabIndex = 0
        Me.cmdOpen.Text = "Open File"
        Me.cmdOpen.UseVisualStyleBackColor = True
        '
        'lblRowCount
        '
        Me.lblRowCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRowCount.Location = New System.Drawing.Point(373, 486)
        Me.lblRowCount.Name = "lblRowCount"
        Me.lblRowCount.Size = New System.Drawing.Size(84, 15)
        Me.lblRowCount.TabIndex = 8
        Me.lblRowCount.Text = "0 Items"
        Me.lblRowCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(93, 12)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.Tag = ""
        Me.cmdSave.Text = "Save File"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'dlgSave
        '
        Me.dlgSave.DefaultExt = "rwz"
        Me.dlgSave.Filter = "RWZ Files|*.rwz|All Files|*.*"
        '
        'dgRules
        '
        Me.dgRules.AllowDrop = True
        Me.dgRules.AllowUserToAddRows = False
        Me.dgRules.AllowUserToDeleteRows = False
        Me.dgRules.AllowUserToResizeColumns = False
        Me.dgRules.AllowUserToResizeRows = False
        Me.dgRules.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgRules.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colRuleName, Me.colRuleType})
        Me.dgRules.Location = New System.Drawing.Point(12, 41)
        Me.dgRules.Name = "dgRules"
        Me.dgRules.ReadOnly = True
        Me.dgRules.RowHeadersVisible = False
        Me.dgRules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgRules.Size = New System.Drawing.Size(445, 442)
        Me.dgRules.TabIndex = 4
        '
        'colRuleName
        '
        Me.colRuleName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colRuleName.DataPropertyName = "Name"
        Me.colRuleName.HeaderText = "Rule Name"
        Me.colRuleName.Name = "colRuleName"
        Me.colRuleName.ReadOnly = True
        '
        'colRuleType
        '
        Me.colRuleType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colRuleType.DataPropertyName = "Data.Criteria"
        Me.colRuleType.HeaderText = "Rule Type"
        Me.colRuleType.Name = "colRuleType"
        Me.colRuleType.ReadOnly = True
        Me.colRuleType.Width = 81
        '
        'cmdMoveUp
        '
        Me.cmdMoveUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdMoveUp.Location = New System.Drawing.Point(463, 41)
        Me.cmdMoveUp.Name = "cmdMoveUp"
        Me.cmdMoveUp.Size = New System.Drawing.Size(75, 23)
        Me.cmdMoveUp.TabIndex = 5
        Me.cmdMoveUp.Text = "Move Up"
        Me.cmdMoveUp.UseVisualStyleBackColor = True
        '
        'cmdMoveDown
        '
        Me.cmdMoveDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdMoveDown.Location = New System.Drawing.Point(463, 70)
        Me.cmdMoveDown.Name = "cmdMoveDown"
        Me.cmdMoveDown.Size = New System.Drawing.Size(75, 23)
        Me.cmdMoveDown.TabIndex = 6
        Me.cmdMoveDown.Text = "Move Down"
        Me.cmdMoveDown.UseVisualStyleBackColor = True
        '
        'cmdSort
        '
        Me.cmdSort.Location = New System.Drawing.Point(463, 115)
        Me.cmdSort.Name = "cmdSort"
        Me.cmdSort.Size = New System.Drawing.Size(75, 37)
        Me.cmdSort.TabIndex = 7
        Me.cmdSort.Text = "Sort Selected"
        Me.cmdSort.UseVisualStyleBackColor = True
        '
        'cmdReadFromOutlook
        '
        Me.cmdReadFromOutlook.Location = New System.Drawing.Point(227, 12)
        Me.cmdReadFromOutlook.Name = "cmdReadFromOutlook"
        Me.cmdReadFromOutlook.Size = New System.Drawing.Size(112, 23)
        Me.cmdReadFromOutlook.TabIndex = 2
        Me.cmdReadFromOutlook.Text = "Read From Outlook"
        Me.cmdReadFromOutlook.UseVisualStyleBackColor = True
        '
        'cmdSaveToOutlook
        '
        Me.cmdSaveToOutlook.Location = New System.Drawing.Point(345, 13)
        Me.cmdSaveToOutlook.Name = "cmdSaveToOutlook"
        Me.cmdSaveToOutlook.Size = New System.Drawing.Size(112, 23)
        Me.cmdSaveToOutlook.TabIndex = 3
        Me.cmdSaveToOutlook.Text = "Save To Outlook"
        Me.cmdSaveToOutlook.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 520)
        Me.Controls.Add(Me.cmdSaveToOutlook)
        Me.Controls.Add(Me.cmdReadFromOutlook)
        Me.Controls.Add(Me.cmdSort)
        Me.Controls.Add(Me.cmdMoveDown)
        Me.Controls.Add(Me.cmdMoveUp)
        Me.Controls.Add(Me.dgRules)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.lblRowCount)
        Me.Controls.Add(Me.cmdOpen)
        Me.MinimumSize = New System.Drawing.Size(394, 272)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RWZ Reader"
        CType(Me.dgRules, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dlgOpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cmdOpen As System.Windows.Forms.Button
    Friend WithEvents lblRowCount As System.Windows.Forms.Label
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents dlgSave As System.Windows.Forms.SaveFileDialog
    Friend WithEvents dgRules As System.Windows.Forms.DataGridView
    Friend WithEvents cmdMoveUp As System.Windows.Forms.Button
    Friend WithEvents cmdMoveDown As System.Windows.Forms.Button
    Friend WithEvents colRuleName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRuleType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdSort As Button
    Friend WithEvents cmdReadFromOutlook As Button
    Friend WithEvents cmdSaveToOutlook As Button
End Class
