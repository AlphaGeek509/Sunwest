Imports System.IO


Public Class frmRemoveImages
    Dim txtPath(10) As TextBox
    Dim chkDelete(10) As CheckBox
    Dim strInitalDirectory As String = "C:\Documents and Settings\" & Environment.UserName & "\Desktop\"

    Private Sub ViewImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click, Button12.Click, Button13.Click, Button14.Click, Button15.Click, Button16.Click, Button17.Click, Button18.Click, Button19.Click, Button20.Click
        Dim btnCaller As Button = CType(sender, Button)
        Dim intIndex As Integer = btnCaller.Tag

        System.Diagnostics.Process.Start("Explorer.exe", txtPath(intIndex).Text)
    End Sub

    Public Sub frmAddImages_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtPath(1) = TextBox1
        txtPath(2) = TextBox2
        txtPath(3) = TextBox3
        txtPath(4) = TextBox4
        txtPath(5) = TextBox5
        txtPath(6) = TextBox6
        txtPath(7) = TextBox7
        txtPath(8) = TextBox8
        txtPath(9) = TextBox9
        txtPath(10) = TextBox10

        chkDelete(1) = CheckBox1
        chkDelete(2) = CheckBox2
        chkDelete(3) = CheckBox3
        chkDelete(4) = CheckBox4
        chkDelete(5) = CheckBox5
        chkDelete(6) = CheckBox6
        chkDelete(7) = CheckBox7
        chkDelete(8) = CheckBox8
        chkDelete(9) = CheckBox9
        chkDelete(10) = CheckBox10

        Dim strSQL As String
        Dim dsImagePaths As DataSet
        Dim intCtr As Integer

        strSQL = "SELECT WORK_ORDER_ID, ID, IMAGE_PATH, WORK_ORDER_ID " & _
                      "FROM IMAGES " & _
                      "WHERE WORK_ORDER_ID = '" & lblSaveID.Text & "'"

        dsImagePaths = fctGetDataSet(strSQL)

        If dsImagePaths.Tables(0).Rows.Count > 0 Then
            Do Until intCtr = dsImagePaths.Tables(0).Rows.Count Or intCtr = 9
                txtPath(intCtr + 1).Text = dsImagePaths.Tables(0).Rows(intCtr).Item("IMAGE_PATH")
                txtPath(intCtr + 1).Tag = dsImagePaths.Tables(0).Rows(intCtr).Item("ID")

                intCtr += 1
            Loop
        End If

        'subPositionFormOnScreen("MoveToLastPosition", Me)
    End Sub


    Public Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim strSQL As String
        Dim intPathCtr As Integer = 1
        Dim dsID As New DataSet
        Dim dsImageRoot As New DataSet
        Dim bolInsertStatus As Boolean
        Dim strImageType As String

        If lblImageType.Text = "TEMPLATE" Then
            strImageType = "TEMPLATE\"
        Else
            strImageType = ""
        End If


        Do Until intPathCtr = 11
            If chkDelete(intPathCtr).Checked = True Then
                If Len(txtPath(intPathCtr).Text) > 0 Then
                    '- Delete the path out to the database -'
                    Try
                        strSQL = "DELETE FROM IMAGES " & _
                                      "WHERE ID = '" & txtPath(intPathCtr).Tag & "'"

                        bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)

                        Try
                            File.Delete(txtPath(intPathCtr).Text)
                        Catch ex As Exception
                            MsgBox("Unable to delete: " & txtPath(intPathCtr).Text & " you'll have to manually delete the file.", MsgBoxStyle.OkOnly)
                        End Try


                        If bolInsertStatus = False Then
                            MsgBox("An error deleting the image!", MsgBoxStyle.Critical)
                            Exit Sub
                        End If
                    Catch ex As Exception
                        MsgBox("Error deleting image from database")
                    End Try
                End If

            End If
            intPathCtr += 1
        Loop

        If lblImageType.Text = "TEMPLATE" Then
            frmSearchOrAddTemplate.subLoadImageCount(lblSaveID.Text)
        Else
            frmWO.subLoadImageCount(lblSaveID.Text, "WO")
        End If

        Me.Close()
    End Sub
End Class