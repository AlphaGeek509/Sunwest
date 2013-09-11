Public Class frmSearchCustomer

    Private Sub frmSearchCustomer_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        dgvFindCustomer.DataSource = Nothing
    End Sub

    Private Sub frmSearchCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gstrSearchCustID = Nothing
    End Sub

    Public Sub subSearchCustomerID(ByVal strCustID As String, ByVal strCompany As String, ByVal strCustorComp As String)
        Dim strSQL As String
        Dim dsLoadCust As New DataSet
        Dim dsCreditCard As New DataSet
        Dim strFirst As String = Nothing
        Dim strLast As String = Nothing
        Dim strState As String = Nothing
        Dim strWhere As String = Nothing

        If strCustorComp = "CUSTOMER" Then
            strWhere = "WHERE CUST_ID LIKE '" & strCustID & "%'"
        Else
            strWhere = "WHERE COMPANY LIKE '" & strCompany & "%'"
        End If

        strSQL = "SELECT CUST_ID, FIRST_NAME, LAST_NAME, COMPANY, DAY_PHONE  " & _
                      "FROM CUSTOMER_BILL_TO " & _
                      "" & strWhere & ""

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
        End If
        dsLoadCust.Dispose()
    End Sub

    Private Sub dgvFindCustomer_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFindCustomer.DoubleClick
        gstrSearchCustID = dgvFindCustomer.SelectedRows.Item(0).Cells(0).Value
        Me.Close()
    End Sub
End Class