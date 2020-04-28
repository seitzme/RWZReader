''' <summary>
''' Represents a RWZ file exported by Outlook
''' </summary>
''' <remarks></remarks>
Public Class RulesExportFile
    Inherits System.ComponentModel.BindingList(Of RulesObjects.RuleItem)

    Public Property Header As Byte()
    Public Property Trailer As Byte()
    Public Property ItemCount As Short

    Shared Function Parse(filename As String) As RulesExportFile
        Dim bytes() As Byte

        bytes = IO.File.ReadAllBytes(filename)

        Return RulesExportFile.Parse(bytes)

    End Function

    Shared Function Parse(bytes() As Byte) As RulesExportFile
        Dim file As New RulesExportFile
        Dim item As RuleItem
        Dim len As Integer
        Dim br As New IO.BinaryReader(New IO.MemoryStream(bytes))

        file.Header = br.ReadBytes(&H2C) ' Header
        file.ItemCount = br.ReadInt16

        Do
            item = New RuleItem
            item.Header = br.ReadBytes(&H4) ' Record header
            len = br.ReadByte ' Length of name
            item.Name = System.Text.Encoding.Unicode.GetString(br.ReadBytes(len * 2)) ' 2 bytes for each char

            item.Padding = br.ReadBytes(&H14) ' Padding

            If br.BaseStream.Position = br.BaseStream.Length Then
                ' incomplete final item. roll back to last item ending
                With br.BaseStream
                    .Position -= item.Padding.Length
                    .Position -= len * 2
                    .Position -= item.Header.Length
                    .Position -= 1
                End With

                Exit Do
            End If

            len = br.ReadInt16 ' Get length of data block
            item.Data = New RulesObjects.BaseRuleData(br.ReadBytes(len)) 'read data block

            file.Add(item)
            br.ReadBytes(2) ' Delimiter between rules

        Loop While br.BaseStream.Length - br.BaseStream.Position > 24

        file.Trailer = br.ReadBytes(CInt(br.BaseStream.Length - br.BaseStream.Position))

        br.Close()
        br.Dispose()

        Return file

    End Function

    Public Function GetBytes() As Byte()
        Dim s As IO.MemoryStream
        Dim sw As IO.BinaryWriter
        Dim sr As IO.BinaryReader
        Dim bytes() As Byte

        s = New IO.MemoryStream
        sw = New IO.BinaryWriter(s)

        sw.Write(Me.Header)
        sw.Write(Me.ItemCount)

        For i As Integer = 0 To Me.Count - 1
            sw.Write(Me.Item(i).ToBytes(i = 0))
        Next

        sw.Write(Me.Trailer)

        s.Seek(0, IO.SeekOrigin.Begin)

        sr = New IO.BinaryReader(s)
        bytes = sr.ReadBytes(CInt(s.Length))

        sr.Close()
        sw.Close()
        s.Close()

        sw.Dispose()
        sr.Dispose()
        s.Dispose()

        Return bytes

    End Function

    ''' <summary>
    ''' Saves the export file to disk
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <remarks></remarks>
    Public Sub Save(filename As String)
        IO.File.WriteAllBytes(filename, Me.GetBytes)

    End Sub

    ''' <summary>
    ''' Support function for moving items within the list
    ''' </summary>
    ''' <param name="itemIndexes">An array of indexes to move</param>
    ''' <param name="delta">The positive or negative number of spaces to move</param>
    ''' <remarks></remarks>
    Public Sub ChangeItemIndexes(itemIndexes() As Integer, delta As Integer)
        Dim item As RuleItem

        Array.Sort(itemIndexes)
        If delta > 0 Then Array.Reverse(itemIndexes)

        For Each i In itemIndexes
            If i + delta >= 0 AndAlso i + delta <= Me.Count - 1 Then
                item = Me.Item(i)
                Me.RemoveAt(i)
                Me.Insert(i + delta, item)

            End If ' Item can be moved without exceeding bounds

        Next ' Each index in array

        ' Raise event for databound controls to refresh
        OnListChanged(New System.ComponentModel.ListChangedEventArgs(ComponentModel.ListChangedType.Reset, 0))

    End Sub

    Public Sub SortAlpha(itemIndexes() As Integer)
        Dim startIndex As Integer
        Dim tempItems As List(Of RuleItem)

        startIndex = itemIndexes.Min
        tempItems = New List(Of RuleItem)

        Array.Sort(itemIndexes)
        Array.Reverse(itemIndexes)

        For Each i As Integer In itemIndexes
            tempItems.Add(Me.Item(i))
            Me.RemoveAt(i)
        Next

        For Each sortedItem As RuleItem In tempItems.OrderByDescending(Function(x) x.Name)
            Me.Insert(startIndex, sortedItem)
        Next

        ' Raise event for databound controls to refresh
        OnListChanged(New System.ComponentModel.ListChangedEventArgs(ComponentModel.ListChangedType.Reset, 0))

    End Sub

End Class

