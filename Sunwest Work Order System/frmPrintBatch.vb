Public Class frmPrintBatch

    Private Sub btnPrintBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintBatch.Click
        If Len(txtStart.Text) > 0 Then
            If IsNumeric(txtStart.Text) Then
                intBatchPrintStart = txtStart.Text
            Else
                MsgBox("Please input a numeric value for start", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        Else
            MsgBox("Please input a numeric value for start", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If Len(txtEnd.Text) > 0 Then
            If IsNumeric(txtEnd.Text) Then
                intBatchPrintEnd = txtEnd.Text
            Else
                MsgBox("Please input a numeric value for end", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        Else
            MsgBox("Please input a numeric value for end", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        Me.Close()
    End Sub
End Class