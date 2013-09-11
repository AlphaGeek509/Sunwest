Imports System.IO

Module Global_Defs
    Public gstrUserID As String
    Public gintWorkOrderID As Integer
    Public gstrCustIDFound As String
    Public gstrSearchCustID As String
    Public gstrCopyTemplateName As String
    Public bolCopyImages As Boolean
    Public intPrintBatchStart As Integer
    Public intPrintBatchEnd As Integer



    Public Function fctGetDataSet(ByVal strSQL As String) As DataSet
        Dim Connection As New Odbc.OdbcConnection
        Dim Command As New Odbc.OdbcCommand
        Dim Adapter As New Odbc.OdbcDataAdapter
        Dim DataSet As New DataSet

        If System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
            Connection.ConnectionString = "DRIVER={MySQL ODBC 3.51 Driver};SERVER=192.168.1.100;DATABASE=sunwest;UID=sunwest;PWD=angela;"
        Else
            Connection.ConnectionString = "DRIVER={MySQL ODBC 3.51 Driver};SERVER=localhost;DATABASE=sunwest;UID=sunwest;PWD=angela;"
        End If

        Connection.Open()

        With Command
            .CommandText = strSQL
            .CommandType = CommandType.Text
            .Connection = Connection
        End With

        Adapter.SelectCommand = Command
        Adapter.Fill(DataSet)
        Connection.Close()

        Return DataSet
        DataSet.Dispose()
    End Function

    Public Function fctInsertOrUpdateIntoDB(ByVal strSQL As String) As Boolean
        Dim Connection As New Odbc.OdbcConnection
        Dim Command As New Odbc.OdbcCommand
        Dim Adapter As New Odbc.OdbcDataAdapter

        If System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
            Connection.ConnectionString = "DRIVER={MySQL ODBC 3.51 Driver};SERVER=192.168.1.100;DATABASE=sunwest;UID=sunwest;PWD=angela;"
        Else
            Connection.ConnectionString = "DRIVER={MySQL ODBC 3.51 Driver};SERVER=localhost;DATABASE=sunwest;UID=sunwest;PWD=angela;"
        End If
        Connection.Open()

        ' Try
        With Command
            .CommandText = strSQL
            .CommandType = CommandType.Text
            .Connection = Connection
            .ExecuteNonQuery()
        End With
        Connection.Close()
        Return True
        ' Catch ex As Exception
        Connection.Close()
        Return False
        'End Try
    End Function

    Public Sub subGetCustAddress(ByRef strCustID As String, ByVal strTableLookup As String, ByRef strFirst As String, ByRef strLast As String, ByRef strCompany As String, ByRef strAddr1 As String, ByRef strAddr2 As String, _
                                                 ByRef strAddr3 As String, ByRef strCity As String, ByRef strState As String, ByRef strZipcode As String, ByRef strDayPhone As String, ByRef strEveningPhone As String, _
                                                 ByRef stremail As String, ByRef strCustomerFound As String, ByVal strCustorComp As String)
        Dim strSQL As String
        Dim dsCust As New DataSet
        Dim strWhere As String

        If strCustorComp = "CUSTOMER" Then
            strWhere = "WHERE CUST_ID LIKE '" & strCustID & "%'"
        Else
            strWhere = "WHERE COMPANY LIKE '" & strCompany & "%'"
        End If

        strSQL = "SELECT CUST_ID, FIRST_NAME, LAST_NAME, ADDR_1, ADDR_2, ADDR_3, CITY, " & _
                            "STATE, ZIPCODE, COMPANY, DAY_PHONE, EVENING_PHONE, EMAIL " & _
                      "FROM " & strTableLookup & " " & _
                      "" & strWhere & ""

        dsCust = fctGetDataSet(strSQL)

        If dsCust.Tables(0).Rows.Count > 1 Then
            strCustomerFound = "MORE_THAN_ONE"
            Exit Sub
        ElseIf dsCust.Tables(0).Rows.Count = 1 Then
            '- Show the only customer associated with this customer id -'
            If Not IsDBNull(dsCust.Tables(0).Rows(0).Item("CUST_ID")) Then
                strCustID = dsCust.Tables(0).Rows(0).Item("CUST_ID")
            End If
            If Not IsDBNull(dsCust.Tables(0).Rows(0).Item("FIRST_NAME")) Then
                strFirst = dsCust.Tables(0).Rows(0).Item("FIRST_NAME")
            End If
            If Not IsDBNull(dsCust.Tables(0).Rows(0).Item("LAST_NAME")) Then
                strLast = dsCust.Tables(0).Rows(0).Item("LAST_NAME")
            End If
            If Not IsDBNull(dsCust.Tables(0).Rows(0).Item("ADDR_1")) Then
                strAddr1 = dsCust.Tables(0).Rows(0).Item("ADDR_1")
            End If
            If Not IsDBNull(dsCust.Tables(0).Rows(0).Item("ADDR_2")) Then
                strAddr2 = dsCust.Tables(0).Rows(0).Item("ADDR_2")
            End If
            If Not IsDBNull(dsCust.Tables(0).Rows(0).Item("ADDR_3")) Then
                strAddr3 = dsCust.Tables(0).Rows(0).Item("ADDR_3")
            End If
            If Not IsDBNull(dsCust.Tables(0).Rows(0).Item("CITY")) Then
                strCity = dsCust.Tables(0).Rows(0).Item("CITY")
            End If
            If Not IsDBNull(dsCust.Tables(0).Rows(0).Item("STATE")) Then
                strState = dsCust.Tables(0).Rows(0).Item("STATE")
            End If
            If Not IsDBNull(dsCust.Tables(0).Rows(0).Item("DAY_PHONE")) Then
                strDayPhone = dsCust.Tables(0).Rows(0).Item("DAY_PHONE")
            End If
            If Not IsDBNull(dsCust.Tables(0).Rows(0).Item("EVENING_PHONE")) Then
                strEveningPhone = dsCust.Tables(0).Rows(0).Item("EVENING_PHONE")
            End If
            If Not IsDBNull(dsCust.Tables(0).Rows(0).Item("ZIPCODE")) Then
                strZipcode = dsCust.Tables(0).Rows(0).Item("ZIPCODE")
            End If
            If Not IsDBNull(dsCust.Tables(0).Rows(0).Item("COMPANY")) Then
                strCompany = dsCust.Tables(0).Rows(0).Item("COMPANY")
            End If
            If Not IsDBNull(dsCust.Tables(0).Rows(0).Item("EMAIL")) Then
                stremail = dsCust.Tables(0).Rows(0).Item("EMAIL")
            End If
            gstrCustIDFound = dsCust.Tables(0).Rows(0).Item("CUST_ID")
            strCustomerFound = "1 FOUND"
        Else
            strCustomerFound = "NONE FOUND"
        End If
    End Sub
    Public Sub subLoadStateProv(ByRef cboState As ComboBox)
        Dim strSQL As String
        Dim dsState As New DataSet
        Dim intCtr As Integer
        strSQL = "SELECT COUNTRY_ID, PROVSTATE_NAME, PROVSTATE_ABBR " & _
                      "FROM STATE_PROV " & _
                      "ORDER BY COUNTRY_ID, PROVSTATE_NAME ASC"

        dsState = fctGetDataSet(strSQL)

        If dsState.Tables(0).Rows.Count > 0 Then
            Do Until intCtr = dsState.Tables(0).Rows.Count
                cboState.Items.Add(New cboItem(dsState.Tables(0).Rows(intCtr).Item("PROVSTATE_NAME"), dsState.Tables(0).Rows(intCtr).Item("PROVSTATE_ABBR")))
                intCtr += 1
            Loop
        Else
            MsgBox("Error reading from table State_Prov", MsgBoxStyle.Critical, "DB Error")
        End If

        cboState.SelectedIndex = 0
        dsState.Dispose()
    End Sub

    Public Class cboItem
        Private strDisplayMember As String
        Private strValueMember As String

        Public Sub New()

            strDisplayMember = ""
            strValueMember = ""
        End Sub
        Public Sub New(ByVal DisplayMember As String, ByVal ValueMember As String)
            strDisplayMember = DisplayMember
            strValueMember = ValueMember
        End Sub
        Public Property DisplayMember() As String
            Get
                Return strDisplayMember
            End Get
            Set(ByVal sValue As String)
                strDisplayMember = sValue
            End Set
        End Property
        Public Property ValueMember() As String
            Get
                Return strValueMember
            End Get
            Set(ByVal sValue As String)
                strValueMember = sValue
            End Set
        End Property
        Public Overrides Function ToString() As String
            Return strDisplayMember
        End Function
    End Class

    Public Function fctCustomerExists(ByVal strCustID As String) As String
        Dim strCustExists As String = "NO"
        Dim strSQL As String
        Dim dsFindCust As New DataSet

        strSQL = "SELECT CUST_ID " & _
                    "FROM CUSTOMER_BILL_TO " & _
                    "WHERE CUST_ID = '" & UCase(strCustID) & "'"


        dsFindCust = fctGetDataSet(strSQL)

        If dsFindCust.Tables(0).Rows.Count = 1 Then
            dsFindCust.Dispose()
            Return "YES"
        Else
            dsFindCust.Dispose()
            Return "NO"
        End If
    End Function

    Public Sub subCheckSecurity(ByVal strApp As String, ByRef intSecLevel As Integer)
        Dim strSQL As String
        Dim dsSecurity As New DataSet
        strSQL = "SELECT USER_ID, SEC_APP, SEC_LEVEL " & _
                      "FROM SECURITY " & _
                      "WHERE SEC_APP = '" & strApp & "' AND " & _
                            "USER_ID = '" & gstrUserID & "'"

        dsSecurity = fctGetDataSet(strSQL)

        If dsSecurity.Tables(0).Rows.Count > 0 Then
            intSecLevel = dsSecurity.Tables(0).Rows(0).Item("SEC_LEVEL")
        End If

        dsSecurity.Dispose()
    End Sub

    Public Sub subSaveImage(ByVal strImageType As String, ByVal strSaveID As String, ByVal strImagePath As String)

        Dim strSQL As String
        Dim intPathCtr As Integer = 1
        Dim dsID As New DataSet
        Dim dsImageRoot As New DataSet
        Dim intBaseImageCtr As Integer
        Dim bolInsertStatus As Boolean
        Dim strFilePath As String

        '- Check if root folder exists -'
        strSQL = "SELECT APP_NAME, DEFAULT_PATH " & _
                                     "FROM SETUP_PATHS " & _
                                     "WHERE APP_NAME = 'IMAGE'"

        dsImageRoot = fctGetDataSet(strSQL)

        If dsImageRoot.Tables(0).Rows.Count = 1 Then
            If Not System.IO.Directory.Exists(dsImageRoot.Tables(0).Rows(0).Item("DEFAULT_PATH") & "\" & strImageType & strSaveID) Then
                Directory.CreateDirectory(dsImageRoot.Tables(0).Rows(0).Item("DEFAULT_PATH") & "\" & strImageType & strSaveID)
            End If
        Else
            MsgBox("Please create a default image path first!", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        '- Get unique image id -'
        Try
            strSQL = "SELECT ID_VALUE FROM AUTO_GENERATE WHERE ID_NAME = 'IMAGE'"
            dsID = fctGetDataSet(strSQL)
            If dsID.Tables(0).Rows.Count > 0 Then
                If dsID.Tables(0).Rows(0).Item("ID_VALUE") <= 0 Then
                    intBaseImageCtr = 1
                Else
                    intBaseImageCtr = dsID.Tables(0).Rows(0).Item("ID_VALUE") + 1
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString & " Error getting ID_VALUE")
        End Try


        '- Copy the specified file to the computer -'
        Try
            strFilePath = dsImageRoot.Tables(0).Rows(0).Item("DEFAULT_PATH") & "\" & strImageType & strSaveID & "\" & intBaseImageCtr & "_" & Mid(strImagePath, strImagePath.LastIndexOf("\") + 2)
            File.Copy(strImagePath, strFilePath, True)
        Catch ex As Exception
            MsgBox(ex.ToString & ControlChars.NewLine & strFilePath & " File copy error")
        End Try


        '- MySQL used the "\" as an escape character so we need to double qualify it -'
        strFilePath = strFilePath.Replace("\", "\\")
        '- Write the path out to the database -'
        Try
            Dim strUniqueID As String = intBaseImageCtr & "_" & strSaveID
            strSQL = "INSERT INTO IMAGES(ID, IMAGE_PATH, WORK_ORDER_ID) VALUES('" & strUniqueID & "' , '" & strFilePath & "', '" & strSaveID & "')"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
            If bolInsertStatus = False Then
                MsgBox("An error occured while saving the image!", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("Error inserting image path into database")
        End Try


        Try
            strSQL = "UPDATE AUTO_GENERATE SET ID_VALUE = '" & intBaseImageCtr & "' WHERE ID_NAME = 'IMAGE'"
            bolInsertStatus = fctInsertOrUpdateIntoDB(strSQL)
            If bolInsertStatus = False Then
                MsgBox("An error occured updating table AUTO_GENERATE with a new intBaseImageCtr!", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("Error updating auto_generate")
        End Try
    End Sub


    Public Sub subPositionFormOnScreen(ByVal strPositionAction As String, ByVal frmFormToPosition As Form)
        Dim intFormLocationX As Integer
        Dim intFormLocationY As Integer
        Dim intFormWidth As Integer
        Dim intFormHeight As Integer
        Dim intScreenResolutionX As Integer
        Dim intScreenResolutionY As Integer
        Dim scrScreens() As System.Windows.Forms.Screen = System.Windows.Forms.Screen.AllScreens
        Dim intUpperBound As Integer
        Dim intScreenIndex As Integer

        '---- For Multiple Monitors - Sum total screen width for total screen width ----
        intUpperBound = scrScreens.GetUpperBound(0)
        For intScreenIndex = 0 To intUpperBound
            intScreenResolutionX = intScreenResolutionX + scrScreens(intScreenIndex).Bounds.Width
        Next
        '---- Get Screen Resolution for height ----
        intScreenResolutionY = Screen.PrimaryScreen.Bounds.Height


        If strPositionAction = "MoveToLastPosition" Then
            '---- Set Form Location (after retrieving previous location saved in registry) ----
            Try
                intFormLocationX = GetSetting(Mid(System.Windows.Forms.Application.ExecutablePath, InStrRev(System.Windows.Forms.Application.ExecutablePath, "\") + 1), frmFormToPosition.Name.ToString(), "FormLocationX")
                intFormLocationY = GetSetting(Mid(System.Windows.Forms.Application.ExecutablePath, InStrRev(System.Windows.Forms.Application.ExecutablePath, "\") + 1), frmFormToPosition.Name.ToString(), "FormLocationY")
                intFormWidth = GetSetting(Mid(System.Windows.Forms.Application.ExecutablePath, InStrRev(System.Windows.Forms.Application.ExecutablePath, "\") + 1), frmFormToPosition.Name.ToString(), "FormWidth")
                intFormHeight = GetSetting(Mid(System.Windows.Forms.Application.ExecutablePath, InStrRev(System.Windows.Forms.Application.ExecutablePath, "\") + 1), frmFormToPosition.Name.ToString(), "FormHeight")
            Catch ex As Exception
                SaveSetting(Mid(System.Windows.Forms.Application.ExecutablePath, InStrRev(System.Windows.Forms.Application.ExecutablePath, "\") + 1), frmFormToPosition.Name.ToString(), "FormLocationX", 1)
                SaveSetting(Mid(System.Windows.Forms.Application.ExecutablePath, InStrRev(System.Windows.Forms.Application.ExecutablePath, "\") + 1), frmFormToPosition.Name.ToString(), "FormLocationY", 1)

                intFormLocationX = 1
                intFormLocationY = 1
            End Try
            '---- Adjust for missing multiple monitors (Remote Desktop or Hardware Change) ----
            If intFormLocationX + frmFormToPosition.Size.Width > intScreenResolutionX Then
                intFormLocationX = intScreenResolutionX - frmFormToPosition.Size.Width
            End If
            '---- Adjust for people closing from off bottom of screen ----
            If intFormLocationY + frmFormToPosition.Size.Height > intScreenResolutionY Then
                intFormLocationY = intScreenResolutionY - frmFormToPosition.Size.Height
            End If

            frmFormToPosition.Left = intFormLocationX
            frmFormToPosition.Top = intFormLocationY
            If intFormWidth > 0 Then
                frmFormToPosition.Width = intFormWidth
                frmFormToPosition.Height = intFormHeight
            End If

        ElseIf strPositionAction = "SavePosition" Then
            '---- Save Setting on Form Closing ----
            Dim intFormX As Integer = frmFormToPosition.Location.X
            Dim intFormY As Integer = frmFormToPosition.Location.Y

            Dim intFormSizeWidth As Integer
            Dim intFormSizeHeight As Integer

            '---- Adjust for form size if closing forms while minimized or too small ----

            If frmFormToPosition.Height < 100 Then
                If frmFormToPosition.MinimumSize.Height > 0 Then
                    intFormSizeHeight = frmFormToPosition.MinimumSize.Height
                Else
                    intFormSizeHeight = 600
                End If
            Else
                intFormSizeHeight = frmFormToPosition.Height
            End If
            If frmFormToPosition.Width < 100 Then
                If frmFormToPosition.MinimumSize.Width > 0 Then
                    intFormSizeWidth = frmFormToPosition.MinimumSize.Width
                Else
                    intFormSizeWidth = 800
                End If
            Else
                intFormSizeWidth = frmFormToPosition.Width
            End If


            '---- Move starting positions back onto visible screen ----
            If intFormX <= 0 Then
                intFormX = 1
            End If
            If intFormY <= 0 Then
                intFormY = 1
            End If

            '---- Write settings to registry ----
            SaveSetting(Mid(System.Windows.Forms.Application.ExecutablePath, InStrRev(System.Windows.Forms.Application.ExecutablePath, "\") + 1), frmFormToPosition.Name.ToString(), "FormLocationX", intFormX)
            SaveSetting(Mid(System.Windows.Forms.Application.ExecutablePath, InStrRev(System.Windows.Forms.Application.ExecutablePath, "\") + 1), frmFormToPosition.Name.ToString(), "FormLocationY", intFormY)
            SaveSetting(Mid(System.Windows.Forms.Application.ExecutablePath, InStrRev(System.Windows.Forms.Application.ExecutablePath, "\") + 1), frmFormToPosition.Name.ToString(), "FormWidth", intFormSizeWidth)
            SaveSetting(Mid(System.Windows.Forms.Application.ExecutablePath, InStrRev(System.Windows.Forms.Application.ExecutablePath, "\") + 1), frmFormToPosition.Name.ToString(), "FormHeight", intFormSizeHeight)
        End If
    End Sub
End Module
