
Partial Class PWIP_MasterPage
    Inherits System.Web.UI.MasterPage
	
		  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
			   If Not IsNothing(Session("custname")) Then
					lblWelcomemsg.Text="Welcome Mr/Mrs. " & Session("custname")
					lblMyprod.Text="My Products"
					lblMyprod.NavigateUrl="findprod.aspx?custid=" & Session("custid") 
					lblLogout.Text="Logout"
					lblLogout.NavigateUrl="Logout.aspx"
				End If
		  End sub
	
End Class

