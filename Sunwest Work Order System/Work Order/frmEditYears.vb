Public Class frmEditYears

    Private Sub frmEditYears_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strSQL As String
        Dim dsYears As New DataSet
        Dim intCtr As Integer
        Dim dt As New DataTable
        '- Add the values to the data table -'
        dt.Columns.Add("Year", System.Type.GetType("System.String"))
        dt.Columns.Add("Display Order", System.Type.GetType("System.String"))

        strSQL = "SELECT YEAR_DESC, YEAR_ORDER, VISIBLE " & _
                      "FROM AUTO_YEAR " & _
                      "WHERE YEAR_VALUE <> 'NULL' " & _
                      "ORDER BY YEAR_ORDER ASC"

        dsYears = fctGetDataSet(strSQL)

        If dsYears.Tables(0).Rows.Count > 0 Then
            Do Until intCtr = dsYears.Tables(0).Rows.Count
                '- Load the values into combobox for order selections -'
                cboOrder.Items.Add(New cboItem(Trim(dsYears.Tables(0).Rows(intCtr).Item("YEAR_ORDER")), dsYears.Tables(0).Rows(intCtr).Item("YEAR_ORDER")))

                Dim dr As DataRow
                dr = dt.NewRow
                dr("Year") = dsYears.Tables(0).Rows(intCtr).Item("YEAR_DESC")
                dr("Display Order") = dsYears.Tables(0).Rows(intCtr).Item("YEAR_ORDER")

                dt.Rows.Add(dr)
                intCtr += 1
            Loop

            dgvYears.DataSource = dt
            intCtr = 0

            Do Until intCtr = dsYears.Tables(0).Rows.Count
                '- Change the visibility status of years -'
                Dim dgCB As New DataGridViewCheckBoxCell
                If dsYears.Tables(0).Rows(intCtr).Item("VISIBLE") = "YES" Then
                    '- Checked -'
                    dgCB = CType(dgvYears("chkHide", intCtr), DataGridViewCheckBoxCell)
                    dgCB.Value = False
                Else
                    '- Uncheck the Box -'
                    dgCB = CType(dgvYears("chkHide", intCtr), DataGridViewCheckBoxCell)
                    dgCB.Value = True
                End If

                intCtr += 1
            Loop

        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim strSQL As String
        Dim bolInsertStatus As Boolean
        Dim intCtr As Integer = 0
        Dim strVisible As String = Nothing
        Dim dgCB As New DataGridViewCheckBoxCell

        strSQL = "DELETE FROM AUTO_YEAR " & _
                      "WHERE YEAR_VALUE <> 'NULL'"

        bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)

        If bolInsertStatus = False Then
            MsgBox("An error occured delete the Auto_Year table!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Do Until intCtr = dgvYears.RowCount
            dgCB = CType(dgvYears("chkHide", intCtr), DataGridViewCheckBoxCell)
            If dgCB.EditedFormattedValue Then
                '- Checked -'
                strVisible = "NO"
            Else
                '- Uncheck the Box -'
                strVisible = "YES"
            End If


            If dgvYears.Rows(intCtr).Cells(2).Value = cboOrder.SelectedIndex + 1 Then
                '- Insert the new date the user wants -'
                strSQL = "INSERT AUTO_YEAR(YEAR_VALUE, YEAR_DESC, YEAR_ORDER, VISIBLE) " & _
                          "VALUES('" & txtNewYear.Text & "', '" & txtNewYear.Text & "', '" & cboOrder.SelectedIndex + 1 & "', 'YES')"
                bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)

                '- Now insert the record your now accessing -'
                strSQL = "INSERT AUTO_YEAR(YEAR_VALUE, YEAR_DESC, YEAR_ORDER, VISIBLE) " & _
                          "VALUES('" & dgvYears.Rows(intCtr).Cells(1).Value & "', '" & dgvYears.Rows(intCtr).Cells(1).Value & "', '" & dgvYears.Rows(intCtr).Cells(2).Value + 1 & "', '" & strVisible & "')"
                bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
            Else
                '- Nothing matched so continue the insert -'
                strSQL = "INSERT AUTO_YEAR(YEAR_VALUE, YEAR_DESC, YEAR_ORDER, VISIBLE) " & _
                          "VALUES('" & dgvYears.Rows(intCtr).Cells(1).Value & "', '" & dgvYears.Rows(intCtr).Cells(1).Value & "', '" & dgvYears.Rows(intCtr).Cells(2).Value + 1 & "', '" & strVisible & "')"
                bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)

            End If

            If bolInsertStatus = False Then
                MsgBox("An error occured updating the Auto_Year table!", MsgBoxStyle.Critical)
                Exit Sub
            End If

            intCtr += 1
        Loop


        '- Now that the data has changed rebind it. -'
        Dim dsYears As New DataSet
        intCtr = 0
        dgvYears.DataSource = Nothing
        txtNewYear.Text = Nothing
        cboOrder.SelectedIndex = -1

        strSQL = "SELECT YEAR_DESC as 'Year', YEAR_ORDER as 'Display Order' " & _
                      "FROM AUTO_YEAR " & _
                      "WHERE YEAR_VALUE <> 'NULL' " & _
                      "ORDER BY YEAR_ORDER ASC"

        dsYears = fctGetDataSet(strSQL)

        dgvYears.DataSource = dsYears.Tables(0)

        If dsYears.Tables(0).Rows.Count > 0 Then
            Do Until intCtr = dsYears.Tables(0).Rows.Count
                '- Load the values into combobox -'
                cboOrder.Items.Add(New cboItem(Trim(dsYears.Tables(0).Rows(intCtr).Item("Display Order")), dsYears.Tables(0).Rows(intCtr).Item("Display Order")))
                intCtr += 1
            Loop
        End If
    End Sub

    Private Sub dgvYears_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvYears.CellContentClick
        Dim dgCB As New DataGridViewCheckBoxCell
        Dim intCurrRowIndex As Integer

        dgCB = CType(dgvYears("chkHide", e.RowIndex), DataGridViewCheckBoxCell)

        intCurrRowIndex = dgvYears.CurrentRow.Index
        Dim chkSubItem As New DataGridViewCheckBoxCell
        chkSubItem = CType(dgvYears("chkHide", intCurrRowIndex), DataGridViewCheckBoxCell)

        If dgCB.EditedFormattedValue Then
            '- Checked -'
            chkSubItem.Value = True
        Else
            '- Uncheck the Box -'
            chkSubItem.Value = False
        End If
    End Sub
End Class