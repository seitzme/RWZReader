''' <summary>
''' Provides support for criteria that rules use for matching
''' </summary>
''' <remarks>
''' First Critera appears x002A bytes after data block size bytes, (plus x0010 offset for first rule)
''' </remarks>
Public Class RuleCriteria
    Public Enum CriteriaEnum As Byte
        OnThisComputerOnly = &H4F
        WhereMyNameIsInTo = &HC2
        SentOnlyToMe = &HC9
        WhereMyNameIsNotInTo = &HCA
        FromPeople = &HCB
        SentToPeople = &HCC
        WithWordsInSubject = &HCD
        WithWordsInBody = &HCE
        WithWordsInSubjectOrBody = &HCF
        WhichIsAnAutomaticReply = &HDC
        WhichHasAnAttachment = &HDE
        WithSelectedProperties = &HDF
        WhichHasASizeBetween = &HE0
        WHereMyNameIsInCC = &HE2
        WhereMyNameIsInToOrCC = &HE3
        WhichUsesTheForm = &HE4
        WithWordsInRecipientsAddress = &HE5
        WithWordsInSendersAddress = &HE6
        WithWordsInMessageHeader = &HE8
        WhichIsAMeetingInvoice = &HF1
        AssignedToAnyCategory = &HF6
        FromRSSFeed = &HF7
        AssignedToSpecificCategory = &HD7
        FlaggedForAction = &HD0
        FlaggedAsImportance = &HD2
        FlaggedAsSensitivity = &HD3
        ReceivedBetween = &HE1
        ThroughSpecificAccount = &HEE
        SenderInSpeciedAddressBook = &HF0 ' Requires On This Computer only
    End Enum

End Class
