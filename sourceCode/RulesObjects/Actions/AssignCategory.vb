Public Class AssignCategory

    Private _Header() As Byte
    Public Property Name As String

    Public Sub New(bytes() As Byte)
        Parse(bytes)
    End Sub

    Private Sub Parse(bytes() As Byte)
        Dim br As New IO.BinaryReader(New IO.MemoryStream(bytes))
        Dim len As Integer

        _Header = br.ReadBytes(&H8)
        len = br.ReadByte
        Me.Name = System.Text.Encoding.Unicode.GetString(br.ReadBytes(len * 2))

        br.Dispose()

    End Sub

    Public Function ToBytes() As Byte()
        Dim bytes As New List(Of Byte)

        With bytes
            .Add(RuleAction.ActionEnum.AssignCategory)
            .AddRange(_Header) ' Length &h0b
            .Add(CByte(Name.Length))
            .AddRange(System.Text.Encoding.Unicode.GetBytes(Me.Name))
        End With

        Return bytes.ToArray

    End Function

End Class
