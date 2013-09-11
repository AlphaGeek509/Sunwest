Public Class frmCopyTemplate

    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        Dim strSQL As String
        Dim dsValidTemplateName As DataSet

        strSQL = "SELECT ID " & _
                      "FROM TEMPLATE " & _
                      "WHERE DESCRIPTION = '" & txtNewTemplateName.Text & "'"

        dsValidTemplateName = fctGetDataSet(strSQL)

        If dsValidTemplateName.Tables(0).Rows.Count > 0 Then
            txtNewTemplateName.SelectAll()
            MsgBox("You already have a template by that name.", MsgBoxStyle.Critical)

        Else
            gstrCopyTemplateName = txtNewTemplateName.Text

            If chkIncludePictures.Checked = True Then
                bolCopyImages = True
            End If
            Me.Close()
        End If
    End Sub

    Private Sub lblOldTemplateName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblOldTemplateName.Click
        Clipboard.SetDataObject(lblOldTemplateName.Text)
    End Sub
End Class