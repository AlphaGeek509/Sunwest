Public Class frmCustomer
    Public Function fctInsertCustomer() As String
        Dim msgResult As MsgBoxResult
        Dim bolInsertStatus As Boolean
        Dim strSQL As String
        Dim cboBillStateItem As cboItem
        Dim cboShipStateItem As cboItem
        Dim strCardType As String = Nothing
        Dim dsFindCust As New DataSet

        Dim strCustomerExists As String

        cboBillStateItem = cboBillState.Items(cboBillState.SelectedIndex)
        cboShipStateItem = cboShipState.Items(cboShipState.SelectedIndex)


        msgResult = MsgBox("Would you like to add customer " & UCase(lblCustomerID.Text) & " to the database?", MsgBoxStyle.YesNo, "Customer ID not found in the database.")
        If msgResult = MsgBoxResult.Yes Then
            '- First check to see if the customer id is in the database somewhere -'
            strCustomerExists = fctCustomerExists(lblCustomerID.Text)

            If strCustomerExists = "YES" Then
                strSQL = "SELECT CUSTOMER_ID " & _
                            "FROM AUTO_GENERATE"

                dsFindCust = fctGetDataSet(strSQL)

                lblCustomerID.Text = lblCustomerID.Text & CInt(dsFindCust.Tables(0).Rows(0).Item("CUSTOMER_ID")) + 1

                strSQL = "UPDATE AUTO_GENERATE SET ID_VALUE = '" & CInt(dsFindCust.Tables(0).Rows(0).Item("CUSTOMER_ID")) + 1 & "' WHERE ID_NAME = 'CUSTOMER_ID'"
                bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
                If bolInsertStatus = False Then
                    MsgBox("An error occured updating table AUTO_GENERATE!", MsgBoxStyle.Critical)
                End If
            End If


            '- Insert a new customer BILL TO record into the database -'
            strSQL = "INSERT CUSTOMER_BILL_TO(CUST_ID, FIRST_NAME, LAST_NAME, COMPANY, ADDR_1, ADDR_2, ADDR_3, CITY, STATE, DAY_PHONE, ZIPCODE, EVENING_PHONE, EMAIL, PAYMENT_TYPE) " & _
                         "VALUE('" & UCase(lblCustomerID.Text) & "', '" & Trim(txtBillFirst.Text) & "', '" & Trim(txtBillLast.Text) & "', '" & Trim(txtBillCompany.Text) & "', '" & Trim(txtBillAddr1.Text) & "', '" & Trim(txtBillAddr2.Text) & "', '" & Trim(txtBillAddr3.Text) & "', " & _
                         "'" & Trim(txtBillCity.Text) & "', '" & cboBillStateItem.ValueMember & "', '" & Trim(txtBillDayPhone.Text) & "', '" & Trim(txtBillZipcode.Text) & "', '" & Trim(txtBillEveningPhone.Text) & "', '" & Trim(txtBillEmail.Text) & "', '" & cboPaymentType.SelectedItem & "')"

            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)

            If bolInsertStatus = False Then
                MsgBox("An error occured adding the Customer Bill To Table!", MsgBoxStyle.Critical)
                Return "ERROR"
            End If




            '- Insert a new customer SHIP TO record into the database -'
            strSQL = "INSERT CUSTOMER_SHIP_TO(CUST_ID, FIRST_NAME, LAST_NAME, COMPANY, ADDR_1, ADDR_2, ADDR_3, CITY, STATE, DAY_PHONE, ZIPCODE, EVENING_PHONE, EMAIL) " & _
                         "VALUE('" & UCase(lblCustomerID.Text) & "', '" & Trim(txtShipFirst.Text) & "', '" & Trim(txtShipLast.Text) & "', '" & Trim(txtShipCompany.Text) & "', '" & Trim(txtShipAddr1.Text) & "', '" & Trim(txtShipAddr2.Text) & "', '" & Trim(txtShipAddr3.Text) & "', " & _
                         "'" & Trim(txtShipCity.Text) & "', '" & cboShipStateItem.ValueMember & "', '" & Trim(txtShipDayPhone.Text) & "', '" & Trim(txtShipZipcode.Text) & "', '" & Trim(txtShipEveningPhone.Text) & "', '" & Trim(txtShipEmail.Text) & "')"

            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)

            If bolInsertStatus = False Then
                MsgBox("An error occured adding the Customer Ship To Table!", MsgBoxStyle.Critical)
                Return "ERROR"
            End If
            Return "SUCCESS"




            If radioMasterCard.Checked = True Then
                strCardType = "MasterCard"
            Else
                strCardType = "VISA"
            End If

            '- Insert a new customer CREDIT CARD record into the database -'
            strSQL = "INSERT CUSTOMER_CREDIT_CARD(CUSTOMER_ID, CARD_TYPE, CARD_NUMBER, NAME_ON_CARD, CVV, EXP_MONTH, EXP_YEAR, BANK_TELEPHONE) " & _
                         "VALUE('" & lblCustomerID.Text & "', '" & strCardType & "', '" & txtCCNumber.Text & "', '" & txtCardHolderName.Text & "', '" & txtCVV.Text & "', '" & cboMonth.SelectedText & "', '" & cboYear.SelectedText & "', '" & txtBankTelephone.Text & "', )"

            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)

            If bolInsertStatus = False Then
                MsgBox("An error occured adding the Customer Credit Card Table!", MsgBoxStyle.Critical)
                Return "ERROR"
            End If
            Return "SUCCESS"
        Else
            MsgBox("Unable to save WO without Customer ID", MsgBoxStyle.OkOnly)
            Return "ERROR"
            Exit Function
        End If
    End Function
    Public Function fctUpdateCustomer() As String
        Dim msgResult As MsgBoxResult
        Dim bolUpdateStatus As Boolean
        Dim strSQL As String
        Dim strCardType As String
        Dim cboStateItem As cboItem
        cboStateItem = cboShipState.Items(cboShipState.SelectedIndex)

        msgResult = MsgBox(lblCustomerID.Text & " information has changed." & ControlChars.NewLine & ControlChars.NewLine & "Would you like to update this customer's information in the database?", MsgBoxStyle.YesNo, "Update Customer Information")
        If msgResult = MsgBoxResult.Yes Then
            '- Update the customer BILL TO record into the database -'
            strSQL = "UPDATE CUSTOMER_BILL_TO SET " & _
                                "FIRST_NAME = '" & txtBillFirst.Text & "', " & _
                                "LAST_NAME = '" & txtBillLast.Text & "', " & _
                                "COMPANY = '" & txtBillCompany.Text & "', " & _
                                "ADDR_1 = '" & txtBillAddr1.Text & "', " & _
                                "ADDR_2 = '" & txtBillAddr2.Text & "', " & _
                                "ADDR_3 = '" & txtBillAddr3.Text & "', " & _
                                "CITY = '" & txtBillCity.Text & "', " & _
                                "STATE = '" & cboStateItem.ValueMember & "', " & _
                                "ZIPCODE = '" & txtBillZipcode.Text & "', " & _
                                "DAY_PHONE = '" & txtBillDayPhone.Text & "', " & _
                                "EVENING_PHONE = '" & txtBillEveningPhone.Text & "', " & _
                                "PAYMENT_TYPE = '" & cboPaymentType.SelectedItem & "', " & _
                                "EMAIL = '" & txtBillEmail.Text & "' " & _
                            "WHERE CUST_ID = '" & lblCustomerID.Text & "'"

            bolUpdateStatus = fctInsertOrUpdateIntoDB(strSQL)

            If bolUpdateStatus = False Then
                MsgBox("An error occured updating the Customer Bill To Table!", MsgBoxStyle.Critical)
                Return "ERROR"
            End If




            '- Update the customer SHIP TO record into the database -'
            strSQL = "UPDATE CUSTOMER_SHIP_TO SET " & _
                                "FIRST_NAME = '" & txtShipFirst.Text & "', " & _
                                "LAST_NAME = '" & txtShipLast.Text & "', " & _
                                "COMPANY = '" & txtShipCompany.Text & "', " & _
                                "ADDR_1 = '" & txtShipAddr1.Text & "', " & _
                                "ADDR_2 = '" & txtShipAddr2.Text & "', " & _
                                "ADDR_3 = '" & txtShipAddr3.Text & "', " & _
                                "CITY = '" & txtShipCity.Text & "', " & _
                                "STATE = '" & cboStateItem.ValueMember & "', " & _
                                "ZIPCODE = '" & txtShipZipcode.Text & "', " & _
                                "DAY_PHONE = '" & txtShipDayPhone.Text & "', " & _
                                "EVENING_PHONE = '" & txtShipEveningPhone.Text & "', " & _
                                "EMAIL = '" & txtShipEmail.Text & "' " & _
                            "WHERE CUST_ID = '" & lblCustomerID.Text & "'"

            bolUpdateStatus = fctInsertOrUpdateIntoDB(strSQL)

            If bolUpdateStatus = False Then
                MsgBox("An error occured updating the Customer Ship To Table!", MsgBoxStyle.Critical)
                Return "ERROR"
            End If



            If radioMasterCard.Checked = True Then
                strCardType = "MasterCard"
            Else
                strCardType = "VISA"
            End If
            '- Update the customer Credit Card record into the database -'
            strSQL = "UPDATE  CUSTOMER_CREDIT_CARD SET " & _
                                "CUST_ID = '" & lblCustomerID.Text & "', " & _
                                "CARD_TYPE =  '" & strCardType & "', " & _
                                "CARD_NUMBER = '" & txtCCNumber.Text & "', " & _
                                "NAME_ON_CARD = '" & txtCardHolderName.Text & "', " & _
                                "CVV = '" & txtCVV.Text & "', " & _
                                "EXP_MONTH = '" & cboMonth.SelectedItem & "', " & _
                                "EXP_YEAR = '" & cboYear.SelectedItem & "', " & _
                                "BANK_TELEPHONE = '" & txtBankTelephone.Text & "' " & _
                            "WHERE CUST_ID = '" & lblCustomerID.Text & "'"

            bolUpdateStatus = fctInsertOrUpdateIntoDB(strSQL)

            If bolUpdateStatus = False Then
                MsgBox("An error occured updating the Customer Credit Card Table!", MsgBoxStyle.Critical)
                Return "ERROR"
            End If
            Return "SUCCESS"
        Else
            MsgBox("Unable to update the Customer ID", MsgBoxStyle.OkOnly)
            Return "ERROR"
            Exit Function
        End If
    End Function

    Private Sub frmCustomer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'subPositionFormOnScreen("SavePosition", Me)
    End Sub
    Private Sub frmCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        subLoadStateProv(cboBillState)
        subLoadStateProv(cboShipState)
        subClear()
        Dim intCC As Integer

        subCheckSecurity("CREDIT_CARD_EDIT", intCC)
        If intCC < 75 Then
            cboPaymentType.Enabled = False
        Else
            cboPaymentType.Enabled = True
        End If

        'subPositionFormOnScreen("MoveToLastPosition", Me)
    End Sub

    Public Sub subClear()
        txtBillFirst.Text = Nothing
        txtBillLast.Text = Nothing
        txtBillCompany.Text = Nothing
        txtBillAddr1.Text = Nothing
        txtBillAddr2.Text = Nothing
        txtBillAddr3.Text = Nothing
        txtBillCity.Text = Nothing
        cboBillState.SelectedIndex = 0
        txtBillZipcode.Text = Nothing
        txtBillDayPhone.Text = Nothing
        txtBillEveningPhone.Text = Nothing
        txtBillEmail.Text = Nothing

        txtShipFirst.Text = Nothing
        txtShipLast.Text = Nothing
        txtShipCompany.Text = Nothing
        txtShipAddr1.Text = Nothing
        txtShipAddr2.Text = Nothing
        txtShipAddr3.Text = Nothing
        txtShipCity.Text = Nothing
        cboShipState.SelectedIndex = 0
        txtShipZipcode.Text = Nothing
        txtShipDayPhone.Text = Nothing
        txtShipEveningPhone.Text = Nothing
        txtShipEmail.Text = Nothing

        radioMasterCard.Checked = False
        radioVisa.Checked = False
        txtCCNumber.Text = Nothing
        txtCVV.Text = Nothing
        txtCardHolderName.Text = Nothing
        cboMonth.SelectedIndex = 0
        cboYear.SelectedIndex = 0
        txtBankTelephone.Text = Nothing

        txtSearchCustID.Text = Nothing
        txtSearchFirst.Text = Nothing
        txtSearchLast.Text = Nothing

        btnSave.Text = "Save Customer Information"
        cboPaymentType.SelectedIndex = 0
        gboxCreditCard.Visible = False

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim strStatus As String = Nothing
        Dim intAddEditCustomer As Integer

        '- Error Checking -'
        '- Payment type not checked -'
        If cboPaymentType.SelectedIndex = 0 Then
            MsgBox("Please select at payment type.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        '- Credit Card -'
        If cboPaymentType.SelectedIndex = 3 Then
            If Len(txtCCNumber.Text) < 11 Then
                MsgBox("Credit Card number can not be empty.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            If Len(txtCardHolderName.Text) < 4 Then
                MsgBox("Card holders name must be longer the four characters.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            If cboMonth.SelectedIndex = 0 Then
                MsgBox("Please select a expiration month.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            If cboYear.SelectedIndex = 0 Then
                MsgBox("Please select a expiration year.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        End If

        '- Billing Method -'
        If radCopyBilling.Checked = False And radClearShipping.Checked = False Then
            MsgBox("Please select a shipping method.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        '- Customer ID -'
        If Len(txtBillFirst.Text) = 0 Then
            MsgBox("Please enter a billable firtst name", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If Len(txtBillLast.Text) = 0 Then
            MsgBox("Please enter a billable last name", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        '- City -'
        If Len(txtBillCity.Text) = 0 Then
            MsgBox("Please enter a billable city", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        '- State -'
        If cboBillState.SelectedIndex = 0 Then
            MsgBox("Please select a billable state/prov", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        '- Telephone -'
        If Len(txtBillDayPhone.Text) = 0 Then
            MsgBox("Please enter a billable day time phone number", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        '- Email -'
        If Len(txtBillEmail.Text) = 0 Then
            MsgBox("Please enter a billable email address", MsgBoxStyle.OkOnly)
            Exit Sub
        End If


        lblCustomerID.Text = Trim(txtBillFirst.Text.Chars(0)) & Trim(txtBillLast.Text)

        If Me.Tag = "SAVE" Then
            subCheckSecurity("CUSTOMER_ADD", intAddEditCustomer)
            If intAddEditCustomer <> 100 Then
                MsgBox("You do not have authority to create Customers" & ControlChars.NewLine & ControlChars.NewLine & "Contact your administrator.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            strStatus = fctInsertCustomer()
            If strStatus = "SUCCESS" Then
                MsgBox("Customer information successfully saved.", MsgBoxStyle.OkOnly)
            End If


        ElseIf Me.Tag = "UPDATE" Then
            subCheckSecurity("CUSTOMER_EDIT", intAddEditCustomer)
            If intAddEditCustomer <> 75 Then
                MsgBox("You do not have authority to update Customers" & ControlChars.NewLine & ControlChars.NewLine & "Contact your administrator.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            strStatus = fctUpdateCustomer()
            If strStatus = "SUCCESS" Then
                MsgBox("Customer information successfully update.", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Public Sub btnFindCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindCustomer.Click
        Me.Tag = "UPDATE"
        Dim strSQL As String
        Dim dsLoadCust As New DataSet
        Dim dsCreditCard As New DataSet
        Dim strFirst As String = Nothing
        Dim strLast As String = Nothing
        Dim strState As String = Nothing
        Dim strwhere As String = Nothing

        If Len(txtSearchCustID.Text) > 0 Then
            strwhere = "CUST_ID LIKE '" & txtSearchCustID.Text & "%' "
        End If

        If Len(txtSearchFirst.Text) > 0 Then
            If Len(strwhere) > 0 Then
                strwhere = "OR FIRST_NAME LIKE '" & txtSearchFirst.Text & "%' "
            Else
                strwhere = "FIRST_NAME LIKE '" & txtSearchFirst.Text & "%' "
            End If
        End If

        If Len(txtSearchLast.Text) > 0 Then
            If Len(strwhere) > 0 Then
                strwhere = "OR LAST_NAME LIKE '" & txtSearchLast.Text & "%' "
            Else
                strwhere = "LAST_NAME LIKE '" & txtSearchLast.Text & "%'"
            End If
        End If

        If Len(txtSearchComp.Text) > 0 Then
            If Len(strwhere) > 0 Then
                strwhere = "OR COMPANY LIKE '" & txtSearchComp.Text & "%' "
            Else
                strwhere = "COMPANY LIKE '" & txtSearchComp.Text & "%'"
            End If
        End If

        If Len(strwhere) = 0 Then
            MsgBox("Please enter in a search criteria.", MsgBoxStyle.OkOnly)
            txtSearchCustID.Focus()
            Exit Sub
        End If

        strSQL = "SELECT CUST_ID, FIRST_NAME, LAST_NAME, COMPANY, DAY_PHONE  " & _
                      "FROM CUSTOMER_BILL_TO " & _
                      "WHERE " & strwhere

        dsLoadCust = fctGetDataSet(strSQL)

        If dsLoadCust.Tables(0).Rows.Count > 1 Then
            Dim intHeadingCtr As Integer

            If dsLoadCust.Tables(0).Rows.Count > 0 Then
                '- Loop for the Heading -'
                Dim dt As New DataTable
                dt.Columns.Add("Customer ID", System.Type.GetType("System.String"))
                dt.Columns.Add("Name", System.Type.GetType("System.String"))
                dt.Columns.Add("Company", System.Type.GetType("System.String"))
                dt.Columns.Add("Daytime Telephone", System.Type.GetType("System.String"))

                Do Until intHeadingCtr = dsLoadCust.Tables(0).Rows.Count
                    Dim dr As DataRow
                    dr = dt.NewRow
                    dr("Customer ID") = dsLoadCust.Tables(0).Rows(intHeadingCtr).Item("CUST_ID")
                    dr("Name") = dsLoadCust.Tables(0).Rows(intHeadingCtr).Item("FIRST_NAME") & " " & dsLoadCust.Tables(0).Rows(intHeadingCtr).Item("LAST_NAME")
                    dr("Company") = dsLoadCust.Tables(0).Rows(intHeadingCtr).Item("COMPANY")
                    dr("Daytime Telephone") = dsLoadCust.Tables(0).Rows(intHeadingCtr).Item("DAY_PHONE")
                    dt.Rows.Add(dr)

                    intHeadingCtr += 1
                Loop
                dgvFindCustomer.DataSource = dt
                dgvFindCustomer.Columns(0).Width = 100
                dgvFindCustomer.Columns(1).Width = 200
                dgvFindCustomer.Columns(2).Width = 125
                dgvFindCustomer.Columns(3).Width = 125

            Else
                MsgBox("Error reading from table Machine_Work", MsgBoxStyle.Critical, "DB Error")
            End If

            dsLoadCust.Dispose()

        ElseIf dsLoadCust.Tables(0).Rows.Count = 1 Then
            lblCustomerID.Text = dsLoadCust.Tables(0).Rows(0).Item("CUST_ID")
            SubLoadCustomerInfo()
        Else
            MsgBox("There was a problem loading the Customer ID from the database.", MsgBoxStyle.Critical)
        End If

        dsLoadCust.Dispose()
        dsCreditCard.Dispose()
    End Sub


    Public Sub subCheckBillAsShip()
        If txtShipFirst.Text = txtBillFirst.Text Then
            If txtShipLast.Text = txtBillLast.Text Then
                If txtShipCompany.Text = txtBillCompany.Text Then
                    If txtShipAddr1.Text = txtBillAddr1.Text Then
                        If txtShipAddr2.Text = txtBillAddr2.Text Then
                            If txtShipAddr3.Text = txtBillAddr3.Text Then
                                If txtShipCity.Text = txtBillCity.Text Then
                                    If cboShipState.SelectedIndex = cboBillState.SelectedIndex Then
                                        If txtShipZipcode.Text = txtBillZipcode.Text Then
                                            If txtShipDayPhone.Text = txtBillDayPhone.Text Then
                                                If txtShipEveningPhone.Text = txtBillEveningPhone.Text Then
                                                    If txtShipEmail.Text = txtBillEmail.Text Then
                                                        radCopyBilling.Checked = True
                                                        radClearShipping.Checked = False
                                                    Else
                                                        radCopyBilling.Checked = False
                                                        radClearShipping.Checked = True
                                                    End If
                                                Else
                                                    radCopyBilling.Checked = False
                                                    radClearShipping.Checked = True
                                                End If
                                            Else
                                                radCopyBilling.Checked = False
                                                radClearShipping.Checked = True
                                            End If
                                        Else
                                            radCopyBilling.Checked = False
                                            radClearShipping.Checked = True
                                        End If
                                    Else
                                        radCopyBilling.Checked = False
                                        radClearShipping.Checked = True
                                    End If
                                Else
                                    radCopyBilling.Checked = False
                                    radClearShipping.Checked = True
                                End If
                            Else
                                radCopyBilling.Checked = False
                                radClearShipping.Checked = True
                            End If
                        Else
                            radCopyBilling.Checked = False
                            radClearShipping.Checked = True
                        End If
                    Else
                        radCopyBilling.Checked = False
                        radClearShipping.Checked = True
                    End If
                Else
                    radCopyBilling.Checked = False
                    radClearShipping.Checked = True
                End If
            Else
                radCopyBilling.Checked = False
                radClearShipping.Checked = True
            End If
        Else
            radCopyBilling.Checked = False
            radClearShipping.Checked = True
        End If

    End Sub

    Private Sub radCopyBilling_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radCopyBilling.CheckedChanged
        'radClearShipping.Checked = False

        txtShipFirst.Text = txtBillFirst.Text
        txtShipLast.Text = txtBillLast.Text
        txtShipCompany.Text = txtBillCompany.Text
        txtShipAddr1.Text = txtBillAddr1.Text
        txtShipAddr2.Text = txtBillAddr2.Text
        txtShipAddr3.Text = txtBillAddr3.Text
        txtShipCity.Text = txtBillCity.Text
        cboShipState.SelectedIndex = cboBillState.SelectedIndex
        txtShipZipcode.Text = txtBillZipcode.Text
        txtShipDayPhone.Text = txtBillDayPhone.Text
        txtShipEveningPhone.Text = txtBillEveningPhone.Text
        txtShipEmail.Text = txtBillEmail.Text

        txtShipFirst.Enabled = False
        txtShipLast.Enabled = False
        txtShipCompany.Enabled = False
        txtShipAddr1.Enabled = False
        txtShipAddr2.Enabled = False
        txtShipAddr3.Enabled = False
        txtShipCity.Enabled = False
        cboShipState.Enabled = False
        txtShipZipcode.Enabled = False
        txtShipDayPhone.Enabled = False
        txtShipEveningPhone.Enabled = False
        txtShipEmail.Enabled = False
    End Sub
    Private Sub radClearShipping_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radClearShipping.CheckedChanged
        'radCopyBilling.Checked = False
        'radClearShipping.Checked = True

        txtShipFirst.Text = Nothing
        txtShipLast.Text = Nothing
        txtShipCompany.Text = Nothing
        txtShipAddr1.Text = Nothing
        txtShipAddr2.Text = Nothing
        txtShipAddr3.Text = Nothing
        txtShipCity.Text = Nothing
        txtShipZipcode.Text = Nothing
        txtShipDayPhone.Text = Nothing
        txtShipEveningPhone.Text = Nothing
        txtShipEmail.Text = Nothing

        txtShipFirst.Enabled = True
        txtShipLast.Enabled = True
        txtShipCompany.Enabled = True
        txtShipAddr1.Enabled = True
        txtShipAddr2.Enabled = True
        txtShipAddr3.Enabled = True
        txtShipCity.Enabled = True
        cboShipState.Enabled = True
        txtShipZipcode.Enabled = True
        txtShipDayPhone.Enabled = True
        txtShipEveningPhone.Enabled = True
        txtShipEmail.Enabled = True
    End Sub

    Public Sub SubLoadCustomerInfo()
        Dim strSQL As String
        Dim dsLoadCust As New DataSet
        Dim dsCreditCard As New DataSet
        Dim strFirst As String = Nothing
        Dim strLast As String = Nothing
        Dim strState As String = Nothing
        Dim strwhere As String = Nothing
        Dim cboItem As cboItem


        '- Customer Bill To -'
        subGetCustAddress(lblCustomerID.Text, "CUSTOMER_BILL_TO", txtBillFirst.Text, txtBillLast.Text, txtBillCompany.Text, txtBillAddr1.Text, _
                                     txtBillAddr2.Text, txtBillAddr3.Text, txtBillCity.Text, strState, txtBillZipcode.Text, _
                                     txtBillDayPhone.Text, txtBillEveningPhone.Text, txtBillEmail.Text, Nothing, "CUSTOMER")

        Dim intStateCtr As Integer
        Do Until intStateCtr = cboBillState.Items.Count
            cboItem = cboBillState.Items(intStateCtr)
            If cboItem.ValueMember = strState Then
                cboBillState.SelectedIndex = intStateCtr
                Exit Do
            End If
            intStateCtr += 1
        Loop



        '- Customer Ship To address -'
        '-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        '- Required to step thru it twice for the radio button clear the form after its loaded. -'
        strState = Nothing
        intStateCtr = 0
        subGetCustAddress(lblCustomerID.Text, "CUSTOMER_SHIP_TO", txtShipFirst.Text, txtShipLast.Text, txtShipCompany.Text, txtShipAddr1.Text, _
                                     txtShipAddr2.Text, txtShipAddr3.Text, txtShipCity.Text, strState, txtShipZipcode.Text, _
                                     txtShipDayPhone.Text, txtShipEveningPhone.Text, txtShipEmail.Text, Nothing, "CUSTOMER")
        Do Until intStateCtr = cboShipState.Items.Count
            cboItem = cboShipState.Items(intStateCtr)
            If cboItem.ValueMember = strState Then
                cboShipState.SelectedIndex = intStateCtr
                Exit Do
            End If
            intStateCtr += 1
        Loop

        subCheckBillAsShip()
        strState = Nothing
        intStateCtr = 0
        subGetCustAddress(lblCustomerID.Text, "CUSTOMER_SHIP_TO", txtShipFirst.Text, txtShipLast.Text, txtShipCompany.Text, txtShipAddr1.Text, _
                                     txtShipAddr2.Text, txtShipAddr3.Text, txtShipCity.Text, strState, txtShipZipcode.Text, _
                                     txtShipDayPhone.Text, txtShipEveningPhone.Text, txtShipEmail.Text, Nothing, "CUSTOMER")
        Do Until intStateCtr = cboShipState.Items.Count
            cboItem = cboShipState.Items(intStateCtr)
            If cboItem.ValueMember = strState Then
                cboShipState.SelectedIndex = intStateCtr
                Exit Do
            End If
            intStateCtr += 1
        Loop
        '-------------------------------------------------------------------------------------------------------------------------------------------------------------------




        strSQL = "SELECT CUST_ID, CARD_TYPE, CARD_NUMBER, NAME_ON_CARD, CVV, EXP_MONTH, EXP_YEAR, BANK_TELEPHONE " & _
                      "FROM CUSTOMER_CREDIT_CARD " & _
                      "WHERE CUST_ID = '" & lblCustomerID.Text & "'"

        dsCreditCard = fctGetDataSet(strSQL)

        If dsCreditCard.Tables(0).Rows.Count = 1 Then
            If Not IsDBNull(dsCreditCard.Tables(0).Rows(0).Item("CARD_TYPE")) Then
                If dsCreditCard.Tables(0).Rows(0).Item("CARD_TYPE") = "MasterCard" Then
                    radioMasterCard.Checked = True
                Else
                    radioVisa.Checked = True
                End If
            End If

            If Not IsDBNull(dsCreditCard.Tables(0).Rows(0).Item("CARD_NUMBER")) Then
                txtCCNumber.Text = dsCreditCard.Tables(0).Rows(0).Item("CARD_NUMBER")
            Else
                txtCCNumber.Text = Nothing
            End If

            If Not IsDBNull(dsCreditCard.Tables(0).Rows(0).Item("NAME_ON_CARD")) Then
                txtCardHolderName.Text = dsCreditCard.Tables(0).Rows(0).Item("NAME_ON_CARD")
            Else
                txtCardHolderName.Text = Nothing
            End If

            If Not IsDBNull(dsCreditCard.Tables(0).Rows(0).Item("CVV")) Then
                txtCVV.Text = dsCreditCard.Tables(0).Rows(0).Item("CVV")
            Else
                txtCVV.Text = Nothing
            End If

            If Not IsDBNull(dsCreditCard.Tables(0).Rows(0).Item("EXP_MONTH")) Then
                cboMonth.SelectedIndex = cboMonth.FindStringExact(dsCreditCard.Tables(0).Rows(0).Item("EXP_MONTH"))
            Else
                cboMonth.SelectedIndex = 0
            End If

            If Not IsDBNull(dsCreditCard.Tables(0).Rows(0).Item("EXP_YEAR")) Then
                cboYear.SelectedIndex = cboYear.FindStringExact(dsCreditCard.Tables(0).Rows(0).Item("EXP_YEAR"))
            Else
                cboYear.SelectedIndex = 0
            End If

            If Not IsDBNull(dsCreditCard.Tables(0).Rows(0).Item("BANK_TELEPHONE")) Then
                txtBankTelephone.Text = dsCreditCard.Tables(0).Rows(0).Item("BANK_TELEPHONE")
            Else
                txtBankTelephone.Text = Nothing
            End If
        Else
            strSQL = "SELECT PAYMENT_TYPE " & _
                          "FROM CUSTOMER_BILL_TO " & _
                          "WHERE CUST_ID = '" & lblCustomerID.Text & "'"

            dsCreditCard = fctGetDataSet(strSQL)

            If dsCreditCard.Tables(0).Rows.Count > 0 Then
                cboPaymentType.SelectedIndex = cboPaymentType.FindString(dsCreditCard.Tables(0).Rows(0).Item("PAYMENT_TYPE"))
            End If
        End If


        btnSave.Text = "Update Customer Information"
    End Sub

    Private Sub dgvFindCustomer_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFindCustomer.DoubleClick
        lblCustomerID.Text = dgvFindCustomer.SelectedRows.Item(0).Cells(0).Value
        If lblCustomerID.Text.Length <> 0 Then
            subClear()
            SubLoadCustomerInfo()
        End If
    End Sub
    Private Sub radioMasterCard_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioMasterCard.CheckedChanged, radioVisa.CheckedChanged
        txtCCNumber.Text = Nothing
        txtCVV.Text = Nothing
        txtCardHolderName.Text = Nothing
        cboMonth.SelectedIndex = 0
        cboYear.SelectedIndex = 0
        txtBankTelephone.Text = Nothing
    End Sub

    Private Sub lblCustomerID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblCustomerID.TextChanged
        lblCustomerID.Text = UCase(lblCustomerID.Text)
    End Sub

    Private Sub cboPaymentType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPaymentType.SelectedIndexChanged
        If cboPaymentType.SelectedIndex = 3 Then
            gboxCreditCard.Visible = True
            Me.Height = 895
        Else
            gboxCreditCard.Visible = False
            Me.Height = 766

        End If
    End Sub
End Class