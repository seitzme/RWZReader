''' <summary>
''' The block of data that comprises a rule, including criteria, actions, and exceptions
''' </summary>
''' <remarks></remarks>
Public Class BaseRuleData
    Private _DataBytes() As Byte

    Public Property Criteria As RuleCriteria.CriteriaEnum

    Public Sub New(bytes() As Byte)
        _DataBytes = bytes
        Parse()
    End Sub

    Private Sub Parse()
        Dim tempBytes As List(Of Byte)

        ' The first rule has an extra 16-byte section in the middle of it.  This is accounted for in the length of the rule.
        If _DataBytes(&H4) = &HFF And _DataBytes(&H5) = &HFF Then ' Means extra &h10 bytes are included
            ' Remove First rule data
            tempBytes = New List(Of Byte)
            With tempBytes
                .AddRange(_DataBytes)
                .Item(&H4) = &H0
                .Item(&H5) = &H0
                .RemoveRange(&H6, &H10)
            End With

            _DataBytes = tempBytes.ToArray

        End If

        Criteria = CType(_DataBytes(&H2A), RuleCriteria.CriteriaEnum)

    End Sub

    ''' <summary>
    ''' Serializes the rule data back into bytes, including the size information
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ToBytes(Optional isFirstRule As Boolean = False) As Byte()
        Dim bytes As New Generic.List(Of Byte)

        With bytes
            .AddRange(_DataBytes)
            If isFirstRule Then
                .Item(&H4) = &HFF
                .Item(&H5) = &HFF
                .InsertRange(&H6, FirstRuleData)
            End If

            .InsertRange(0, New Byte() {CByte(.Count And &HFF), CByte(.Count >> 8)})

        End With

        Return bytes.ToArray
    End Function

    Private Function FirstRuleData() As Byte()
        Dim bytes As New Generic.List(Of Byte)

        With bytes
            .Add(&H00)
            .Add(&H00)
            .Add(&H0C)
            .Add(&H00)
            .AddRange(Text.Encoding.Default.GetBytes("CRuleElement"))
        End With

        Return bytes.ToArray

    End Function

End Class