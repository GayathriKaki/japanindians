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

Partial Class FindProd
    Inherits System.Web.UI.Page
   
    Sub Page_Load(ByVal Source As Object, ByVal E As EventArgs) Handles MyBase.Load
        Try
if Request.Querystring("custid")<>"" then
searchPanel.Visible=false
'btnSendMail2.Visible=true
else
'btnSendMail2.Visible=false
searchPanel.Visible=true
end if
           if isNothing(session("custid")) then 
		   lblsend.text=""
		   end if
            If Not IsPostBack Then
			
				ddCountry_click(1,dd_state)
              if Request.Querystring("custid")<>"" then
			  	BindGrid(7)
			  End if
			  
			  Else
			  
			 ' Response.write("postback")
			  BindGrid(8)
            End If

        Catch ex As Exception

        End Try
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
		
        Dim lst As New ListItem
        lst.Text = "All"
        lst.Value = 0

        cmb.Items.Insert(0, lst)

        cmb.SelectedIndex = -1

End Sub
Public Sub State_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dd_State.SelectedIndexChanged

	if dd_state.SelectedValue <> "" then
	
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
		Dim lst As New ListItem
        lst.Text = "All"
        lst.Value = 0

        dd_City.Items.Insert(0, lst)
        dd_City.SelectedIndex = -1
End if

End Sub


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


 Public Function SelectProd(ByVal prodid As int32) As String
        If Not IsDBNull(prodid) Then
            if  Not isnothing(session("custid")) then
                Return "<input name='chkSelect' type='checkbox' value='" & prodid & "'  />"
           else
			 Return ""
			 end if
        Else
            Return ""
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
 Public Function GetEditData(ByVal custid As int32,ByVal prodid As object) As String
        If Not IsNothing(session("custid")) Then
            If custid = Cint(session("custid")) Then
                Return "<a  href='vnd_prod_edit.aspx?type=edit&custid=" & cstr(session("custid")) & "&id=" & cstr(prodid) & "'><font style='font-size:12px; font-weight:bold'>Edit/Hide your product</font></a>"
            Else
                Return ""
            End If

        Else
            Return ""
        End If
    End Function
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
         "            <tr>" & _
              "<td  width='5%' >" & _			  
			"<img src='" & session("appurl") & "prodImages/" & dspro.tables(0).rows(i).item("prod_largeimage") & " width='150' height='150' />" & _
             "           	 </td>" & _
			" <td align='left' width='100%'>" & _
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
  lblmsg.Text="<b>Products sent to all the Registered members through an Email.</b>"
 
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
	 
	
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
         storeslist.DataSource =Nothing

          BindGrid(8)
    End Sub
	
	
    Protected Sub btnSearchbyName_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchbyName.Click
         storeslist.DataSource =Nothing

          BindGrid(11)
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
				
				if dd_city.SelectedIndex > 0 then
				.s_city=dd_city.SelectedValue
				else
				.s_city=0
				
				end if

				if dd_state.SelectedIndex > 0 then
				.state_id=dd_state.SelectedValue
				else
				.state_id=0
				
				end if
				if qtype=11 then
				.prod_name=txtSearch.Text
				end if
				.cust_id=Request.Querystring("custid")
				
			
            End With
            ds = Dbobject.Sp_prod(strdata, 2, "Resale_Products")


            Dbobject.close()
            If ds.Tables(0).Rows.Count > 0 Then
			if Request.Querystring("custid")<>"" then

			btnSendMail2.Visible=true
			else
			btnSendMail2.Visible=false
			
			end if
                storeslist.DataSource = ds.Tables(0).DefaultView
                storeslist.DataBind()
				lblmsg.text =""
                ' catlist.Columns(0).Visible = False
            Else
			 storeslist.DataSource = NOthing
                storeslist.DataBind()
                lblmsg.text = "No Products Available "

            End If



        Catch ex As Exception
            Response.Write(ex.ToString())


        End Try
		End Sub
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
End Class
