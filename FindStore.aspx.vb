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

Partial Class FindStore
    Inherits System.Web.UI.Page
   
    Sub Page_Load(ByVal Source As Object, ByVal E As EventArgs) Handles MyBase.Load
        Try

           
            If Not IsPostBack Then
			
			ddCountry_click(1,dd_state)
                'lblQuiltstore.Text = BindData(4)
'                lblStoreOwners.Text = BindData(5)
'                lblCountry.Text = Bindcountry()
'                lblState.Text = Bindstate()
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
        lst.Text = "None"
        lst.Value = ""

        cmb.Items.Insert(0, lst)

        cmb.SelectedIndex = -1

End Sub
Public Sub State_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dd_State.SelectedIndexChanged
if dd_state.SelectedValue<>"" then
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
        lst.Text = "None"
        lst.Value = ""

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

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try

            Dim strdata As str_store
            Dim conobj As clsCon
            Dim Dbobject As New BusinessLayer.DBClass
            Dim ds As New DataSet
            conobj = Session("con")
            Dbobject.Connectionstring = conobj.Connectionstring
            Dbobject.Connect()
            With strdata
                .QueryType = 2
                '.wa_cust_id = Session("custid")
				if dd_state.SelectedValue <> "" then
				.state_id=dd_state.SelectedValue
				end if
				
				if dd_city.SelectedValue <> "" then
				.s_city=dd_city.SelectedValue
				End if
				'Response.write("state=" & dd_state.SelectedValue)
'				Response.write("city=" & dd_city.SelectedValue)

            End With
            ds = Dbobject.Sp_store(strdata, 2, "store")


            Dbobject.close()
            If ds.Tables(0).Rows.Count > 0 Then
                storeslist.DataSource = ds.Tables(0).DefaultView
                storeslist.DataBind()
                ' catlist.Columns(0).Visible = False
            Else
                lblmsg.text = "No Stores Available "

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

                Return "<img class='shadow' rel='gray' alt=""Model"" src='storeimages/" & myval & "' width='150' height='150'   border=0 id=""catimg"" name=""catimg"" onclick=""javascript:window.open('storeimages/" & myval & "')"" Target=""_blank"" style=""cursor:pointer"" />"

            Else
                Return ""
            End If


        End If

    End Function
End Class
