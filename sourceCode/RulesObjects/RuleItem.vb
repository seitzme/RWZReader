''' <summary>
''' A distinct rule which is repeated with a rule export file
''' </summary>
''' <remarks></remarks>
Public Class RuleItem
    Public Property Header As Byte()
    Public Property Name As String
    Public Property Padding As Byte()
    Public Property Data As BaseRuleData

    ''' <summary>
    ''' Serializes the rule into a byte array for saving
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ToBytes(isFirstRule As Boolean) As Byte()
        Dim bytes As New Generic.List(Of Byte)

        With bytes
            .AddRange(Header)
            .Add(CByte(Name.Length))
            .AddRange(Text.Encoding.Unicode.GetBytes(Me.Name))
            .AddRange(Me.Padding)
            .AddRange(Me.Data.ToBytes(isFirstRule))
            .Add(&H00)
            .Add(&H00)

        End With

        Return bytes.ToArray

    End Function

End Class
