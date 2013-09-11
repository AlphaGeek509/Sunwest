Public Class frmSearchOrAddTemplate

    Private Sub frmSearchOrAddTemplate_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'subPositionFormOnScreen("SavePosition", Me)
    End Sub

    Private Sub frmSearchOrAddTemplate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            subClear()
            subLoadTemplates()
        End If
    End Sub


    Private Sub frmSearchOrAddTemplate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        subClear()

        subLoadTemplates()
        subLoadMachineWorkOrdered(0)
        subLoadMaterialUsed(0)
        subLoadMake(0)
        subLoadYear(0)
        subLoadFreightCarrier(0)
        subLoadImageCount(0)
        'subPositionFormOnScreen("SavePosition", Me)
    End Sub

    Public Sub subLoadTemplates()
        Dim strSQL As String
        Dim dsTemplate As New DataSet
        Dim intCtr As Integer

        '- Cylinder Head -'
        strSQL = "SELECT ID, DESCRIPTION, VISIBLE " & _
                      "FROM TEMPLATE " & _
                      "WHERE VISIBLE = 'YES' AND TYPE = 'CylinderHead' " & _
                      "ORDER BY DESCRIPTION ASC"

        dsTemplate = fctGetDataSet(strSQL)

        cboCylinderHead.Items.Clear()
        If dsTemplate.Tables(0).Rows.Count > 0 Then
            Do Until intCtr = dsTemplate.Tables(0).Rows.Count
                '- Load the values into combobox -'
                cboCylinderHead.Items.Add(New cboItem(Trim(dsTemplate.Tables(0).Rows(intCtr).Item("DESCRIPTION")), dsTemplate.Tables(0).Rows(intCtr).Item("ID")))
                intCtr += 1
            Loop
        End If
        cboCylinderHead.SelectedIndex = -1

        '-Long Block -'
        intCtr = 0
        dsTemplate.Clear()
        strSQL = "SELECT ID, DESCRIPTION, VISIBLE " & _
                     "FROM TEMPLATE " & _
                     "WHERE VISIBLE = 'YES' AND TYPE = 'LongBlock' " & _
                     "ORDER BY DESCRIPTION ASC"

        dsTemplate = fctGetDataSet(strSQL)
        cboLongBlock.Items.Clear()
        If dsTemplate.Tables(0).Rows.Count > 0 Then
            Do Until intCtr = dsTemplate.Tables(0).Rows.Count
                '- Load the values into combobox -'
                cboLongBlock.Items.Add(New cboItem(Trim(dsTemplate.Tables(0).Rows(intCtr).Item("DESCRIPTION")), dsTemplate.Tables(0).Rows(intCtr).Item("ID")))
                intCtr += 1
            Loop
        End If
        cboLongBlock.SelectedIndex = -1

        '- Piece Work -'
        intCtr = 0
        dsTemplate.Clear()
        strSQL = "SELECT ID, DESCRIPTION, VISIBLE " & _
                     "FROM TEMPLATE " & _
                     "WHERE VISIBLE = 'YES' AND TYPE = 'PieceWork' " & _
                     "ORDER BY DESCRIPTION ASC"

        dsTemplate = fctGetDataSet(strSQL)
        cboPieceWork.Items.Clear()
        If dsTemplate.Tables(0).Rows.Count > 0 Then
            Do Until intCtr = dsTemplate.Tables(0).Rows.Count
                '- Load the values into combobox -'
                cboPieceWork.Items.Add(New cboItem(Trim(dsTemplate.Tables(0).Rows(intCtr).Item("DESCRIPTION")), dsTemplate.Tables(0).Rows(intCtr).Item("ID")))
                intCtr += 1
            Loop
        End If
        cboPieceWork.SelectedIndex = -1
    End Sub

    Public Sub subLoadImageCount(ByVal intTemplateID As Integer)
        Dim strSQL As String
        Dim dsImageCt As New DataSet


        strSQL = "SELECT WORK_ORDER_ID, ID, IMAGE_PATH " & _
                      "FROM IMAGES " & _
                      "WHERE WORK_ORDER_ID = '" & intTemplateID & "'"

        dsImageCt = fctGetDataSet(strSQL)

        If dsImageCt.Tables(0).Rows.Count > 0 Then
            lblImageCount.Text = dsImageCt.Tables(0).Rows.Count
        Else
            lblImageCount.Text = 0
        End If
        Me.Refresh()
    End Sub

    Public Sub subClear()
        lblTemplateID.Text = Nothing
        txtSave.Text = Nothing
        Dim dgTextBox As New DataGridViewTextBoxCell
        Dim dgCB As New DataGridViewCheckBoxCell

        subLoadMachineWorkOrdered(0)
        subLoadMaterialUsed(0)

        cboCore.SelectedIndex = -1
        cboCore.Text = Nothing
        txtPO.Text = Nothing
        txtCubic.Text = Nothing
        chkFreightCorePur.Checked = False
        chkFreightOutgoing.Checked = False
        chkFreightReturn.Checked = False
        chkFreightOwn.Checked = False
        If cboFreightCarriers.Items.Count > 0 Then
            cboFreightCarriers.SelectedIndex = 0
        Else
            cboFreightCarriers.SelectedIndex = -1
        End If

        txtBlock.Text = Nothing
        txtCrank.Text = Nothing
        txtHead.Text = Nothing
        txtHeadCore.Text = Nothing
        txtRodCore.Text = Nothing
        txtCamCore.Text = Nothing
        txtCrankCore.Text = Nothing
        txtBlockCore.Text = Nothing
        txtBlockCore.Text = Nothing
        Try
            cboMake.SelectedIndex = 0
            cboYear.Text = Nothing
            cboYear.SelectedIndex = 0
        Catch ex As Exception
        End Try

        'cboLoad.SelectedIndex = 0
        txtSave.Text = Nothing
        radCylinderHead.Checked = False
        radLongBlock.Checked = False
        radPieceWork.Checked = False
        lblTemplateType.Text = Nothing
        lblItemDesc.Text = Nothing
        cboCylinderHead.Text = ""
        cboLongBlock.Text = ""
        cboPieceWork.Text = ""
        txtModel.Text = ""
        txtVinCode.Text = ""
        rtxtNotes.Text = ""
        lblImageCount.Text = 0
        lblID.Text = ""
        txtCylinderHead.Text = ""
        txtLongBlock.Text = ""
        txtPieceWork.Text = ""

        cboCylinderHead.Items.Clear()
        cboLongBlock.Items.Clear()
        cboPieceWork.Items.Clear()

        txtSearchTemplateID.Text = ""
    End Sub

    Public Sub subLoadMake(ByVal intWorkOrderID As Integer)
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

        strSQL = "SELECT AUTO_MAKE FROM TEMPLATE WHERE ID = '" & intWorkOrderID & "'"
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
    Public Sub subLoadYear(ByVal intWorkOrderID As Integer)
        Dim strSQL As String
        Dim dsYear As New DataSet
        Dim dsLoadYear As New DataSet
        Dim strLoadYear As String = Nothing
        Dim intLoadYearIndex As Integer
        Dim intCtr As Integer

        strSQL = "SELECT YEAR_VALUE, YEAR_DESC, YEAR_ORDER " & _
                      "FROM AUTO_YEAR " & _
                      "WHERE VISIBLE = 'YES' " & _
                      "ORDER BY YEAR_ORDER ASC"

        dsYear = fctGetDataSet(strSQL)

        strSQL = "SELECT AUTO_YEAR " & _
                      "FROM TEMPLATE " & _
                      "WHERE ID = '" & intWorkOrderID & "'"

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
    Public Sub subLoadFreightCarrier(ByVal intWorkOrderID As Integer)
        Dim strSQL As String
        Dim dsFreightCarrer As New DataSet
        Dim dsFreightLookup As New DataSet
        'Dim strFreightLookup As String
        Dim strLoadFreightCarrer As String = Nothing
        Dim intLoadFreightCarrer As Integer
        Dim intCtr As Integer

        strSQL = "SELECT FREIGHT_VALUE, FREIGHT_DESC, FREIGHT_ORDER, FREIGHT_VISIBLE " & _
                      "FROM FREIGHT_CARRIERS " & _
                      "WHERE FREIGHT_VISIBLE = 'YES' " & _
                      "ORDER BY FREIGHT_ORDER ASC"

        dsFreightCarrer = fctGetDataSet(strSQL)



        strSQL = "SELECT FREIGHT_CARRIER " & _
                     "FROM TEMPLATE " & _
                     "WHERE ID = '" & intWorkOrderID & "'"

        dsFreightLookup = fctGetDataSet(strSQL)
        If dsFreightLookup.Tables(0).Rows.Count > 0 Then
            strLoadFreightCarrer = dsFreightLookup.Tables(0).Rows(0).Item("FREIGHT_CARRIER")
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


    Public Sub subLoadMachineWorkOrdered(ByVal intTemplateID As Integer)
        Dim strSQL As String
        Dim dsMaterialUsedHeading As New DataSet
        Dim dsMaterialUsedSubItem As New DataSet
        Dim intHeadingCtr As Integer

        strSQL = "SELECT MACHINE_ID, MACHINE_ITEM  " & _
                      "FROM MACHINE_WORK " & _
                      "ORDER BY MACHINE_ID ASC"

        dsMaterialUsedHeading = fctGetDataSet(strSQL)

        If dsMaterialUsedHeading.Tables(0).Rows.Count > 0 Then
            '- Loop for the Heading -'
            Dim dt As New DataTable
            dt.Columns.Add("Machine Work Ordered", System.Type.GetType("System.String"))
            dt.Columns.Add("Quantity", System.Type.GetType("System.String"))
            dt.Columns.Add("Cost", System.Type.GetType("System.String"))
            dt.Columns.Add("Item_Type", System.Type.GetType("System.String"))

            Do Until intHeadingCtr = dsMaterialUsedHeading.Tables(0).Rows.Count
                Dim dr As DataRow
                dr = dt.NewRow
                dr("Machine Work Ordered") = dsMaterialUsedHeading.Tables(0).Rows(intHeadingCtr).Item("MACHINE_ITEM")
                dr("Item_Type") = dsMaterialUsedHeading.Tables(0).Rows(intHeadingCtr).Item("MACHINE_ID")
                dt.Rows.Add(dr)

                intHeadingCtr += 1
            Loop
            dgv1.DataSource = dt
            dgv1.Columns(0).Width = 25
            dgv1.Columns(1).Width = 275
            dgv1.Columns(2).Width = 150
            dgv1.Columns(3).Width = 125
            dgv1.Columns(4).Visible = False
        Else
            MsgBox("Error reading from table Machine_Work", MsgBoxStyle.Critical, "DB Error")
        End If

        dsMaterialUsedHeading.Dispose()
    End Sub
    Public Sub subLoadMaterialUsed(ByVal intTemplateID As Integer)
        Dim strSQL As String
        Dim dsMaterialUsed As New DataSet
        Dim dsMaterialUsedSubItem As New DataSet
        Dim intHeadingCtr As Integer

        strSQL = "SELECT MATERIAL_ID, MATERIAL_ITEM " & _
                      "FROM MATERIAL_USED " & _
                      "ORDER BY MATERIAL_ID ASC"

        dsMaterialUsed = fctGetDataSet(strSQL)

        If dsMaterialUsed.Tables(0).Rows.Count > 0 Then

            '- Loop for the Heading -'
            Dim dt As New DataTable
            dt.Columns.Add("Material Used", System.Type.GetType("System.String"))
            dt.Columns.Add("Part Number", System.Type.GetType("System.String"))
            dt.Columns.Add("Size", System.Type.GetType("System.String"))
            dt.Columns.Add("Item_Type", System.Type.GetType("System.String"))

            Do Until intHeadingCtr = dsMaterialUsed.Tables(0).Rows.Count
                Dim dr As DataRow
                dr = dt.NewRow
                dr("Material Used") = dsMaterialUsed.Tables(0).Rows(intHeadingCtr).Item("MATERIAL_ITEM")
                dr("Item_Type") = dsMaterialUsed.Tables(0).Rows(intHeadingCtr).Item("MATERIAL_ID")
                dt.Rows.Add(dr)

                intHeadingCtr += 1
            Loop

            With dgv2
                .DataSource = dt
                .Columns(0).Width = 25
                .Columns(1).Width = 275
                .Columns(2).Width = 150
                .Columns(3).Width = 125
                .Columns(4).Visible = False
            End With

        Else
            MsgBox("Error reading from table Material_Used", MsgBoxStyle.Critical, "DB Error")
        End If
        dsMaterialUsed.Dispose()
    End Sub

    ''Private Sub dgv1_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellContentClick
    ''    Dim dgCB As New DataGridViewCheckBoxCell
    ''    dgCB = CType(dgv1("colCheckBox", e.RowIndex), DataGridViewCheckBoxCell)
    ''    If dgCB.EditedFormattedValue Then
    ''        '- Checked -'
    ''        If dgv1.CurrentRow.Cells("Item_Type").Value < 1000 Then
    ''            Dim intStartIndex As Integer
    ''            Dim intCurrRowIndex As Integer

    ''            intStartIndex = dgv1.CurrentRow.Index
    ''            intCurrRowIndex = dgv1.CurrentRow.Index

    ''            Try
    ''                Do Until CInt(dgv1.Rows(intCurrRowIndex).Cells("Item_Type").Value) = CInt(dgv1.Rows(intStartIndex).Cells("Item_Type").Value + 1)
    ''                    Dim chkSubItem As New DataGridViewCheckBoxCell
    ''                    chkSubItem = CType(dgv1("colCheckBox", intCurrRowIndex), DataGridViewCheckBoxCell)
    ''                    '- Check the Box -'
    ''                    chkSubItem.Value = True

    ''                    intCurrRowIndex += 1
    ''                Loop
    ''            Catch ex As Exception
    ''            End Try
    ''        End If
    ''    Else
    ''        '- Checkbox just become unchecked -'
    ''        If dgv1.CurrentRow.Cells("Item_Type").Value < 1000 Then
    ''            Dim intStartIndex As Integer
    ''            Dim intCurrRowIndex As Integer

    ''            intStartIndex = dgv1.CurrentRow.Index
    ''            intCurrRowIndex = dgv1.CurrentRow.Index

    ''            Try
    ''                Do Until CInt(dgv1.Rows(intCurrRowIndex).Cells("Item_Type").Value) = CInt(dgv1.Rows(intStartIndex).Cells("Item_Type").Value + 1)
    ''                    Dim chkSubItem As New DataGridViewCheckBoxCell
    ''                    chkSubItem = CType(dgv1("colCheckBox", intCurrRowIndex), DataGridViewCheckBoxCell)
    ''                    '- Uncheck the Box -'
    ''                    chkSubItem.Value = False

    ''                    intCurrRowIndex += 1
    ''                Loop
    ''            Catch ex As Exception
    ''            End Try
    ''        End If
    ''    End If
    ''End Sub
    'Private Sub dgv1_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgv1.DataBindingComplete
    '    For i As Integer = 0 To dgv1.RowCount - 1
    '        If dgv1.Rows(i).Cells("Item_Type").Value < 1000 Then
    '            For j As Integer = 0 To dgv1.ColumnCount - 1
    '                dgv1.Rows(i).Cells(j).Style.Font = New Font(dgv1.DefaultCellStyle.Font, FontStyle.Bold)
    '            Next
    '        End If
    '    Next
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
    'Private Sub dgv2_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgv2.DataBindingComplete
    '    For i As Integer = 0 To dgv2.RowCount - 1
    '        If dgv2.Rows(i).Cells("Item_Type").Value < 5000 Then
    '            For j As Integer = 0 To dgv2.ColumnCount - 1
    '                dgv2.Rows(i).Cells(j).Style.Font = New Font(dgv2.DefaultCellStyle.Font, FontStyle.Bold)
    '            Next
    '        End If
    '    Next
    'End Sub

    Private Sub SelectComboChange_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCylinderHead.SelectedIndexChanged, _
                                                                                                                                                                                  cboLongBlock.SelectedIndexChanged, _
                                                                                                                                                                                  cboPieceWork.SelectedIndexChanged
        Dim cboItemTemplate As cboItem
        Dim cboTemp As ComboBox

        txtCylinderHead.Text = ""
        txtLongBlock.Text = ""
        txtPieceWork.Text = ""

        subLoadMachineWorkOrdered(0)
        subLoadMaterialUsed(0)

        cboTemp = CType(sender, ComboBox)
        lblItemDesc.Text = cboTemp.Text
        If cboTemp.Name = "cboCylinderHead" Then
            txtCylinderHead.Text = cboTemp.Text
        ElseIf cboTemp.Name = "cboLongBlock" Then
            txtLongBlock.Text = cboTemp.Text
        ElseIf cboTemp.Name = "cboPieceWork" Then
            txtPieceWork.Text = cboTemp.Text
        End If

        cboItemTemplate = cboTemp.Items(cboTemp.SelectedIndex)
        btnDelete.Visible = True
        btnUpdate.Visible = True
        lblTemplateID.Text = cboItemTemplate.ValueMember

        subLoadTemplateInfo(lblTemplateID.Text)
    End Sub

    Public Sub subLoadTemplateInfo(ByVal strTemplateID As String)

        Dim strSQL As String
        Dim dsMW As New DataSet
        Dim dsMU As New DataSet

        Dim intCtr As Integer
        Dim intDGVCtr As Integer
        Dim dgTextBoxCell As New DataGridViewTextBoxCell
        Dim dgCB As New DataGridViewCheckBoxCell

        strSQL = "SELECT ID, MW_ITEM_ID, QUANTITY, COST, MACHINE_ITEM " & _
              "FROM MACHINE_WORK_TEMPLATE " & _
              "WHERE ID = '" & strTemplateID & "'"

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


        '- Material Used -'
        intDGVCtr = 0
        intCtr = 0
        strSQL = "SELECT ID, MU_ITEM_ID, PART_NUMBER, SIZE, MATERIAL_ITEM " & _
                              "FROM MATERIAL_USED_TEMPLATE " & _
                              "WHERE ID = '" & strTemplateID & "'"

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

        Dim dsLoadAdmin As New DataSet
        strSQL = "SELECT ID, DESCRIPTION, VISIBLE, CORE_NO, PO_NO, CUBIC_INCH, AUTO_MAKE, AUTO_YEAR, " & _
                            "FREIGHT_CORE_PUR, FREIGHT_OUTGOING, FREIGHT_RETURN, FREIGHT_OWN, BLOCK_NO, CRANK_NO, HEAD_NO, CON_ROD_CORE, " & _
                            "CAM_CORE, BLOCK_CORE_CHARGE, CRANK_CORE, HEAD_CORE, TYPE, AUTO_MODEL, AUTO_VIN_CODE, NOTES " & _
                      "FROM TEMPLATE " & _
                      "WHERE ID = '" & strTemplateID & "'"

        dsLoadAdmin = fctGetDataSet(strSQL)

        If dsLoadAdmin.Tables(0).Rows.Count = 1 Then
            If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("CORE_NO")) Then
                cboCore.SelectedIndex = cboCore.FindStringExact(dsLoadAdmin.Tables(0).Rows(0).Item("CORE_NO"))
            Else
                cboCore.SelectedText = Nothing
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
                End If
                If dsLoadAdmin.Tables(0).Rows(0).Item("TYPE") = "LongBlock" Then
                    radLongBlock.Checked = True
                End If
                If dsLoadAdmin.Tables(0).Rows(0).Item("TYPE") = "PieceWork" Then
                    radPieceWork.Checked = True
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
            If Not IsDBNull(dsLoadAdmin.Tables(0).Rows(0).Item("ID")) Then
                subLoadImageCount(dsLoadAdmin.Tables(0).Rows(0).Item("ID"))
            End If

            subLoadYear(strTemplateID)
            subLoadMake(strTemplateID)
            subLoadFreightCarrier(strTemplateID)

            lblTemplateID.Text = dsLoadAdmin.Tables(0).Rows(0).Item("ID")
            btnDelete.Visible = True
            btnUpdate.Visible = True
        End If

    End Sub

    Public Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim strSQL As String
        Dim dsID As New DataSet
        Dim intID As Integer
        Dim bolInsertStatus As Boolean
        Dim strNote As String

        If Len(txtSave.Text) = 0 Then
            MsgBox("Please give a descriptive name for this template.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        '- Must have a valid Template Type -'
        If radCylinderHead.Checked = False Then
            If radLongBlock.Checked = False Then
                If radPieceWork.Checked = False Then
                    MsgBox("Please select a template type.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            End If
        End If





        '- Get the latest Template number -'
        strSQL = "SELECT ID_NAME, ID_VALUE " & _
                    "FROM AUTO_GENERATE " & _
                    "WHERE ID_NAME = 'TEMPLATE' "

        dsID = fctGetDataSet(strSQL)

        If dsID.Tables(0).Rows.Count = 0 Then
            intID = 1
        Else
            intID = dsID.Tables(0).Rows(0).Item("ID_VALUE") + 1
        End If
        lblID.Text = intID
        lblTemplateID.Text = intID

        txtSave.Text = txtSave.Text.Replace("'", "")




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




        Dim intRowIndex As Integer
        Dim dgCB As DataGridViewCheckBoxCell
        Do Until intRowIndex = dgv1.Rows.Count
            dgCB = New DataGridViewCheckBoxCell
            dgCB = CType(dgv1("colCheckBox", intRowIndex), DataGridViewCheckBoxCell)

            If dgCB.EditedFormattedValue Then
                '- Checked -'
                strSQL = "INSERT MACHINE_WORK_TEMPLATE(ID, MW_ITEM_ID, QUANTITY, COST, MACHINE_ITEM) " & _
                              "VALUES('" & intID & "', '" & dgv1.Rows(intRowIndex).Cells("Item_Type").Value & "', '" & dgv1.Rows(intRowIndex).Cells("Quantity").Value & "', '" & dgv1.Rows(intRowIndex).Cells("Cost").Value & "', '" & dgv1.Rows(intRowIndex).Cells("Machine Work Ordered").Value & "')"
                bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)

                If bolInsertStatus = False Then
                    MsgBox("An error occured while saving the template under the Machine Worked section!", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If
            intRowIndex += 1
        Loop

        bolInsertStatus = Nothing
        intRowIndex = 0
        Do Until intRowIndex = dgv2.Rows.Count
            dgCB = New DataGridViewCheckBoxCell
            dgCB = CType(dgv2("colCheckBox2", intRowIndex), DataGridViewCheckBoxCell)

            If dgCB.EditedFormattedValue Then
                '- Checked -'
                strSQL = "INSERT MATERIAL_USED_TEMPLATE(ID, MU_ITEM_ID, PART_NUMBER, SIZE, MATERIAL_ITEM) " & _
                              "VALUES('" & intID & "', '" & dgv2.Rows(intRowIndex).Cells("Item_Type").Value & "', '" & dgv2.Rows(intRowIndex).Cells("Part Number").Value & "', '" & dgv2.Rows(intRowIndex).Cells("Size").Value & "', '" & dgv2.Rows(intRowIndex).Cells("Material Used").Value & "')"
                bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
                If bolInsertStatus = False Then
                    MsgBox("An error occured while saving the template under the Material Used section!", MsgBoxStyle.Critical)
                    Exit Sub
                End If

            End If
            intRowIndex += 1
        Loop

        '- Write the template description to the table -'
        bolInsertStatus = Nothing
        Dim cboItemMake As cboItem
        Dim cboItemYear As New cboItem
        cboItemMake = cboMake.Items(cboMake.SelectedIndex)
        Dim cboItemFreight As New cboItem
        cboItemFreight = cboFreightCarriers.Items(cboFreightCarriers.SelectedIndex)
        If cboYear.SelectedIndex = -1 Then
            cboItemYear.ValueMember = cboYear.Text
        Else
            cboItemYear = cboYear.Items(cboYear.SelectedIndex)
        End If

        strNote = rtxtNotes.Text.Replace(ControlChars.CrLf, "-NL-")

        strSQL = "INSERT TEMPLATE(ID, DESCRIPTION, VISIBLE, CORE_NO, PO_NO, CUBIC_INCH, AUTO_MAKE, AUTO_YEAR, " & _
                            "FREIGHT_CORE_PUR, FREIGHT_OUTGOING, FREIGHT_RETURN, BLOCK_NO, CRANK_NO, HEAD_NO, CON_ROD_CORE, " & _
                            "CAM_CORE, BLOCK_CORE_CHARGE, CRANK_CORE, FREIGHT_OWN, FREIGHT_CARRIER, HEAD_CORE, TYPE, AUTO_MODEL, AUTO_VIN_CODE, NOTES) " & _
                      "VALUES('" & intID & "', '" & txtSave.Text & "', 'YES', '" & cboCore.Text & "', '" & txtPO.Text & "', '" & txtCubic.Text & "', '" & cboItemMake.ValueMember & "', '" & cboItemYear.ValueMember & "'," & _
                            "'" & chkFreightCorePur.Checked.GetHashCode & "', '" & chkFreightOutgoing.Checked.GetHashCode & "', '" & chkFreightReturn.Checked.GetHashCode & "', '" & txtBlock.Text & "', '" & txtCrank.Text & "', '" & txtHead.Text & "', '" & txtRodCore.Text & "', " & _
                            "'" & txtCamCore.Text & "', '" & txtBlockCore.Text & "', '" & txtCrankCore.Text & "', '" & chkFreightOwn.Checked.GetHashCode & "', '" & cboItemFreight.ValueMember & "', '" & txtHeadCore.Text & "', '" & lblTemplateType.Text & "', '" & txtModel.Text & "', '" & txtVinCode.Text & "', '" & strNote & "')"

        bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
        If bolInsertStatus = False Then
            MsgBox("An error occured updating table AUTO_GENERATE!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        '- Update the auto generate table -'
        bolInsertStatus = Nothing
        strSQL = "UPDATE AUTO_GENERATE SET ID_VALUE = '" & intID & "' WHERE ID_NAME = 'TEMPLATE'"
        bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
        If bolInsertStatus = False Then
            MsgBox("An error occured updating table AUTO_GENERATE!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        MsgBox("Template saved successfuly!", MsgBoxStyle.Exclamation)
        subLoadTemplates()
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim strSQL As String
        Dim msgResult As MsgBoxResult

        msgResult = MsgBox("Are you sure you want to delete the template?", MsgBoxStyle.YesNoCancel)

        If msgResult = MsgBoxResult.Yes Then
            strSQL = "DELETE FROM MACHINE_WORK_TEMPLATE  WHERE ID = '" & lblTemplateID.Text & "'"
            fctInsertOrUpdateIntoDB(strSQL)

            strSQL = "DELETE FROM MATERIAL_USED_TEMPLATE  WHERE ID = '" & lblTemplateID.Text & "'"
            fctInsertOrUpdateIntoDB(strSQL)

            strSQL = "DELETE FROM TEMPLATE  WHERE ID = '" & lblTemplateID.Text & "'"
            fctInsertOrUpdateIntoDB(strSQL)

            MsgBox("Template successfuly deleted!", MsgBoxStyle.Exclamation)
            subClear()
            subLoadTemplates()
        End If
    End Sub
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim strSQL As String
        Dim bolInsertStatus As Boolean
        Dim intRowIndex As Integer
        Dim dgCB As DataGridViewCheckBoxCell
        Dim strNote As String

        '- First delete the values from the database before we update them -'
        strSQL = "DELETE FROM MACHINE_WORK_TEMPLATE WHERE ID = '" & lblTemplateID.Text & "'"
        bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
        If bolInsertStatus = False Then
            MsgBox("An error Deleting values from the MACHINE_WORK_TEMPLATE!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        strSQL = "DELETE FROM MATERIAL_USED_TEMPLATE WHERE ID = '" & lblTemplateID.Text & "'"
        bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
        If bolInsertStatus = False Then
            MsgBox("An error Deleting values from the MATERIAL_USED_TEMPLATE!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        '- Gather all the checkboxs and insert them -'
        Do Until intRowIndex = dgv1.Rows.Count
            dgCB = New DataGridViewCheckBoxCell
            dgCB = CType(dgv1("colCheckBox", intRowIndex), DataGridViewCheckBoxCell)

            If dgCB.EditedFormattedValue Then
                '- Checked -'
                strSQL = "INSERT MACHINE_WORK_TEMPLATE(ID, MW_ITEM_ID, QUANTITY, COST, MACHINE_ITEM) " & _
                              "VALUES('" & lblTemplateID.Text & "', '" & dgv1.Rows(intRowIndex).Cells("Item_Type").Value & "', '" & dgv1.Rows(intRowIndex).Cells("Quantity").Value & "', '" & dgv1.Rows(intRowIndex).Cells("Cost").Value & "', '" & dgv1.Rows(intRowIndex).Cells("Machine Work Ordered").Value & "')"
                bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)

                If bolInsertStatus = False Then
                    MsgBox("An error occured while saving the template under the Machine Worked section!", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If
            intRowIndex += 1
        Loop

        bolInsertStatus = Nothing
        intRowIndex = 0
        Do Until intRowIndex = dgv1.Rows.Count
            dgCB = New DataGridViewCheckBoxCell
            dgCB = CType(dgv2("colCheckBox2", intRowIndex), DataGridViewCheckBoxCell)

            If dgCB.EditedFormattedValue Then
                '- Checked -'
                strSQL = "INSERT MATERIAL_USED_TEMPLATE(ID, MU_ITEM_ID, PART_NUMBER, SIZE, MATERIAL_ITEM) " & _
                              "VALUES('" & lblTemplateID.Text & "', '" & dgv2.Rows(intRowIndex).Cells("Item_Type").Value & "', '" & dgv2.Rows(intRowIndex).Cells("Part Number").Value & "', '" & dgv2.Rows(intRowIndex).Cells("Size").Value & "', '" & dgv2.Rows(intRowIndex).Cells("Material Used").Value & "')"
                bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
                If bolInsertStatus = False Then
                    MsgBox("An error occured while saving the template under the Material Used section!", MsgBoxStyle.Critical)
                    Exit Sub
                End If

            End If
            intRowIndex += 1
        Loop

        '- Write the template description to the table -'
        bolInsertStatus = Nothing
        Dim cboItemMake As cboItem
        Dim cboItemYear As New cboItem
        Dim cboItemFreight As New cboItem
        cboItemFreight = cboFreightCarriers.Items(cboFreightCarriers.SelectedIndex)
        cboItemMake = cboMake.Items(cboMake.SelectedIndex)
        If cboYear.SelectedIndex = 0 Or cboYear.SelectedIndex = -1 Then
            cboItemYear.ValueMember = cboYear.Text
        Else
            cboItemYear = cboYear.Items(cboYear.SelectedIndex)
        End If

        strNote = rtxtNotes.Text.Replace(ControlChars.CrLf, "-NL-")

        strSQL = "UPDATE TEMPLATE SET " & _
                            "DESCRIPTION = '" & lblItemDesc.Text & "', " & _
                            "VISIBLE = 'YES', " & _
                            "CORE_NO = '" & cboCore.Text & "', " & _
                            "PO_NO = '" & txtPO.Text & "', " & _
                            "CUBIC_INCH = '" & txtCubic.Text & "', " & _
                            "AUTO_MAKE = '" & cboItemMake.ValueMember & "', " & _
                            "AUTO_YEAR = '" & cboItemYear.ValueMember & "', " & _
                            "FREIGHT_CORE_PUR = '" & chkFreightCorePur.Checked.GetHashCode & "', " & _
                            "FREIGHT_OUTGOING = '" & chkFreightOutgoing.Checked.GetHashCode & "', " & _
                            "FREIGHT_RETURN = '" & chkFreightReturn.Checked.GetHashCode & "', " & _
                            "FREIGHT_CARRIER = '" & cboItemFreight.ValueMember & "', " & _
                            "FREIGHT_OWN = '" & chkFreightOwn.Checked.GetHashCode & "', " & _
                            "BLOCK_NO = '" & txtBlock.Text & "', " & _
                            "CRANK_NO = '" & txtCrank.Text & "', " & _
                            "HEAD_NO = '" & txtHead.Text & "', " & _
                            "CON_ROD_CORE = '" & txtRodCore.Text & "', " & _
                            "CAM_CORE = '" & txtCamCore.Text & "', " & _
                            "HEAD_CORE = '" & txtHeadCore.Text & "', " & _
                            "TYPE = '" & lblTemplateType.Text & "', " & _
                            "AUTO_MODEL = '" & txtModel.Text & "', " & _
                            "AUTO_VIN_CODE = '" & txtVinCode.Text & "', " & _
                            "NOTES = '" & strNote & "', " & _
                            "BLOCK_CORE_CHARGE = '" & txtBlockCore.Text & "' " & _
                        "WHERE ID = '" & lblTemplateID.Text & "'"
        bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
        If bolInsertStatus = False Then
            MsgBox("An error occured updating table AUTO_GENERATE!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        rtxtNotes.Text = rtxtNotes.Text.Replace("-NL-", ControlChars.CrLf)
        MsgBox("Template successfuly updated!", MsgBoxStyle.Exclamation)
    End Sub

    Private Sub btnLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        frmWO.subClear("NEW")
        frmWO.subUpdateMachineWork(lblTemplateID.Text, "TEMPLATE")
        frmWO.subUpdateMaterialUsed(lblTemplateID.Text, "TEMPLATE")
        frmWO.subLoadMake(lblTemplateID.Text, "TEMPLATE")
        frmWO.subLoadYear(lblTemplateID.Text, "TEMPLATE")
        frmWO.subLoadAdministration(lblTemplateID.Text, "TEMPLATE")
        frmWO.subLoadFreightCarrier(lblTemplateID.Text, "TEMPLATE")
        frmWO.subLoadImageCount(lblTemplateID.Text, "TEMPLATE")

        Me.Close()
    End Sub

    Private Sub TemplateTypes_Changed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radCylinderHead.CheckedChanged, radLongBlock.CheckedChanged, radPieceWork.CheckedChanged
        Dim radTemp As RadioButton
        radTemp = CType(sender, RadioButton)

        If radTemp.Checked = True Then
            lblTemplateType.Text = radTemp.Tag
        End If
    End Sub

    Private Sub dgv1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv1.MouseEnter
        dgv1.Focus()
    End Sub

    Private Sub dgv2_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv2.MouseEnter
        dgv2.Focus()
    End Sub

    Private Sub btnViewImages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewImages.Click
        If lblImageCount.Text <> "" Then
            If lblImageCount.Text <> 0 Then
                Dim strSQL As String
                Dim dsImagePath As New DataSet

                strSQL = "SELECT WORK_ORDER_ID, ID, IMAGE_PATH " & _
                            "FROM IMAGES " & _
                            "WHERE WORK_ORDER_ID = '" & lblTemplateID.Text & "'"

                dsImagePath = fctGetDataSet(strSQL)

                If dsImagePath.Tables(0).Rows.Count > 0 Then
                    System.Diagnostics.Process.Start("Explorer.exe", Mid(dsImagePath.Tables(0).Rows(0).Item("IMAGE_PATH"), 1, dsImagePath.Tables(0).Rows(0).Item("IMAGE_PATH").ToString.LastIndexOf("\")))
                End If
            End If
        End If
    End Sub

    Private Sub AddImagesToTemplateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddImagesToTemplateToolStripMenuItem.Click
        Dim frmAddImages As New frmAddImages
        If lblTemplateID.Text = "" Then
            MsgBox("Please save the template before adding pictures to it.", MsgBoxStyle.OkOnly)
        ElseIf lblTemplateID.Text = 0 Then
            MsgBox("Please save the template before adding pictures to it.", MsgBoxStyle.OkOnly)
        Else
            frmAddImages.lblImageType.Text = "TEMPLATE"
            frmAddImages.lblSaveID.Text = lblTemplateID.Text
            frmAddImages.ShowDialog()
        End If


    End Sub

    Private Sub btnCopyTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyTemplate.Click
        Dim frmCopyTemplate As New frmCopyTemplate
        gstrCopyTemplateName = ""
        bolCopyImages = False

        frmCopyTemplate.lblOldTemplateName.Text = lblItemDesc.Text
        frmCopyTemplate.lblIncludeImages.Text = "Would you like to add the " & lblImageCount.Text & " images from " & lblItemDesc.Text & "?"

        frmCopyTemplate.ShowDialog()

        If Len(gstrCopyTemplateName) > 0 Then
            txtSave.Text = gstrCopyTemplateName
            btnSave_Click(Nothing, Nothing)

            If bolCopyImages = True Then
                Dim strSQL As String
                Dim dsCopyImages As DataSet

                strSQL = "SELECT IMAGES.ID, WORK_ORDER_ID, IMAGE_PATH " & _
                              "FROM IMAGES, TEMPLATE " & _
                              "WHERE IMAGES.WORK_ORDER_ID = TEMPLATE.ID AND " & _
                                    "TEMPLATE.DESCRIPTION = '" & lblItemDesc.Text & "'"

                dsCopyImages = fctGetDataSet(strSQL)

                If dsCopyImages.Tables(0).Rows.Count > 0 Then
                    Dim intCtr As Integer

                    Do Until intCtr = dsCopyImages.Tables(0).Rows.Count
                        Dim strImagePath As String = dsCopyImages.Tables(0).Rows(intCtr).Item("IMAGE_PATH")
                        Dim strID As String = dsCopyImages.Tables(0).Rows(intCtr).Item("ID")
                        Dim strTemplateID As String = dsCopyImages.Tables(0).Rows(intCtr).Item("WORK_ORDER_ID")

                        subSaveImage("TEMPLATE\", lblID.Text, strImagePath)

                        intCtr += 1
                    Loop
                End If
            End If
        End If
    End Sub

    Private Sub RemoveImagesFromTemplateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveImagesFromTemplateToolStripMenuItem.Click
        Dim frmRemoveImages As New frmRemoveImages
        If CInt(lblImageCount.Text) = 0 Then
            MsgBox("It appears that there are no pictures added to this work order.", MsgBoxStyle.OkOnly)
        Else
            frmRemoveImages.lblImageType.Text = "TEMPLATE"
            frmRemoveImages.lblSaveID.Text = lblTemplateID.Text
            frmRemoveImages.ShowDialog()
        End If
    End Sub


    Private Sub btnSearchTemplateID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchTemplateID.Click
        If Len(txtSearchTemplateID.Text) > 0 Then
            Dim strSQL As String
            Dim dsTemplateID As DataSet

            strSQL = "SELECT ID, TYPE, DESCRIPTION " & _
                          "FROM TEMPLATE " & _
                          "WHERE DESCRIPTION = '" & txtSearchTemplateID.Text & "' AND " & _
                                "VISIBLE = 'YES'"

            dsTemplateID = fctGetDataSet(strSQL)

            If dsTemplateID.Tables(0).Rows.Count > 0 Then
                subLoadTemplateInfo(dsTemplateID.Tables(0).Rows(0).Item("ID"))
                lblItemDesc.Text = dsTemplateID.Tables(0).Rows(0).Item("DESCRIPTION")

                If dsTemplateID.Tables(0).Rows(0).Item("TYPE") = "CylinderHead" Then
                    cboCylinderHead.FindString(dsTemplateID.Tables(0).Rows(0).Item("DESCRIPTION"))
                    txtCylinderHead.Text = dsTemplateID.Tables(0).Rows(0).Item("DESCRIPTION")
                ElseIf dsTemplateID.Tables(0).Rows(0).Item("TYPE") = "LongBlock" Then
                    txtLongBlock.Text = dsTemplateID.Tables(0).Rows(0).Item("DESCRIPTION")
                ElseIf dsTemplateID.Tables(0).Rows(0).Item("TYPE") = "PieceWork" Then
                    txtPieceWork.Text = dsTemplateID.Tables(0).Rows(0).Item("DESCRIPTION")
                End If
            Else
                MsgBox("Unable to find a template with that give description.", MsgBoxStyle.OkCancel)
            End If
        End If
    End Sub
End Class