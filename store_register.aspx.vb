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
Imports BusinessLayer.Constants

Partial Class store_register
    Inherits System.Web.UI.Page

  

    Sub Page_Load(ByVal Source As Object, ByVal E As EventArgs) Handles MyBase.Load
        Try

           If Not IsPostBack Then
                loadCountrycmb(dd_country)
            End If

        Catch ex As Exception

        End Try
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





    Public Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
	
	 If Page.IsValid Then
            Try
                Dim strdata As str_store
                Dim conobj As clsCon
                Dim Dbobject As New BusinessLayer.DBClass
                Dim mydscat As New DataSet
                conobj = Session("con")
                Dbobject.Connectionstring = conobj.Connectionstring
				
				
                
                With strdata
					
                    .Querytype = 3
                  .s_name=txtname.Text
				   .s_address=txtAddress.Text
				   .s_city=dd_city.SelectedValue
				   .state_id=dd_state.SelectedValue
				   .country_id=dd_country.SelectedValue
				   .s_zip=txtzip.Text
				   .s_phone=txtphone.Text
				   .s_email=txtemail.Text
				   .s_website=txtwebsite.Text
				   .s_contact= txtcontact.Text
				   .map_link=txtmap.Text
				   .cust_id=session("custid")
				   .s_desc=txtdesc.Text
				  
				  
				

					
					Dim id as String
					Dim custpic as string=""
					id=Getmaxid()
					If Not (FImgThumb.PostedFile Is Nothing) Then
					 If FImgThumb.Value <> "" Then
					 
         			custpic=uploadFile("store_file_" & id, FImgThumb)
						
           
      				 End If
					 if custpic="" then
					   lblWarning.Text = "Only .gif or .jpg or png file are allowed"
					  
					  Else
					  	.s_image=custpic
					  End If
				End If
					
                  
                End With
				Dbobject.Connect()
                mydscat = Dbobject.Sp_store(strdata, 2, "store")

                Dbobject.close()

lblWarning.Text="Store Registered Successfully and email sent to all the Customers with your details"

Dim bdy as String

bdy="<table width=""600"" border='0' cellspacing='0' cellpadding='0'  style=' background-color:White'>" & _
"<tr><td><h1   style='background: #26618d;border-bottom: 1px solid #fff; border-top: 2px solid #fff;margin-bottom: 1px;'><a href='#'>" & _
"<img src='http://www.japan-indians.com/images/Japan-Indianslogo.gif' width='257' height='96' alt='Japan Indians/ICE Indians'  /></a></h1></td></tr>" & _
"<tr><td align='center'>" & _
"<table width='80%' border='1' bordercolor='lightblue' cellspacing='1' cellpadding='2'  class='main'  >" & _
 " <tr>" & _
  "  <td colspan='2' align='center' bgcolor='lightblue'><b><font color='#000000'>New Store/Service Registered </font></b></td>" & _
  "</tr>" & _
  "<tr>" & _
   " <td colspan='2' align='center'>&nbsp;</td>" & _
  "</tr>" & _
  "<tr>" & _
   " <td width='50%' align='right'><strong>Name:<font style='color: red;'> *</font></strong></td>" & _
    "<td  align='left' width='50%'>" & txtname.Text & "&nbsp;" & _
     "<asp:RequiredFieldValidator ID='RequiredFieldValidator2' runat='server' ControlToValidate='txtname' ErrorMessage='Enter Store Name'></asp:RequiredFieldValidator></td>" & _
 " </tr>  " & _
"  <tr>" & _
 "   <td width='50%' align='right'><strong>Description:</strong></td>" & _
  "  <td  align='left' width='50%'>" & txtdesc.Text & "nbsp;" & _
 "   </td>" & _
  "</tr>" & _
  "<tr >" & _
   " <td align='right'><strong>Address:<font style='color: red;'> *</font></strong></td>" & _
    "<td align='left' >" & txtaddress.Text & _
 "   </td>" & _
  "</tr>  " & _
"  <tr >" & _
 "   <td align='right'><strong>Country:</strong></td>" & _
"  <td align='left' >" & dd_country.SelectedItem.Text  & _
   " </td>" & _
"  </tr>" & _
 " <tr >" & _
    "<td align='right'><strong>State:<font style='color: red;'> *</font></strong></td>" & _
    "<td align='left' >" & dd_state.SelectedItem.Text & _
    "</td>" & _
"  </tr>" & _
 " <tr >" & _
"    <td align='right'><strong>City:<font style='color: red;'> *</font></strong></td>" & _
   " <td align='left' >" & dd_city.SelectedItem.Text & _    
"    </td>" & _
"  </tr>" & _
  "  <tr >" & _
"    <td align='right'><strong>Zip:<font style='color: red;'> *</font></strong></td>" & _
"    <td align='left' >" & txtzip.Text & _     
"               </td>" & _
"  </tr>" & _
"  <tr >" & _
"    <td align='right'><strong>Phone:<font style='color: red;'> *</font></strong></td>" & _
"    <td align='left' >" & txtphone.Text & _
     "    </td>" & _
"  </tr>" & _
"  <tr >" & _
"    <td align='right'> <strong>Email:<font style='color: red;'> *</font></strong></td>" & _
"    <td align='left' >" & txtemail.Text & _
"    </td>" & _
"  </tr>" & _
"  <tr >" & _
"    <td align='right'><strong>Contact:</strong></td>" & _
"    <td align='left' >" & txtcontact.Text & _
"    </td>" & _
"  </tr>" & _
"  <tr >" & _
"    <td align='right'><strong>Website:</strong></td>" & _
"    <td align='left' >" & txtwebsite.Text & _
"    </td>" & _
"  </tr>" & _
  "   <tr >" & _
"    <td align='right'><strong>Google Map Link:</strong></td>" & _
"    <td align='left' >" & txtmap.Text & _
"    </td>" & _
"  </tr>" & _  
"  <tr>" & _
"    <td colspan='2'>&nbsp;</td>" & _
"  </tr>" & _
"</table>" & _
"</td></tr>" & _
"</table>"



			
				Dim emails as string
 Dim message As New SendMail
 
  Dim cons As New BusinessLayer.Constants
  
 emails=cons.GetEmails(conobj)

   message.MailSend(emails, "info@japan-indians.com", "Japan Indians - A new Store/Service has been registered.", bdy)
   
  ' Response.write(emails)
clearall()

            Catch ex As Exception
                Response.Write(ex.ToString())

            End Try
        End If

    End Sub
	
	
	 Public Function uploadFile(ByVal name As String, ByVal Fle As Object) As String
        Try
            Dim str1, ext As String
            Dim flext As String
            Dim flength As Long
            flength = 1048576
            flext = LCase(Path.GetExtension(Fle.Value))
          
            If (flext = ".gif") Or (flext = ".jpg") Or (flext = ".png") Then
					flext = LCase(Path.GetExtension(Fle.Value))
					
					Dim myFile As HttpPostedFile = Fle.PostedFile
					If Not (Fle.PostedFile Is Nothing) Then
						' If myFile.ContentLength Then
						str1 = Server.MapPath(".") & "\storeimages\" & name & flext
						Fle.PostedFile.SaveAs(str1)
						Return  name & flext
					Else
						Return ""
						'End If
					End If
			else
				Return ""
			End If
            ' Else
            'lblWarning.Visible = True
            ' lblWarning.Text = "Only .gif or .jpg file are allowed"
            ' Return False
            'End If
        Catch ex As Exception
            ' lblWarning.Text = "Problem with uploading " & ex.ToString

            Response.Write("Problem with uploading " & ex.ToString)
        End Try
    End Function



	
	Public Function Getmaxid() as Int32
	
	

                Dim strdata As str_store
                Dim conobj As clsCon
                Dim Dbobject As New BusinessLayer.DBClass
                Dim mydscat As New DataSet
                conobj = Session("con")
                Dbobject.Connectionstring = conobj.Connectionstring
                Dbobject.Connect()
                With strdata
                    .Querytype = 4
                   
                End With
                mydscat = Dbobject.Sp_store(strdata, 2, "store")

                Dbobject.close()

                Dim maxid As Integer = 1
                If mydscat.Tables(0).Rows.Count > 0 Then
					if Not IsDBNull(mydscat.Tables(0).Rows(0).Item(0)) Then
					   maxid = mydscat.Tables(0).Rows(0).Item(0)
					 End if
					 
				End If
				 
				 Return maxid
                
	End Function
	
    Public Sub clearall()
    txtname.Text=""
				   txtAddress.Text=""
				  
				 txtzip.Text=""
				   txtphone.Text=""
				   txtemail.Text=""
				   txtwebsite.Text=""
				    txtcontact.Text=""
				   txtmap.Text=""
				   
				   txtdesc.Text=""
				  
		
		
    End Sub

    Protected Sub btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Response.Redirect("Findstore.aspx")
    End Sub
End Class
