Imports System.Type
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared



Public Class frmWO
    Public strCustAddrChanged As String = "NO"
    '- Integer value will be based on level -> Add = 100, Edit = 75, Delete = 50
    Public intSecurityCustomer(3) As Integer
    Public intSecurityAdmin(3) As Integer
    Public intSecurityWO(3) As Integer
    Public intSecurityImages(3) As Integer
    Public lblImagesFromTemplate(20) As Label
    Public strTemplateDesc As String
    Public strSaveBeforeExiting As String = "NO"
    


    Private Sub btnEmail_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Directory.Exists("C:\Sunwest\tmpEmailPDF") Then
            Directory.Delete("C:\Sunwest\tmpEmailPDF", True)
        End If

        'subPositionFormOnScreen("SavePosition", Me)
    End Sub
    Private Sub frmWO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Dirty.IsDirty = True Then
                Dim msgResult As New MsgBoxResult

                msgResult = MsgBox("It appears you have made changes to the work order." & ControlChars.NewLine & ControlChars.NewLine & "Would you like to save your changes?", MsgBoxStyle.YesNoCancel)
                If msgResult = MsgBoxResult.Yes Then
                    btnSaveWO_Click(Nothing, Nothing)
                    subClear("NEW")
                Else
                    subClear("NEW")
                End If
            Else
                subClear("NEW")
            End If
        End If
    End Sub
    Public Sub subClear(ByVal strNew As String)
     
        Dim Ctrl As Control
        Dim childCtrl As Control
        Dim ctrlType As Type

        For Each Ctrl In Me.Controls
            If Ctrl.HasChildren = True Then
                For Each childCtrl In Ctrl.Controls
                    ctrlType = childCtrl.GetType

                    If ctrlType.Name = "TextBox" Then
                        If strNew = "NEW" Then
                            childCtrl.Text = Nothing
                        End If
                        childCtrl.BackColor = Color.White
                    End If

                    If ctrlType.Name = "ComboBox" Then
                        If strNew = "NEW" Then
                            Dim cbCtrl As ComboBox = CType(childCtrl, ComboBox)
                            cbCtrl.SelectedIndex = -1
                            cbCtrl.SelectedIndex = -1
                        End If
                        Dim cbCtrlBC As ComboBox = CType(childCtrl, ComboBox)
                        cbCtrlBC.BackColor = Color.White
                    End If
                Next
            End If
        Next

        txtNeedBy.Text = Format(Now, "MM/dd/yyyy")
        If strNew = "NEW" Then
            lblWO.Text = ""
            dtWODate.Value = Now()
            lblMachinist.Text = Nothing
            lblUpdateUser.Text = Nothing
            lblUpdateDate.Text = Nothing
            gstrCustIDFound = Nothing
            strCustAddrChanged = "NO"
            btnSaveWO.BackColor = Color.WhiteSmoke
            txtNeedBy.Text = Format(Now, "MM/dd/yyyy")
            dtNeededBy.Value = Now
            Me.Tag = "INSERT"
            btnSaveWO.Text = "Save Work Order"
            btnSaveWO.BackColor = Color.Gainsboro

            txtRodCore.Text = Nothing
            txtCamCore.Text = Nothing
            txtCrankCore.Text = Nothing
            txtHeadCore.Text = Nothing
            txtBlockCore.Text = Nothing
            txtInvoice.Text = Nothing
            cboCore.SelectedIndex = 0

            txtRodCore.ForeColor = Color.Black
            txtCamCore.ForeColor = Color.Black
            txtCrankCore.ForeColor = Color.Black
            txtHeadCore.ForeColor = Color.Black
            txtBlockCore.ForeColor = Color.Black
            txtInvoice.ForeColor = Color.Black

            txtRodCore.Font = New Font(txtRodCore.Font, FontStyle.Regular)
            txtCamCore.Font = New Font(txtCamCore.Font, FontStyle.Regular)
            txtCrankCore.Font = New Font(txtCrankCore.Font, FontStyle.Regular)
            txtHeadCore.Font = New Font(txtHeadCore.Font, FontStyle.Regular)
            txtBlockCore.Font = New Font(txtBlockCore.Font, FontStyle.Regular)
            txtInvoice.Font = New Font(txtInvoice.Font, FontStyle.Regular)

            rtxtNotes.Text = Nothing

            chkFreightCorePur.Checked = False
            chkFreightOutgoing.Checked = False
            chkFreightReturn.Checked = False
            chkFreightOwn.Checked = False
            cboFreightCarriers.Enabled = True
            cboFreightCarriers.SelectedIndex = -1

            lblBillTo.Text = Nothing
            lblSoldCustomerName.Text = Nothing
            lblSoldCompany.Text = Nothing
            lblSoldAddr1.Text = Nothing
            lblSoldAddr2.Text = Nothing
            lblSoldAddr3.Text = Nothing
            lblSoldCity.Text = Nothing
            lblSoldState.Text = Nothing
            lblSoldZip.Text = Nothing
            lblSoldTelephone.Text = Nothing

            lblShipTo.Text = Nothing
            lblShipCustomerName.Text = Nothing
            lblShipCompany.Text = Nothing
            lblShipAddr1.Text = Nothing
            lblShipAddr2.Text = Nothing
            lblShipAddr3.Text = Nothing
            lblShipCity.Text = Nothing
            lblShipState.Text = Nothing
            lblShipZip.Text = Nothing
            lblShipTelephone.Text = Nothing

            lblSimStatus.Text = "N/A"
            cboStatus.BackColor = Color.WhiteSmoke
            cboStatus.SelectedIndex = 0
            txtShelfNumber.Text = Nothing

            lblImageCount.Text = Nothing

            radCylinderHead.Checked = False
            radLongBlock.Checked = False
            radPieceWork.Checked = False
            lblWorkOrderType.Text = Nothing
            txtModel.Text = ""
            txtVinCode.Text = ""

            lblTempCylinderHead.Text = ""
            lblTempLongBlock.Text = ""
            lblTempPieceWork.Text = ""
            strTemplateDesc = ""
            txtWO.Text = ""

            intBatchPrintStart = 0
            intBatchPrintEnd = 0

            Try
                cboYear.SelectedIndex = 0
                cboMake.SelectedIndex = 0
                cboFreightCarriers.SelectedIndex = 0
            Catch ex As Exception
            End Try

            subLoadMachineWorkOrdered()
            subLoadMaterialUsed()
            Dirty.ResetDirtyState()

            'Dim intDGVCtr As Integer
            ''- dgv1 ='
            'Do Until intDGVCtr = dgv1.Rows.Count
            '    Dim dgCB As New DataGridViewCheckBoxCell
            '    Dim dgTextBox As New DataGridViewTextBoxCell
            '    dgCB = CType(dgv1("colCheckBox", intDGVCtr), DataGridViewCheckBoxCell)
            '    dgCB.Value = False

            '    dgTextBox = CType(dgv1(2, intDGVCtr), DataGridViewTextBoxCell)
            '    dgTextBox.Value = Nothing

            '    dgTextBox = CType(dgv1(3, intDGVCtr), DataGridViewTextBoxCell)
            '    dgTextBox.Value = Nothing

            '    intDGVCtr += 1
            'Loop

            ''- dgv2 -'
            'intDGVCtr = 0
            'Do Until intDGVCtr = dgv2.Rows.Count
            '    Dim dgCB As New DataGridViewCheckBoxCell
            '    Dim dgTextBox As New DataGridViewTextBoxCell

            '    dgCB = CType(dgv2("colCheckBox2", intDGVCtr), DataGridViewCheckBoxCell)
            '    dgCB.Value = False

            '    dgTextBox = CType(dgv2(2, intDGVCtr), DataGridViewTextBoxCell)
            '    dgTextBox.Value = Nothing

            '    dgTextBox = CType(dgv2(3, intDGVCtr), DataGridViewTextBoxCell)
            '    dgTextBox.Value = Nothing

            '    intDGVCtr += 1
            'Loop
        End If
    End Sub
    Private Sub frmWO_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        frmLogin.ShowDialog()

        If gstrUserID <> Nothing Then
            subLoadWO(Nothing)
            Dirty.StartMonitoring()
        Else
            Me.Close()
        End If

        For ictr As Integer = 0 To 20
            lblImagesFromTemplate(ictr) = New Label
        Next

        'subPositionFormOnScreen("MoveToLastPosition", Me)
    End Sub

    Public Sub subLoadWO(ByVal intWorkOrderID As Integer)
        Dim intAddImages As Integer
        subClear("NEW")
        Me.Text = "Sunwest Work Order System - " & gstrUserID
        subLoadMake(intWorkOrderID, "WO")
        subLoadYear(intWorkOrderID, "WO")
        subLoadFreightCarrier(intWorkOrderID, "WO")

        subLoadMachineWorkOrdered()
        subLoadMaterialUsed()

        subCheckSecurity("IMAGES_ADD", intAddImages)
        If intAddImages = 100 Then
            AddImagesToolStripMenuItem.Enabled = True
        Else
            AddImagesToolStripMenuItem.Enabled = False
        End If

        subCheckSecurity("EMPLOYEE_ADD", intAddImages)
        If intAddImages = 100 Then
            tsiNewEmployee.Enabled = True
        Else
            tsiNewEmployee.Enabled = False
        End If

        subCheckSecurity("EMPLOYEE_EDIT", intAddImages)
        If intAddImages = 75 Then
            tsiEditEmployee.Enabled = True
        Else
            tsiEditEmployee.Enabled = False
        End If

        If intWorkOrderID > 0 Then
            lblWO.Text = intWorkOrderID
            txtWO.Text = intWorkOrderID
        End If

        cboStatus.SelectedIndex = 0

        If intWorkOrderID <> 0 Then
            subLoadAdministration(intWorkOrderID, "WO")
            subUpdateMachineWork(intWorkOrderID, "WO")
            subUpdateMaterialUsed(intWorkOrderID, "WO")
            btnFindCust_Click(Nothing, Nothing)
            subLoadImageCount(intWorkOrderID, "WO")
            subLoadSimTest(intWorkOrderID)

            btnSaveWO.Text = "Update Work Order"
            Me.Tag = "UPDATE"
        End If

        strSaveBeforeExiting = "NO"
    End Sub

    Public Sub subUpdateMachineWork(ByVal intID As Integer, ByVal strPassingForm As String)
        Dim strSQL As String
        Dim dsMW As New DataSet
        Dim dgTextBoxCell As New DataGridViewTextBoxCell
        Dim dgCB As New DataGridViewCheckBoxCell
        Dim intCtr As Integer
        Dim intDGVCtr As Integer



        If strPassingForm = "TEMPLATE" Then
            strSQL = "SELECT ID, MW_ITEM_ID, QUANTITY, COST, MACHINE_ITEM " & _
                          "FROM MACHINE_WORK_TEMPLATE " & _
                          "WHERE ID = '" & intID & "'"
        ElseIf strPassingForm = "WO" Then
            Me.Tag = "UPDATE"

            strSQL = "SELECT WO_ID, MW_ITEM_ID, QUANTITY, COST, MACHINE_ITEM " & _
                          "FROM MACHINE_WORK_WO " & _
                          "WHERE WO_ID = '" & intID & "'"
        Else
            MsgBox("Unrecognized Parent Form!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        dsMW = fctGetDataSet(strSQL)

        If dsMW.Tables(0).Rows.Count > 0 Then
            Do Until intCtr = dsMW.Tables(0).Rows.Count
                If dsMW.Tables(0).Rows(intCtr).Item("MW_ITEM_ID") = dgv1.Rows(intDGVCtr).Cells(4).Value Then

                    dgCB = CType(dgv1("colCheckBox", intDGVCtr), DataGridViewCheckBoxCell)
                    dgCB.Value = True

                    If Not IsDBNull(dsMW.Tables(0).Rows(intCtr).Item("QUANTITY")) Then
                        dgTextBoxCell = CType(dgv1(2, intDGVCtr), DataGridViewTextBoxCell)
                        dgTextBoxCell.Value = dsMW.Tables(0).Rows(intCtr).Item("QUANTITY")
                    End If

                    If Not IsDBNull(dsMW.Tables(0).Rows(intCtr).Item("COST")) Then
                        dgTextBoxCell = CType(dgv1(3, intDGVCtr), DataGridViewTextBoxCell)
                        dgTextBoxCell.Value = dsMW.Tables(0).Rows(intCtr).Item("COST")
                    End If

                    If Not IsDBNull(dsMW.Tables(0).Rows(intCtr).Item("MACHINE_ITEM")) Then
                        dgTextBoxCell = CType(dgv1(1, intDGVCtr), DataGridViewTextBoxCell)
                        dgTextBoxCell.Value = dsMW.Tables(0).Rows(intCtr).Item("MACHINE_ITEM")
                    End If
                    intCtr += 1
                Else
                    intDGVCtr += 1
                End If
            Loop
        Else
            'MsgBox("Unable to load the Machine Work items for this template.", MsgBoxStyle.OkOnly)
        End If

        dsMW.Dispose()
    End Sub
    Public Sub subUpdateMaterialUsed(ByVal intID As Integer, ByVal strPassingForm As String)
        Dim dsMU As New DataSet
        Dim intCtr As Integer
        Dim intDGVCtr As Integer
        Dim strSQL As String
        Dim dgCB As New DataGridViewCheckBoxCell
        Dim dgTextBoxCell As New DataGridViewTextBoxCell


        If strPassingForm = "TEMPLATE" Then
            strSQL = "SELECT ID, MU_ITEM_ID, PART_NUMBER, SIZE, MATERIAL_ITEM " & _
                         "FROM MATERIAL_USED_TEMPLATE " & _
                         "WHERE ID = '" & intID & "'"
        ElseIf strPassingForm = "WO" Then
            Me.Tag = "UPDATE"

            strSQL = "SELECT WO_ID, MU_ITEM_ID, PART_NUMBER, SIZE, MATERIAL_ITEM " & _
                          "FROM MATERIAL_USED_WO " & _
                          "WHERE WO_ID = '" & intID & "'"
        Else
            MsgBox("Unrecognized Parent Form!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        dsMU = fctGetDataSet(strSQL)

        If dsMU.Tables(0).Rows.Count > 0 Then
            Do Until intCtr = dsMU.Tables(0).Rows.Count
                If dsMU.Tables(0).Rows(intCtr).Item("MU_ITEM_ID") = dgv2.Rows(intDGVCtr).Cells(4).Value Then
                    dgCB = CType(dgv2("colCheckBox2", intDGVCtr), DataGridViewCheckBoxCell)
                    dgCB.Value = True

                    If Not IsDBNull(dsMU.Tables(0).Rows(intCtr).Item("PART_NUMBER")) Then
                        dgTextBoxCell = CType(dgv2(2, intDGVCtr), DataGridViewTextBoxCell)
                        dgTextBoxCell.Value = dsMU.Tables(0).Rows(intCtr).Item("PART_NUMBER")
                    End If

                    If Not IsDBNull(dsMU.Tables(0).Rows(intCtr).Item("SIZE")) Then
                        dgTextBoxCell = CType(dgv2(3, intDGVCtr), DataGridViewTextBoxCell)
                        dgTextBoxCell.Value = dsMU.Tables(0).Rows(intCtr).Item("SIZE")
                    End If

                    If Not IsDBNull(dsMU.Tables(0).Rows(intCtr).Item("MATERIAL_ITEM")) Then
                        dgTextBoxCell = CType(dgv2(1, intDGVCtr), DataGridViewTextBoxCell)
                        dgTextBoxCell.Value = dsMU.Tables(0).Rows(intCtr).Item("MATERIAL_ITEM")
                    End If
                    intCtr += 1
                Else
                    intDGVCtr += 1
                End If
            Loop
        Else
            'MsgBox("Unable to load the Material Used items for this template.", MsgBoxStyle.OkOnly)
        End If

        dsMU.Dispose()
    End Sub

    Public Sub subLoadMake(ByVal intWorkOrderID As Integer, ByVal strPassingForm As String)
        Dim strSQL As String
        Dim dsMake As New DataSet
        Dim dsLoadMake As New DataSet
        Dim intCtr As Integer

        Dim intLoadMakeIndex As Integer
        Dim strLoadMake As String = Nothing

        strSQL = "SELECT MAKE_ORDER, MAKE_VALUE, MAKE_DESC " & _
                      "FROM AUTO_MAKE " & _
                      "ORDER BY MAKE_ORDER ASC"

        dsMake = fctGetDataSet(strSQL)

        If strPassINGForm = "TEMPLATE" Then
            strSQL = "SELECT AUTO_MAKE " & _
                          "FROM TEMPLATE " & _
                          "WHERE ID = '" & intWorkOrderID & "'"
        ElseIf strPassINGForm = "WO" Then
            strSQL = "SELECT AUTO_MAKE " & _
                          "FROM WORK_ORDER " & _
                          "WHERE WORK_ORDER_ID = '" & intWorkOrderID & "'"
        End If

        dsLoadMake = fctGetDataSet(strSQL)

        If dsLoadMake.Tables(0).Rows.Count = 1 Then
            strLoadMake = dsLoadMake.Tables(0).Rows(0).Item("AUTO_MAKE")
        End If

        If dsMake.Tables(0).Rows.Count > 0 Then
            Do Until intCtr = dsMake.Tables(0).Rows.Count
                '- Save the search index of the make -'
                If strLoadMake = dsMake.Tables(0).Rows(intCtr).Item("MAKE_VALUE") Then
                    intLoadMakeIndex = intCtr
                End If

                '- Load the values into combobox -'
                cboMake.Items.Add(New cboItem(Trim(dsMake.Tables(0).Rows(intCtr).Item("MAKE_DESC")), dsMake.Tables(0).Rows(intCtr).Item("MAKE_VALUE")))
                intCtr += 1
            Loop
        Else
            MsgBox("Error reading from table Auto_Make", MsgBoxStyle.Critical, "DB Error")
        End If

        '- Change the selected index -'
        If intLoadMakeIndex <> 0 Then
            cboMake.SelectedIndex = intLoadMakeIndex
        ElseIf Len(strLoadMake) > 0 Then
            cboMake.Text = strLoadMake
        Else
            cboMake.SelectedIndex = 0
        End If

        dsMake.Dispose()
    End Sub
    Public Sub subLoadYear(ByVal intWorkOrderID As Integer, ByVal strPassingForm As String)
        Dim strSQL As String
        Dim dsYear As New DataSet
        Dim dsLoadYear As New DataSet
        Dim strLoadYear As String = Nothing
        Dim intLoadYearIndex As Integer
        Dim intCtr As Integer

        strSQL = "SELECT YEAR_VALUE, YEAR_DESC, YEAR_ORDER, VISIBLE " & _
                      "FROM AUTO_YEAR " & _
                      "WHERE VISIBLE = 'YES' " & _
                      "ORDER BY YEAR_ORDER ASC"

        dsYear = fctGetDataSet(strSQL)

        If strPassingForm = "TEMPLATE" Then
            strSQL = "SELECT AUTO_YEAR " & _
                          "FROM TEMPLATE " & _
                          "WHERE ID = '" & intWorkOrderID & "'"
        ElseIf strPassingForm = "WO" Then
            strSQL = "SELECT AUTO_YEAR " & _
                          "FROM WORK_ORDER " & _
                          "WHERE WORK_ORDER_ID = '" & intWorkOrderID & "'"
        End If


        dsLoadYear = fctGetDataSet(strSQL)
        If dsLoadYear.Tables(0).Rows.Count > 0 Then
            strLoadYear = dsLoadYear.Tables(0).Rows(0).Item("AUTO_YEAR")
        End If

        If dsYear.Tables(0).Rows.Count > 0 Then
            Do Until intCtr = dsYear.Tables(0).Rows.Count
                '- Save the search index of the year -'
                If dsYear.Tables(0).Rows(intCtr).Item("YEAR_VALUE") <> "NULL" Then
                    If strLoadYear = dsYear.Tables(0).Rows(intCtr).Item("YEAR_VALUE") Then
                        intLoadYearIndex = intCtr
                    End If
                End If

                '- Load the values into combobox -'
                cboYear.Items.Add(New cboItem(dsYear.Tables(0).Rows(intCtr).Item("YEAR_DESC"), dsYear.Tables(0).Rows(intCtr).Item("YEAR_VALUE")))
                intCtr += 1
            Loop
        Else
            MsgBox("Error reading from table Auto_Year", MsgBoxStyle.Critical, "DB Error")
        End If

        '- Change the selected index -'
        If intLoadYearIndex <> 0 Then
            cboYear.SelectedIndex = intLoadYearIndex
        ElseIf Len(strLoadYear) > 0 Then
            cboYear.Text = strLoadYear
        Else
            cboYear.SelectedIndex = 0
        End If

        dsYear.Dispose()
    End Sub
    Public Sub subLoadFreightCarrier(ByVal intWorkOrderID As Integer, ByVal strPassingForm As String)
        Dim strSQL As String
        Dim dsFreightCarrer As New DataSet
        Dim dsLoadFreightCarrer As New DataSet
        Dim strLoadFreightCarrer As String = Nothing
        Dim intLoadFreightCarrer As Integer
        Dim intCtr As Integer

        strSQL = "SELECT FREIGHT_VALUE, FREIGHT_DESC, FREIGHT_ORDER, FREIGHT_VISIBLE " & _
                      "FROM FREIGHT_CARRIERS " & _
                      "WHERE FREIGHT_VISIBLE = 'YES' " & _
                      "ORDER BY FREIGHT_ORDER ASC"

        dsFreightCarrer = fctGetDataSet(strSQL)

        If strPassingForm = "TEMPLATE" Then
            strSQL = "SELECT FREIGHT_CARRIER " & _
                          "FROM TEMPLATE " & _
                          "WHERE ID = '" & intWorkOrderID & "'"
        ElseIf strPassingForm = "WO" Then
            strSQL = "SELECT FREIGHT_CARRIER " & _
                          "FROM WORK_ORDER " & _
                          "WHERE WORK_ORDER_ID = '" & intWorkOrderID & "'"
        End If

        '- Load the unique freight carrier -'
        dsLoadFreightCarrer = fctGetDataSet(strSQL)
        If dsLoadFreightCarrer.Tables(0).Rows.Count > 0 Then
            If Not IsDBNull(dsLoadFreightCarrer.Tables(0).Rows(0).Item("FREIGHT_CARRIER")) Then
                strLoadFreightCarrer = dsLoadFreightCarrer.Tables(0).Rows(0).Item("FREIGHT_CARRIER")
            End If
        End If

        If dsFreightCarrer.Tables(0).Rows.Count > 0 Then
            If cboFreightCarriers.Items.Count = 0 Then
                Do Until intCtr = dsFreightCarrer.Tables(0).Rows.Count
                    '- Load the values into combobox -'
                    cboFreightCarriers.Items.Add(New cboItem(dsFreightCarrer.Tables(0).Rows(intCtr).Item("FREIGHT_DESC"), dsFreightCarrer.Tables(0).Rows(intCtr).Item("FREIGHT_VALUE")))
                    intCtr += 1
                Loop
            End If
        Else
            MsgBox("Error reading from table Freight_Carriers", MsgBoxStyle.Critical, "DB Error")
        End If

        '- Save the search index of the year -'
        intCtr = 0
        Do Until intCtr = dsFreightCarrer.Tables(0).Rows.Count
            If dsFreightCarrer.Tables(0).Rows(intCtr).Item("FREIGHT_VALUE") <> "NULL" Then
                If strLoadFreightCarrer = dsFreightCarrer.Tables(0).Rows(intCtr).Item("FREIGHT_VALUE") Then
                    intLoadFreightCarrer = intCtr
                End If
            End If

            intCtr += 1
        Loop

        '- Change the selected index -'
        If intLoadFreightCarrer <> 0 Then
            cboFreightCarriers.SelectedIndex = intLoadFreightCarrer
        ElseIf Len(strLoadFreightCarrer) > 0 Then
            cboFreightCarriers.Text = strLoadFreightCarrer
        Else
            cboFreightCarriers.SelectedIndex = 0
        End If

        dsFreightCarrer.Dispose()
    End Sub

    Public Sub subLoadMachineWorkOrdered()
        Dim strSQL As String
        Dim dsMaterialUsedHeading As New DataSet
        Dim dsMaterialUsedSubItem As New DataSet
        Dim intHeadingCtr As Integer

        strSQL = "SELECT MACHINE_ID, MACHINE_ITEM, VISIBLE " & _
                      "FROM MACHINE_WORK " & _
                      "WHERE VISIBLE IS NULL " & _
                      "ORDER BY MACHINE_ID ASC"

        dsMaterialUsedHeading = fctGetDataSet(strSQL)

        If dsMaterialUsedHeading.Tables(0).Rows.Count > 0 Then
            '- Loop for the Heading -'
            Dim dt As New DataTable
            dt.Columns.Add("Machine Work Ordered", System.Type.GetType("System.String"))
            dt.Columns.Add("Quantity", System.Type.GetType("System.String"))
            dt.Columns.Add("Cost", System.Type.GetType("System.String"))
            dt.Columns.Add("Machine_ID", System.Type.GetType("System.String"))

            Do Until intHeadingCtr = dsMaterialUsedHeading.Tables(0).Rows.Count
                Dim dr As DataRow
                dr = dt.NewRow
                dr("Machine_ID") = dsMaterialUsedHeading.Tables(0).Rows(intHeadingCtr).Item("MACHINE_ID")
                dr("Machine Work Ordered") = dsMaterialUsedHeading.Tables(0).Rows(intHeadingCtr).Item("MACHINE_ITEM")
                'dr("Item_Type") = dsMaterialUsedHeading.Tables(0).Rows(intHeadingCtr).Item("MACHINE_ID")
                dt.Rows.Add(dr)

                intHeadingCtr += 1
            Loop
            dgv1.DataSource = dt
            dgv1.Columns(0).Width = 25
            dgv1.Columns(1).Width = 200
            dgv1.Columns(2).Width = 75
            dgv1.Columns(3).Width = 50
            dgv1.Columns(4).Visible = False

        Else
            MsgBox("Error reading from table Machine_Work", MsgBoxStyle.Critical, "DB Error")
        End If

        dsMaterialUsedHeading.Dispose()
    End Sub
    Public Sub subLoadMaterialUsed()
        Dim strSQL As String
        Dim dsMaterialUsed As New DataSet
        Dim dsMaterialUsedSubItem As New DataSet

        Dim intHeadingCtr As Integer

        strSQL = "SELECT MATERIAL_ID, MATERIAL_ITEM, VISIBLE " & _
                      "FROM MATERIAL_USED " & _
                      "WHERE VISIBLE IS NULL " & _
                      "ORDER BY MATERIAL_ID ASC"

        dsMaterialUsed = fctGetDataSet(strSQL)

        If dsMaterialUsed.Tables(0).Rows.Count > 0 Then

            '- Loop for the Heading -'
            Dim dt As New DataTable
            dt.Columns.Add("Material Used", System.Type.GetType("System.String"))
            dt.Columns.Add("Part Number", System.Type.GetType("System.String"))
            dt.Columns.Add("Size", System.Type.GetType("System.String"))
            dt.Columns.Add("Material_ID", System.Type.GetType("System.String"))

            Do Until intHeadingCtr = dsMaterialUsed.Tables(0).Rows.Count
                Dim dr As DataRow
                dr = dt.NewRow
                dr("Material_ID") = dsMaterialUsed.Tables(0).Rows(intHeadingCtr).Item("MATERIAL_ID")
                dr("Material Used") = dsMaterialUsed.Tables(0).Rows(intHeadingCtr).Item("MATERIAL_ITEM")

                dt.Rows.Add(dr)

                intHeadingCtr += 1
            Loop

            With dgv2
                .DataSource = dt
                .Columns(0).Width = 25
                .Columns(1).Width = 175
                .Columns(2).Width = 300
                .Columns(3).Width = 100
                .Columns(4).Visible = False
            End With

        Else
            MsgBox("Error reading from table Material_Used", MsgBoxStyle.Critical, "DB Error")
        End If
        dsMaterialUsed.Dispose()
    End Sub
    Public Sub subLoadAdministration(ByVal intWorkOrderID As Integer, ByVal strPassingForm As String)
        Dim strSQL As String = Nothing
        Dim dsLoadAdmin As New DataSet


        If strPassingForm = "TEMPLATE" Then
            strSQL = "SELECT CORE_NO, PO_NO, CUBIC_INCH, FREIGHT_CORE_PUR, FREIGHT_OUTGOING, FREIGHT_RETURN, FREIGHT_OWN, BLOCK_NO, CRANK_NO, " & _
                          "HEAD_NO, CON_ROD_CORE, CAM_CORE, CRANK_CORE, BLOCK_CORE_CHARGE, HEAD_CORE, FREIGHT_CARRIER, TYPE, AUTO_MODEL, AUTO_VIN_CODE, DESCRIPTION, NOTES " & _
                          "FROM TEMPLATE " & _
                          "WHERE ID = '" & intWorkOrderID & "' "
        ElseIf strPassingForm = "WO" Then
            strSQL = "SELECT CUSTOMER_ID, CORE_NO, PO_NO, CUBIC_INCH, WO_DATE, BLOCK_NO, CRANK_NO, HEAD_NO, CON_ROD_CORE, CAM_CORE, CRANK_CORE, " & _
                                      "BLOCK_CORE_CHARGE, NEEDED_BY, INVOICE_NO, NOTES, MACHINIST, UPDATE_USER, UPDATE_DATE, FREIGHT_CORE_PUR, HEAD_CORE, " & _
                                      "FREIGHT_OUTGOING, FREIGHT_RETURN, STATUS, FREIGHT_OWN, TYPE, SHELF_NUMBER, AUTO_MODEL, AUTO_VIN_CODE, TEMPLATE_DESC " & _
                                "FROM WORK_ORDER " & _
                                "WHERE WORK_ORDER.WORK_ORDER_ID = '" & intWorkOrderID & "' "
        End If

        dsLoadAdmin = fctGetDataSet(strSQL)

        If dsLoadAdmin.Tables(0).Rows.Count = 1 Then
            Try
                lblWO.Text = intWorkOrderID

                If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("CUSTOMER_ID")) Then
                    txtCustomerID.Text = dsLoadAdmin.Tables(0).Rows(0).Item("CUSTOMER_ID")
                Else
                    txtCustomerID.Text = Nothing
                End If
            Catch ex As Exception
            End Try

            If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("CORE_NO")) Then
                cboCore.SelectedIndex = cboCore.FindStringExact(dsLoadAdmin.Tables(0).Rows(0).Item("CORE_NO"))
            Else
                cboCore.SelectedIndex = 0
            End If
            If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("PO_NO")) Then
                txtPO.Text = dsLoadAdmin.Tables(0).Rows(0).Item("PO_NO")
            Else
                txtPO.Text = Nothing
            End If
            If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("CUBIC_INCH")) Then
                txtCubic.Text = dsLoadAdmin.Tables(0).Rows(0).Item("CUBIC_INCH")
            Else
                txtCubic.Text = Nothing
            End If
            Try
                If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("WO_DATE")) Then
                    dtWODate.Value = dsLoadAdmin.Tables(0).Rows(0).Item("WO_DATE")
                Else
                    dtWODate.Text = Nothing
                End If
            Catch ex As Exception
            End Try
            If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("FREIGHT_CORE_PUR")) Then
                chkFreightCorePur.Checked = dsLoadAdmin.Tables(0).Rows(0).Item("FREIGHT_CORE_PUR")
            End If
            If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("FREIGHT_OUTGOING")) Then
                chkFreightOutgoing.Checked = dsLoadAdmin.Tables(0).Rows(0).Item("FREIGHT_OUTGOING")
            End If
            If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("FREIGHT_RETURN")) Then
                chkFreightReturn.Checked = dsLoadAdmin.Tables(0).Rows(0).Item("FREIGHT_RETURN")
            End If
            If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("FREIGHT_OWN")) Then
                chkFreightOwn.Checked = dsLoadAdmin.Tables(0).Rows(0).Item("FREIGHT_OWN")
            End If
            If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("BLOCK_NO")) Then
                txtBlock.Text = dsLoadAdmin.Tables(0).Rows(0).Item("BLOCK_NO")
            Else
                txtBlock.Text = Nothing
            End If
            If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("CORE_NO")) Then
                txtCrank.Text = dsLoadAdmin.Tables(0).Rows(0).Item("CRANK_NO")
            Else
                txtCrank.Text = Nothing
            End If
            If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("HEAD_NO")) Then
                txtHead.Text = dsLoadAdmin.Tables(0).Rows(0).Item("HEAD_NO")
            Else
                txtHead.Text = Nothing
            End If
            If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("CON_ROD_CORE")) Then
                txtRodCore.Text = dsLoadAdmin.Tables(0).Rows(0).Item("CON_ROD_CORE")
            Else
                txtRodCore.Text = Nothing
            End If
            If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("CAM_CORE")) Then
                txtCamCore.Text = dsLoadAdmin.Tables(0).Rows(0).Item("CAM_CORE")
            Else
                txtCamCore.Text = Nothing
            End If
            If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("CRANK_CORE")) Then
                txtCrankCore.Text = dsLoadAdmin.Tables(0).Rows(0).Item("CRANK_CORE")
            Else
                txtCrankCore.Text = Nothing
            End If
            If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("BLOCK_CORE_CHARGE")) Then
                txtBlockCore.Text = dsLoadAdmin.Tables(0).Rows(0).Item("BLOCK_CORE_CHARGE")
            Else
                txtBlockCore.Text = Nothing
            End If
            If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("HEAD_CORE")) Then
                txtHeadCore.Text = dsLoadAdmin.Tables(0).Rows(0).Item("HEAD_CORE")
            Else
                txtHeadCore.Text = Nothing
            End If
            If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("TYPE")) Then
                If dsLoadAdmin.Tables(0).Rows(0).Item("TYPE") = "CylinderHead" Then
                    radCylinderHead.Checked = True
                    Try
                        If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("DESCRIPTION")) Then
                            lblTempCylinderHead.Text = dsLoadAdmin.Tables(0).Rows(0).Item("DESCRIPTION")
                            strTemplateDesc = dsLoadAdmin.Tables(0).Rows(0).Item("DESCRIPTION")
                        End If
                    Catch ex As Exception
                    End Try
                End If
                If dsLoadAdmin.Tables(0).Rows(0).Item("TYPE") = "LongBlock" Then
                    radLongBlock.Checked = True
                    Try
                        If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("DESCRIPTION")) Then
                            lblTempLongBlock.Text = dsLoadAdmin.Tables(0).Rows(0).Item("DESCRIPTION")
                            strTemplateDesc = dsLoadAdmin.Tables(0).Rows(0).Item("DESCRIPTION")
                        End If
                    Catch ex As Exception
                    End Try
                End If
                If dsLoadAdmin.Tables(0).Rows(0).Item("TYPE") = "PieceWork" Then
                    radPieceWork.Checked = True
                    Try
                        If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("DESCRIPTION")) Then
                            lblTempPieceWork.Text = dsLoadAdmin.Tables(0).Rows(0).Item("DESCRIPTION")
                            strTemplateDesc = dsLoadAdmin.Tables(0).Rows(0).Item("DESCRIPTION")
                        End If
                    Catch ex As Exception
                    End Try
                End If
            End If
            If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("AUTO_MODEL")) Then
                txtModel.Text = dsLoadAdmin.Tables(0).Rows(0).Item("AUTO_MODEL")
            Else
                txtModel.Text = Nothing
            End If
            If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("AUTO_VIN_CODE")) Then
                txtVinCode.Text = dsLoadAdmin.Tables(0).Rows(0).Item("AUTO_VIN_CODE")
            Else
                txtVinCode.Text = Nothing
            End If
            If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("NOTES")) Then
                rtxtNotes.Text = dsLoadAdmin.Tables(0).Rows(0).Item("NOTES")
                rtxtNotes.Text = rtxtNotes.Text.Replace("-NL-", ControlChars.CrLf)
            Else
                rtxtNotes.Text = Nothing
            End If


            '- Items that are only found in Work Order. -'
            '- The following code will error out (expected) if pulling from a template -'
            Try
                If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("NEEDED_BY")) Then
                    dtNeededBy.Value = dsLoadAdmin.Tables(0).Rows(0).Item("NEEDED_BY")
                Else
                    dtNeededBy.Value = Now
                End If
                If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("INVOICE_NO")) Then
                    txtInvoice.Text = dsLoadAdmin.Tables(0).Rows(0).Item("INVOICE_NO")
                Else
                    txtInvoice.Text = Nothing
                End If

                If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("MACHINIST")) Then
                    lblMachinist.Text = dsLoadAdmin.Tables(0).Rows(0).Item("MACHINIST")
                Else
                    lblMachinist.Text = Nothing
                End If
                If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("UPDATE_USER")) Then
                    lblUpdateUser.Text = dsLoadAdmin.Tables(0).Rows(0).Item("UPDATE_USER")
                Else
                    lblUpdateUser.Text = Nothing
                End If
                If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("UPDATE_DATE")) Then
                    lblUpdateDate.Text = dsLoadAdmin.Tables(0).Rows(0).Item("UPDATE_DATE")
                Else
                    lblUpdateDate.Text = Nothing
                End If
                If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("STATUS")) Then
                    cboStatus.SelectedIndex = cboStatus.FindStringExact(dsLoadAdmin.Tables(0).Rows(0).Item("STATUS"))
                Else
                    cboStatus.SelectedIndex = 1
                End If
                If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("SHELF_NUMBER")) Then
                    txtShelfNumber.Text = dsLoadAdmin.Tables(0).Rows(0).Item("SHELF_NUMBER")
                Else
                    txtShelfNumber.Text = Nothing
                End If
                If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("TYPE")) Then
                    If dsLoadAdmin.Tables(0).Rows(0).Item("TYPE") = "CylinderHead" Then
                        If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("TEMPLATE_DESC")) Then
                            lblTempCylinderHead.Text = dsLoadAdmin.Tables(0).Rows(0).Item("TEMPLATE_DESC")
                            strTemplateDesc = dsLoadAdmin.Tables(0).Rows(0).Item("TEMPLATE_DESC")
                        Else
                            strTemplateDesc = Nothing
                        End If
                    End If
                    If dsLoadAdmin.Tables(0).Rows(0).Item("TYPE") = "LongBlock" Then
                        If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("TEMPLATE_DESC")) Then
                            lblTempLongBlock.Text = dsLoadAdmin.Tables(0).Rows(0).Item("TEMPLATE_DESC")
                            strTemplateDesc = dsLoadAdmin.Tables(0).Rows(0).Item("TEMPLATE_DESC")
                        Else
                            strTemplateDesc = Nothing
                        End If
                    End If
                    If dsLoadAdmin.Tables(0).Rows(0).Item("TYPE") = "PieceWork" Then
                        If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("TEMPLATE_DESC")) Then
                            lblTempPieceWork.Text = dsLoadAdmin.Tables(0).Rows(0).Item("TEMPLATE_DESC")
                            strTemplateDesc = dsLoadAdmin.Tables(0).Rows(0).Item("TEMPLATE_DESC")
                        Else
                            strTemplateDesc = Nothing
                        End If
                    End If
                End If

            Catch ex As Exception
            End Try
            dsLoadAdmin.Dispose()

        Else
            MsgBox("There is an error loading the Administration Values from table WORK_ORDER.", MsgBoxStyle.Critical)
        End If
    End Sub
    Public Sub subLoadSimTest(ByVal intWorkOrderID As Integer)
        Dim strSQL As String
        Dim dsSimTest As New DataSet

        strSQL = "SELECT WORK_ORDER_ID " & _
                      "FROM SIM_TEST " & _
                      "WHERE WORK_ORDER_ID = '" & lblWO.Text & "'"

        dsSimTest = fctGetDataSet(strSQL)

        If dsSimTest.Tables(0).Rows.Count > 0 Then
            lblSimStatus.Text = "COMPLETED"
        Else
            lblSimStatus.Text = "N/A"
        End If

    End Sub
    Public Sub subLoadImageCount(ByVal intWorkOrderID As Integer, ByVal strPassingForm As String)
        Dim strSQL As String
        Dim dsImageCt As New DataSet
        Dim imgCtr As Integer = 0

        strSQL = "SELECT ID, WORK_ORDER_ID, IMAGE_PATH " & _
                      "FROM IMAGES " & _
                      "WHERE WORK_ORDER_ID = '" & intWorkOrderID & "'"

        dsImageCt = fctGetDataSet(strSQL)

        If strPassingForm = "TEMPLATE" Then
            Do Until imgctr = dsImageCt.Tables(0).Rows.Count
                If Not IsDBNull(dsImageCt.Tables(0).Rows(imgCtr).Item("IMAGE_PATH")) Then
                    lblImagesFromTemplate(imgCtr).Text = dsImageCt.Tables(0).Rows(imgCtr).Item("IMAGE_PATH")
                End If

                imgCtr += 1
            Loop
        Else
            If dsImageCt.Tables(0).Rows.Count > 0 Then
                lblImageCount.Text = dsImageCt.Tables(0).Rows.Count
            Else
                lblImageCount.Text = 0
            End If
        End If
    End Sub


    Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        subClear("NEW")
    End Sub

    '- The following code will allow group selection base upon the item that is in bold. -'
    'Private Sub dgv1_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellContentClick
    '    Dim dgCB As New DataGridViewCheckBoxCell
    '    dgCB = CType(dgv1("colCheckBox", e.RowIndex), DataGridViewCheckBoxCell)
    '    If dgCB.EditedFormattedValue Then
    '        '- Checked -'
    '        If dgv1.CurrentRow.Cells("Item_Type").Value < 1000 Then
    '            Dim intStartIndex As Integer
    '            Dim intCurrRowIndex As Integer

    '            intStartIndex = dgv1.CurrentRow.Index
    '            intCurrRowIndex = dgv1.CurrentRow.Index

    '            Try
    '                Do Until CInt(dgv1.Rows(intCurrRowIndex).Cells("Item_Type").Value) = CInt(dgv1.Rows(intStartIndex).Cells("Item_Type").Value + 1)
    '                    Dim chkSubItem As New DataGridViewCheckBoxCell
    '                    chkSubItem = CType(dgv1("colCheckBox", intCurrRowIndex), DataGridViewCheckBoxCell)
    '                    '- Check the Box -'
    '                    chkSubItem.Value = True

    '                    intCurrRowIndex += 1
    '                Loop
    '            Catch ex As Exception
    '            End Try
    '        End If
    '    Else
    '        '- Checkbox just become unchecked -'
    '        If dgv1.CurrentRow.Cells("Item_Type").Value < 1000 Then
    '            Dim intStartIndex As Integer
    '            Dim intCurrRowIndex As Integer

    '            intStartIndex = dgv1.CurrentRow.Index
    '            intCurrRowIndex = dgv1.CurrentRow.Index

    '            Try
    '                Do Until CInt(dgv1.Rows(intCurrRowIndex).Cells("Item_Type").Value) = CInt(dgv1.Rows(intStartIndex).Cells("Item_Type").Value + 1)
    '                    Dim chkSubItem As New DataGridViewCheckBoxCell
    '                    chkSubItem = CType(dgv1("colCheckBox", intCurrRowIndex), DataGridViewCheckBoxCell)
    '                    '- Uncheck the Box -'
    '                    chkSubItem.Value = False

    '                    intCurrRowIndex += 1
    '                Loop
    '            Catch ex As Exception
    '            End Try
    '        End If
    '    End If
    'End Sub




    'Private Sub dgv2_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv2.CellContentClick
    '    Dim dgCB As New DataGridViewCheckBoxCell
    '    dgCB = CType(dgv2("colCheckBox2", e.RowIndex), DataGridViewCheckBoxCell)
    '    If dgCB.EditedFormattedValue Then
    '        '- Checked -'
    '        If dgv2.CurrentRow.Cells("Item_Type").Value < 5000 Then
    '            Dim intStartIndex As Integer
    '            Dim intCurrRowIndex As Integer

    '            intStartIndex = dgv2.CurrentRow.Index
    '            intCurrRowIndex = dgv2.CurrentRow.Index

    '            Try
    '                Do Until CInt(dgv2.Rows(intCurrRowIndex).Cells("Item_Type").Value) = CInt(dgv2.Rows(intStartIndex).Cells("Item_Type").Value + 1)
    '                    Dim chkSubItem As New DataGridViewCheckBoxCell
    '                    chkSubItem = CType(dgv2("colCheckBox2", intCurrRowIndex), DataGridViewCheckBoxCell)
    '                    '- Check the Box -'
    '                    chkSubItem.Value = True

    '                    intCurrRowIndex += 1
    '                Loop
    '            Catch ex As Exception
    '            End Try
    '        End If
    '    Else
    '        '- Checkbox just become unchecked -'
    '        If dgv2.CurrentRow.Cells("Item_Type").Value < 5000 Then
    '            Dim intStartIndex As Integer
    '            Dim intCurrRowIndex As Integer

    '            intStartIndex = dgv2.CurrentRow.Index
    '            intCurrRowIndex = dgv2.CurrentRow.Index

    '            Try
    '                Do Until CInt(dgv2.Rows(intCurrRowIndex).Cells("Item_Type").Value) = CInt(dgv2.Rows(intStartIndex).Cells("Item_Type").Value + 1)
    '                    Dim chkSubItem As New DataGridViewCheckBoxCell
    '                    chkSubItem = CType(dgv2("colCheckBox2", intCurrRowIndex), DataGridViewCheckBoxCell)
    '                    '- Uncheck the Box -'
    '                    chkSubItem.Value = False

    '                    intCurrRowIndex += 1
    '                Loop
    '            Catch ex As Exception
    '            End Try
    '        End If
    '    End If
    'End Sub
    'Private Sub dgv1_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgv1.DataBindingComplete
    '    For i As Integer = 0 To dgv1.RowCount - 1
    '        If dgv1.Rows(i).Cells("Item_Type").Value < 1000 Then
    '            For j As Integer = 0 To dgv1.ColumnCount - 1
    '                dgv1.Rows(i).Cells(j).Style.Font = New Font(dgv1.DefaultCellStyle.Font, FontStyle.Bold)
    '            Next
    '        End If
    '    Next
    'End Sub
    'Private Sub dgv2_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgv2.DataBindingComplete
    '    For i As Integer = 0 To dgv2.RowCount - 1
    '        If dgv2.Rows(i).Cells("Item_Type").Value < 5000 Then
    '            For j As Integer = 0 To dgv2.ColumnCount - 1
    '                dgv2.Rows(i).Cells(j).Style.Font = New Font(dgv2.DefaultCellStyle.Font, FontStyle.Bold)
    '            Next
    '        End If
    '    Next
    'End Sub

    Private Sub tsiNewEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsiNewEmployee.Click
        frmEmployee.subLoadForm(Nothing)
    End Sub
    Private Sub tsiEditEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsiEditEmployee.Click
        frmShowEmployees.Show()
        frmShowEmployees.BringToFront()
    End Sub

    Public Function fctGetWorkOrderID() As Integer
        Dim strSQL As String
        Dim dsID As New DataSet
        '- Get last Work Order ID and increment it by one -'
        strSQL = "SELECT ID_NAME, ID_VALUE " & _
                      "FROM AUTO_GENERATE " & _
                      "WHERE ID_NAME = 'WO_ID'"

        dsID = fctGetDataSet(strSQL)

        If dsID.Tables(0).Rows.Count = 1 Then
            Return dsID.Tables(0).Rows(0).Item("ID_VALUE") + 1
        Else
            Return 0
        End If

    End Function

    Public Sub subInsertWO(ByVal intWorkOrderID As Integer)
        Dim strSQL As String
        Dim bolInsertStatus As Boolean
        Dim cboItemMake As cboItem
        Dim cboItemYear As New cboItem
        Dim cboItemFreight As New cboItem
        Dim strNote As String

        cboItemMake = cboMake.Items(cboMake.SelectedIndex)
        '- User didn't select a freightCarrier so input null -'
        If cboFreightCarriers.SelectedIndex = 0 Then
            cboItemFreight.ValueMember = "NULL"
        Else
            cboItemFreight = cboFreightCarriers.Items(cboFreightCarriers.SelectedIndex)
        End If


        If cboYear.SelectedIndex = -1 Then
            cboItemYear.ValueMember = cboYear.Text
        ElseIf cboYear.SelectedIndex = 0 Then
            cboItemYear.ValueMember = cboYear.Text
        Else
            cboItemYear = cboYear.Items(cboYear.SelectedIndex)
        End If

        strNote = rtxtNotes.Text.Replace(ControlChars.CrLf, "-NL-")

        '- Insert Work Order Core Information -'
        strSQL = "INSERT WORK_ORDER(CORE_NO, PO_NO, CUBIC_INCH, WO_DATE, AUTO_MAKE, AUTO_YEAR, FREIGHT_CORE_PUR, FREIGHT_OUTGOING, FREIGHT_RETURN, BLOCK_NO, CRANK_NO, HEAD_NO, CON_ROD_CORE, " & _
                            "CAM_CORE, BLOCK_CORE_CHARGE, NEEDED_BY, INVOICE_NO, NOTES, MACHINIST, UPDATE_USER, UPDATE_DATE, WORK_ORDER_ID, CUSTOMER_ID, CRANK_CORE, STATUS, HEAD_CORE, FREIGHT_CARRIER, FREIGHT_OWN, SHELF_NUMBER, TYPE, " & _
                            "AUTO_MODEL, AUTO_VIN_CODE, TEMPLATE_DESC) " & _
                      "VALUES('" & cboCore.Text & "', '" & txtPO.Text & "', '" & txtCubic.Text & "', '" & Format(dtWODate.Value, "yyyy-MM-dd HH:MM:ss") & "', '" & cboItemMake.ValueMember & "', '" & cboItemYear.ValueMember & "'," & _
                            "'" & chkFreightCorePur.Checked.GetHashCode & "', '" & chkFreightOutgoing.Checked.GetHashCode & "', '" & chkFreightReturn.Checked.GetHashCode & "', '" & txtBlock.Text & "', '" & txtCrank.Text & "', '" & txtHead.Text & "', " & _
                            "'" & txtRodCore.Text & "', '" & txtCamCore.Text & "', '" & txtBlockCore.Text & "', '" & Format(CType(txtNeedBy.Text, Date), "yyyy-MM-dd") & "', '" & txtInvoice.Text & "', '" & strNote & "', " & _
                            "'" & gstrUserID & "', '" & gstrUserID & "', '" & Format(Now, "yyyy-MM-dd HH:MM:ss") & "', '" & intWorkOrderID & "', '" & txtCustomerID.Text & "', '" & txtCrankCore.Text & "', '" & cboStatus.SelectedItem & "', '" & txtHeadCore.Text & "', '" & cboItemFreight.ValueMember & "', '" & chkFreightOwn.Checked.GetHashCode & "', '" & txtShelfNumber.Text & "', '" & lblWorkOrderType.Text & "', " & _
                            "'" & txtModel.Text & "', '" & txtVinCode.Text & "', '" & strTemplateDesc & "')"

        bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)

        If bolInsertStatus = False Then
            MsgBox("An error occured updating the Customer!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        rtxtNotes.Text = rtxtNotes.Text.Replace("-NL-", ControlChars.CrLf)
        bolInsertStatus = Nothing
    End Sub
    Public Sub subInsertMachWork(ByVal intWorkOrderID As Integer)
        Dim intRowIndex As Integer
        Dim dgCB As DataGridViewCheckBoxCell
        Dim strSQL As String
        Dim bolInsertStatus As Boolean

        Do Until intRowIndex = dgv1.Rows.Count
            dgCB = New DataGridViewCheckBoxCell
            dgCB = CType(dgv1("colCheckBox", intRowIndex), DataGridViewCheckBoxCell)

            If dgCB.EditedFormattedValue Then
                '- Checked -'

                strSQL = "INSERT MACHINE_WORK_WO(WO_ID, MW_ITEM_ID, QUANTITY, COST, MACHINE_ITEM) " & _
                              "VALUES('" & intWorkOrderID & "', '" & dgv1.Rows(intRowIndex).Cells(4).Value & "', '" & dgv1.Rows(intRowIndex).Cells("Quantity").Value & "', '" & dgv1.Rows(intRowIndex).Cells("Cost").Value & "', '" & dgv1.Rows(intRowIndex).Cells("Machine Work Ordered").Value & "')"
                bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)

                If bolInsertStatus = False Then
                    MsgBox("An error occured creating one of the machine work items!", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If
            intRowIndex += 1
        Loop
    End Sub
    Public Sub subInsertMatUsed(ByVal intWorkOrderID As Integer)
        Dim intRowIndex As Integer
        Dim dgCB As DataGridViewCheckBoxCell
        Dim strSQL As String
        Dim bolInsertStatus As Boolean

        Do Until intRowIndex = dgv2.Rows.Count
            dgCB = New DataGridViewCheckBoxCell
            dgCB = CType(dgv2("colCheckBox2", intRowIndex), DataGridViewCheckBoxCell)

            If dgCB.EditedFormattedValue Then
                '- Checked -'
                strSQL = "INSERT MATERIAL_USED_WO(WO_ID, MU_ITEM_ID, PART_NUMBER, SIZE, MATERIAL_ITEM) " & _
                              "VALUES('" & intWorkOrderID & "', '" & dgv2.Rows(intRowIndex).Cells(4).Value & "', '" & dgv2.Rows(intRowIndex).Cells("Part Number").Value & "', '" & dgv2.Rows(intRowIndex).Cells("Size").Value & "', '" & dgv2.Rows(intRowIndex).Cells("Material Used").Value & "')"
                bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
                If bolInsertStatus = False Then
                    MsgBox("An error occured creating one of the material used items!", MsgBoxStyle.Critical)
                    Exit Sub
                End If

            End If
            intRowIndex += 1
        Loop
    End Sub

    Public Sub subInsertWorkOrderID(ByVal intworkOrderID As Integer)
        Dim strSQL As String
        Dim bolInsertStatus As Boolean

        strSQL = "UPDATE AUTO_GENERATE SET ID_VALUE = '" & intworkOrderID & "' WHERE ID_NAME = 'WO_ID'"
        bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
        If bolInsertStatus = False Then
            MsgBox("An error occured updating table AUTO_GENERATE!", MsgBoxStyle.Critical)
            Exit Sub
        End If
    End Sub

    Private Sub btnSaveWO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveWO.Click
        subSaveWorkOrder(1)
    End Sub

    Public Sub subSaveWorkOrder(ByVal intMultipleWorkOrder As Integer)
        Dim strError As String = Nothing
        Dim strSQL As String
        Dim bolInsertStatus As Boolean
        Dim dsID As New DataSet
        Dim strStatus As String

        Dim intSecAddUpdateWO As Integer
        Dim intMultipleLoop As Integer = 0

        Do Until intMultipleLoop = intMultipleWorkOrder
            '- Make sure that all required fields are entered -'
            strError = fctRequiredFields()

            '- Must have a valid Template Type -'
            If radCylinderHead.Checked = False Then
                If radLongBlock.Checked = False Then
                    If radPieceWork.Checked = False Then
                        MsgBox("Please select a Work Order type.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    End If
                End If
            End If

            If strError <> "ERRORS MADE" Then
                '- Remove possible apostrophes -'
                Dim Ctrl As Control
                Dim childCtrl As Control
                Dim ctrlType As Type
                For Each Ctrl In Me.Controls
                    If Ctrl.HasChildren = True Then
                        For Each childCtrl In Ctrl.Controls
                            ctrlType = childCtrl.GetType
                            If ctrlType.Name = "TextBox" Then
                                childCtrl.Text = childCtrl.Text.Replace("'", "")
                            End If
                        Next
                    End If
                Next

                strStatus = Nothing
                Dim msgResult As MsgBoxResult

                If Me.Tag = "INSERT" Then
                    subCheckSecurity("WO_ADD", intSecAddUpdateWO)
                    If intSecAddUpdateWO <> 100 Then
                        MsgBox("You do not have authority to save Work Orders." & ControlChars.NewLine & ControlChars.NewLine & "Contact your administrator.", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    lblWO.Text = fctGetWorkOrderID()
                    lblWO.Refresh()
                    If cboStatus.SelectedIndex = 0 Then
                        cboStatus.SelectedIndex = 1
                    End If
                    subInsertWO(lblWO.Text)
                    subInsertMachWork(lblWO.Text)
                    subInsertMatUsed(lblWO.Text)
                    subInsertWorkOrderID(lblWO.Text)
                    txtWO.Text = lblWO.Text

                    If Len(lblImagesFromTemplate(0).Text) > 0 Then
                        Dim frmAddImage As New frmAddImages

                        frmAddImage.TextBox1.Text = lblImagesFromTemplate(0).Text
                        frmAddImage.TextBox2.Text = lblImagesFromTemplate(1).Text
                        frmAddImage.TextBox3.Text = lblImagesFromTemplate(2).Text
                        frmAddImage.TextBox4.Text = lblImagesFromTemplate(3).Text
                        frmAddImage.TextBox5.Text = lblImagesFromTemplate(4).Text
                        frmAddImage.TextBox6.Text = lblImagesFromTemplate(5).Text
                        frmAddImage.TextBox7.Text = lblImagesFromTemplate(6).Text
                        frmAddImage.TextBox8.Text = lblImagesFromTemplate(7).Text
                        frmAddImage.TextBox9.Text = lblImagesFromTemplate(8).Text
                        frmAddImage.TextBox10.Text = lblImagesFromTemplate(9).Text

                        frmAddImage.lblImageType.Text = "WO"
                        frmAddImage.lblSaveID.Text = lblWO.Text
                        frmAddImage.frmAddImages_Load(Nothing, Nothing)
                        frmAddImage.btnSave_Click(Nothing, Nothing)
                        frmAddImage.Close()
                        frmAddImage.Dispose()

                        subLoadImageCount(lblWO.Text, "WO")
                    End If

                    subClear("SAVE")
                    Me.Tag = "UPDATE"
                    btnSaveWO.Text = "Update Work Order"
                    Dirty.ResetDirtyState()
                    'btnSaveWO.BackColor = Color.LawnGreen

                ElseIf Me.Tag = "UPDATE" Then
                    subCheckSecurity("WO_EDIT", intSecAddUpdateWO)
                    If intSecAddUpdateWO < 75 Then
                        MsgBox("You do not have authority to update Work Orders" & ControlChars.NewLine & ControlChars.NewLine & "Contact your administrator.", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    msgResult = MsgBox("It appears you have made changes to the work order." & ControlChars.NewLine & ControlChars.NewLine & "Would you like to save your changes?", MsgBoxStyle.YesNoCancel)
                    If msgResult = MsgBoxResult.Yes Then
                        '- Delete all items associated with this work order -'
                        strSQL = "DELETE FROM MACHINE_WORK_WO WHERE WO_ID = '" & lblWO.Text & "'"
                        bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
                        If bolInsertStatus = False Then
                            MsgBox("An error Deleting values from the MACHINE_WORK_WO!", MsgBoxStyle.Critical)
                            Exit Sub
                        End If
                        strSQL = "DELETE FROM MATERIAL_USED_WO WHERE WO_ID = '" & lblWO.Text & "'"
                        bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
                        If bolInsertStatus = False Then
                            MsgBox("An error Deleting values from the MATERIAL_USED_WO!", MsgBoxStyle.Critical)
                            Exit Sub
                        End If
                        strSQL = "DELETE FROM WORK_ORDER WHERE WORK_ORDER_ID = '" & lblWO.Text & "'"
                        bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
                        If bolInsertStatus = False Then
                            MsgBox("An error Deleting values from the WORK_ORDER!", MsgBoxStyle.Critical)
                            Exit Sub
                        End If

                        '- Now save the work order information under the curret ID -'
                        If cboStatus.SelectedIndex = 0 Then
                            cboStatus.SelectedIndex = 1
                        End If
                        subInsertWO(lblWO.Text)
                        subInsertMachWork(lblWO.Text)
                        subInsertMatUsed(lblWO.Text)

                    End If
                End If

                lblUpdateUser.Text = gstrUserID
                lblUpdateDate.Text = Format(Now, "MM-dd-yyyy HH:MM:ss")
                Dirty.ResetDirtyState()
            Else
                Exit Sub
            End If

            intMultipleLoop += 1
        Loop
    End Sub


    'Public Sub subLoadCustomer(ByVal intWorkOrderID As Integer)
    '    Dim strSQL As String
    '    Dim dsLoadCust As New DataSet
    '    Dim strFirst As String = Nothing
    '    Dim strLast As String = Nothing

    '    strSQL = "SELECT CUSTOMER_ID FROM WORK_ORDER WHERE WORK_ORDER_ID = '" & intWorkOrderID & "'"
    '    dsLoadCust = fctGetDataSet(strSQL)

    '    If dsLoadCust.Tables(0).Rows.Count = 1 Then

    '        txtCustomerID.Text = dsLoadCust.Tables(0).Rows(0).Item("CUSTOMER_ID")
    '        subGetCustAddress(txtCustomerID.Text, "CUSTOMER_BILL_TO", strFirst, strLast, lblSoldCompany.Text, lblSoldAddr1.Text, _
    '                                     lblSoldAddr2.Text, lblSoldAddr3.Text, lblSoldCity.Text, lblSoldState.Text, lblSoldZip.Text, _
    '                                     lblSoldTelephone.Text, Nothing, Nothing, Nothing)
    '        lblSoldCustomerName.Text = strFirst & " " & strLast

    '        subGetCustAddress(txtCustomerID.Text, "CUSTOMER_SHIP_TO", strFirst, strLast, lblShipCompany.Text, lblShipAddr1.Text, _
    '                         lblShipAddr2.Text, lblShipAddr3.Text, lblShipCity.Text, lblShipState.Text, lblShipZip.Text, _
    '                         lblShipTelephone.Text, Nothing, Nothing, Nothing)
    '        lblShipCustomerName.Text = strFirst & " " & strLast

    '    Else
    '        MsgBox("There was a problem loading the Customer ID from the database.", MsgBoxStyle.Critical)
    '    End If
    'End Sub


    Public Function fctRequiredFields() As String
        Dim strError As String = Nothing
        '- Administration -'
        If cboMake.SelectedIndex = 0 Then
            cboMake.BackColor = Color.Red
            MsgBox("Please select the Make of Car.", MsgBoxStyle.OkOnly)
            strError = "ERRORS MADE"
        End If
        'If cboYear.SelectedIndex = 0 Then
        '    cboYear.BackColor = Color.Red
        '    strError = "ERRORS MADE"
        'End If

        '- Customer Requirements -'
        If txtCustomerID.Text.Length < 2 Then
            txtCustomerID.BackColor = Color.Red
            strError = "ERRORS MADE"
        End If
        'If txtFirst.Text.Length < 1 Then
        '    txtFirst.BackColor = Color.Red
        '    strError = "ERRORS MADE"
        'End If
        'If txtLast.Text.Length < 2 Then
        '    txtLast.BackColor = Color.Red
        '    strError = "ERRORS MADE"
        'End If
        'If txtAddr1.Text.Length < 1 Then
        '    txtAddr1.BackColor = Color.Red
        '    strError = "ERRORS MADE"
        'End If
        'If txtCity.Text.Length < 1 Then
        '    txtCity.BackColor = Color.Red
        '    strError = "ERRORS MADE"
        'End If
        'If cboState.SelectedIndex <= 0 Then
        '    cboState.BackColor = Color.Red
        '    strError = "ERRORS MADE"
        'End If

        'If cboStatus.SelectedIndex = 0 Then
        '    cboStatus.BackColor = Color.White
        '    strError = "ERRORS MADE"
        'End If


        '- Machine Work Ordered -'
        Dim intCurrRowIndex As Integer
        Dim bolItemCheck As Boolean
        Try
            Do Until intCurrRowIndex = dgv1.Rows.Count
                Dim chkSubItem As New DataGridViewCheckBoxCell
                chkSubItem = CType(dgv1("colCheckBox", intCurrRowIndex), DataGridViewCheckBoxCell)
                '- Check the Box -'
                If chkSubItem.Value = True Then
                    bolItemCheck = True
                End If

                intCurrRowIndex += 1
            Loop
        Catch ex As Exception
        End Try

        If bolItemCheck = False Then
            MsgBox("Please select at least on machine operation", MsgBoxStyle.OkOnly)
            strError = "ERRORS MADE"
        End If

        '- Material Used -'
        Return strError
    End Function

    Private Sub Customer_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        If gstrCustIDFound <> Nothing Then
            strCustAddrChanged = "YES"
        End If
    End Sub
    Private Sub EditWorkOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditWorkOrderToolStripMenuItem.Click
        frmSearchWorkOrder.ShowDialog()
    End Sub
    Private Sub dtNeededBy_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtNeededBy.ValueChanged
        txtNeedBy.Text = Trim(Mid(dtNeededBy.Value, 1, dtNeededBy.Value.ToString.IndexOf(" ")))
    End Sub

    Private Sub WorkOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WorkOrderToolStripMenuItem.Click
        subClear("NEW")
    End Sub
    Private Sub TemplateToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmTemplateNew.Click
        '- Save -'
        Dim frmSearchOrAddTemplate As New frmSearchOrAddTemplate
        frmSearchOrAddTemplate.lblSave.Visible = True
        frmSearchOrAddTemplate.txtSave.Visible = True
        frmSearchOrAddTemplate.btnSave.Visible = True

        frmSearchOrAddTemplate.ShowDialog()
    End Sub
    Private Sub TemplateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmTemplateEdit.Click
        '- Edit/Load an existing Template-'
        Dim frmSearchOrAddTemplate As New frmSearchOrAddTemplate
        frmSearchOrAddTemplate.lblLoad.Visible = True
        frmSearchOrAddTemplate.lblCylinderHead.Visible = True
        frmSearchOrAddTemplate.cboCylinderHead.Visible = True
        frmSearchOrAddTemplate.lblLongBlock.Visible = True
        frmSearchOrAddTemplate.cboLongBlock.Visible = True
        frmSearchOrAddTemplate.lblPieceWork.Visible = True
        frmSearchOrAddTemplate.cboPieceWork.Visible = True
        frmSearchOrAddTemplate.btnLoad.Visible = True
        frmSearchOrAddTemplate.txtCylinderHead.Visible = True
        frmSearchOrAddTemplate.txtLongBlock.Visible = True
        frmSearchOrAddTemplate.txtPieceWork.Visible = True

        frmSearchOrAddTemplate.ShowDialog()
    End Sub

    Private Sub btnViewImages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewImages.Click
        If lblImageCount.Text <> "" Then
            If lblImageCount.Text <> 0 Then
                Dim strSQL As String
                Dim dsImagePath As New DataSet

                strSQL = "SELECT WORK_ORDER_ID, ID, IMAGE_PATH " & _
                            "FROM IMAGES " & _
                            "WHERE WORK_ORDER_ID = '" & lblWO.Text & "'"

                dsImagePath = fctGetDataSet(strSQL)

                If dsImagePath.Tables(0).Rows.Count > 0 Then
                    System.Diagnostics.Process.Start("Explorer.exe", Mid(dsImagePath.Tables(0).Rows(0).Item("IMAGE_PATH"), 1, dsImagePath.Tables(0).Rows(0).Item("IMAGE_PATH").ToString.LastIndexOf("\")))
                End If
            End If
        End If
    End Sub

    Private Sub SetDefaultsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetDefaultsToolStripMenuItem.Click
        Dim frmDefaults As New frmDefaults
        frmDefaults.ShowDialog()
    End Sub
    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        Dim intWorkOrder As Integer = lblWO.Text
        subPrintWO("LOCAL", intWorkOrder)
    End Sub

    Private Sub AutoYearsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoYearsToolStripMenuItem.Click
        Dim frmEditYears As New frmEditYears
        frmEditYears.Show()
        frmEditYears.BringToFront()

    End Sub
    Private Sub AddImagesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddImagesToolStripMenuItem.Click
        Dim frmAddImages As New frmAddImages
        If lblWO.Text = "" Then

            If lblWO.Text = 0 Then
                MsgBox("Please save the work order before adding pictures to it.", MsgBoxStyle.OkOnly)
            End If
        Else
            frmAddImages.lblImageType.Text = "WORK_ORDER"
            frmAddImages.lblSaveID.Text = lblWO.Text
            frmAddImages.ShowDialog()
        End If
    End Sub

    Private Sub btnFindCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindCust.Click, btnFindComp.Click
        Dim strFirst As String = Nothing
        Dim strLast As String = Nothing
        Dim strCustomerFound As String = Nothing
        Dim msgResult As MsgBoxResult

        Dim btnTemp As Button
        Dim strCustorComp As String = Nothing
        btnTemp = CType(sender, Button)

        Try
            strCustorComp = btnTemp.Tag.ToString
            If btnTemp.Tag = "COMPANY" Then
                lblSoldCompany.Text = txtCompany.Text
            End If
        Catch ex As Exception
            strCustorComp = "CUSTOMER"
        End Try


        subGetCustAddress(txtCustomerID.Text, "CUSTOMER_BILL_TO", strFirst, strLast, lblSoldCompany.Text, lblSoldAddr1.Text, lblSoldAddr2.Text, _
                                                 lblSoldAddr3.Text, lblSoldCity.Text, lblSoldState.Text, lblSoldZip.Text, lblSoldTelephone.Text, Nothing, _
                                                 Nothing, strCustomerFound, strCustorComp)
        If strCustomerFound = "1 FOUND" Then
            lblBillTo.Text = strFirst & " " & strLast

            If lblSoldCompany.Text.Length > 0 Then
                lblBillTo.Text = lblBillTo.Text & ControlChars.NewLine & lblSoldCompany.Text
            End If
            If lblSoldAddr1.Text.Length > 0 Then
                lblBillTo.Text = lblBillTo.Text & ControlChars.NewLine & lblSoldAddr1.Text
            End If
            If lblSoldAddr2.Text.Length > 0 Then
                lblBillTo.Text = lblBillTo.Text & ControlChars.NewLine & lblSoldAddr2.Text
            End If
            If lblSoldAddr3.Text.Length > 0 Then
                lblBillTo.Text = lblBillTo.Text & ControlChars.NewLine & lblSoldAddr3.Text
            End If
            If lblSoldCity.Text.Length > 0 Then
                lblBillTo.Text = lblBillTo.Text & ControlChars.NewLine & lblSoldCity.Text
            End If
            If lblSoldState.Text.Length > 0 Then
                lblBillTo.Text = lblBillTo.Text & ", " & lblSoldState.Text
            End If
            If lblSoldZip.Text.Length > 0 Then
                lblBillTo.Text = lblBillTo.Text & " " & lblSoldZip.Text
            End If
            If lblSoldTelephone.Text.Length > 0 Then
                lblBillTo.Text = lblBillTo.Text & ControlChars.NewLine & lblSoldTelephone.Text
            End If


            strFirst = Nothing
            strLast = Nothing

            subGetCustAddress(txtCustomerID.Text, "CUSTOMER_SHIP_TO", strFirst, strLast, lblShipCompany.Text, lblShipAddr1.Text, lblShipAddr2.Text, _
                                                             lblShipAddr3.Text, lblShipCity.Text, lblShipState.Text, lblShipZip.Text, lblShipTelephone.Text, Nothing, _
                                                             Nothing, strCustomerFound, "CUSTOMER")

            lblShipTo.Text = strFirst & " " & strLast

            If lblShipCompany.Text.Length > 0 Then
                lblShipTo.Text = lblShipTo.Text & ControlChars.NewLine & lblShipCompany.Text
            End If
            If lblShipAddr1.Text.Length > 0 Then
                lblShipTo.Text = lblShipTo.Text & ControlChars.NewLine & lblShipAddr1.Text
            End If
            If lblShipAddr2.Text.Length > 0 Then
                lblShipTo.Text = lblShipTo.Text & ControlChars.NewLine & lblShipAddr2.Text
            End If
            If lblShipAddr3.Text.Length > 0 Then
                lblShipTo.Text = lblShipTo.Text & ControlChars.NewLine & lblShipAddr3.Text
            End If
            If lblShipCity.Text.Length > 0 Then
                lblShipTo.Text = lblShipTo.Text & ControlChars.NewLine & lblShipCity.Text
            End If
            If lblShipState.Text.Length > 0 Then
                lblShipTo.Text = lblShipTo.Text & ", " & lblShipState.Text
            End If
            If lblShipZip.Text.Length > 0 Then
                lblShipTo.Text = lblShipTo.Text & " " & lblShipZip.Text
            End If
            If lblShipTelephone.Text.Length > 0 Then
                lblShipTo.Text = lblShipTo.Text & ControlChars.NewLine & lblShipTelephone.Text
            End If
            txtCompany.Text = lblShipCompany.Text

        ElseIf strCustomerFound = "MORE_THAN_ONE" Then
            Dim frmSearchCustomer As New frmSearchCustomer
            frmSearchCustomer.subSearchCustomerID(txtCustomerID.Text, txtCompany.Text, btnTemp.Tag.ToString)
            frmSearchCustomer.ShowDialog()

            If Len(gstrSearchCustID) > 0 Then
                txtCustomerID.Text = gstrSearchCustID
                btnFindCust_Click(Nothing, Nothing)
            End If
        ElseIf strCustomerFound = "NONE FOUND" Then
            msgResult = MsgBox("Unable to find a Customer ID similiar to: " & txtCustomerID.Text & ControlChars.NewLine & "Would you like to create a new customer?", MsgBoxStyle.YesNo)
            If msgResult = MsgBoxResult.Yes Then
                Dim frmCustomer As New frmCustomer
                frmCustomer.ShowDialog()

                '- A recursive call to fill in the customer information once the created a new customer
                If frmCustomer.lblCustomerID.Text.Length <> 0 Then
                    If frmCustomer.lblCustomerID.Text <> "LBLCUSTOMERID" Then
                        txtCustomerID.Text = frmCustomer.lblCustomerID.Text
                        btnFindCust_Click(Nothing, Nothing)
                    Else
                        txtCustomerID.Text = Nothing
                        Exit Sub
                    End If
                Else
                    txtCustomerID.Text = Nothing
                    Exit Sub
                End If

            End If
        End If
    End Sub


    Public Sub subFindCustomer()

    End Sub

    Private Sub CustomerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerToolStripMenuItem.Click
        Dim frmCustomer As New frmCustomer
        frmCustomer.Show()
    End Sub

    Private Sub CustomerToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerToolStripMenuItem1.Click
        Dim frmCustomer As New frmCustomer
        frmCustomer.Show()
    End Sub

    Private Sub txtRodCore_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRodCore.TextChanged, txtCamCore.TextChanged, txtCrankCore.TextChanged, _
                                                                                                                                                                  txtBlockCore.TextChanged, txtHeadCore.TextChanged
        Dim txtTemp As TextBox
        txtTemp = CType(sender, TextBox)

        txtTemp.ForeColor = Color.Red
        txtTemp.Font = New Font(txtTemp.Font, FontStyle.Bold)
    End Sub

    Private Sub SimulationTestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimulationTestToolStripMenuItem.Click
        Dim frmSimTest As New frmSimTest


        If fctValidWONumber(lblWO.Text) = "YES" Then
            frmSimTest.lblWO.Text = gintWorkOrderID
            frmSimTest.ShowDialog()

            subLoadSimTest(gintWorkOrderID)
        Else
            MsgBox("You must have a vaild Work Order number.  Consider saving current Work Order.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
    End Sub

    Public Function fctValidWONumber(ByVal strWONum As String) As String
        Dim strSQL As String
        Dim dsValidWO As New DataSet

        strSQL = "SELECT WORK_ORDER_ID " & _
                      "FROM WORK_ORDER " & _
                      "WHERE WORK_ORDER_ID = '" & strWONum & "'"

        dsValidWO = fctGetDataSet(strSQL)

        If dsValidWO.Tables(0).Rows.Count > 0 Then
            Return "YES"
        Else
            Return "NO"
        End If
    End Function

    Private Sub lblWO_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblWO.TextChanged
        If Len(lblWO.Text) >= 1 Then
            If IsNumeric(lblWO.Text) = True Then
                gintWorkOrderID = lblWO.Text
            End If
        End If
    End Sub

    Private Sub cboStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStatus.SelectedIndexChanged
        If cboStatus.SelectedIndex = 1 Then
            '- Opened -'
            imgGreen.BringToFront()
        ElseIf cboStatus.SelectedIndex = 2 Then
            '- Closed -'
            imgRed.BringToFront()
            If chkFreightCorePur.Checked = True Then
                If chkFreightOutgoing.Checked = False Then
                    MsgBox("You must check the ""Core Purchase"" option in order to close this Work Order.", MsgBoxStyle.OkOnly)
                End If
            End If

        ElseIf cboStatus.SelectedIndex = 3 Then
            '- Cancelled -'
            imgRed.BringToFront()
        Else
            '- New Work Order -'
            imgYellow.BringToFront()
        End If
    End Sub

    Private Sub btnEmailWO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmailWO.Click
        Dim objMail As Object
        Dim objclient As Object
        Dim msgResult As New MsgBoxResult
        Dim strEmailTo As String

        Dim strSQL As String
        Dim dsImages As DataSet

        If lblWO.Text = 0 Then
            Exit Sub
        End If

        If lblWO.Text < 100 Then
            msgResult = MsgBox("You must first save the Work Order before emailing." & ControlChars.NewLine & ControlChars.NewLine & "Would you like to save the WO now?", MsgBoxStyle.YesNoCancel)
            If msgResult = MsgBoxResult.Yes Then
                btnSaveWO_Click(Nothing, Nothing)
            Else
                Exit Sub
            End If
        End If

        subPrintWO("EMAIL", lblWO.Text)

        If Not File.Exists("C:\Sunwest\tmpEmailPDF\" & lblWO.Text & ".pdf") Then
            MsgBox("Unable to find " & lblWO.Text & ".pdf.  Emailing of Work Order did not happen.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        objMail = CreateObject("Outlook.application")
        objclient = objMail.createitem(0)

        strSQL = "SELECT EMAIL " & _
                      "FROM CUSTOMER_BILL_TO " & _
                      "WHERE CUST_ID = '" & txtCustomerID.Text & "'"

        dsImages = fctGetDataSet(strSQL)

        If dsImages.Tables(0).Rows.Count > 0 Then
            objclient.To = dsImages.Tables(0).Rows(0).Item("EMAIL").ToString
        Else
            objclient.To = ""
        End If
        dsImages.Dispose()

        objclient.Subject = "Sunwest Work Order - #" & lblWO.Text
        objclient.Body = ""
        objclient.Attachments.Add("C:\Sunwest\tmpEmailPDF\" & lblWO.Text & ".pdf")

        msgResult = Nothing
        If IsNumeric(lblImageCount.Text) Then
            If lblImageCount.Text > 0 Then
                msgResult = MsgBox("Would you like also attach images from this Work Order to the email?", MsgBoxStyle.YesNo)
                If msgResult = MsgBoxResult.Yes Then
                    strSQL = "SELECT WORK_ORDER_ID, ID, IMAGE_PATH " & _
                                "FROM IMAGES " & _
                                "WHERE WORK_ORDER_ID = '" & lblWO.Text & "'"

                    dsImages = fctGetDataSet(strSQL)

                    If dsImages.Tables(0).Rows.Count > 0 Then
                        Try
                            Do Until dsImages.Tables(0).Rows.Count = 0
                                objclient.Attachments.Add(dsImages.Tables(0).Rows(0).Item("IMAGE_PATH").ToString)
                                dsImages.Tables(0).Rows.RemoveAt(0)
                            Loop
                        Catch ex As Exception
                            MsgBox("There was a problem attaching the pictrue(s) to the email." & ControlChars.CrLf & "Stored Image Path: " & dsImages.Tables(0).Rows(0).Item("IMAGE_PATH").ToString)
                        End Try
                    End If

                    dsImages.Dispose()
                End If
            End If
        End If

        objclient.display()
    End Sub

    Private Sub PrintPreviewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        subPrintWO("PREVIEW", lblWO.Text)
    End Sub

    Private Sub OpenWorkOrdersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenWorkOrdersToolStripMenuItem.Click
        Dim frmSearchWorkOrder As New frmSearchWorkOrder
        frmSearchWorkOrder.chkOpen.Checked = True
        frmSearchWorkOrder.Show()
        frmSearchWorkOrder.BringToFront()
        frmSearchWorkOrder.btnSearch_Click(Nothing, Nothing)
        Dirty.ResetDirtyState()
    End Sub
    Private Sub ClosedWorkOrdersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClosedWorkOrdersToolStripMenuItem.Click
        Dim frmSearchWorkOrder As New frmSearchWorkOrder
        frmSearchWorkOrder.chkClosed.Checked = True
        frmSearchWorkOrder.Show()
        frmSearchWorkOrder.BringToFront()
        frmSearchWorkOrder.btnSearch_Click(Nothing, Nothing)
        Dirty.ResetDirtyState()
    End Sub
    Private Sub CancelledWorkOrdersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelledWorkOrdersToolStripMenuItem.Click
        Dim frmSearchWorkOrder As New frmSearchWorkOrder
        frmSearchWorkOrder.chkCancelled.Checked = True
        frmSearchWorkOrder.Show()
        frmSearchWorkOrder.BringToFront()
        frmSearchWorkOrder.btnSearch_Click(Nothing, Nothing)
        Dirty.ResetDirtyState()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutACC.ShowDialog()

        'Dim strVersion As String
        'If System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
        '    strVersion = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()
        'Else
        '    strVersion = "Debug"
        'End If

        'MsgBox("Current Work Order Version: " & strVersion, MsgBoxStyle.OkOnly)
    End Sub

    Private Sub TemplateTypes_Changed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radCylinderHead.CheckedChanged, radLongBlock.CheckedChanged, radPieceWork.CheckedChanged
        Dim radTemp As RadioButton
        radTemp = CType(sender, RadioButton)

        If radTemp.Checked = True Then
            lblWorkOrderType.Text = radTemp.Tag
        End If
    End Sub



    Private Sub txtWO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWO.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.End Or e.KeyCode = Keys.Return Then
            subLoadWO(txtWO.Text)
            Dirty.ResetDirtyState()
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        subLoadWO(txtWO.Text)
        Dirty.ResetDirtyState()
    End Sub

    'Public Sub subLoadWO()
    '    Dim strSQL As String
    '    Dim dsWOID As New DataSet

    '    strSQL = "SELECT WORK_ORDER_ID " & _
    '                  "FROM WORK_ORDER " & _
    '                  "WHERE WORK_ORDER_ID = '" & txtWO.Text & "'"

    '    dsWOID = fctGetDataSet(strSQL)

    '    If dsWOID.Tables(0).Rows.Count = 1 Then
    '        subLoadAdministration(txtWO.Text, "WO")
    '        subUpdateMachineWork(txtWO.Text, "WO")
    '        subUpdateMaterialUsed(txtWO.Text, "WO")
    '        btnFindCust_Click(Nothing, Nothing)
    '        subLoadImageCount(txtWO.Text, "WO")
    '        subLoadSimTest(txtWO.Text)

    '        btnSaveWO.Text = "Update Work Order"
    '        Me.Tag = "UPDATE"
    '    Else
    '        MsgBox("No matching work orders found!", MsgBoxStyle.OkOnly)
    '        Exit Sub
    '    End If
    'End Sub

    Private Sub RemoveImagesFromWOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveImagesFromWOToolStripMenuItem.Click
        Dim frmRemoveImages As New frmRemoveImages
        If CInt(lblImageCount.Text) = 0 Then
            MsgBox("It appears that there are no pictures added to this work order.", MsgBoxStyle.OkOnly)
        Else
            frmRemoveImages.lblImageType.Text = "WORK_ORDER"
            frmRemoveImages.lblSaveID.Text = lblWO.Text
            frmRemoveImages.ShowDialog()
        End If
    End Sub

    Private Sub SaveMultipleWorkOrdersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveMultipleWorkOrdersToolStripMenuItem.Click
        Dim intMultipleWOLoop As Integer = 0
        Dim strTemp As String

        strTemp = InputBox("Please enter the number of multiple work orders you would like to create:", "Create Multiple")

        If IsNumeric(strTemp) = True Then
            Do Until intMultipleWOLoop = CInt(strTemp)
                subSaveWorkOrder(1)

                Me.Tag = "INSERT"
                lblWO.Text = ""
                txtWO.Text = ""
                intMultipleWOLoop += 1
            Loop
        Else
            If strTemp <> "" Then
                MsgBox("It appears that you didn't input a number.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        End If

    End Sub

    Private Sub ReduceImageSizeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReduceImageSizeToolStripMenuItem.Click
        frmImageResizer.Show()
    End Sub

    Private Sub btnCustomerSS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerSS.Click
        txtCustomerID.Text = "SSTOCK"
        btnFindCust_Click(btnFindCust, Nothing)

        cboStatus.SelectedIndex = cboStatus.FindString("CLOSED")
    End Sub

    Private Sub PrintBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintBatchToolStripMenuItem.Click
        frmPrintBatch.ShowDialog()

        If intBatchPrintStart > 0 And intBatchPrintEnd > 0 Then
            Do Until intBatchPrintStart = intBatchPrintEnd + 1
                subPrintWO("LOCAL", intBatchPrintStart)
                intBatchPrintStart += 1
            Loop
            subClear("New")
        End If

    End Sub
End Class


