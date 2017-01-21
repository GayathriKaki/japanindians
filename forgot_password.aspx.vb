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

Partial Class forgot_password
    Inherits System.Web.UI.Page
	 
	Public cust_id as string
		Public pwd as string
	
	Sub Page_Load(ByVal Source As Object, ByVal E As EventArgs) Handles MyBase.Load
      
   
    End Sub
    Public Function checkemail() as Boolean
       
       Try
            Dim strdata As Str_Customers
			Dim stat as string
        Dim conobj As clsCon
        Dim custname As String = ""
        Dim Dbobject As New BusinessLayer.DBClass
        Dim ds As New DataSet
        conobj = Session("con")
        Dbobject.Connectionstring = conobj.Connectionstring
        Dbobject.Connect()
        With strdata
            .querytype = 9
			.cust_email=txtUid.Text
			
           

        End With
        ds = Dbobject.Sp_Customers(strdata, 2, "Customers")

      
        Dbobject.close()


            If ds.Tables(0).Rows.Count > 0 Then
                stat= True
				 If Not IsDBNull(ds.Tables(0).Rows(0).Item("cust_id")) Then
                cust_id = ds.Tables(0).Rows(0).Item("cust_id")
            Else
                cust_id = ""

            End If
			
			If Not IsDBNull(ds.Tables(0).Rows(0).Item("cust_password")) Then
                pwd = ds.Tables(0).Rows(0).Item("cust_password")
            Else
                pwd = ""

            End If
              
            Else
               stat= False
            End If
           
			Return stat
        Catch ex As Exception
            lblError.Text = ex.ToString()

        End Try
    End Function
	
	' Public sub Getemail(Byval email as string)
'        Dim wmail As String
'         strConn = System.Configuration.ConfigurationSettings.AppSettings("dbConnection")
'        MySQL = "Select * from customers where Email='" & email & "'"
'        MyConn = New OdbcConnection(strConn)
'        Dim ds As DataSet = New DataSet()
'        Dim Cmd As New OdbcDataAdapter(MySQL, MyConn)
'        Cmd.Fill(ds, "customers")
'        If ds.Tables(0).Rows.Count > 0 Then
'            If Not IsDBNull(ds.Tables(0).Rows(0).Item("cust_userid")) Then
'                cust_id = ds.Tables(0).Rows(0).Item("cust_userid")
'            Else
'                cust_id = ""
'
'            End If
'			
'			If Not IsDBNull(ds.Tables(0).Rows(0).Item("password")) Then
'                pwd = ds.Tables(0).Rows(0).Item("password")
'            Else
'                pwd = ""
'
'            End If
'       
'
'        End If
'        MyConn.Close()
'    
'
'
'    End sub

    Protected Sub image_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles image.Click
	Try

 Dim message As New SendMail
 Dim clientbody as string
 Dim cliet as Boolean
 cliet=checkemail()
' Response.write(cliet)
 
 
'Response.end()
      
If cliet=True then
'call Getemail(txtUid.Text)

    clientbody = "<table width='80%' align='center' border='0' cellspacing='1' cellpadding='1' style='background-color:#CFCEBC'>" & _
         "<tr ><td colspan='2' align='center'><a href='http://www.japan-indians.com/index.html'>Click Here to visit the site </a></td></tr>" & _
         "<tr style='background-color:#ffffff'><td colspan='2' align='center'> <br>Hi   &nbsp;&nbsp;&nbsp;&nbsp;Here are your Login Details for the site Japan-Indians.com.</td>" & _
         "</tr><tr style='background-color:#ffffff'><td colspan='2'>&nbsp;</td></tr><tr style='background-color:#ffffff'><td align='right'>User ID : &nbsp;&nbsp; </td>" & _
           "<td>&nbsp;&nbsp;" & cust_id & "</td></tr><tr style='background-color:#ffffff'> <td align='right'>Password :&nbsp;&nbsp; </td><td>&nbsp;&nbsp;" & pwd & "</td>" & _
        "<tr style='background-color:#ffffff'> <td colspan='2'>&nbsp;</td></tr></table>"

  message.MailSend(txtUid.Text.trim(), "info@japan-indians.com", "Japan Indians  Login Credentials", clientbody)
  lblError.Text =""
  lbllogin.Text="Your Password is sent to your email"
 
else
 lblError.Text = "The Email ID does not Exist"
  Exit sub
end if


        Catch ex As Exception
            lblError.Text = ex.ToString()

        End Try

    End Sub

   

End Class
