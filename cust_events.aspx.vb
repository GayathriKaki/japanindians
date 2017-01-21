Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports BusinessLayer.Struclass
Imports BusinessLayer.DBClass
Imports ConnectionServices

Partial Class cust_events
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then

                BindData()

            End If

        Catch ex As Exception
            'Response.Write(ex.ToString())
        End Try
    End Sub
   



    Sub BindData()
        Try

            Dim strdata As str_cust_events
            Dim conobj As clsCon
            Dim Dbobject As New BusinessLayer.DBClass
            Dim ds As New DataSet
            conobj = Session("con")
            Dbobject.Connectionstring = conobj.Connectionstring
            Dbobject.Connect()
            With strdata
                .QueryType = 1
                '.wa_cust_id = Session("custid")

            End With
            ds = Dbobject.Sp_cust_events(strdata, 2, "events")


            Dbobject.close()
            If ds.Tables(0).Rows.Count > 0 Then
                catlist.DataSource = ds.Tables(0).DefaultView
                catlist.DataBind()
                ' catlist.Columns(0).Visible = False
            Else
                lblmsg.text = "No Events Available "

            End If



        Catch ex As Exception
            Response.Write(ex.ToString())


        End Try

    End Sub
	
	

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




    Public Function getedate(ByVal dt As Object, ByVal t As Object)

        Dim myval As String = ""

        'here you can check the value
        If Not IsDBNull(dt) Then
            myval = dt

        End If
        Dim dtstring As String

        If myval = Nothing Or IsDBNull(myval) Or myval = "" Then
            dtstring = ""
        Else
            If myval <> "" And myval <> Nothing Then

                dtstring = CDate(dt).DayOfWeek.Tostring() & ", " & MonthName(CDate(dt).Month) & " " & CDate(dt).Day & ", " & CDate(dt).Year
                If t <> "" Then
                    dtstring = dtstring & " | " & t
                End If
            Else
                dtstring = ""
            End If


        End If

        Return dtstring


    End Function

    Public Function getaddr(ByVal stat As Object, ByVal city As Object, ByVal zip As Object)

        Dim myval As String = ""

        'here you can check the value
        If Not IsDBNull(stat) Then
            myval = Getstate(stat)

        End If

        If Not IsDBNull(city) Then
            myval = myval & ", " & Getcity(city)

        End If

        If Not IsDBNull(zip) Then
            myval = myval & " " & zip

        End If

        Return myval


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

                Return "<img class='shadow' rel='gray' alt=""Model"" src='Eventimages/" & myval & "' width='150' height='150'   border=0 id=""catimg"" name=""catimg"" onclick=""javascript:window.open('Eventimages/" & myval & "')"" Target=""_blank"" style=""cursor:pointer"" />"

            Else
                Return ""
            End If


        End If

    End Function



End Class
