Imports Microsoft.Win32

Public Class frmLogin


    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim strSQL As String
        Dim dsSecurity As New DataSet
        Dim cboUsersItem As New cboItem

        If cboUsers.SelectedIndex = -1 Then
            Exit Sub
        End If

        cboUsersItem = cboUsers.Items(cboUsers.SelectedIndex)

        strSQL = "SELECT USER_ID, PASSWORD " & _
                      "FROM EMPLOYEE " & _
                      "WHERE USER_ID = '" & cboUsersItem.ValueMember & "' AND " & _
                            "PASSWORD = '" & txtPassword.Text & "' AND " & _
                            "STATUS = 'ACTIVE'"


        dsSecurity = fctGetDataSet(strSQL)

        If dsSecurity.Tables(0).Rows.Count > 0 Then
            gstrUserID = cboUsersItem.ValueMember
            Me.Close()
        Else
            MsgBox("Incorrect User ID and/or Password entered or your account is inactive!", MsgBoxStyle.Critical, "Security Error")
            txtPassword.SelectAll()
        End If

        dsSecurity.Dispose()
    End Sub

    Private Sub frmLogin_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'subPositionFormOnScreen("SavePosition", Me)
    End Sub

    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strSQL As String
        Dim dsSecurity As New DataSet
        Dim intCtr As Integer

        strSQL = "SELECT USER_ID " & _
                      "FROM EMPLOYEE " & _
                      "WHERE STATUS = 'ACTIVE' " & _
                      "ORDER BY USER_ID ASC"

        dsSecurity = fctGetDataSet(strSQL)

        If dsSecurity.Tables(0).Rows.Count > 0 Then
            Do Until intCtr = dsSecurity.Tables(0).Rows.Count
                cboUsers.Items.Add(New cboItem(Trim(dsSecurity.Tables(0).Rows(intCtr).Item("USER_ID")), dsSecurity.Tables(0).Rows(intCtr).Item("USER_ID")))

                intCtr += 1
            Loop
        End If

        cboUsers.Focus()
        'subPositionFormOnScreen("MoveToLastPosition", Me)
    End Sub

    Private Sub cboUsers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUsers.SelectedIndexChanged

        txtPassword.Focus()
    End Sub
End Class