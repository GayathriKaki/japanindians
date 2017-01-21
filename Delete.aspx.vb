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
	''' Summary description for Delete.
	''' </summary>
	Public Class Delete
		Inherits System.Web.UI.Page
		Private articleid As Integer = 0
		Private commentid As Integer = 0

		Private Sub Page_Load(sender As Object, e As System.EventArgs)
			' Put user code to initialize the page here
			If Request.QueryString("id") IsNot Nothing Then
				articleid = Convert.ToInt32(Request.QueryString("id"))
			End If

			If Request.QueryString("CId") IsNot Nothing Then
				commentid = Convert.ToInt32(Request.QueryString("CId"))
			End If


			Try


				Dim [myclass] As New clsDataAccess()
				[myclass].openConnection()
				Dim myReturn As [Boolean] = [myclass].DeleteForumData(articleid, commentid)
				[myclass].closeConnection()

				Response.Redirect("Forum.aspx?id=" & articleid)
			Catch generatedExceptionName As Exception

				Response.Write("<h2> Unexpected error ! Try slamming your head into your computer monitor :)</h2>")
			End Try


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
			AddHandler Me.Load, New System.EventHandler(AddressOf Me.Page_Load)
		End Sub
		#End Region
	End Class
End Namespace