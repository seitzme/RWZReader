Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace RulesObjects_Unit_Tests
    <TestClass>
    Public Class UnitTest1
        <TestMethod>
        Sub TestTrue()
            Dim result As Boolean = True

            Assert.IsTrue(result, "${value} should be true")
        End Sub
    End Class
End Namespace

