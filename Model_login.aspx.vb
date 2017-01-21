Imports System.Web
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports BusinessLayer.Struclass
Imports BusinessLayer.DBClass
Imports ConnectionServices
Partial Class pwip_Model_login
    Inherits System.Web.UI.Page
	
	
	
	  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
		
      
        Dim strdata As str_Customers
        Dim conobj As clsCon
        Dim custname As String = ""
        Dim Dbobject As New BusinessLayer.DBClass
        Dim mydscat As New DataSet


        conobj = Session("con")
        Dbobject.Connectionstring = conobj.Connectionstring
        Dbobject.Connect()
        With strdata
            ' .Querytype = 2
            ' .site_id = Request.QueryString("tv_id")

            '.model_id = 1
            .Cust_email = Request("txtusername")
            .Cust_password = Request("txtpassword")
            .Querytype = 7



        End With
        mydscat = Dbobject.Sp_Customers(strdata, 2, "Customers")

        If mydscat.Tables(0).Rows.Count > 0 Then
            'If mydscat.Tables(0).Rows(0).Item("model_status") = False Then
            '    lblmsg.Text = "Your Account is Inactive.Please Wait while we process your Account."
            '    Exit Sub
            'Else
            Session("custid") = mydscat.Tables(0).Rows(0).Item("Cust_id")
			Session("custname")=mydscat.Tables(0).Rows(0).Item("Cust_name")
			session("custaddress")=mydscat.Tables(0).Rows(0).Item("Cust_Address")
			session("custcountry")=mydscat.Tables(0).Rows(0).Item("Cust_Country")
			session("custcity")=mydscat.Tables(0).Rows(0).Item("Cust_City")
			session("custstate")=mydscat.Tables(0).Rows(0).Item("Cust_State")
			session("custemail")=mydscat.Tables(0).Rows(0).Item("Cust_email")
			session("custmobile")=mydscat.Tables(0).Rows(0).Item("Cust_CellNumber")
            Response.Redirect("FindProd.aspx")
            'End If
        Else
		
'lblmsg.Visible=True
 '           lblmsg.Text = "Invalid Username/Password"
        End If
        Dbobject.close()
    End Sub

    Protected Sub btn_submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_submit.Click
	

		
        If Not IsNothing(Session("custid")) Then
            Response.Redirect("findprod.aspx")
        End If

        Dim strdata As str_Customers
        Dim conobj As clsCon
        Dim custname As String = ""
        Dim Dbobject As New BusinessLayer.DBClass
        Dim mydscat As New DataSet


        conobj = Session("con")
        Dbobject.Connectionstring = conobj.Connectionstring
        Dbobject.Connect()
        With strdata
            
            .Cust_email = txt_username.Text
            .Cust_password = txt_password.Text
            .Querytype = 7



        End With
        mydscat = Dbobject.Sp_Customers(strdata, 2, "Customers")

        If mydscat.Tables(0).Rows.Count > 0 Then
            'If mydscat.Tables(0).Rows(0).Item("model_status") = False Then
            '    lblmsg.Text = "Your Account is Inactive.Please Wait while we process your Account."
            '    Exit Sub
            'Else
            Session("custid") = mydscat.Tables(0).Rows(0).Item("Cust_id")
				Session("custname")=mydscat.Tables(0).Rows(0).Item("Cust_name")
				if not ISNOTHING(Session("redirectpage")) then
				 Response.Redirect(Session("redirectpage"))
				else
            Response.Redirect("findprod.aspx")
			
			End if
            'End If
        Else
		lblmsg.Visible=True
            lblmsg.Text = "Invalid Username/Password"
        End If
        Dbobject.close()


    End Sub
End Class
