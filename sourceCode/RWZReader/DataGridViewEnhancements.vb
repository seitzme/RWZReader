''' <summary>
''' This class contains functions that can enhance the datagridview
''' </summary>
''' <remarks></remarks>
Public Class DataGridViewEnhancements

    ''' <summary>
    ''' Enables binding of nested objects in the datapropertyname field
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' To use, add a event handler for the datagridview's cellformatting event to this method
    ''' </remarks>
    Shared Sub DatagridView_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        Dim dg As DataGridView

        Try
            dg = CType(sender, DataGridView)

            If dg.Rows(e.RowIndex).DataBoundItem IsNot Nothing AndAlso dg.Columns(e.ColumnIndex).DataPropertyName.Contains("."c) Then
                e.Value = BindProperty(dg.Rows(e.RowIndex).DataBoundItem, dg.Columns(e.ColumnIndex).DataPropertyName)
                e.FormattingApplied = True
            End If

        Catch ex As Exception

        End Try

    End Sub

    ' Used to bind nested objects to datagridview columns
    Private Shared Function BindProperty(ByVal propertyObject As Object, ByVal propertyName As String) As String
        Dim retValue As String = ""
        Dim properties As System.Reflection.PropertyInfo()
        Dim startPropertyName As String

        Try
            If propertyName.Contains("."c) Then
                startPropertyName = propertyName.Substring(0, propertyName.IndexOf("."c))
                properties = propertyObject.GetType().GetProperties

                Try
                    For Each info As System.Reflection.PropertyInfo In properties
                        If String.Compare(info.Name, startPropertyName, True) = 0 Then
                            retValue = BindProperty(info.GetValue(propertyObject, Nothing), propertyName.Substring(propertyName.IndexOf("."c) + 1))
                            Exit For
                        End If
                    Next

                Catch ex As Exception
                    Debug.WriteLine(ex.Message)

                End Try

            Else
                properties = propertyObject.GetType().GetProperties

                For Each info As System.Reflection.PropertyInfo In properties
                    If String.Compare(info.Name, propertyName, True) = 0 Then
                        If info.GetValue(propertyObject, Nothing) IsNot Nothing Then
                            retValue = info.GetValue(propertyObject, Nothing).ToString
                        Else
                            retValue = Nothing
                        End If
                        Exit For
                    End If
                Next

            End If

        Catch ex As Exception
            Debug.WriteLine(ex.Message)

        End Try

        Return retValue

    End Function



End Class
