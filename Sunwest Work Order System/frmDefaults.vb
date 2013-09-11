Public Class frmDefaults

    Private Sub btnImagePath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImagePath.Click
        Dim fsdImage As New FolderBrowserDialog
        fsdImage.ShowDialog()

        txtImagePath.Text = fsdImage.SelectedPath
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim strSQL As String
        Dim dsImage As New DataSet
        Dim bolInsertStatus As Boolean

        strSQL = "SELECT APP_NAME, DEFAULT_PATH " & _
                        "FROM SETUP_PATHS " & _
                        "WHERE APP_NAME = 'IMAGE'"
        dsImage = fctGetDataSet(strSQL)

        txtImagePath.Text = txtImagePath.Text.Replace("\", "\\")

        If dsImage.Tables(0).Rows.Count = 0 Then
            strSQL = "INSERT SETUP_PATHS(APP_NAME, DEFAULT_PATH) " & _
                                            "VALUES('IMAGE', '" & txtImagePath.Text & "')"
        Else
            strSQL = "UPDATE SETUP_PATHS SET " & _
                            "APP_NAME = 'IMAGE', " & _
                            "DEFAULT_PATH = '" & txtImagePath.Text & "' " & _
                          "WHERE APP_NAME = 'IMAGE'"
        End If

        bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)

        If bolInsertStatus = False Then
            MsgBox("An error saving the default path!", MsgBoxStyle.Critical)
        End If

        Me.Close()
    End Sub

    Private Sub frmDefaults_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strSQL As String
        Dim dsImage As New DataSet

        strSQL = "SELECT APP_NAME, DEFAULT_PATH " & _
                        "FROM SETUP_PATHS " & _
                        "WHERE APP_NAME = 'IMAGE'"
        dsImage = fctGetDataSet(strSQL)

        txtImagePath.Text = dsImage.Tables(0).Rows(0).Item("DEFAULT_PATH")
    End Sub
End Class