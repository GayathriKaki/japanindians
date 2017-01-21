Imports System.Data
Imports System.Data.Odbc
Partial Class store_search
    Inherits System.Web.UI.Page
    Public MyConn As OdbcConnection
    Sub Page_Load(ByVal Source As Object, ByVal E As EventArgs) Handles MyBase.Load

        Try

if Request.QueryString("key")<>"" then
lblSearch.Text="Store Search for """ & Request.QueryString("key") & """"
end if
       
            MyConn = New OdbcConnection(Application("strCon"))
            If Not IsPostBack Then
                BindData(1)
                'lblState.Text = Bindstate()

                If Request.QueryString("state") <> "" Then
                    lblname.Text = "Stores in " & GetState(Request.QueryString("state"), "state_abbv")
                    lblcat.Text = "National Stores"

                End If
                If Request.QueryString("name") <> "" Then
                    ' lblname.Text = "Stores in " & Request.QueryString("name")
                    If Request.QueryString("c_id") <> "" Then
                        lblcat.Text = "International Stores  "
                        lblname.Text = "Stores in " & Request.QueryString("name")

                    Else
                        lblname.Text = "Stores in " & Request.QueryString("name")
                        lblcat.Text = "National Stores"



                    End If

                End If

             '   lblCountry.Text = Bindcountry()
            End If
        Catch ex As Exception

            Response.Write(ex.ToString())

        End Try
    End Sub

   ' Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
'        BindData(3)
'    End Sub


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

    Function Bindcountry()
        Try

            ' Dim strConn As String
            Dim MySQL As String
            Dim content As String = ""
            Dim i As Integer
            Dim td As Integer = 1
            ' strConn = System.Configuration.ConfigurationSettings.AppSettings("dbConnection")
            MySQL = "Select * from country where country_id<>1 order by country_name"
            ' lblcat.Text = "Collections"
            content = "<table width='100%'><tr>"
            ' Dim MyConn As New OdbcConnection(strConn)
            If MyConn.State = ConnectionState.Closed Then
                MyConn.Open()
            End If
            Dim ds As DataSet = New DataSet()
            Dim Cmd As New OdbcDataAdapter(MySQL, MyConn)
            Cmd.Fill(ds, "country")

            ' content = content & "<td height='26px'><img src='images/divider-dot.gif' border=0><a href='store_search.aspx?c_id=1&name=USA'>&nbsp;USA</a></td>"

            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    td = td + 1
                    ' If Not IsDBNull(ds.Tables(0).Rows(0).Item("page_content")) Then
                    content = content & "<td height='26px'><img src='images/divider-dot.gif' border=0><a href='store_search.aspx?c_id=" & ds.Tables(0).Rows(i).Item("country_id") & "&name=" & ds.Tables(0).Rows(i).Item("country_name") & "'>&nbsp;" & ds.Tables(0).Rows(i).Item("country_name") & "</a></td>"
                    ' End If
                    If td Mod 4 = 0 And td > 3 Then
                        content = content & "</tr><tr>"
                    End If


                Next

                content = content & "</tr></table>"


            End If

            MyConn.Close()

            Return content

        Catch ex As Exception

        End Try
    End Function

    Public Function GetState(ByVal stateId As String, ByVal state_id As String) As String


        Try
            Dim mystatecon As OdbcConnection
            Dim MySQL, state As String
            Dim ds As DataSet = New DataSet()
            mystatecon = New OdbcConnection(Application("strCon"))

            If mystatecon.State = ConnectionState.Closed Then
                mystatecon.Open()
            End If

            MySQL = "select * from state where   " & state_id & "='" & stateId & "'"

            ' Response.Write(MySQL)
            ' Response.End()

            Dim Cmd As New OdbcDataAdapter(MySQL, mystatecon)
            Cmd.Fill(ds, "state")
            If ds.Tables("state").Rows.Count > 0 Then
                state = ds.Tables("state").Rows(0).Item("state_name")
            Else
                state = ""
            End If
            mystatecon.Dispose()
            mystatecon.Close()

            Return state

        Catch ex As Exception
            Response.Write(ex.ToString())

        End Try

    End Function
    Public Function GetCountry(ByVal countryId As Integer) As String

        Try
            Dim mystatecon As OdbcConnection
            Dim MySQL, country As String
            Dim ds As DataSet = New DataSet()
            mystatecon = New OdbcConnection(Application("strCon"))

            If mystatecon.State = ConnectionState.Closed Then
                mystatecon.Open()
            End If

            MySQL = "select * from country where country_id=" & countryId
            Dim Cmd As New OdbcDataAdapter(MySQL, mystatecon)
            Cmd.Fill(ds, "country")
            If ds.Tables("country").Rows.Count > 0 Then
                country = ds.Tables("country").Rows(0).Item("country_name")
            Else
                country = ""
            End If
            mystatecon.Dispose()
            mystatecon.Close()

            Return country

        Catch ex As Exception

        End Try


    End Function
    Sub BindData(ByVal type As Integer)
        Try

            ' Dim strConn As String
            lblmsg.Text = ""
            ' strConn = System.Configuration.ConfigurationSettings.AppSettings("dbConnection")
            Dim MySQL As String
            ' Dim state_id As String
            ' Dim MyConn As New OdbcConnection(strConn)
            Dim ds As DataSet = New DataSet()
            If type = 1 Then
                If Request.QueryString("state_id") <> "" Then
                    MySQL = "select * from store where state_id=" & Request.QueryString("state_id")

                ElseIf Request.QueryString("c_id") <> "" Then

                    MySQL = "select * from store where country_id=" & Request.QueryString("c_id")

                ElseIf Request.QueryString("state") <> "" Then
                    MySQL = "select store.* from state inner join store on store.state_id=state.state_id  where state.state_abbv='" & Request.QueryString("state") & "'"
                ElseIf Request.QueryString("key") <> "" Then
                    MySQL = "select store.* from state inner join store on  store.state_id=state.state_id " & _
                    "  inner join country on store.country_id = country.country_id  where state_abbv like '%" & _
                    Trim(Request.QueryString("key")) & "%' or country_name ='" & Trim(Request.QueryString("key")) & _
                    "' or state_name like '%" & Trim(Request.QueryString("key")) & "%' or s_name like '%" & _
                    Trim(Request.QueryString("key")) & "%' or s_city like '%" & Trim(Request.QueryString("key")) & _
                    "%' or s_address like '%" & Trim(Request.QueryString("key")) & "%'"

                Else
                    MySQL = "select * from store"

                End If

            Else

                MySQL = "select * from store"
                'MySQL = "select * from store where s_name like '%" & txtsearch.Text & "%' or s_city like '%" & txtsearch.Text & "%' or s_address like '%" & txtsearch.Text & "%'"

                ' MySQL = "select store.* from state inner join store on  store.state_id=state.state_id " & _
                '               "  inner join country on store.country_id = country.country_id  where state_abbv like '%" & _
                '              txtsearch.Text.Trim() & "%' or country_name ='" & Trim(txtsearch.Text) & _
                '               "' or state_name like '%" & txtsearch.Text.Trim() & "%' or s_name like '%" & _
                '               txtsearch.Text.Trim() & "%' or s_city like '%" & txtsearch.Text.Trim() & _
                '               "%' or s_address like '%" & txtsearch.Text.Trim() & "%'"

            End If

            ' Response.Write("MySQL=" & MySQL)
            If MyConn.State = ConnectionState.Closed Then
                MyConn.Open()
            End If
            Dim Cmd As New OdbcDataAdapter(MySQL, MyConn)
            Cmd.Fill(ds, "store")
            If ds.Tables(0).Rows.Count > 0 Then
            Else

                If Request.QueryString("name") <> "" Then
                    lblmsg.Text = "<b>No stores Available in " & Request.QueryString("name") & "</b>"
                    lblname.Text = ""
                Else
                    lblmsg.Text = "<b>No stores Available in selected State</b>"
                    lblname.Text = ""

                End If

            End If
            storeslist.DataSource = ds.Tables("store").DefaultView
            storeslist.DataBind()


            'MyConn.Dispose()
            MyConn.Close()


        Catch ex As Exception

        End Try
    End Sub

    Function Bindstate()
        Try

            Dim MySQL As String
            Dim content As String = ""
            Dim i As Integer
            MySQL = "Select * from state order by state_name"
            If MyConn.State = ConnectionState.Closed Then
                MyConn.Open()
            End If
            Dim ds As DataSet = New DataSet()
            Dim Cmd As New OdbcDataAdapter(MySQL, MyConn)
            Cmd.Fill(ds, "state")
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    ' If Not IsDBNull(ds.Tables(0).Rows(0).Item("page_content")) Then
                    content = content & " <img src='images/divider-dot.gif' border=0>  <a href='store_search.aspx?state_id=" & ds.Tables(0).Rows(i).Item("state_id") & "&name=" & ds.Tables(0).Rows(i).Item("state_name") & "'>&nbsp;" & ds.Tables(0).Rows(i).Item("state_name") & "</a>"
                    ' End If 
                Next
            End If

            MyConn.Close()

            Return content

        Catch ex As Exception

        End Try
    End Function
End Class
