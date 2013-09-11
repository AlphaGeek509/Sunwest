Public Class frmSimTest
    Dim strSimTestFound As String = Nothing

    Private Sub frmSimTest_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'subPositionFormOnScreen("SavePosition", Me)
    End Sub

    Private Sub frmSimTest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblWO.Text = gintWorkOrderID
        cboRunTime.SelectedIndex = 0
        cboLoad.SelectedIndex = 0
        cboOilPressure.SelectedIndex = 0
        cboCompression.SelectedIndex = 0

        '- Check for existing Sim Test -'
        Dim strSQL As String
        Dim dsDataset As New DataSet
        Dim intLoopCtr As Integer = 0

        strSQL = "SELECT WORK_ORDER_ID, RUN_TIME, ELECTRIC_LOAD, OIL_PRESSURE, COMPRESSION " & _
                      "FROM SIM_TEST " & _
                      "WHERE WORK_ORDER_ID = '" & lblWO.Text & "'"

        dsDataset = fctGetDataSet(strSQL)

        If dsDataset.Tables(0).Rows.Count = 1 Then
            strSimTestFound = "FOUND"

            If Not IsDBNull(dsDataset.Tables(0).Rows(0).Item("RUN_TIME")) Then
                cboRunTime.SelectedIndex = cboRunTime.FindStringExact(dsDataset.Tables(0).Rows(0).Item("RUN_TIME"))
            End If

            If Not IsDBNull(dsDataset.Tables(0).Rows(0).Item("ELECTRIC_LOAD")) Then
                cboLoad.SelectedIndex = cboLoad.FindStringExact(dsDataset.Tables(0).Rows(0).Item("ELECTRIC_LOAD"))
            End If

            If Not IsDBNull(dsDataset.Tables(0).Rows(0).Item("OIL_PRESSURE")) Then
                cboOilPressure.SelectedIndex = cboOilPressure.FindStringExact(dsDataset.Tables(0).Rows(0).Item("OIL_PRESSURE"))
            End If

            If Not IsDBNull(dsDataset.Tables(0).Rows(0).Item("COMPRESSION")) Then
                cboCompression.SelectedIndex = cboCompression.FindStringExact(dsDataset.Tables(0).Rows(0).Item("COMPRESSION"))
            End If

            btnSave.Text = "Update Sim Test"
        Else
            strSimTestFound = "NO"
        End If

        'subPositionFormOnScreen("MoveToLastPosition", Me)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim strSQL As String
        Dim bolResult As Boolean

        If strSimTestFound = "FOUND" Then
            strSQL = "DELETE FROM SIM_TEST WHERE WORK_ORDER_ID = '" & lblWO.Text & "'"
            bolResult = fctInsertOrUpdateIntoDB(strSQL)
            If bolResult = False Then
                MsgBox("An error Deleting values from the SIM_TEST table!", MsgBoxStyle.Critical)
                Exit Sub
            End If

            strSQL = "INSERT SIM_TEST(WORK_ORDER_ID, RUN_TIME, ELECTRIC_LOAD, OIL_PRESSURE, COMPRESSION) " & _
                                "VALUES('" & lblWO.Text & "', '" & cboRunTime.SelectedItem & "', '" & cboLoad.SelectedItem & "', '" & cboOilPressure.SelectedItem & "', '" & cboCompression.SelectedItem & "')"
            bolResult = fctInsertOrUpdateIntoDB(strSQL)
            If bolResult = False Then
                MsgBox("An error Inserting values into the SIM_TEST table!", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Else
            strSQL = "INSERT SIM_TEST(WORK_ORDER_ID, RUN_TIME, ELECTRIC_LOAD, OIL_PRESSURE, COMPRESSION) " & _
                                "VALUES('" & lblWO.Text & "', '" & cboRunTime.SelectedItem & "', '" & cboLoad.SelectedItem & "', '" & cboOilPressure.SelectedItem & "', '" & cboCompression.SelectedItem & "')"
            bolResult = fctInsertOrUpdateIntoDB(strSQL)
            If bolResult = False Then
                MsgBox("An error Inserting values into the SIM_TEST table!", MsgBoxStyle.Critical)
                Exit Sub
            End If
        End If

        Me.Close()
    End Sub
End Class