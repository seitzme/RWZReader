Public Class frmDetails

    Private rule As RulesObjects.RuleItem

    Public Sub New(item As RulesObjects.RuleItem)
        InitializeComponent()
        rule = item
    End Sub

    Private Sub frmDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Parse()
    End Sub

    Private Sub Parse()

    End Sub
End Class


