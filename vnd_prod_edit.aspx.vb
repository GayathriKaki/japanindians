Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports BusinessLayer.Struclass
Imports BusinessLayer.DBClass
Imports ConnectionServices
Imports System.IO
Partial Class pwip_vnd_prod_edit
    Inherits System.Web.UI.Page

   
   

   
   
public imageProd as string


    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Try

            Dim strFile1 As String = ""
         
		' Response.write("im=" & imageProd)
		 'response.end()
            Dim conobj As clsCon
            Dim Dbobject As New BusinessLayer.DBClass
            conobj = Session("con")
            Dbobject.Connectionstring = conobj.Connectionstring



            Dim product_id As Integer = 0

            Dim SelectedID As String = Request.QueryString("id")
            Dim dt As String = ""


          
		  

            Dim fld As String = ""
            Dim vals As String = ""
            Dim fl1 As Boolean
            Dim fl2 As Boolean
            'Dim fl3 As Boolean
            Dim maxid As Int32
            Dim dsattr As New DataSet
            Dim p As Integer

      maxid = getmaxid() + 1
          
		  
            strFile1 = ""




Dim strFile2 as String
          
		  
            If FImgLarge.Value <> "" Then
                fl2 = uploadFile("prodimg_large_" & maxid, FImgLarge)
                If fl2 Then
                    strFile2 = "prodimg_large_" & maxid & LCase(Path.GetExtension(FImgLarge.Value))
                End If

            End If


          
		  
                Dim strdata As str_prod

                Dim custname As String = ""

                Dim dsprod As New DataSet

                dsprod = Nothing

                With strdata
                    .cust_id = Session("custid")
					
					if Request.Querystring("id") <> "" then
					.prod_id=Request.Querystring("id")
					    .querytype = 9
					else
                    .querytype = 4
               		end if
				  
				        .prod_price = txtprice.Text
                   
				   



                    .prod_cat = cmbprodcat.SelectedValue
                   
				    .prod_desc = txtDesc.Text
					
					
                    If chkhide.Checked = True Then
                        .prod_hide = True
                    Else
                        .prod_hide = False

                    End If

                   if strFile2="" then
				  .prod_largeimage= lblLimg2.Text
				  else
				    .prod_largeimage = strFile2
					end if
					
					'response.write("img=" & .prod_largeimage)
                    ' .prod_magnifyimage = strFile3
                    .prod_name = txtname.Text
					
					'Response.write(txtname.text & "chk=" &  chkhide.Checked)
                    '.prod_stock = txtstock.Text
                  
				  .last_day_togo=txt_date.text
				  .prod_pickup_address=txtAddr.Text

                End With

                Dbobject.Connect()
                dsprod = Dbobject.Sp_prod(strdata, 2, "pwip_products")
               
			   
                ' Response.Write("product_id=" & product_id)



                Dbobject.close()


'Response.end()

            lblWarning.Visible = True
            lblWarning.Text = "Product Saved Successfully.Scroll down to send your products"
            Session("pi") = Request.QueryString("pi")
          
               ' Response.Redirect("findprod.aspx?pi=" & Request.QueryString("pi") & "&msg=updated&custid=" + Request.Querystring("custid"))
           
BindGrid(13)


        Catch ex As Exception
            Response.Write(ex.ToString())
        End Try
    End Sub
   
   
	 Public Sub sendmail(ByVal sender As Object, ByVal e As System.EventArgs)
	Try
	
	'Response.write(Request.Form("chkSelect"))
	
	  Dim strdata As str_prod
            Dim conobj As clsCon
            Dim Dbobject As New BusinessLayer.DBClass
            Dim dspro As New DataSet
            conobj = Session("con")
            Dbobject.Connectionstring = conobj.Connectionstring
            Dbobject.Connect()
            With strdata
                .QueryType = 10
                .prod_name = cstr(Request.Form("chkSelect"))

            End With
            dspro = Dbobject.Sp_prod(strdata, 2, "resale_products")


            Dbobject.close()
			
			Dim emails as string
				 Dim cons As New BusinessLayer.Constants
 emails=cons.GetEmails(conobj)
'Response.write(emails)
'response.end()'
' Dim message As New SendMail
 Dim clientbody as string
' Dim cliet as Boolean
' cliet=checkemail()
'' Response.write(cliet)
' 
' 
''Response.end()
'      
'If cliet=True then
'Getemail("All")
'
if dspro.tables(0).rows.count>0 then
    clientbody = "<table width='80%' align='center' border='1' cellspacing='1' cellpadding='1' style='background-color:lightblue'>" & _
         "<tr ><td  align='center'><a href='http://www.japan-indians.com/index.html'>Click Here to visit the site </a></td></tr>" & _
         "<tr style='background-color:#ffffff'><td  align='center'> <br>Following products are available for resale/Give away</td>" & _
         "</tr>" 
		 
		 dim i as integer
		 
		 for i = 0 to dspro.tables(0).rows.count - 1
		 
		' REsponse.write("i=" & i & " <br> count=" & dspro.tables(0).rows.count)
	clientbody=clientbody & "<tr style='background-color:lightblue'><td><br><br><table    border='1' bordercolor='#ffffff'  cellspacing='5' cellpadding='9'  bgcolor='lightblue'>" & _
         "            <tr>" 
		 
		 if dspro.tables(0).rows(i).item("prod_largeimage") <> "" then
             clientbody=clientbody &  "<td  width='5%' >" & _			  
			"<img src='" & session("appurl") & "prodImages/" & dspro.tables(0).rows(i).item("prod_largeimage") & " width='150' height='150' />" & _
             "           	 </td>" 
			 
			 end if 
			 clientbody=clientbody & " <td align='left' width='100%'>" & _
			 "<table width='100%'>" & _
"			 	<tr>" & _
"                    <td  valign='Top' align='left'   >" & _
"					<font size='2'  face='Arial, Helvetica, sans-serif'>" & _
"					" & _
			"		<b>" & dspro.tables(0).rows(i).item("prod_name") & "</b>" & _
"            <br>" & dspro.tables(0).rows(i).item("prod_desc")  & _
"			  <br>" & dspro.tables(0).rows(i).item("prod_price")  & _
"			  			  <br>Last to GO : " & dspro.tables(0).rows(i).item("last_day_togo")   & _
"              		<br />Pick Up Address:<br>" & dspro.tables(0).rows(i).item("prod_pickup_address")  & _
                  " Phone Number : " & dspro.tables(0).rows(i).item("cust_cellnumber") & _
"              	   <br>Contact Person : " &  dspro.tables(0).rows(i).item("cust_name") & _
"                  Email : <a href='mailto:" & dspro.tables(0).rows(i).item("cust_email") & ">" & _
dspro.tables(0).rows(i).item("cust_email") & "</a>                     " & _
"			  </td>" & _
 "                               </tr>                          " & _
                                "                              </table><td></tr></table></td></tr>"
							
							
				Next				 
		 
		clientbody=clientbody & "</table>"
'Response.write(clientbody)
 Dim message As New SendMail
 message.MailSend(emails, "info@japan-indians.com", "Japan Indians - Products available for Resale/Give away.", clientbody)
  'lblError.Text =""
  lblWarning.Text="<b>Products sent to all the Registered members through an Email.</b>"
 lblWarning.Visible=true
'else
' lblError.Text = "The Email ID does not Exist"
'  Exit sub
'end if
'
end if
        Catch ex As Exception
          response.write(ex.ToString())

        End Try

    End Sub
'
'   

	 Public Sub sendmail2(ByVal sender As Object, ByVal e As System.EventArgs)
	Try
	
	'Response.write(Request.Form("chkSelect"))
	
	  Dim strdata As str_prod
            Dim conobj As clsCon
            Dim Dbobject As New BusinessLayer.DBClass
            Dim dspro As New DataSet
            conobj = Session("con")
            Dbobject.Connectionstring = conobj.Connectionstring
            Dbobject.Connect()
            With strdata
                .QueryType = 12
                .cust_id = session("custid")

            End With
            dspro = Dbobject.Sp_prod(strdata, 2, "resale_products")


            Dbobject.close()
			
			Dim emails as string
				 Dim cons As New BusinessLayer.Constants
 emails=cons.GetEmails(conobj)
'Response.write(emails)
'response.end()'
' Dim message As New SendMail
 Dim clientbody as string
' Dim cliet as Boolean
' cliet=checkemail()
'' Response.write(cliet)
' 
' 
''Response.end()
'      
'If cliet=True then
'Getemail("All")
'
if dspro.tables(0).rows.count>0 then
    clientbody = "<table width='80%' align='center' border='1' cellspacing='1' cellpadding='1' style='background-color:lightblue'>" & _
         "<tr ><td  align='center'><a href='http://www.japan-indians.com/index.html'>Click Here to visit the site </a></td></tr>" & _
         "<tr style='background-color:#ffffff'><td  align='center'> <br>Following products are available for resale/Give away</td>" & _
         "</tr>" 
		 
		 dim i as integer
		 
		 for i = 0 to dspro.tables(0).rows.count - 1
		 
		' REsponse.write("i=" & i & " <br> count=" & dspro.tables(0).rows.count)
	clientbody=clientbody & "<tr style='background-color:lightblue'><td><br><br><table    border='1' bordercolor='#ffffff'  cellspacing='5' cellpadding='9'  bgcolor='lightblue'>" & _
         "            <tr>" 
		 
		 if dspro.tables(0).rows(i).item("prod_largeimage") <> "" then
             clientbody=clientbody &  "<td  width='5%' >" & _			  
			"<img src='" & session("appurl") & "prodImages/" & dspro.tables(0).rows(i).item("prod_largeimage") & " width='150' height='150' />" & _
             "           	 </td>" 
			 
			 end if 
			 clientbody=clientbody & " <td align='left' width='100%'>" & _
			 "<table width='100%'>" & _
"			 	<tr>" & _
"                    <td  valign='Top' align='left'   >" & _
"					<font size='2'  face='Arial, Helvetica, sans-serif'>" & _
"					" & _
			"		<b>" & dspro.tables(0).rows(i).item("prod_name") & "</b>" & _
"            <br>" & dspro.tables(0).rows(i).item("prod_desc")  & _
"			  <br>" & dspro.tables(0).rows(i).item("prod_price")  & _
"			  			  <br>Last to GO : " & dspro.tables(0).rows(i).item("last_day_togo")   & _
"              		<br />Pick Up Address:<br>" & dspro.tables(0).rows(i).item("prod_pickup_address")  & _
                  " Phone Number : " & dspro.tables(0).rows(i).item("cust_cellnumber") & _
"              	   <br>Contact Person : " &  dspro.tables(0).rows(i).item("cust_name") & _
"                  Email : <a href='mailto:" & dspro.tables(0).rows(i).item("cust_email") & ">" & _
dspro.tables(0).rows(i).item("cust_email") & "</a>                     " & _
"			  </td>" & _
 "                               </tr>                          " & _
                                "                              </table><td></tr></table></td></tr>"
							
							
				Next				 
		 
		clientbody=clientbody & "</table>"
'Response.write(clientbody)
 Dim message As New SendMail
 message.MailSend(emails, "info@japan-indians.com", "Japan Indians - Products available for Resale/GIve away.", clientbody)
  'lblError.Text =""
  lblWarning.Text="<b>Products sent to all the Registered members through an Email.</b>"
 lblWarning.Visible=true
'else
' lblError.Text = "The Email ID does not Exist"
'  Exit sub
'end if
'
end if
        Catch ex As Exception
          response.write(ex.ToString())

        End Try

    End Sub
'
'   

 Public Function SelectProd(ByVal prodid As int32) As String
        If Not IsDBNull(prodid) Then
            
                Return "<input name='chkSelect' type='checkbox' value='" & prodid & "'  />"
           

        Else
            Return ""
        End If
    End Function
	
	 Public Function GetImgURL(ByVal Row As Object, ByVal id As Int32) As String

        Dim myval As String = ""

        'here you can check the value
        If Not IsDBNull(Row) Then
            myval = Row

        End If

        If myval = Nothing Or IsDBNull(myval) Or myval = "" Then
            Return ""
        Else
            If myval <> "" And myval <> Nothing Then

                Return "<img class='shadow' rel='gray' alt=""Model"" src='prodimages/" & myval & "' width='150' height='150'   border=0 id=""catimg"" name=""catimg"" onclick=""javascript:window.open('prodimages/" & myval & "')"" Target=""_blank"" style=""cursor:pointer"" />"

            Else
                Return ""
            End If


        End If

    End Function
	
	
    Public Function GetData(ByVal content As Object, ByVal txt As String) As String
        If Not IsDBNull(content) Then
            If content <> "" Then
                Return txt & content
            Else
                Return ""
            End If

        Else
            Return ""
        End If
    End Function
    Public Function getmaxid() As Int32
        'Get Max id 
        Dim maxid As Int32 = 0

        Dim strdata As str_prod
        Dim conobj As clsCon
        Dim custname As String = ""
        Dim Dbobject As New BusinessLayer.DBClass
        Dim ds As New DataSet


        conobj = Session("con")
        Dbobject.Connectionstring = conobj.Connectionstring
        Dbobject.Connect()
        With strdata
            .querytype = 5

        End With
        ds = Dbobject.Sp_prod(strdata, 2, "Resale_products")
        Dbobject.close()
        If ds.Tables(0).Rows.Count > 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                maxid = ds.Tables(0).Rows(0).Item(0)
            End If
        End If

        Return maxid
    End Function



    Public Sub loadcatcmb(ByVal cmb As DropDownList)
        Dim strdata As Str_prod_cat
        Dim conobj As clsCon
        Dim custname As String = ""
        Dim Dbobject As New BusinessLayer.DBClass
        Dim mydscat As New DataSet


        conobj = Session("con")
        Dbobject.Connectionstring = conobj.Connectionstring
        Dbobject.Connect()
        With strdata
            .querytype = 1
          '  .vendor_id = Session("custid")

        End With
        mydscat = Dbobject.Sp_prod_cat(strdata, 2, "prod_cat")

        Dbobject.close()

        cmb.DataSource = mydscat.Tables(0).DefaultView
        cmb.DataTextField = "cat_name"
        cmb.DataValueField = "prod_cat_id"

        cmb.DataBind()

        Dim lst As New ListItem
        lst.Text = "None"
        lst.Value = 0

        cmb.Items.Insert(0, lst)


    End Sub


    Public Sub Loadprod(ByVal pid As int32)
	
	'REsponse.write("xx<br>")
        Dim strdata As Str_prod
        Dim conobj As clsCon
        Dim custname As String = ""
        Dim Dbobject As New BusinessLayer.DBClass
        Dim mydscat As New DataSet


        conobj = Session("con")
        Dbobject.Connectionstring = conobj.Connectionstring
        Dbobject.Connect()
        With strdata
            .querytype = 2
            .prod_id = pid

        End With
        mydscat = Dbobject.Sp_prod(strdata, 2, "prod_cat")

        Dbobject.close()

      if  mydscat.tables(0).rows.count>0 Then
	 if not isdbnull(mydscat.tables(0).rows(0).item("prod_name")) then
 txtname.Text=mydscat.tables(0).rows(0).item("prod_name")
   end if
   if not isdbnull(mydscat.tables(0).rows(0).item("prod_desc")) then
  txtDesc.Text=mydscat.tables(0).rows(0).item("prod_desc")
  
  end if
  
   if not isdbnull(mydscat.tables(0).rows(0).item("prod_cat")) then
   cmbprodcat.selectedValue=cint(mydscat.tables(0).rows(0).item("prod_cat")) 
	end if
	
	 if not isdbnull(mydscat.tables(0).rows(0).item("prod_price")) then
        txtprice.Text=mydscat.tables(0).rows(0).item("prod_price")
     end if
	 
      if not isdbnull(mydscat.tables(0).rows(0).item("prod_hide")) then
	  'Response.write(mydscat.tables(0).rows(0).item("prod_hide"))
  chkhide.Checked=mydscat.tables(0).rows(0).item("prod_hide")
     end if
	 
	 if not isdbnull(mydscat.tables(0).rows(0).item("prod_largeimage")) then
	 lblLimg2.Text=mydscat.tables(0).rows(0).item("prod_largeimage") 
       lblLimg.Text= "<img width='150' height='150'   src='prodImages/" + mydscat.tables(0).rows(0).item("prod_largeimage") + "' />"
	   end if
	   
	   
	   if not isdbnull(mydscat.tables(0).rows(0).item("last_day_togo")) then
      txt_date.Text=mydscat.tables(0).rows(0).item("last_day_togo")
	  end if
	  
	if not isdbnull(mydscat.tables(0).rows(0).item("prod_pickup_address")) then
	txtAddr.Text=mydscat.tables(0).rows(0).item("prod_pickup_address")
	end if
	End if

    End Sub

    Protected Sub btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Response.Redirect("findprod.aspx?pi=" & Request.QueryString("pi") & "&msg=updated&custid=" + Request.Querystring("custid"))
    End Sub

    Protected Sub lnkBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkBack.Click
        Response.Redirect("findprod.aspx?pi=" & Request.QueryString("pi") & "&msg=updated&custid=" + Request.Querystring("custid"))
    End Sub

    Public Function uploadFile(ByVal name As String, ByVal Fle As Object) As Boolean
        Try
            Dim str1, ext As String
            Dim flext As String
            Dim flength As Long
            flength = 1048576
            flext = LCase(Path.GetExtension(Fle.Value))
            If (flext = ".gif") Or (flext = ".jpg") Or (flext = ".jpeg") Or (flext = ".png") Then
                ext = LCase(Path.GetExtension(Fle.Value))
                'If flext = ".gif" Then
                '    ext = ".gif"
                'ElseIf flext = ".jpg" Then
                '    ext = ".jpg"
                'End If
                Dim myFile As HttpPostedFile = Fle.PostedFile
                If Not (Fle.PostedFile Is Nothing) Then
                    If myFile.ContentLength Then
                        str1 = Server.MapPath(".") & "\prodImages\" & name & ext
                        Fle.PostedFile.SaveAs(str1)
                        Return True
                    Else
                        Return False
                    End If
                End If
            Else
                lblWarning.Visible = True
                lblWarning.Text = "Only .gif or .jpg or .jpeg file  or .png are allowed"
                Return False
            End If
        Catch ex As Exception
            lblWarning.Text = "Problem with uploading " & ex.ToString
        End Try
    End Function
	
	public sub loadcustvalues()
	 dim custcity as string
	  dim custstate as string
	  
	  'response.write("state=" & Session("custstate"))
	  if not ISNothing(Session("custstate")) Then
	  custstate=Getstate(cint(Session("custstate")))
	  end if
	  if not isnothing(Session("custcity")) then
	  custcity=Getcity(cint(Session("custcity")))
	  
	  end if
	txtAddr.Text=Session("custaddress") & "," & custstate & "," & custcity
	end sub


	
    Public Function GetCity(Byval id as Int32) as string
        Try

            Dim strdata As str_City
            Dim conobj As clsCon
            Dim Dbobject As New BusinessLayer.DBClass
            Dim ds As New DataSet
            conobj = Session("con")
            Dbobject.Connectionstring = conobj.Connectionstring
            
            With strdata
                .QueryType = 2
                .City_id = id

            End With
			Dbobject.Connect()
            ds = Dbobject.Sp_City(strdata, 2, "City")


            Dbobject.close()
            If ds.Tables(0).Rows.Count > 0 Then
              return ds.Tables(0).Rows(0).Item("City_name")
            Else
               return ""

            End If



        Catch ex As Exception
            Response.Write(ex.ToString())


        End Try

    End Function

		
    Public Function Getstate(Byval id as Int32) as string
        Try

            Dim strdata As str_state
            Dim conobj As clsCon
            Dim Dbobject As New BusinessLayer.DBClass
            Dim ds As New DataSet
            conobj = Session("con")
            Dbobject.Connectionstring = conobj.Connectionstring
            Dbobject.Connect()
            With strdata
                .QueryType = 3
                .State_id = id

            End With
            ds = Dbobject.Sp_State(strdata, 2, "State")


            Dbobject.close()
            If ds.Tables(0).Rows.Count > 0 Then
              return ds.Tables(0).Rows(0).Item("State_name")
            Else
               return ""

            End If



        Catch ex As Exception
            Response.Write(ex.ToString())


        End Try

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If  IsNothing(Session("custid")) Then 
			Session("redirectpage")="vnd_prod_edit.aspx?type=" + request.querystring("type") + "&custid=" + request.querystring("custid") + "&id=" + request.querystring("id")
			Response.Redirect("model_login.aspx")
			'else
				
		End if
		Session("redirectpage")=""
		
        If Not IsPostBack Then
            loadcatcmb(cmbprodcat)
          loadcustvalues()
		  If Request.querystring("id")<>"" then
			Loadprod(Request.querystring("id"))
			End if

        End If

BindGrid(13)
    End Sub
	
	
	Public Sub BindGrid(Byval qtype as Int32)
	
	
	 Try
	 
	' Response.write("qtype=" & qtype)

            Dim strdata As str_prod
            Dim conobj As clsCon
            Dim Dbobject As New BusinessLayer.DBClass
            Dim ds As New DataSet
            conobj = Session("con")
            Dbobject.Connectionstring = conobj.Connectionstring
            Dbobject.Connect()
            With strdata
			
                .QueryType = qtype
                '.wa_cust_id = Session("custid")
				
				
				.s_city=0
				

				
				.state_id=0
				
				
				.cust_id=session("custid")
				
			
            End With
            ds = Dbobject.Sp_prod(strdata, 2, "Resale_Products")


            Dbobject.close()
            If ds.Tables(0).Rows.Count > 0 Then
			
                storeslist.DataSource = ds.Tables(0).DefaultView
                storeslist.DataBind()
				'lblmsg.text =""
                ' catlist.Columns(0).Visible = False
				
				
			btnSendMail2.Visible=true
			btnSendMail3.Visible=true
			
			
            Else
			 storeslist.DataSource = NOthing
                storeslist.DataBind()
                'lblmsg.text = "No Products Available "
btnSendMail2.Visible=false
	btnSendMail3.Visible=false		
            End If



        Catch ex As Exception
            Response.Write(ex.ToString())


        End Try
		End Sub
   
   
End Class
