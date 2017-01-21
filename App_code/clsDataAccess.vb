'*****************************************************************************************************************
'Class name : clsDataAccess 
'Defination : This class is the most important class as it does all the updating,Inserting,deleting,Retrieving
'part in the database.The methods in this class is called by all the other methods in other classes.Connection
'with the database is set up here only.We have used Granth SQL database.We added this class after our analysis
'phase.As you will go through the code we have not used any attributes in any class the only thing we have used is
'a query and nothing else. 
'Date Added : 11/11/05
'Please keep the comments if you distribute
'Author :        Quartz (Rajesh Lal - connectrajesh@hotmail.com)
'*****************************************************************************************************************

Imports System.Configuration
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Namespace JumpyForum
	Public Class clsDataAccess
		' Class defination
		Public Sub New()
		End Sub
		Private mycon As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))

		Public Function openConnection() As Boolean
		' Opens database connection with Granth in SQL SERVER
			If mycon.State = ConnectionState.Closed Then
				mycon.Open()
			End If

			Return True
		End Function
		Public Sub closeConnection()
		' Closes database connection with Granth in SQL SERVER

			mycon.Close()
			mycon = Nothing
		End Sub
		Public Function getData(query As String) As SqlDataReader
		' Getdata from the table required(given in query)in datareader
			Dim sqlCommand As New SqlCommand()
			sqlCommand.CommandText = query
			sqlCommand.Connection = mycon
			Dim myr As SqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
			Return myr

		End Function
		Public Function getForumData(ArticleId As Integer) As SqlDataReader
		' Getdata from the table required(given in query)in datareader
			Dim sqlCommand As New SqlCommand()
			sqlCommand.CommandType = CommandType.StoredProcedure
			sqlCommand.CommandText = "ShowHierarchyForum"
			Dim newSqlParam As New SqlParameter()
			newSqlParam.ParameterName = "@ArticleId"
			newSqlParam.SqlDbType = SqlDbType.Int
			newSqlParam.Direction = ParameterDirection.Input
			newSqlParam.Value = ArticleId
			sqlCommand.Parameters.Add(newSqlParam)

			Dim newSqlParam2 As New SqlParameter()
			newSqlParam2.ParameterName = "@Root"
			newSqlParam2.SqlDbType = SqlDbType.Int
			newSqlParam2.Direction = ParameterDirection.Input
			newSqlParam2.Value = 0
			sqlCommand.Parameters.Add(newSqlParam2)
			sqlCommand.Connection = mycon

			Dim myr As SqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
			Return myr

		End Function
		Public Function DeleteForumData(ArticleId As Integer, root As Integer) As Boolean
		' Getdata from the table required(given in query)in datareader
			Dim sqlCommand As New SqlCommand()
			sqlCommand.CommandType = CommandType.StoredProcedure

			sqlCommand.CommandText = "DeleteHierarchyForum"
			Dim newSqlParam As New SqlParameter()
			newSqlParam.ParameterName = "@ArticleId"
			newSqlParam.SqlDbType = SqlDbType.Int
			newSqlParam.Direction = ParameterDirection.Input
			newSqlParam.Value = ArticleId
			sqlCommand.Parameters.Add(newSqlParam)

			Dim newSqlParam2 As New SqlParameter()
			newSqlParam2.ParameterName = "@Root"
			newSqlParam2.SqlDbType = SqlDbType.Int
			newSqlParam2.Direction = ParameterDirection.Input
			newSqlParam2.Value = root
			sqlCommand.Parameters.Add(newSqlParam2)
			sqlCommand.Connection = mycon

			Dim i As Integer = sqlCommand.ExecuteNonQuery()
			If i = 0 Then
				Return True
			Else
				Return False
			End If

		End Function
		Public Sub saveData(query As String)
		' Save data usually,inserts and updates the data in table given in query
			Dim sqlCommand As New SqlCommand()
			sqlCommand.CommandText = query
			sqlCommand.Connection = mycon
			sqlCommand.ExecuteNonQuery()
			sqlCommand.Dispose()

		End Sub
		Public Function saveNewData(query As String) As Boolean
		' Save data usually,inserts and updates the data in table given in query
			Dim stat As Boolean = False
			Try
				Dim sqlCommand As New SqlCommand()
				sqlCommand.CommandText = query
				sqlCommand.Connection = mycon
				sqlCommand.ExecuteNonQuery()
				sqlCommand.Dispose()
				stat = True
			Catch
				stat = False
			End Try
			Return stat

		End Function

		Public Function DeleteData(query As String) As Integer
		' Delete data in database depending on the tablename given in query.
			Dim sqlCommand As New SqlCommand()
			sqlCommand.CommandText = query
			sqlCommand.Connection = mycon
			Return sqlCommand.ExecuteNonQuery()

		End Function
		Public Function getDataforUpdate(query As String) As SqlDataAdapter
		' Get data by paging using datagrid which returns the dataset in datagris
			Dim sqlDataAdapter As New SqlDataAdapter(query, mycon)
			Dim dataSet As New DataSet()
			'sqlDataAdapter.Fill(dataSet,"NewData");
			Return sqlDataAdapter
		End Function
		Public Function getDatabyPaging(query As String) As DataSet
		' Get data by paging using datagrid which returns the dataset in datagris
			Dim sqlDataAdapter As New SqlDataAdapter(query, mycon)
			Dim dataSet As New DataSet()
			sqlDataAdapter.Fill(dataSet)
			Return dataSet

		End Function
		Public Function getCheck(query As String) As Integer
		' check a particular value to see the validity of mediaid and userid.This method is called in media and user class.
			Dim i As Integer
			Dim sqlCommand As New SqlCommand()
			sqlCommand.CommandText = query
			sqlCommand.Connection = mycon
			i = Convert.ToInt32(sqlCommand.ExecuteScalar())
			Return i
		End Function
		Public Function getValue(query As String, j As Integer) As String
		' Get a value of limit from the database table Employees to check before issuing media.
			Dim i As String = "0"

			Dim sqlCommand As New SqlCommand()
			sqlCommand.CommandText = query
			sqlCommand.Connection = mycon
			Dim myReader As SqlDataReader = sqlCommand.ExecuteReader()

			If myReader.Read() = True Then


				i = myReader.GetValue(j).ToString()
			End If
			Return i
		End Function

		'Public Function Login(query As String) As SqlDataReader
'		'Log in method for LA and Client.
'			Dim [myclass] As New clsDataAccess()
'			[myclass].openConnection()
'			Dim dr As SqlDataReader = [myclass].getData(query)
'			'Class Data Access is called here
'			Return dr
'		End Function
		Public Function getTablenames() As DataTable
			Dim da As New SqlDataAdapter("SELECT * FROM Information_Schema.Tables where Table_Type = 'BASE TABLE'", mycon)
			Dim dt As New DataTable()
			da.Fill(dt)
			Return dt

		End Function

		Public Function TableWrite(query As String) As Integer
			Dim sqlCommand As New SqlCommand()
			sqlCommand.CommandText = query
			sqlCommand.Connection = mycon
			Return sqlCommand.ExecuteNonQuery()
		End Function



	End Class
End Namespace