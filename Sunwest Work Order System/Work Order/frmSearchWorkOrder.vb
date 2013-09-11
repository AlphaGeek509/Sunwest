Public Class frmSearchWorkOrder

    Private Sub frmSearchWorkOrder_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'subPositionFormOnScreen("SavePosition", Me)
    End Sub

    Private Sub frmSearchWorkOrder_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            subClear()
        ElseIf e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Return Then
            btnSearch_Click(Nothing, Nothing)
        End If
    End Sub

    Public Sub subClear()
        txtWO.Text = Nothing
        txtFrom.Text = Nothing
        txtTo.Text = Nothing
        cboEmployee.SelectedIndex = -1
        txtCustID.Text = Nothing
        dgvShowWO.ClearSelection()
        dgvShowWO.DataSource = Nothing
        txtCustFirst.Text = Nothing
        txtCustLast.Text = Nothing
    End Sub

    Private Sub frmSearchWorkOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        subClear()

        Dim strSQL As String
        Dim dsEmployee As New DataSet
        Dim intCtr As Integer
        strSQL = "SELECT FIRST_NAME, LAST_NAME, USER_ID " & _
                      "FROM EMPLOYEE " & _
                      "WHERE STATUS = 'ACTIVE' " & _
                      "ORDER BY FIRST_NAME ASC"

        dsEmployee = fctGetDataSet(strSQL)

        cboEmployee.Items.Clear()

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

        txtWO.Focus()
        'subPositionFormOnScreen("MoveToLastPosition", Me)
    End Sub

    Private Sub frmSearchWorkOrder_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Dim intXaxis As Integer = Me.Size.Width
        Dim intYaxis As Integer = Me.Size.Height

        intXaxis = intXaxis - dgvShowWO.Width
        intYaxis = intYaxis - dgvShowWO.Height

        dgvShowWO.Width = Me.Size.Width - 250
        dgvShowWO.Height = Me.Size.Height - 50
    End Sub

    Public Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim strSQL As String
        Dim dsResults As New DataSet
        Dim strWhere As String = Nothing

        dgvShowWO.DataSource = Nothing

        If Len(txtWO.Text) > 0 Then
            strWhere = " WORK_ORDER_ID LIKE '" & txtWO.Text & "%' "
        End If

        If Len(txtFrom.Text) > 0 Then
            If Len(strWhere) > 0 Then
                strWhere += " AND WO_DATE >= '" & Format(CDate(txtFrom.Text), "yyyyMMdd") & "000000" & "'"
            Else
                strWhere = " WO_DATE >= '" & Format(CDate(txtFrom.Text), "yyyyMMdd") & "000000" & "'"
            End If

            If Len(txtTo.Text) > 0 Then
                If Len(strWhere) > 0 Then
                    strWhere += " AND WO_DATE <= '" & Format(CDate(txtTo.Text).AddDays(1), "yyyyMMdd") & "000000" & "'"
                Else
                    strWhere = " WO_DATE <= '" & Format(CDate(txtTo.Text).AddDays(1), "yyyyMMdd") & "000000" & "'"
                End If
            End If
        End If

        If cboEmployee.SelectedIndex <> -1 Then
            Dim CboEmployeeItem As New cboItem
            CboEmployeeItem = cboEmployee.Items(cboEmployee.SelectedIndex)
            If Len(strWhere) > 0 Then
                strWhere += " AND MACHINIST = '" & CboEmployeeItem.ValueMember & " '"
            Else
                strWhere = " MACHINIST = '" & CboEmployeeItem.ValueMember & " '"
            End If
        End If

        If Len(txtCustID.Text) > 0 Then
            If Len(strWhere) > 0 Then
                strWhere += " AND CUSTOMER_ID = '" & txtCustID.Text & " '"
            Else
                strWhere = " CUSTOMER_ID = '" & txtCustID.Text & " '"
            End If
        End If

        If Len(txtCustFirst.Text) > 0 Then
            If Len(strWhere) > 0 Then
                strWhere += " AND FIRST_NAME LIKE '" & txtCustFirst.Text & "%'"
            Else
                strWhere = " FIRST_NAME LIKE '" & txtCustFirst.Text & "%'"
            End If
        End If

        If Len(txtCustLast.Text) > 0 Then
            If Len(strWhere) > 0 Then
                strWhere += " AND LAST_NAME LIKE '" & txtCustLast.Text & "%'"
            Else
                strWhere = " LAST_NAME LIKE '" & txtCustLast.Text & "%'"
            End If
        End If

        If chkOpen.Checked = True Then
            If Len(strWhere) > 0 Then
                strWhere += " AND STATUS = 'OPEN'"
            Else
                strWhere = " STATUS = 'OPEN'"
            End If
        End If

        If chkClosed.Checked = True Then
            If Len(strWhere) > 0 Then
                strWhere += " AND STATUS = 'CLOSED'"
            Else
                strWhere = " STATUS = 'CLOSED'"
            End If
        End If

        If chkCancelled.Checked = True Then
            If Len(strWhere) > 0 Then
                strWhere += " AND STATUS = 'CANCELLED'"
            Else
                strWhere = " STATUS = 'CANCELLED'"
            End If
        End If

        If strWhere <> Nothing Then
            strWhere = "WHERE " & UCase(strWhere)

            strSQL = "SELECT WORK_ORDER_ID, STATUS, CUSTOMER_ID, MAKE_DESC, AUTO_YEAR, CUBIC_INCH, NEEDED_BY, " & _
                                "CUST_ID, FIRST_NAME, LAST_NAME, ADDR_1, ADDR_2, ADDR_3, CITY, STATE, ZIPCODE, COMPANY, DAY_PHONE, TYPE " & _
                          "FROM WORK_ORDER, CUSTOMER_BILL_TO, AUTO_MAKE " & _
                          "" & strWhere & " " & _
                                " AND CUSTOMER_ID = CUST_ID AND " & _
                                "MAKE_VALUE = AUTO_MAKE " & _
                          "ORDER BY WO_DATE ASC"

            dsResults = fctGetDataSet(strSQL)

            Dim dt As New DataTable
            dt.Columns.Add("WO ID", System.Type.GetType("System.String"))
            dt.Columns.Add("WO Status", System.Type.GetType("System.String"))
            dt.Columns.Add("Customer Name", System.Type.GetType("System.String"))
            dt.Columns.Add("Auto Make", System.Type.GetType("System.String"))
            dt.Columns.Add("Cubic Inch Dis.", System.Type.GetType("System.String"))
            dt.Columns.Add("Auto Year", System.Type.GetType("System.String"))
            dt.Columns.Add("Needed By", System.Type.GetType("System.String"))
            dt.Columns.Add("WO Type", System.Type.GetType("System.String"))

            If dsResults.Tables(0).Rows.Count = 1 Then
                frmWO.subLoadWO(dsResults.Tables(0).Rows(0).Item("WORK_ORDER_ID"))
                Me.Close()

            ElseIf dsResults.Tables(0).Rows.Count > 0 Then
                Dim intRowCtr As Integer
                Do Until intRowCtr = dsResults.Tables(0).Rows.Count
                    Dim dr As DataRow
                    dr = dt.NewRow
                    Dim strAddress As String = Nothing
                    dr("WO ID") = dsResults.Tables(0).Rows(intRowCtr).Item("WORK_ORDER_ID")

                    If Not IsDBNull(dsResults.Tables(0).Rows(intRowCtr).Item("STATUS")) Then
                        dr("WO Status") = dsResults.Tables(0).Rows(intRowCtr).Item("STATUS")
                    End If

                    If Not IsDBNull(dsResults.Tables(0).Rows(intRowCtr).Item("CUSTOMER_ID")) Then
                        strAddress = dsResults.Tables(0).Rows(intRowCtr).Item("CUSTOMER_ID")
                    End If

                    '- Insert Company -'
                    If Not IsDBNull(dsResults.Tables(0).Rows(intRowCtr).Item("COMPANY")) Then
                        If dsResults.Tables(0).Rows(intRowCtr).Item("COMPANY") <> Nothing Then
                            strAddress = dsResults.Tables(0).Rows(intRowCtr).Item("COMPANY")
                        End If
                    End If

                    '- Insert First Name -'
                    If Not IsDBNull(dsResults.Tables(0).Rows(intRowCtr).Item("FIRST_NAME")) Then
                        If Len(strAddress) > 0 Then
                            strAddress += ControlChars.CrLf & dsResults.Tables(0).Rows(intRowCtr).Item("FIRST_NAME")
                        End If
                    End If

                    '- Insert Last Name -'
                    If Not IsDBNull(dsResults.Tables(0).Rows(intRowCtr).Item("LAST_NAME")) Then
                        If Len(strAddress) > 0 Then
                            strAddress += " " & dsResults.Tables(0).Rows(intRowCtr).Item("LAST_NAME")
                        End If
                    End If

                    '- Insert Address 1 -'
                    If Not IsDBNull(dsResults.Tables(0).Rows(intRowCtr).Item("ADDR_1")) Then
                        If dsResults.Tables(0).Rows(intRowCtr).Item("ADDR_1") <> Nothing Then
                            If Len(strAddress) > 0 Then
                                strAddress += ControlChars.CrLf & dsResults.Tables(0).Rows(intRowCtr).Item("ADDR_1")
                            End If
                        End If
                    End If

                    '- Insert Address 2 -'
                    If Not IsDBNull(dsResults.Tables(0).Rows(intRowCtr).Item("ADDR_2")) Then
                        If dsResults.Tables(0).Rows(intRowCtr).Item("ADDR_2") <> Nothing Then
                            If Len(strAddress) > 0 Then
                                strAddress += ControlChars.CrLf & dsResults.Tables(0).Rows(intRowCtr).Item("ADDR_2")
                            End If
                        End If
                    End If

                    '- Insert Address 3 -'
                    If Not IsDBNull(dsResults.Tables(0).Rows(intRowCtr).Item("ADDR_3")) Then
                        If dsResults.Tables(0).Rows(intRowCtr).Item("ADDR_3") <> Nothing Then
                            If Len(strAddress) > 0 Then
                                strAddress += ControlChars.CrLf & dsResults.Tables(0).Rows(intRowCtr).Item("ADDR_3")
                            End If
                        End If
                    End If

                    '- Insert Address City -'
                    If Not IsDBNull(dsResults.Tables(0).Rows(intRowCtr).Item("CITY")) Then
                        If dsResults.Tables(0).Rows(intRowCtr).Item("CITY") <> Nothing Then
                            If Len(strAddress) > 0 Then
                                strAddress += ControlChars.CrLf & dsResults.Tables(0).Rows(intRowCtr).Item("CITY") & ", "
                            End If
                        End If

                    End If

                    '- Insert Address State -'
                    If Not IsDBNull(dsResults.Tables(0).Rows(intRowCtr).Item("STATE")) Then
                        If dsResults.Tables(0).Rows(intRowCtr).Item("STATE") <> Nothing Then
                            If Len(strAddress) > 0 Then
                                strAddress += dsResults.Tables(0).Rows(intRowCtr).Item("STATE") & " "
                            End If
                        End If
                    End If

                    dr("Customer Name") = strAddress
                    dr("Auto Make") = dsResults.Tables(0).Rows(intRowCtr).Item("MAKE_DESC")
                    dr("Auto Year") = dsResults.Tables(0).Rows(intRowCtr).Item("AUTO_YEAR")
                    dr("Needed By") = Mid(dsResults.Tables(0).Rows(intRowCtr).Item("NEEDED_BY"), 1, dsResults.Tables(0).Rows(intRowCtr).Item("NEEDED_BY").ToString.IndexOf(" "))
                    dr("Cubic Inch Dis.") = dsResults.Tables(0).Rows(intRowCtr).Item("CUBIC_INCH")

                    If dsResults.Tables(0).Rows(intRowCtr).Item("TYPE") = "CylinderHead" Then
                        dr("WO Type") = "Cylinder Head"
                    End If
                    If dsResults.Tables(0).Rows(intRowCtr).Item("TYPE") = "LongBlock" Then
                        dr("WO Type") = "Long Block"
                    End If
                    If dsResults.Tables(0).Rows(intRowCtr).Item("TYPE") = "PieceWork" Then
                        dr("WO Type") = "Piece Work"
                    End If

                    dt.Rows.Add(dr)
                    intRowCtr += 1
                Loop


                dgvShowWO.DataSource = dt

                dgvShowWO.Columns(0).Width = 50
                dgvShowWO.Columns(1).Width = 80
                dgvShowWO.Columns(2).Width = 175
                dgvShowWO.Columns(3).Width = 70
                dgvShowWO.Columns(4).Width = 70
                dgvShowWO.Columns(5).Width = 70
                dgvShowWO.Columns(6).Width = 75
                dgvShowWO.Columns(7).Width = 70

                dgvShowWO.Columns(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True

            ElseIf dsResults.Tables(0).Rows.Count = 0 Then
                MsgBox("Your search criteria produced no results!", MsgBoxStyle.OkOnly)
            End If
        Else
            MsgBox("Please select at least one search criteria.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub dtpFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFrom.ValueChanged
        txtFrom.Text = Trim(Mid(dtpFrom.Value, 1, dtpFrom.Value.ToString.IndexOf(" ")))
    End Sub
    Private Sub dtpTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTo.ValueChanged
        txtTo.Text = Trim(Mid(dtpTo.Value, 1, dtpTo.Value.ToString.IndexOf(" ")))
    End Sub

    Private Sub dgvShowWO_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvShowWO.DataBindingComplete
        Dim intRowIndex As Integer

        Do Until intRowIndex = dgvShowWO.Rows.Count
            If intRowIndex Mod 2 = 0 Then
                '- Change the back color -'
                For Each cell As DataGridViewCell In dgvShowWO.Rows(intRowIndex).Cells
                    cell.Style.BackColor = Color.Gainsboro
                    If cell.Value.ToString = "OPEN" Then
                        cell.Style.BackColor = Color.Green
                        cell.Style.ForeColor = Color.White
                    End If

                    If cell.Value.ToString = "CLOSED" Then
                        cell.Style.BackColor = Color.Red
                        cell.Style.ForeColor = Color.White
                    End If
                Next
            End If

            intRowIndex += 1
        Loop
    End Sub

    Private Sub dgvShowWO_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvShowWO.DoubleClick
        frmWO.subLoadWO(dgvShowWO.SelectedCells(0).Value)
        Me.Close()
    End Sub

    Private Sub dgvShowWO_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvShowWO.MouseEnter
        dgvShowWO.Focus()
    End Sub
End Class