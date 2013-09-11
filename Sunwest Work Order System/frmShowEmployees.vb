Public Class frmShowEmployees

    Private Sub frmShowEmployees_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strSQL As String
        Dim dsEmployee As New DataSet
        Dim intCtr As Integer
        strSQL = "SELECT FIRST_NAME, LAST_NAME, USER_ID " & _
                      "FROM EMPLOYEE " & _
                      "WHERE STATUS = 'ACTIVE' " & _
                      "ORDER BY FIRST_NAME ASC"

        dsEmployee = fctGetDataSet(strSQL)

        If dsEmployee.Tables(0).Rows.Count > 0 Then
            Do Until intCtr = dsEmployee.Tables(0).Rows.Count
                cboEmployee.Items.Add(New cboItem(dsEmployee.Tables(0).Rows(intCtr).Item("FIRST_NAME") & " " & dsEmployee.Tables(0).Rows(intCtr).Item("LAST_NAME"), dsEmployee.Tables(0).Rows(intCtr).Item("USER_ID")))
                intCtr += 1
            Loop
        Else
            MsgBox("Error reading from table employee table", MsgBoxStyle.Critical, "DB Error")
        End If

        cboEmployee.SelectedIndex = -1
        dsEmployee.Dispose()
    End Sub

    Private Sub btnDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDone.Click
        If cboEmployee.SelectedIndex > -1 Then
            If Not IsDBNull(cboEmployee.SelectedValue) Then
                Dim cboItem As cboItem
                cboItem = cboEmployee.Items(cboEmployee.SelectedIndex)
                frmEmployee.subLoadForm(cboItem.ValueMember)
                Me.Close()
            End If
        End If
    End Sub
End Class