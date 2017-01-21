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
		
		 Public Structure str_prod
            Dim querytype As Integer
            Dim prod_id As Int32
           
		   
            Dim prod_name As String
            Dim prod_desc As String
            Dim prod_price As string
          
		  
            Dim prod_cat As Int32
          
		  
            Dim prod_largeimage As String			
            Dim cust_id As Integer
			Dim last_day_togo as DateTime
			Dim prod_pickup_address as string
			
		
			Dim prod_hide as Boolean
			
			DIm state_id as int32
			Dim s_city as int32


        End Structure
		
		
		 Public Structure str_prod_cat
            Dim querytype As Integer
            Dim cat_id As Int32
           
		   
            Dim cat_name As String
            Dim cat_desc As String
         	
            Dim cust_id As Integer
			


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
		    Dim Cust_picture  as String 
        End Structure
		
		Public Structure str_Country
           Dim QueryType As Int32
           Dim Country_id As Int32
		   Dim Country_name  as String 
		
        End Structure
		
		Public Structure str_City
           Dim QueryType As Int32
           Dim City_id As Int32
		   Dim Country_id  as Int32 
		   Dim State_id  as Int32 
		   Dim City_name  as String 
		 
        End Structure
		
		
		Public Structure str_State
           Dim QueryType As Int32
           Dim State_id As Int32
		   Dim Country_id  as Int32 
		   Dim State_name  as String 
		 		 
        End Structure
		Public Structure str_cust_events
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

            Dim cust_id As Int32
        End Structure
		
		Public Structure str_store
			Dim s_id as int32
			Dim s_name as  string 
			Dim s_address as string 
			Dim s_city as int32 
			Dim state_id as int32 
			Dim country_id as int32
			Dim s_zip as string 
			Dim s_phone as string
			Dim s_email as string
			Dim s_website as string
			Dim s_contact as string
			Dim map_link as string
				Dim s_image as string
				Dim s_desc as string
			Dim Querytype  as int32
			Dim cust_id  as int32
		
		End Structure

    End Class



End Namespace