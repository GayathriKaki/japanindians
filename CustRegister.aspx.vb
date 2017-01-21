Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports BusinessLayer.Struclass
Imports BusinessLayer.DBClass
Imports ConnectionServices
Imports SendMail
Imports System.IO

#Region "Page comments"
'Created By                   Created for                           Created on 
'support.itc.worldwide       Wedding Album,Cust registraton        Jun 8,2009
#End Region

Partial Class CustRegister
    Inherits System.Web.UI.Page
	
	
	  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	  If Not IsPostBack Then
	  loadCountrycmb(dd_country)
	  End If
       
	   End Sub

 Public Sub loadCountrycmb(ByVal cmb As DropDownList)
        Dim strdata As Str_Country
        Dim conobj As clsCon
        Dim custname As String = ""
        Dim Dbobject As New BusinessLayer.DBClass
        Dim mydscat As New DataSet





        conobj = Session("con")
        Dbobject.Connectionstring = conobj.Connectionstring
        Dbobject.Connect()
        With strdata
            .querytype = 1
           

        End With
        mydscat = Dbobject.Sp_Country(strdata, 2, "Country")

      
        Dbobject.close()

        cmb.DataSource = mydscat.Tables(0).DefaultView
        cmb.DataTextField = "Country"
        cmb.DataValueField = "Country_id"
        cmb.DataBind()
        cmb.SelectedIndex = -1

ddCountry_click(1,dd_state)
    End Sub


Public Sub ddCountry_click(ByVal cid AS Int32,ByVal cmb As DropDownList)
  Dim strdata As Str_Country
        Dim conobj As clsCon
        Dim custname As String = ""
        Dim Dbobject As New BusinessLayer.DBClass
        Dim mydscat As New DataSet





        conobj = Session("con")
        Dbobject.Connectionstring = conobj.Connectionstring
        Dbobject.Connect()
        With strdata
            .querytype = 5
			.Country_id=cid
           

        End With
        mydscat = Dbobject.Sp_Country(strdata, 2, "Country")

      
        Dbobject.close()

        cmb.DataSource = mydscat.Tables(0).DefaultView
        cmb.DataTextField = "State_name"
        cmb.DataValueField = "State_id"
        cmb.DataBind()
        cmb.SelectedIndex = -1

End Sub
Public Sub State_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dd_State.SelectedIndexChanged
 Dim strdata As Str_State
        Dim conobj As clsCon
        Dim custname As String = ""
        Dim Dbobject As New BusinessLayer.DBClass
        Dim mydscat As New DataSet





        conobj = Session("con")
        Dbobject.Connectionstring = conobj.Connectionstring
        Dbobject.Connect()
        With strdata
            .querytype = 2
			.State_id=dd_state.SelectedValue
       
        End With
        mydscat = Dbobject.Sp_State(strdata, 2, "State")

      
        Dbobject.close()

        dd_City.DataSource = mydscat.Tables(0).DefaultView
        dd_City.DataTextField = "City_name"
        dd_City.DataValueField = "City_id"
        dd_City.DataBind()
        dd_City.SelectedIndex = -1


End Sub

    Protected Sub btn_submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_submit.Click
        If Page.IsValid Then
            Try
                Dim strdata As str_customers
                Dim conobj As clsCon
                Dim Dbobject As New BusinessLayer.DBClass
                Dim mydscat As New DataSet
                conobj = Session("con")
                Dbobject.Connectionstring = conobj.Connectionstring
                
                With strdata
					
                    .Querytype = 4
                    .Cust_name = txt_username.Text
                    .cust_password = txt_password.Text
                    .cust_email = txt_email.Text
                    .cust_country = dd_country.SelectedValue
                    .cust_city = dd_city.SelectedValue
					.Cust_state=dd_state.SelectedValue
					.Cust_address=txt_address.Text
					.Cust_cellNumber=txt_mobile.Text
					
					Dim id as String
					Dim custpic as string=""
					id=Getmaxid()
					 If photo5.Value <> "" Then
					 
         			custpic=uploadFile("Cust_file_" & id, photo5)
						
           
      				 End If
					 if custpic="Not OK" then
					   lblWarning.Text = "Only .gif or .jpg file are allowed"
					  Exit Sub
					  Else
					  	.Cust_picture=custpic
					  End If
				
					
                  
                End With
				Dbobject.Connect()
                mydscat = Dbobject.Sp_customers(strdata, 2, "wa_customers")

                Dbobject.close()
				
 Dim message As New SendMail
				
				Dim clientbody as String=""

               clientbody = "<table width='80%' align='center' border='0' cellspacing='1' cellpadding='1' style='background-color:#CFCEBC'>" & _
			    "<tr ><td colspan='2' align='center'>Registration to the site Japan-Indians.com is Successfull </td></tr>" & _
         "<tr ><td colspan='2' align='center'><a href='http://www.japan-indians.com/index.html'>Click Here to visit the site </a></td></tr>" & _
         "<tr style='background-color:#ffffff'><td colspan='2' align='center'> <br>Hi, <br> &nbsp;&nbsp;&nbsp;&nbsp;Here are your Login Details for the site Japan-Indians.com.</td>" & _
         "</tr><tr style='background-color:#ffffff'><td colspan='2'>&nbsp;</td></tr><tr style='background-color:#ffffff'><td align='right'>User ID : &nbsp;&nbsp; </td>" & _
           "<td>&nbsp;&nbsp;" & txt_email.Text & "</td></tr><tr style='background-color:#ffffff'> <td align='right'>Password :&nbsp;&nbsp; </td><td>&nbsp;&nbsp;" & txt_password.Text & "</td>" & _
        "<tr style='background-color:#ffffff'> <td colspan='2'>Regards,<br>Japan Indians Team.</td></tr></table>"

  message.MailSend(txt_email.Text.trim(), "info@japan-indians.com", "Japan Indians  Login Credentials", clientbody)
 
 'Response.write(clientbody)
lblwarning.text="Customer Registered Successfully"


Clearall()
               ' Response.Redirect("cust_wed_details.aspx?id=" & custid)


            Catch ex As Exception
                Response.Write(ex.ToString())

            End Try
        End If

    End Sub
	
	public sub Clearall()
	txt_username.Text=""
	dd_city.SelectedIndex=-1
	dd_state.SelectedIndex=-1
	txt_mobile.text=""
	
	txt_address.Text=""
	txt_email.Text=""
	
	txt_password.Text=""
	End Sub
	
	Public Function Getmaxid() as Int32
	
	

                Dim strdata As str_customers
                Dim conobj As clsCon
                Dim Dbobject As New BusinessLayer.DBClass
                Dim mydscat As New DataSet
                conobj = Session("con")
                Dbobject.Connectionstring = conobj.Connectionstring
                Dbobject.Connect()
                With strdata
				
			

	
	
	
	
                    .Querytype = 6
                   
                End With
                mydscat = Dbobject.Sp_customers(strdata, 2, "wa_customers")

                Dbobject.close()

                Dim maxid As Integer = 1
                If mydscat.Tables(0).Rows.Count > 0 Then
					if Not IsDBNull(mydscat.Tables(0).Rows(0).Item(0)) Then
					   maxid = mydscat.Tables(0).Rows(0).Item(0)
					 End if
					 
				End If
				 
				 Return maxid
                
	End Function
	
	 Public Function uploadFile(ByVal name As String, ByVal Fle As Object) As String
        Try
		If Not (Fle.PostedFile Is Nothing) Then
            Dim str1, ext As String
            Dim flext As String
            Dim flength As Long
            flength = 1048576
            flext = LCase(Path.GetExtension(Fle.Value))
            'If (flext = ".gif") Or (flext = ".jpg") Then
            flext = LCase(Path.GetExtension(Fle.Value))
            If flext = ".gif" Then
                ext = ".gif"
            ElseIf flext = ".jpg" Then
                ext = ".jpg"
            End If
			if (Lcase(flext)=".gif" or Lcase(flext)=".jpg" or Lcase(flext)=".jpeg") Then
			
           		Dim myFile As HttpPostedFile = Fle.PostedFile
				
					' If myFile.ContentLength Then
					str1 = Server.MapPath(".") & "\Pictures\" & name & flext
					Fle.PostedFile.SaveAs(str1)
					Return  name & flext
				
            Else
                Return "Not OK"
                'End If
            End If
            ' Else
            'lblWarning.Visible = True
            ' lblWarning.Text = "Only .gif or .jpg file are allowed"
            ' Return False
            'End If
			Else
			
			Return "OK"
			End IF
			
        Catch ex As Exception
            ' lblWarning.Text = "Problem with uploading " & ex.ToString

            Response.Write("Problem with uploading " & ex.ToString)
        End Try
    End Function



End Class
