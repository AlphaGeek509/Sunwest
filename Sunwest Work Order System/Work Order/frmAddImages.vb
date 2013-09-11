Imports System.IO


Public Class frmAddImages
    Dim txtPath(10) As TextBox
    Dim strInitalDirectory As String = "C:\Documents and Settings\" & Environment.UserName & "\Desktop\"

    Private Sub BrowsePage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button10.Click
        Dim fsdImage As New OpenFileDialog
        Dim msgResult As MsgBoxResult

        Dim btnCaller As Button = CType(sender, Button)

        fsdImage.InitialDirectory = strInitalDirectory
        fsdImage.DefaultExt = "All Files|*.*"

        msgResult = fsdImage.ShowDialog()
        If msgResult = MsgBoxResult.Ok Then
            Dim intIndex As Integer = btnCaller.Tag
            txtPath(intIndex).Text = fsdImage.FileName

            strInitalDirectory = Mid(txtPath(intIndex).Text, 1, txtPath(intIndex).Text.LastIndexOf("\") + 1)
        End If
    End Sub

    Private Sub frmAddImages_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'subPositionFormOnScreen("SavePosition", Me)
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

        'subPositionFormOnScreen("MoveToLastPosition", Me)
    End Sub

    Public Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim intPathCtr As Integer = 1
        Dim dsID As New DataSet
        Dim dsImageRoot As New DataSet
        Dim strImageType As String



        If lblImageType.Text = "TEMPLATE" Then
            strImageType = "TEMPLATE\"
        Else
            strImageType = ""
        End If

        Do Until intPathCtr = 11
            If Len(txtPath(intPathCtr).Text) > 0 Then
                subSaveImage(strImageType, lblSaveID.Text, txtPath(intPathCtr).Text)
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