Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports BusinessLayer.Struclass
Imports BusinessLayer.DBClass
Imports ConnectionServices
' Created on        Created By
' Dec 10,2008        Gayathri
Namespace BusinessLayer
    
    Public Class Constants
        Public ffmpegpath As String
        Enum RESULT
            NO_ERROR = 1
            INSERT_ERROR = 2
            DELETE_ERROR = 3
            UPDATE_ERROR = 4
            OTHER_ERROR = 5
            LOGIN_SUCCESSFUL = 6
            LOGIN_UNSUCCESSFUL = 7
            CONNECTION_SUCCESSFUL = 8
            CONNECTION_UNSUCCESSFUL = 9

        End Enum
		
		Public Function GetEmails(Byval conobj as clsCon)
		 Try
	 
	' Response.write("qtype=" & qtype)

            Dim strdata As str_Customers

            Dim Dbobject As New BusinessLayer.DBClass
            Dim ds As New DataSet

            Dbobject.Connectionstring = conobj.Connectionstring
            Dbobject.Connect()
            With strdata
			
                .QueryType = 1
               
				
			
            End With
            ds = Dbobject.Sp_Customers(strdata, 2, "Customers")


            Dbobject.close()
			Dim str as string=""
			Dim i as int32
            If ds.Tables(0).Rows.Count > 0 Then
              for i=0 to ds.Tables(0).Rows.Count -1
			  
			  if Not IsDBNull(ds.Tables(0).Rows(i).Item("cust_email"))  Then
			  str=str & ds.Tables(0).Rows(i).Item("cust_email") 
			  End if
			  if i<ds.Tables(0).Rows.Count -1 then
			  str=str &  "," 
			  end if
			'   if  Not IsDBNull(ds.Tables(0).Rows(i).Item("email2"))  Then
'			  str=str & ds.Tables(0).Rows(i).Item("email2") & ","
'			  End if
			  
			  Next
            Else
                return ""

            End If

		return str

        Catch ex As Exception
           ' Response.Write(ex.ToString())
return ex.Tostring()

        End Try
		End FUnction

        Public Function dbcheck(ByVal val As Object)
            If Not IsDBNull(val) Then
                Return val
            Else
                Return ""
            End If
        End Function


      

    End Class


    

End Namespace
