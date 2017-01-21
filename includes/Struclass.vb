Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Drawing
' Created on        Created By
' Dec 102008        Gayathri
Namespace BusinessLayer

    Public Class Struclass
	
	  Public Structure Str_Data
            Dim adapter As SqlDataAdapter
            Dim dataset As DataSet
        End Structure
		
		Public Structure str_Customers
           Dim QueryType As Int32
           Dim Cust_id As Int32
		   Dim Cust_name  as String 
		   Dim Cust_email  as String 
		   Dim Cust_Password  as String 
		   Dim Cust_Country as Int32
		   Dim Cust_State as int32
		   Dim Cust_City as int32
		   Dim Cust_Address as String 
		   Dim Cust_CellNumber  as String 
        End Structure
		
        Public Structure str_Events
            Dim QueryType As Int32
            Dim event_id As Int32
            Dim event_name As String
            Dim event_date As String
            Dim event_time As String
            Dim event_location As String
            Dim event_telephone As String
            Dim event_address As String
            Dim event_state As String
            Dim event_city As String
            Dim event_zip As String
            Dim event_website As String
            Dim event_map As String
            Dim event_comments As String
            Dim event_image As String


        End Structure

    End Class



End Namespace