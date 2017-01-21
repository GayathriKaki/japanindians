' *************************************************
' * Author: Rajesh Lal(connectrajesh@hotmail.com)
' * Date: 12/14/06
' * Company Info: www.irajesh.com
' * See EULA.txt and Copyright.txt for additional information
' * *************************************************

Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Configuration
Namespace JumpyForum
	''' <summary>
	''' Summary description for NewMessage.
	''' </summary>
	Public Class NewMessage
		Inherits System.Web.UI.Page
		'Protected Button1 As System.Web.UI.WebControls.Button
'		Protected RequiredFieldValidator3 As System.Web.UI.WebControls.RequiredFieldValidator
'		Protected RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
'		Protected RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
'		Protected Form1 As System.Web.UI.HtmlControls.HtmlForm
		Private commentid As Integer = 1
		'Protected lblStatus As System.Web.UI.WebControls.Label
'		Protected Button2 As System.Web.UI.WebControls.Button
'		Protected Requiredfieldvalidator4 As System.Web.UI.WebControls.RequiredFieldValidator
'		Protected txtname As System.Web.UI.WebControls.TextBox
'		Protected txtemail As System.Web.UI.WebControls.TextBox
'		Protected txtcomment As System.Web.UI.WebControls.TextBox
'		Protected txtsubject As System.Web.UI.WebControls.TextBox
'		Protected txtProfile As System.Web.UI.WebControls.TextBox
'		Protected MsgType_4 As System.Web.UI.HtmlControls.HtmlInputRadioButton
'		Protected MsgType_1 As System.Web.UI.HtmlControls.HtmlInputRadioButton
'		Protected MsgType_2 As System.Web.UI.HtmlControls.HtmlInputRadioButton
'		Protected MsgType_5 As System.Web.UI.HtmlControls.HtmlInputRadioButton
		Private articleid As Integer = 1

		Private Sub Page_Load(sender As Object, e As System.EventArgs)
			' Put user code to initialize the page here

			If Request.QueryString("id") IsNot Nothing Then
				articleid = Convert.ToInt32(Request.QueryString("id"))
			End If

			If Request.QueryString("Test") IsNot Nothing Then
				If [String].Compare(Request.QueryString("Test").ToLower(), "true") = 0 Then
					Dim mParentId As Integer = 0
					Dim mArticleId As Integer = articleid
					Dim mTitle As String = "Test Message - This Forum Rocks"
					Dim mUserName As String = "quartz"
					Dim mUserEmail As String = "quartz@msn.com"
					Dim mDescription As String = "Original Message - Test Description"
					Dim mIndent As Integer = 0

					Try
						Dim myC As New SqlConnection()
						myC.ConnectionString = ConfigurationSettings.AppSettings("ConnectionString")
						Dim sqlQuery As String = "INSERT into " & ConfigurationSettings.AppSettings("CommentTable") & "(ParentId,ArticleId,Title,UserName,UserEmail,Description,Indent,UserProfile) VALUES ('" & mParentId & "','" & mArticleId & "','" & mTitle & "','" & mUserName & "','" & mUserEmail & "','" & mDescription & "','" & mIndent & "','" &  Session("custid") & "')"
						myC.Open()
						Dim myCommand As New SqlCommand()
						myCommand.CommandText = sqlQuery
						myCommand.Connection = myC
						Dim i As Integer = myCommand.ExecuteNonQuery()
						myC.Close()
						lblStatus.ForeColor = Color.Green
						lblStatus.Text = "Status: Success"

						Response.Redirect("Forum.aspx?id=" & articleid)
					Catch generatedExceptionName As Exception

						lblStatus.ForeColor = Color.Red
						lblStatus.Text = "Status: Error"

					End Try
				End If
			End If

		End Sub
		Private Sub LoadComment()
		End Sub


		#Region "Web Form Designer generated code"
		Protected Overrides Sub OnInit(e As EventArgs)
			'
			' CODEGEN: This call is required by the ASP.NET Web Form Designer.
			'
			InitializeComponent()
			MyBase.OnInit(e)
		End Sub

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			AddHandler Me.txtProfile.TextChanged, New System.EventHandler(AddressOf Me.txtProfile_TextChanged)
			AddHandler Me.Button1.Click, New System.EventHandler(AddressOf Me.Button1_Click)
			AddHandler Me.Button2.Click, New System.EventHandler(AddressOf Me.Button2_Click)
			AddHandler Me.MsgType_5.ServerChange, New System.EventHandler(AddressOf Me.MsgType_5_ServerChange)
			AddHandler Me.Load, New System.EventHandler(AddressOf Me.Page_Load)

		End Sub
		#End Region

		Private Sub Button1_Click(sender As Object, e As System.EventArgs)
			Dim mParentId As Integer = 0
			Dim mArticleId As Integer = articleid
			Dim mTitle As String = "Test"
			Dim mUserName As String = "quartz"
			Dim mUserEmail As String = "quartz@msn.com"
			Dim mDescription As String = "Test Description"
			Dim mIndent As Integer = 0
			Try
				mTitle = txtsubject.Text
				mUserName = txtname.Text
				mUserEmail = txtemail.Text
				mDescription = txtcomment.Text
				Dim mProfile As String = txtProfile.Text
				Dim mCommentType As Integer = 1

				If MsgType_2.Checked Then
					mCommentType = 2
				End If
				'if (MsgType_3.Checked) 
				'	mCommentType = 3;
				If MsgType_4.Checked Then
					mCommentType = 4
				End If
				If MsgType_5.Checked Then
					mCommentType = 5
				End If





				If IsValid Then
					Dim myC As New SqlConnection()
					myC.ConnectionString = ConfigurationSettings.AppSettings("ConnectionString")
					Dim sqlQuery As String = "INSERT into " & ConfigurationSettings.AppSettings("CommentTable") & "(ParentId,ArticleId,Title,UserName,UserEmail,Description,Indent,UserProfile,CommentType) VALUES ('" & mParentId & "','" & mArticleId & "','" & mTitle & "','" & mUserName & "','" & mUserEmail & "','" & mDescription & "','" & mIndent & "','" & mProfile & "','" & mCommentType & "')"
					myC.Open()
					Dim myCommand As New SqlCommand()
					myCommand.CommandText = sqlQuery
					myCommand.Connection = myC
					Dim i As Integer = myCommand.ExecuteNonQuery()
					myC.Close()
					lblStatus.ForeColor = Color.Green
					lblStatus.Text = "Status: Success"
					Response.Redirect("Forum.aspx?id=" & articleid)
				End If
			Catch generatedExceptionName As Exception

				lblStatus.ForeColor = Color.Red
				lblStatus.Text = "Status: Error"
			End Try
		End Sub

		Private Sub Button2_Click(sender As Object, e As System.EventArgs)
			Response.Redirect("Forum.aspx?id=" & articleid)
		End Sub

		Private Sub txtProfile_TextChanged(sender As Object, e As System.EventArgs)

		End Sub

		Private Sub MsgType_5_ServerChange(sender As Object, e As System.EventArgs)

		End Sub
	End Class
End Namespace