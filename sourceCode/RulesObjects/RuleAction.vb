''' <summary>
''' Provides support for different actions that a rule invokes
''' </summary>
''' <remarks>
''' First instance of actions happens x000c bytes after last criteria data block
''' </remarks>
Public Class RuleAction

    Public Enum ActionEnum As Byte
        MoveToFolder = &H2C
        Delete = &H2D
        ForwardToEmail = &H2E
        ReplyUsingTemplate = &H2F
        DisplayMessage = &H30
        ClearMessageFlag = &H32
        AssignCategory = &H33
        PlayASound = &H36 ' Requires On This Computer Only
        MarkAsImportance = &H37
        CopyToFolder = &H39
        StopProcessingRules = &H42
        ForwardAsAttachment = &H47
        PrintIt = &H48
        StartAnApplication = &H49 ' Requires On This Computer Only
        PermanentlyDelete = &H4A ' Requires Stop Processing Rules
        MarkAsRead = &H4C
        DisplayDesktopAlert = &H4F
        FlagForFollowup = &H51
        ClearCategories = &H52
        OnThisComputerOnly = &HEF ' Length &h1e?

    End Enum
End Class
