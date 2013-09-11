
Public Class frmEmployee
    Dim strAddorEdit As String

    Private Sub btnDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDone.Click
        Dim strUserID As String
        Dim strSQL As String
        Dim strUpdateSecurity As String = Nothing
        Dim bolInsertStatus As Boolean

        If Len(txtFirst.Text) < 0 Then
            MsgBox("Please enter a first name.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If Len(txtLast.Text) < 0 Then
            MsgBox("Please enter a first and last name.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        strUserID = Trim(UCase(txtFirst.Text) & UCase(Mid(txtLast.Text, 1, 1)))

        If Len(txtPassword.Text) < 4 Then
            MsgBox("The confirm password must be more an 4 characters long!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If Len(txtConPassword.Text) < 4 Then
            MsgBox("The password must be more an 4 characters long!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If StrComp(txtPassword.Text, txtConPassword.Text, CompareMethod.Text) <> 0 Then
            MsgBox("The passwords do not match!", MsgBoxStyle.Critical)
            txtPassword.SelectAll()
            Exit Sub
        End If

        txtFirst.Text = txtFirst.Text.Replace("'", "")
        txtLast.Text = txtLast.Text.Replace("'", "")
        txtJobDesc.Text = txtJobDesc.Text.Replace("'", "")
        txtConPassword.Text = txtConPassword.Text.Replace("'", "")
        txtPassword.Text = txtPassword.Text.Replace("'", "")

        If strAddorEdit = "ADD" Then
            '- Insert Employee -'
            strSQL = "INSERT INTO EMPLOYEE(USER_ID, FIRST_NAME, LAST_NAME, JOB_TITLE, PASSWORD, STATUS) " & _
                          "VALUES('" & strUserID & "', '" & Trim(txtFirst.Text) & "', '" & Trim(txtLast.Text) & "', '" & txtJobDesc.Text & "', '" & txtConPassword.Text & "', 'ACTIVE')"

            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
            If bolInsertStatus = False Then
                MsgBox("An error occured adding the employee!", MsgBoxStyle.Critical)
            End If

            subInsertSecurity(strUserID)

            MsgBox("Employee " & strUserID & " added successfully!", MsgBoxStyle.Exclamation)
            Me.Close()
        Else
            '- Update Employee -'
            strSQL = "UPDATE EMPLOYEE SET " & _
                            "FIRST_NAME = '" & Trim(txtFirst.Text) & "', " & _
                            "LAST_NAME = '" & Trim(txtLast.Text) & "', " & _
                            "JOB_TITLE = '" & txtJobDesc.Text & "', " & _
                            "PASSWORD = '" & txtConPassword.Text & "', " & _
                            "STATUS = 'ACTIVE' " & _
                          "WHERE USER_ID = '" & strUserID & "'"

            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)

            If bolInsertStatus = False Then
                MsgBox("An error occured updating the employee!", MsgBoxStyle.Critical)
            End If

            subUpdateSecurity(strUserID)

            MsgBox("Employee " & strUserID & " updated successfully!", MsgBoxStyle.Exclamation)
            Me.Close()
        End If
    End Sub

    Public Sub subUpdateSecurity(ByVal strUserID As String)
        Dim strSQL As String
        Dim strUpdateSecurity As String = Nothing
        Dim bolInsertStatus As Boolean

        '- Update security for the employee -'
        '- Customer -'
        If chkCustomerAdd.Checked = True Then
            strSQL = "UPDATE SECURITY SET SEC_LEVEL = '" & chkCustomerAdd.Tag & "' WHERE USER_ID = '" & strUserID & "' AND SEC_APP = 'CUSTOMER_ADD'"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
            If bolInsertStatus = False Then
                MsgBox("An error occured modifying the Customer Add security level!", MsgBoxStyle.Critical)
            End If
        Else
            strSQL = "UPDATE SECURITY SET SEC_LEVEL = '0' WHERE USER_ID = '" & strUserID & "' AND SEC_APP = 'CUSTOMER_ADD'"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
        End If
        If chkCustomerEdit.Checked = True Then
            strSQL = "UPDATE SECURITY SET SEC_LEVEL = '" & chkCustomerEdit.Tag & "' WHERE USER_ID = '" & strUserID & "' AND SEC_APP = 'CUSTOMER_EDIT'"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
            If bolInsertStatus = False Then
                MsgBox("An error occured modifying the Customer Edit security level!", MsgBoxStyle.Critical)
            End If
        Else
            strSQL = "UPDATE SECURITY SET SEC_LEVEL = '0' WHERE USER_ID = '" & strUserID & "' AND SEC_APP = 'CUSTOMER_EDIT'"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
        End If

        '- Credit Card -'
        If chkCreditCardAdd.Checked = True Then
            strSQL = "UPDATE SECURITY SET SEC_LEVEL = '" & chkCreditCardAdd.Tag & "' WHERE USER_ID = '" & strUserID & "' AND SEC_APP = 'CREDIT_CARD_ADD'"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
            If bolInsertStatus = False Then
                MsgBox("An error occured modifying the Customer Add security level!", MsgBoxStyle.Critical)
            End If
        Else
            strSQL = "UPDATE SECURITY SET SEC_LEVEL = '0' WHERE USER_ID = '" & strUserID & "' AND SEC_APP = 'CREDIT_CARD_ADD'"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
        End If
        If chkCreditCardEdit.Checked = True Then
            strSQL = "UPDATE SECURITY SET SEC_LEVEL = '" & chkCreditCardEdit.Tag & "' WHERE USER_ID = '" & strUserID & "' AND SEC_APP = 'CREDIT_CARD_EDIT'"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
            If bolInsertStatus = False Then
                MsgBox("An error occured modifying the Customer Edit security level!", MsgBoxStyle.Critical)
            End If
        Else
            strSQL = "UPDATE SECURITY SET SEC_LEVEL = '0' WHERE USER_ID = '" & strUserID & "' AND SEC_APP = 'CREDIT_CARD_EDIT'"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
        End If


        '- WO -'
        If chkWOAdd.Checked = True Then
            strSQL = "UPDATE SECURITY SET SEC_LEVEL = '" & chkWOAdd.Tag & "' WHERE USER_ID = '" & strUserID & "' AND SEC_APP = 'WO_ADD'"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
            If bolInsertStatus = False Then
                MsgBox("An error occured modifying the WO Add security level!", MsgBoxStyle.Critical)
            End If
        Else
            strSQL = "UPDATE SECURITY SET SEC_LEVEL = '0' WHERE USER_ID = '" & strUserID & "' AND SEC_APP = 'WO_ADD'"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
        End If
        If chkWOEdit.Checked = True Then
            strSQL = "UPDATE SECURITY SET SEC_LEVEL = '" & chkWOEdit.Tag & "' WHERE USER_ID = '" & strUserID & "' AND SEC_APP = 'WO_EDIT'"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
            If bolInsertStatus = False Then
                MsgBox("An error occured modifying the WO Edit security level!", MsgBoxStyle.Critical)
            End If
        Else
            strSQL = "UPDATE SECURITY SET SEC_LEVEL = '0' WHERE USER_ID = '" & strUserID & "' AND SEC_APP = 'WO_EDIT'"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
        End If

        '- Images -'
        If chkImagesAdd.Checked = True Then
            strSQL = "UPDATE SECURITY SET SEC_LEVEL = '" & chkImagesAdd.Tag & "' WHERE USER_ID = '" & strUserID & "' AND SEC_APP = 'IMAGES_ADD'"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
            If bolInsertStatus = False Then
                MsgBox("An error occured modifying the Images Add security level!", MsgBoxStyle.Critical)
            End If
        Else
            strSQL = "UPDATE SECURITY SET SEC_LEVEL = '0' WHERE USER_ID = '" & strUserID & "' AND SEC_APP = 'IMAGES_ADD'"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
        End If
        If chkImagesEdit.Checked = True Then
            strSQL = "UPDATE SECURITY SET SEC_LEVEL = '" & chkImagesEdit.Tag & "' WHERE USER_ID = '" & strUserID & "' AND SEC_APP = 'IMAGES_EDIT'"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
            If bolInsertStatus = False Then
                MsgBox("An error occured modifying the Images Edit security level!", MsgBoxStyle.Critical)
            End If
        Else
            strSQL = "UPDATE SECURITY SET SEC_LEVEL = '0' WHERE USER_ID = '" & strUserID & "' AND SEC_APP = 'IMAGES_EDIT'"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
        End If


        '- EMPLOYEE -'
        If chkEmployeeAdd.Checked = True Then
            strSQL = "UPDATE SECURITY SET SEC_LEVEL = '" & chkEmployeeAdd.Tag & "' WHERE USER_ID = '" & strUserID & "' AND SEC_APP = 'EMPLOYEE_ADD'"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
            If bolInsertStatus = False Then
                MsgBox("An error occured modifying the EMPLOYEE Add security level!", MsgBoxStyle.Critical)
            End If
        Else
            strSQL = "UPDATE SECURITY SET SEC_LEVEL = '0' WHERE USER_ID = '" & strUserID & "' AND SEC_APP = 'EMPLOYEE_ADD'"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
        End If
        If chkEmployeeEdit.Checked = True Then
            strSQL = "UPDATE SECURITY SET SEC_LEVEL = '" & chkEmployeeEdit.Tag & "' WHERE USER_ID = '" & strUserID & "' AND SEC_APP = 'EMPLOYEE_EDIT'"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
            If bolInsertStatus = False Then
                MsgBox("An error occured modifying the EMPLOYEE Edit security level!", MsgBoxStyle.Critical)
            End If
        Else
            strSQL = "UPDATE SECURITY SET SEC_LEVEL = '0' WHERE USER_ID = '" & strUserID & "' AND SEC_APP = 'EMPLOYEE_EDIT'"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
        End If

    End Sub
    Public Sub subInsertSecurity(ByVal struserid As String)
        Dim strSQL As String
        Dim strUpdateSecurity As String = Nothing
        Dim bolInsertStatus As Boolean

        '- Insert security for the employee -'
        '- Customer -'
        If chkCustomerAdd.Checked = True Then
            strSQL = "INSERT INTO SECURITY(USER_ID, SEC_APP, SEC_LEVEL) VALUES('" & struserid & "', 'CUSTOMER_ADD', '" & chkCustomerAdd.Tag & "')"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
            If bolInsertStatus = False Then
                MsgBox("An error occured applying the Customer Add security level!", MsgBoxStyle.Critical)
            End If
        Else
            strSQL = "INSERT INTO SECURITY(USER_ID, SEC_APP, SEC_LEVEL) VALUES('" & struserid & "', 'CUSTOMER_ADD', '0')"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
        End If
        If chkCustomerEdit.Checked = True Then
            strSQL = "INSERT INTO SECURITY(USER_ID, SEC_APP, SEC_LEVEL) VALUES('" & struserid & "', 'CUSTOMER_EDIT', '" & chkCustomerEdit.Tag & "')"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
            If bolInsertStatus = False Then
                MsgBox("An error occured applying the Customer Edit security level!", MsgBoxStyle.Critical)
            End If
        Else
            strSQL = "INSERT INTO SECURITY(USER_ID, SEC_APP, SEC_LEVEL) VALUES('" & struserid & "', 'CUSTOMER_EDIT', '0')"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
        End If


        '- Admin -'
        If chkCreditCardAdd.Checked = True Then
            strSQL = "INSERT INTO SECURITY(USER_ID, SEC_APP, SEC_LEVEL) VALUES('" & struserid & "', 'CREDIT_CARD_ADD', '" & chkCreditCardAdd.Tag & "')"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
            If bolInsertStatus = False Then
                MsgBox("An error occured applying the Admin Add security level!", MsgBoxStyle.Critical)
            End If
        Else
            strSQL = "INSERT INTO SECURITY(USER_ID, SEC_APP, SEC_LEVEL) VALUES('" & struserid & "', 'CREDIT_CARD_ADD', '0')"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
        End If
        If chkCreditCardEdit.Checked = True Then
            strSQL = "INSERT INTO SECURITY(USER_ID, SEC_APP, SEC_LEVEL) VALUES('" & struserid & "', 'CREDIT_CARD_EDIT', '" & chkCreditCardEdit.Tag & "')"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
            If bolInsertStatus = False Then
                MsgBox("An error occured applying the Admin Edit security level!", MsgBoxStyle.Critical)
            End If
        Else
            strSQL = "INSERT INTO SECURITY(USER_ID, SEC_APP, SEC_LEVEL) VALUES('" & struserid & "', 'CREDIT_CARD_EDIT', '0')"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
        End If


        '- WO -'
        If chkWOAdd.Checked = True Then
            strSQL = "INSERT INTO SECURITY(USER_ID, SEC_APP, SEC_LEVEL) VALUES('" & struserid & "', 'WO_ADD', '" & chkWOAdd.Tag & "')"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
            If bolInsertStatus = False Then
                MsgBox("An error occured applying the WO Add security level!", MsgBoxStyle.Critical)
            End If
        Else
            strSQL = "INSERT INTO SECURITY(USER_ID, SEC_APP, SEC_LEVEL) VALUES('" & struserid & "', 'WO_ADD', '0')"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
        End If
        If chkWOEdit.Checked = True Then
            strSQL = "INSERT INTO SECURITY(USER_ID, SEC_APP, SEC_LEVEL) VALUES('" & struserid & "', 'WO_EDIT', '" & chkWOEdit.Tag & "')"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
            If bolInsertStatus = False Then
                MsgBox("An error occured applying the WO Edit security level!", MsgBoxStyle.Critical)
            End If
        Else
            strSQL = "INSERT INTO SECURITY(USER_ID, SEC_APP, SEC_LEVEL) VALUES('" & struserid & "', 'WO_EDIT', '0')"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
        End If


        '- Images -'
        If chkImagesAdd.Checked = True Then
            strSQL = "INSERT INTO SECURITY(USER_ID, SEC_APP, SEC_LEVEL) VALUES('" & struserid & "', 'IMAGES_ADD', '" & chkImagesAdd.Tag & "')"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
            If bolInsertStatus = False Then
                MsgBox("An error occured applying the Images Add security level!", MsgBoxStyle.Critical)
            End If
        Else
            strSQL = "INSERT INTO SECURITY(USER_ID, SEC_APP, SEC_LEVEL) VALUES('" & struserid & "', 'IMAGES_ADD', '0')"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
        End If
        If chkImagesEdit.Checked = True Then
            strSQL = "INSERT INTO SECURITY(USER_ID, SEC_APP, SEC_LEVEL) VALUES('" & struserid & "', 'IMAGES_EDIT', '" & chkImagesEdit.Tag & "')"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
            If bolInsertStatus = False Then
                MsgBox("An error occured applying the Images Edit security level!", MsgBoxStyle.Critical)
            End If
        Else
            strSQL = "INSERT INTO SECURITY(USER_ID, SEC_APP, SEC_LEVEL) VALUES('" & struserid & "', 'IMAGES_EDIT', '0')"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
        End If


        '- EMPLOYEE -'
        If chkEmployeeAdd.Checked = True Then
            strSQL = "INSERT INTO SECURITY(USER_ID, SEC_APP, SEC_LEVEL) VALUES('" & struserid & "', 'EMPLOYEE_ADD', '" & chkEmployeeAdd.Tag & "')"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
            If bolInsertStatus = False Then
                MsgBox("An error occured applying the EMPLOYEE Add security level!", MsgBoxStyle.Critical)
            End If
        Else
            strSQL = "INSERT INTO SECURITY(USER_ID, SEC_APP, SEC_LEVEL) VALUES('" & struserid & "', 'EMPLOYEE_ADD', '0')"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
        End If
        If chkEmployeeEdit.Checked = True Then
            strSQL = "INSERT INTO SECURITY(USER_ID, SEC_APP, SEC_LEVEL) VALUES('" & struserid & "', 'EMPLOYEE_EDIT', '" & chkEmployeeEdit.Tag & "')"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
            If bolInsertStatus = False Then
                MsgBox("An error occured applying the EMPLOYEE Edit security level!", MsgBoxStyle.Critical)
            End If
        Else
            strSQL = "INSERT INTO SECURITY(USER_ID, SEC_APP, SEC_LEVEL) VALUES('" & struserid & "', 'EMPLOYEE_EDIT', '0')"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
        End If
    End Sub

    Public Sub subLoadUser(ByVal strUserID As String)
        Dim strSQL As String
        Dim dsUserID As New DataSet

        strSQL = "SELECT FIRST_NAME, LAST_NAME, JOB_TITLE, USER_ID, PASSWORD " & _
               "FROM EMPLOYEE " & _
               "WHERE USER_ID = '" & strUserID & "' "

        dsUserID = fctGetDataSet(strSQL)

        '- User is found in the system -'
        If dsUserID.Tables(0).Rows.Count > 0 Then
            txtFirst.Text = dsUserID.Tables(0).Rows(0).Item("FIRST_NAME")
            txtLast.Text = dsUserID.Tables(0).Rows(0).Item("LAST_NAME")
            txtPassword.Text = dsUserID.Tables(0).Rows(0).Item("PASSWORD")
            txtConPassword.Text = dsUserID.Tables(0).Rows(0).Item("PASSWORD")
            txtJobDesc.Text = dsUserID.Tables(0).Rows(0).Item("JOB_TITLE")
        End If

        dsUserID.Dispose()
    End Sub
    Public Sub subLoadSecurity(ByVal strUserID As String)
        Dim strSQL As String
        Dim dsSecurity As New DataSet
        Dim intRowCtr As Integer

        strSQL = "SELECT USER_ID, SEC_APP, SEC_LEVEL " & _
               "FROM SECURITY " & _
               "WHERE USER_ID = '" & strUserID & "' "

        dsSecurity = fctGetDataSet(strSQL)

        '- User is found in the system -'
        If dsSecurity.Tables(0).Rows.Count > 0 Then
            Do Until intRowCtr = dsSecurity.Tables(0).Rows.Count
                '- Customer -'
                If dsSecurity.Tables(0).Rows(intRowCtr).Item("SEC_APP") = "CUSTOMER_ADD" And dsSecurity.Tables(0).Rows(intRowCtr).Item("SEC_LEVEL") = 100 Then
                    chkCustomerAdd.Checked = True
                End If

                If dsSecurity.Tables(0).Rows(intRowCtr).Item("SEC_APP") = "CUSTOMER_EDIT" And dsSecurity.Tables(0).Rows(intRowCtr).Item("SEC_LEVEL") = 75 Then
                    chkCustomerEdit.Checked = True
                End If


                '- Admin -'
                If dsSecurity.Tables(0).Rows(intRowCtr).Item("SEC_APP") = "CREDIT_CARD_ADD" And dsSecurity.Tables(0).Rows(intRowCtr).Item("SEC_LEVEL") = 100 Then
                    chkCreditCardAdd.Checked = True
                End If
                If dsSecurity.Tables(0).Rows(intRowCtr).Item("SEC_APP") = "CREDIT_CARD_EDIT" And dsSecurity.Tables(0).Rows(intRowCtr).Item("SEC_LEVEL") = 75 Then
                    chkCreditCardEdit.Checked = True
                End If


                '- Work Orders -'
                If dsSecurity.Tables(0).Rows(intRowCtr).Item("SEC_APP") = "WO_ADD" And dsSecurity.Tables(0).Rows(intRowCtr).Item("SEC_LEVEL") = 100 Then
                    chkWOAdd.Checked = True
                End If

                If dsSecurity.Tables(0).Rows(intRowCtr).Item("SEC_APP") = "WO_EDIT" And dsSecurity.Tables(0).Rows(intRowCtr).Item("SEC_LEVEL") = 75 Then
                    chkWOEdit.Checked = True
                End If


                '- Images -'
                If dsSecurity.Tables(0).Rows(intRowCtr).Item("SEC_APP") = "IMAGES_ADD" And dsSecurity.Tables(0).Rows(intRowCtr).Item("SEC_LEVEL") = 100 Then
                    chkImagesAdd.Checked = True
                End If

                If dsSecurity.Tables(0).Rows(intRowCtr).Item("SEC_APP") = "IMAGES_EDIT" And dsSecurity.Tables(0).Rows(intRowCtr).Item("SEC_LEVEL") = 75 Then
                    chkImagesEdit.Checked = True
                End If


                '- Employee -'
                If dsSecurity.Tables(0).Rows(intRowCtr).Item("SEC_APP") = "EMPLOYEE_ADD" And dsSecurity.Tables(0).Rows(intRowCtr).Item("SEC_LEVEL") = 100 Then
                    chkEmployeeAdd.Checked = True
                End If

                If dsSecurity.Tables(0).Rows(intRowCtr).Item("SEC_APP") = "EMPLOYEE_EDIT" And dsSecurity.Tables(0).Rows(intRowCtr).Item("SEC_LEVEL") = 75 Then
                    chkEmployeeEdit.Checked = True
                End If

                intRowCtr += 1
            Loop
        End If

        dsSecurity.Dispose()
    End Sub

    Public Sub subLoadForm(ByVal strUserID As String)
        subClear()

        If Len(strUserID) > 0 Then
            subLoadUser(strUserID)
            subLoadSecurity(strUserID)
            strAddorEdit = "EDIT"
        Else
            strAddorEdit = "ADD"
        End If
        Me.ShowDialog()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim msgResult As MsgBoxResult
        Dim strSQL As String
        Dim bolInsertStatus As Boolean
        If Len(UCase(txtFirst.Text) & UCase(Mid(txtLast.Text, 1, 1))) > 0 Then
            msgResult = MsgBox("Are you sure you want to delete employee " & UCase(txtFirst.Text) & UCase(Mid(txtLast.Text, 1, 1)) & "?", MsgBoxStyle.YesNo)

            If msgResult = MsgBoxResult.Yes Then
                strSQL = "UPDATE EMPLOYEE SET " & _
                            "STATUS = 'INACTIVE' " & _
                          "WHERE USER_ID = '" & UCase(txtFirst.Text) & UCase(Mid(txtLast.Text, 1, 1)) & "'"

                bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)

                If bolInsertStatus = True Then
                    MsgBox(UCase(txtFirst.Text) & UCase(Mid(txtLast.Text, 1, 1)) & " was successfully deleted from the database!", MsgBoxStyle.OkOnly)
                    Me.Close()
                Else
                    MsgBox("An error occured updating the employee!", MsgBoxStyle.Critical)
                End If
            End If
        End If
    End Sub

    Public Sub subClear()
        txtFirst.Text = Nothing
        txtLast.Text = Nothing
        txtJobDesc.Text = Nothing
        txtConPassword.Text = Nothing
        txtPassword.Text = Nothing

        '- Customer -'
        chkCustomerAdd.Checked = False
        chkCustomerEdit.Checked = False

        '- Admin -'
        chkCreditCardAdd.Checked = False
        chkCreditCardEdit.Checked = False


        '- WO -'
        chkWOAdd.Checked = False
        chkWOEdit.Checked = False

        '- Images -'
        chkImagesAdd.Checked = False
        chkImagesEdit.Checked = False

        '- Employee -'
        chkEmployeeAdd.Checked = False
        chkEmployeeEdit.Checked = False
    End Sub

    Private Sub frmEmployee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim intEmployee As Integer

        subCheckSecurity("EMPLOYEE_EDIT", intEmployee)
        If intEmployee = 75 Then
            btnDone.Enabled = True
        Else
            btnDone.Enabled = False
        End If
    End Sub

    Private Sub chkWOAdd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWOAdd.CheckedChanged

    End Sub
End Class