Imports System.Web
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient 
Partial Class Logout
    Inherits System.Web.UI.Page

	  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      Session("custid")=""
	  Session("custid")=Nothing
	  Session("redirectpage")=Nothing
	  Session("custname")=Nothing
	  
	  Response.Redirect("index.html")
	End Sub
End Class
