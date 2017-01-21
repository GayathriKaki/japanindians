
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports BusinessLayer.Constants
Imports BusinessLayer.Struclass
' Created on        Created By
' jun 1,2008        support.itc.worldwide


Namespace BusinessLayer

    Public Class DBClass

#Region "Data Members"
        '----Local Varibles 
        'Private m_strConnString As String
        Private m_oCommand As SqlCommand
        Private m_oConnection As SqlConnection
        Private m_oTransaction As SqlTransaction
        Private m_connectionStatus As RESULT
        Private m_oConnectionstring As String
        Private Cnerr As String
        Private m_ErrDes As String
        Private m_rpage As String
#End Region

        Public Function dbcheck(ByVal val As Object)
            If Not IsDBNull(val) Then
                Return val
            Else
                Return ""
            End If
        End Function

        Public Property Connectionstring() As String
            Get
                Return m_oConnectionstring
            End Get
            Set(ByVal value As String)
                m_oConnectionstring = value
            End Set
        End Property

        Function Connect()
            m_oConnection = New SqlConnection(m_oConnectionstring)
            m_oConnection.Open()
        End Function

        Function close()
            m_oConnection.Close()
        End Function

        '---To Execute NonQueryData
        Public Sub NonQueryData(ByVal strQryText As String)
            With m_oCommand
                .CommandType = CommandType.Text
                .CommandText = strQryText
                .ExecuteNonQuery()
            End With
        End Sub

        '---To Execute Command  object  using Trasaction
        Public Sub StratTransaction()
            m_oTransaction = m_oConnection.BeginTransaction
            m_oCommand.Transaction = m_oTransaction
        End Sub

        '---To Commit Transaction
        Public Sub CommitTransaction()
            m_oTransaction.Commit()
        End Sub

        '---To RollBack Transaction
        Public Sub RollBackTransaction()
            m_oTransaction.Rollback()
        End Sub

        '--- Query Data  Excuted   Dataset result returned
        Public Sub QueryData(ByVal strQryText As String, ByRef o_dataset As DataSet)
            Dim Resultset As Str_Data
            Dim resultDS As DataSet
            Dim sqlDA As SqlDataAdapter

            m_oCommand.Connection = m_oConnection
            With m_oCommand
                .CommandType = CommandType.Text
                .CommandText = strQryText
            End With

            'Create a new DataSet
            Resultset.adapter = New SqlDataAdapter
            resultDS = New DataSet

            With Resultset.adapter
                ' Add a SelectCommand object
                .SelectCommand = m_oCommand
                ' Populate the DataSet with the returned data
                .Fill(resultDS, "ResultDS")
            End With
            '   Resultset.adapter = sqlDA
            Resultset.dataset = resultDS
            o_dataset = resultDS

        End Sub

        Public Function SetErrodata(ByVal Errdes As String)
            '---Setting Error  description
            Throw New Exception(Errdes)
        End Function

        '--------------This Function Generates Param  object for given values---------------
        '------Param Name
        '------Param value
        '------Param Type
        '------Param Direction

        Private Function GetParam(ByVal PName As String, ByVal PType As DbType, ByVal PDirection As ParameterDirection, ByVal Pvalue As Object) As SqlParameter
            '-------Declaring Parmeter Object
            Dim oPrm As SqlParameter
            '---New instance of  Parmeter object
            oPrm = New SqlParameter
            '---------Set Param  values
            With oPrm
                .ParameterName = PName  '--Set parmname
                .DbType = PType         '--Set  Param Type 
                .Direction = PDirection '-- set param  direction
                '--Checking Param  value
                If .DbType = DbType.String And Pvalue = Nothing Then
                    .Value = ""         '--set param  value
                Else
                    .Value = Pvalue     '--set param  value
                End If

                If .DbType = DbType.DateTime Then
                    If Pvalue = Nothing Or IsDate(Pvalue) = False Then
                        .Value = DBNull.Value       '--set param  value
                    Else
                        .Value = Pvalue     '--set param  value
                    End If
                End If
            End With
            '--Returning Param object
            Return oPrm
        End Function

       
        '---- this  Function Executes command  in a tansaction
        Public Function Exutecommand(ByVal m_oCommand1 As SqlCommand, ByVal Exetype As Integer, ByVal tbname As String)
            Dim Exedataset As Str_Data
            Try
                '---Starting Transaction
                m_oTransaction = m_oConnection.BeginTransaction
                m_oCommand1.Transaction = m_oTransaction
                If Exetype = 1 Then Return m_oCommand1
                '---Executing Command Object
                Exedataset = ExecuteSelectcmd(m_oCommand1, Exetype, tbname)
                '---commit transaction
                CommitTransaction()
            Catch ex As Exception
                '--When Error  occuured
                RollBackTransaction()
                '----Setting Error message
                SetErrodata(ex.Message)
            End Try
            Return Exedataset
        End Function
        Public Function ExecutQuery(ByVal qstr As String)
            Dim Da As SqlDataAdapter
            Dim ds As New DataSet
            Da = New SqlDataAdapter(qstr, m_oConnection)
            Da.Fill(ds, "ordreport")
            Return ds
        End Function

     
        '-----This  Function Executes   command  object  and  it fills  The  data set
        Private Function ExecuteSelectcmd(ByRef m_oCommand1 As SqlCommand, ByVal ExeType As Integer, ByVal tbname As String)
            '--Declare varible here 
            Dim resultDS As DataSet
            Dim sqlDA As SqlDataAdapter


            If ExeType = 1 Then Return m_oCommand1
            If ExeType = 101 Then
                m_oCommand1.ExecuteNonQuery()
            End If
            '---Check  connection  Status

            ''If Me.connectionStatus = RESULT.CONNECTION_SUCCESSFUL Then
            '-- Create a new DataAdapter
            sqlDA = New SqlDataAdapter
            '-- Create a new DataSet
            resultDS = New DataSet
            '---- Add a SelectCommand object
            sqlDA.SelectCommand = m_oCommand1

            ' ----Populate the DataSet with the returned data
            sqlDA.Fill(resultDS, tbname)
            '-----Set Result Data set
            ''Else
            '''----Setting Error message
            ''SetErrodata(Cnerr)
            ''End If
            Return resultDS
        End Function

        '----This  Function Sets Command  Object  values
        Public Function SetCommandobject(ByRef o_cmd As SqlCommand, ByVal Stprocedurenm As String)
            '-------Prepare Command Object
            '-------creat new Command Object
            o_cmd = New SqlCommand
            '----set  values
            With o_cmd
                .Connection = m_oConnection                 '---set connection
                .CommandText = Stprocedurenm                '---set StoreProcedure name
                .CommandType = CommandType.StoredProcedure  '----set Command Type
            End With
            Return o_cmd
        End Function


      
'
'        Public Function Sp_city(ByRef strdata As str_city, ByVal Exetype As Integer, ByVal tbname As String)
'            '----Declaring  Command  Object
'            Dim m_oCommand1 As SqlCommand
'            '-------setting Command Object values
'            m_oCommand1 = SetCommandobject(m_oCommand1, "sp_city")
'            With strdata
'
'                '----Add Required Parameters
'                m_oCommand1.Parameters.Add(GetParam("@QueryType", DbType.Int32, ParameterDirection.Input, .querytype))
'                m_oCommand1.Parameters.Add(GetParam("@country_Id", DbType.Int32, ParameterDirection.Input, .COUNTRY_ID))
'                m_oCommand1.Parameters.Add(GetParam("@city_id", DbType.Int32, ParameterDirection.Input, .city_id))
'                m_oCommand1.Parameters.Add(GetParam("@city", DbType.String, ParameterDirection.Input, .city))
'              
'
'            End With
'            '----Executing Command Object----  
'            Return ExecuteSelectcmd(m_oCommand1, Exetype, tbname)
'        End Function
        
        Public Function Sp_customers(ByRef strdata As str_Customers, ByVal Exetype As Integer, ByVal tbname As String)
            '----Declaring  Command  Object
            Dim m_oCommand1 As SqlCommand
            '-------setting Command Object values
            m_oCommand1 = SetCommandobject(m_oCommand1, "Sp_Customers")

            With strdata
		

                m_oCommand1.Parameters.Add(GetParam("@Cust_id", DbType.Int32, ParameterDirection.Input, .Cust_id))
                m_oCommand1.Parameters.Add(GetParam("@Cust_name", DbType.String, ParameterDirection.Input, .Cust_name))
                m_oCommand1.Parameters.Add(GetParam("@Cust_password", DbType.String, ParameterDirection.Input, .Cust_password))
                m_oCommand1.Parameters.Add(GetParam("@Cust_email", DbType.String, ParameterDirection.Input, .Cust_email))
				 m_oCommand1.Parameters.Add(GetParam("@Cust_State", DbType.Int32, ParameterDirection.Input, .Cust_State))
               
                m_oCommand1.Parameters.Add(GetParam("@Cust_city", DbType.Int32, ParameterDirection.Input, .Cust_city))
                m_oCommand1.Parameters.Add(GetParam("@Cust_country", DbType.Int32, ParameterDirection.Input, .Cust_country))
                m_oCommand1.Parameters.Add(GetParam("@Cust_Address", DbType.String, ParameterDirection.Input, .Cust_Address))
				 m_oCommand1.Parameters.Add(GetParam("@Cust_CellNumber", DbType.String, ParameterDirection.Input, .Cust_CellNumber))
                m_oCommand1.Parameters.Add(GetParam("@Cust_picture", DbType.String, ParameterDirection.Input, .Cust_picture))
               
                m_oCommand1.Parameters.Add(GetParam("@QueryType", DbType.String, ParameterDirection.Input, .Querytype))

            End With
            '----Executing Command Object----  
            Return ExecuteSelectcmd(m_oCommand1, Exetype, tbname)
        End Function


 	Public Function Sp_country(ByRef strdata As str_Country, ByVal Exetype As Integer, ByVal tbname As String)
            '----Declaring  Command  Object
            Dim m_oCommand1 As SqlCommand
            '-------setting Command Object values
            m_oCommand1 = SetCommandobject(m_oCommand1, "Sp_Country")

            With strdata
		
 
		   
                m_oCommand1.Parameters.Add(GetParam("@Country_id", DbType.Int32, ParameterDirection.Input, .Country_id))
                m_oCommand1.Parameters.Add(GetParam("@Country", DbType.String, ParameterDirection.Input, .Country_name))               
                m_oCommand1.Parameters.Add(GetParam("@QueryType", DbType.String, ParameterDirection.Input, .Querytype))

            End With
            '----Executing Command Object----  
            Return ExecuteSelectcmd(m_oCommand1, Exetype, tbname)
        End Function
	Public Function Sp_State(ByRef strdata As str_State, ByVal Exetype As Integer, ByVal tbname As String)
            '----Declaring  Command  Object
            Dim m_oCommand1 As SqlCommand
            '-------setting Command Object values
            m_oCommand1 = SetCommandobject(m_oCommand1, "Sp_State")

            With strdata
		
 
		      m_oCommand1.Parameters.Add(GetParam("@State_id", DbType.Int32, ParameterDirection.Input, .State_id))
                m_oCommand1.Parameters.Add(GetParam("@Country_id", DbType.Int32, ParameterDirection.Input, .Country_id))
                m_oCommand1.Parameters.Add(GetParam("@State_name", DbType.String, ParameterDirection.Input, .State_name))               
                m_oCommand1.Parameters.Add(GetParam("@QueryType", DbType.String, ParameterDirection.Input, .Querytype))

            End With
            '----Executing Command Object----  
            Return ExecuteSelectcmd(m_oCommand1, Exetype, tbname)
        End Function

Public Function Sp_City(ByRef strdata As str_City, ByVal Exetype As Integer, ByVal tbname As String)
            '----Declaring  Command  Object
            Dim m_oCommand1 As SqlCommand
            '-------setting Command Object values
            m_oCommand1 = SetCommandobject(m_oCommand1, "Sp_City")

            With strdata
		
   m_oCommand1.Parameters.Add(GetParam("@City_id", DbType.Int32, ParameterDirection.Input, .City_id))
            
		      m_oCommand1.Parameters.Add(GetParam("@State_id", DbType.Int32, ParameterDirection.Input, .State_id))
                m_oCommand1.Parameters.Add(GetParam("@Country_id", DbType.Int32, ParameterDirection.Input, .Country_id))
                m_oCommand1.Parameters.Add(GetParam("@City_name", DbType.String, ParameterDirection.Input, .City_name))               
                m_oCommand1.Parameters.Add(GetParam("@QueryType", DbType.String, ParameterDirection.Input, .Querytype))

            End With
            '----Executing Command Object----  
            Return ExecuteSelectcmd(m_oCommand1, Exetype, tbname)
        End Function

'
        Public Function Sp_cust_events(ByRef strdata As str_cust_events, ByVal Exetype As Integer, ByVal tbname As String)
            '----Declaring  Command  Object
            Dim m_oCommand1 As SqlCommand
            '-------setting Command Object values
            m_oCommand1 = SetCommandobject(m_oCommand1, "sp_cust_events")
            With strdata




                '----Add Required Parameters
                m_oCommand1.Parameters.Add(GetParam("@QueryType", DbType.Int32, ParameterDirection.Input, .QueryType))
                m_oCommand1.Parameters.Add(GetParam("@event_id", DbType.Int32, ParameterDirection.Input, .event_id))
                m_oCommand1.Parameters.Add(GetParam("@cust_id", DbType.Int32, ParameterDirection.Input, .cust_id))
                m_oCommand1.Parameters.Add(GetParam("@event_name", DbType.String, ParameterDirection.Input, .event_name))
                m_oCommand1.Parameters.Add(GetParam("@event_time", DbType.String, ParameterDirection.Input, .event_time))
                m_oCommand1.Parameters.Add(GetParam("@event_location", DbType.String, ParameterDirection.Input, .event_location))
                m_oCommand1.Parameters.Add(GetParam("@event_date", DbType.String, ParameterDirection.Input, .event_date))

                m_oCommand1.Parameters.Add(GetParam("@event_telephone", DbType.String, ParameterDirection.Input, .event_telephone))
                m_oCommand1.Parameters.Add(GetParam("@event_address", DbType.String, ParameterDirection.Input, .event_address))
                m_oCommand1.Parameters.Add(GetParam("@event_state", DbType.String, ParameterDirection.Input, .event_state))



                m_oCommand1.Parameters.Add(GetParam("@event_city", DbType.String, ParameterDirection.Input, .event_city))
                m_oCommand1.Parameters.Add(GetParam("@event_zip", DbType.String, ParameterDirection.Input, .event_zip))
                m_oCommand1.Parameters.Add(GetParam("@event_website", DbType.String, ParameterDirection.Input, .event_website))




                m_oCommand1.Parameters.Add(GetParam("@event_map", DbType.String, ParameterDirection.Input, .event_map))
                m_oCommand1.Parameters.Add(GetParam("@event_comments", DbType.String, ParameterDirection.Input, .event_comments))
                m_oCommand1.Parameters.Add(GetParam("@event_image", DbType.String, ParameterDirection.Input, .event_image))


            End With
            '----Executing Command Object----  
            Return ExecuteSelectcmd(m_oCommand1, Exetype, tbname)
        End Function


Public Function Sp_store(ByRef strdata As str_store, ByVal Exetype As Integer, ByVal tbname As String)
            '----Declaring  Command  Object
            Dim m_oCommand1 As SqlCommand
            '-------setting Command Object values
            m_oCommand1 = SetCommandobject(m_oCommand1, "Sp_store")

            With strdata
		
					
			   m_oCommand1.Parameters.Add(GetParam("@s_id", DbType.Int32, ParameterDirection.Input, .s_id))
			   m_oCommand1.Parameters.Add(GetParam("@s_name", DbType.String, ParameterDirection.Input, .s_name))  
			   m_oCommand1.Parameters.Add(GetParam("@s_address", DbType.String, ParameterDirection.Input, .s_address))  
						
		       m_oCommand1.Parameters.Add(GetParam("@s_city", DbType.Int32, ParameterDirection.Input, .s_city))
			   m_oCommand1.Parameters.Add(GetParam("@state_id", DbType.Int32, ParameterDirection.Input, .state_id))
			 
                m_oCommand1.Parameters.Add(GetParam("@Country_id", DbType.Int32, ParameterDirection.Input, .Country_id))
				m_oCommand1.Parameters.Add(GetParam("@s_zip", DbType.String, ParameterDirection.Input, .s_zip))	
			    m_oCommand1.Parameters.Add(GetParam("@s_phone", DbType.String, ParameterDirection.Input, .s_phone))		
				m_oCommand1.Parameters.Add(GetParam("@s_email", DbType.String, ParameterDirection.Input, .s_email))	
		        m_oCommand1.Parameters.Add(GetParam("@s_website", DbType.String, ParameterDirection.Input, .s_website))
				
                m_oCommand1.Parameters.Add(GetParam("@s_contact", DbType.String, ParameterDirection.Input, .s_contact))               
				m_oCommand1.Parameters.Add(GetParam("@map_link", DbType.String, ParameterDirection.Input, .map_link))
				m_oCommand1.Parameters.Add(GetParam("@s_image", DbType.String, ParameterDirection.Input, .s_image))
				m_oCommand1.Parameters.Add(GetParam("@s_desc", DbType.String, ParameterDirection.Input, .s_desc))
                m_oCommand1.Parameters.Add(GetParam("@QueryType", DbType.String, ParameterDirection.Input, .Querytype))
				                m_oCommand1.Parameters.Add(GetParam("@cust_id", DbType.Int32, ParameterDirection.Input, .cust_id))

            End With
            '----Executing Command Object----  
            Return ExecuteSelectcmd(m_oCommand1, Exetype, tbname)
        End Function
   

Public Function Sp_Prod(ByRef strdata As str_Prod, ByVal Exetype As Integer, ByVal tbname As String)
            '----Declaring  Command  Object
            Dim m_oCommand1 As SqlCommand
            '-------setting Command Object values
            m_oCommand1 = SetCommandobject(m_oCommand1, "Sp_Prod")
			
			 With strdata
			
			  m_oCommand1.Parameters.Add(GetParam("@QueryType", DbType.String, ParameterDirection.Input, .Querytype))

	
			   m_oCommand1.Parameters.Add(GetParam("@prod_id", DbType.Int32, ParameterDirection.Input, .prod_id))
			   m_oCommand1.Parameters.Add(GetParam("@prod_name", DbType.String, ParameterDirection.Input, .prod_name))  
			   m_oCommand1.Parameters.Add(GetParam("@prod_desc", DbType.String, ParameterDirection.Input, .prod_desc))  
						
		       m_oCommand1.Parameters.Add(GetParam("@prod_price", DbType.String, ParameterDirection.Input, .prod_price))
			   m_oCommand1.Parameters.Add(GetParam("@prod_cat", DbType.Int32, ParameterDirection.Input, .prod_cat))
			                 m_oCommand1.Parameters.Add(GetParam("@prod_hide", DbType.Boolean, ParameterDirection.Input, .prod_hide))
                m_oCommand1.Parameters.Add(GetParam("@cust_id", DbType.Int32, ParameterDirection.Input, .cust_id))
				m_oCommand1.Parameters.Add(GetParam("@prod_largeimage", DbType.String, ParameterDirection.Input, .prod_largeimage))	
			    m_oCommand1.Parameters.Add(GetParam("@last_day_togo", DbType.DateTime, ParameterDirection.Input, .last_day_togo))		
				m_oCommand1.Parameters.Add(GetParam("@prod_pickup_address", DbType.String, ParameterDirection.Input, .prod_pickup_address))	
				
				  m_oCommand1.Parameters.Add(GetParam("@state_id", DbType.Int32, ParameterDirection.Input, .state_id))
				    m_oCommand1.Parameters.Add(GetParam("@s_city", DbType.Int32, ParameterDirection.Input, .s_city))
		       
			   
            End With
            '----Executing Command Object----  
            Return ExecuteSelectcmd(m_oCommand1, Exetype, tbname)
        End Function
   
       
Public Function Sp_Prod_cat(ByRef strdata As str_Prod_cat, ByVal Exetype As Integer, ByVal tbname As String)
            '----Declaring  Command  Object
            Dim m_oCommand1 As SqlCommand
            '-------setting Command Object values
            m_oCommand1 = SetCommandobject(m_oCommand1, "Sp_Prod_cat")
			
			 With strdata
			  m_oCommand1.Parameters.Add(GetParam("@QueryType", DbType.String, ParameterDirection.Input, .Querytype))

	
			   m_oCommand1.Parameters.Add(GetParam("@prod_cat_id", DbType.Int32, ParameterDirection.Input, .cat_id))
			   m_oCommand1.Parameters.Add(GetParam("@cat_name", DbType.String, ParameterDirection.Input, .cat_name))  
			   m_oCommand1.Parameters.Add(GetParam("@cat_desc", DbType.String, ParameterDirection.Input, .cat_desc))  
						
		       m_oCommand1.Parameters.Add(GetParam("@cust_id", DbType.Int32, ParameterDirection.Input, .cust_id))
				
		       
			   
            End With
            '----Executing Command Object----  
            Return ExecuteSelectcmd(m_oCommand1, Exetype, tbname)
        End Function
    End Class
End Namespace
