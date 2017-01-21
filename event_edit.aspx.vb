Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports BusinessLayer.Struclass
Imports BusinessLayer.DBClass
Imports ConnectionServices
Imports System.IO
Partial Class event_edit
    Inherits System.Web.UI.Page
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Try

            Dim strFile1 As String = ""
            Dim SelectedID As String = Request.QueryString("id")
            Dim dt As String = ""


          '  If checkUniqueCode(txt_name.Text.Trim(), SelectedID) = True Then
'                lblWarning.Visible = True
'                lblWarning.Text = "The Event name already exists"
'                txt_name.Focus()
'                Exit Sub
'            End If


            Dim fld As String = ""
            Dim vals As String = ""
            Dim maxid As Int32

            Dim strdata As str_cust_events
            If Request.QueryString("action") = "add" Then
                maxid = getmaxid() + 1
            Else
                maxid = SelectedID

            End If

            Dim fl1 As Boolean

            If FImgThumb.Value <> "" Then

                fl1 = uploadFile("event_photo_img_" & maxid, FImgThumb)
                If fl1 Then
                    strFile1 = "event_photo_img_" & maxid & LCase(Path.GetExtension(FImgThumb.Value))
                End If
            End If
            With strdata

                .event_name = txt_name.Text
                .event_address = txt_address.Text
                .event_city = dd_city.SelectedValue
                .event_comments = txt_comments.Text
                .event_date = txt_date.Text
                .event_location = txt_location.Text
                .event_map = txt_map.Text
                .event_state = dd_state.SelectedValue
                .event_telephone = txt_telephone.Text
                .event_time = txt_time.Text
                .event_website = txt_website.Text
                .event_zip = txt_zip.Text
                .event_image = strFile1

            End With



           ' If Request.QueryString("action") = "add" Then
                'Insert record



                Dim conobj As clsCon
                Dim custname As String = ""
                Dim Dbobject As New BusinessLayer.DBClass
                Dim ds As New DataSet


                conobj = Session("con")
                Dbobject.Connectionstring = conobj.Connectionstring
                Dbobject.Connect()
                With strdata
                    .QueryType = 4
                    .event_name = txt_name.Text
                  '  .event_id = Request.QueryString("id")

                End With
                ds = Dbobject.sp_cust_events(strdata, 2, "events")

                Dbobject.close()





           ' Else
                'update record
'
'
'                ' Dim strdata As str_cust_events
'                Dim conobj As clsCon
'                Dim custname As String = ""
'                Dim Dbobject As New BusinessLayer.DBClass
'                Dim ds As New DataSet
'
'
'                conobj = Session("con")
'                Dbobject.Connectionstring = conobj.Connectionstring
'                Dbobject.Connect()
'                With strdata
'                    .QueryType = 3
'                    .event_id = Request.QueryString("id")
'
'
'                End With
'                ds = Dbobject.sp_cust_events(strdata, 2, "events")
'
'                Dbobject.close()

          '  End If





            BindData()


            lblWarning.Visible = True
            lblWarning.Text = "Updated Successfully"
            Session("pi") = Request.QueryString("pi")
            If Request.QueryString("action") = "add" Then
                clearall()
                Response.Redirect("Cust_events.aspx?pi=" & Request.QueryString("pi") & "&msg=save")
            Else
                Response.Redirect("Cust_events.aspx?pi=" & Request.QueryString("pi") & "&msg=updated")
            End If



        Catch ex As Exception
            Response.Write(ex.ToString())
        End Try
    End Sub


    Public Sub BindData()
        Try



            If Request.QueryString("action") <> "add" Then
                'Edit the values

                Dim strdata As str_cust_events
                Dim conobj As clsCon
                Dim custname As String = ""
                Dim Dbobject As New BusinessLayer.DBClass
                Dim ds As New DataSet


                conobj = Session("con")
                Dbobject.Connectionstring = conobj.Connectionstring
                Dbobject.Connect()
                With strdata
                    .QueryType = 5
                    .event_id = Request.QueryString("id")


                End With
                ds = Dbobject.sp_cust_events(strdata, 2, "events")

                Dbobject.close()

                If ds.Tables(0).Rows.Count > 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item("event_name")) Then
                        txt_name.Text = Trim(ds.Tables(0).Rows(0).Item("event_name"))
                    End If

                    If Not IsDBNull(ds.Tables(0).Rows(0).Item("event_date")) Then
                        txt_date.Text = Trim(ds.Tables(0).Rows(0).Item("event_date"))
                    End If

                    If Not IsDBNull(ds.Tables(0).Rows(0).Item("event_time")) Then
                        txt_time.Text = Trim(ds.Tables(0).Rows(0).Item("event_time"))
                    End If

                    If Not IsDBNull(ds.Tables(0).Rows(0).Item("event_location")) Then
                        txt_location.Text = Trim(ds.Tables(0).Rows(0).Item("event_location"))
                    End If

                    If Not IsDBNull(ds.Tables(0).Rows(0).Item("event_telephone")) Then
                        txt_telephone.Text = Trim(ds.Tables(0).Rows(0).Item("event_telephone"))
                    End If

                    If Not IsDBNull(ds.Tables(0).Rows(0).Item("event_address")) Then
                        txt_address.Text = Trim(ds.Tables(0).Rows(0).Item("event_address"))
                    End If

                    If Not IsDBNull(ds.Tables(0).Rows(0).Item("event_state")) Then
                        dd_state.SelectedValue = Cint(ds.Tables(0).Rows(0).Item("event_state"))
                    End If

                    If Not IsDBNull(ds.Tables(0).Rows(0).Item("event_city")) Then
                        dd_city.SelectedValue = Cint(ds.Tables(0).Rows(0).Item("event_city"))
                    End If

                    If Not IsDBNull(ds.Tables(0).Rows(0).Item("event_zip")) Then
                        txt_zip.Text = Trim(ds.Tables(0).Rows(0).Item("event_zip"))
                    End If

                    If Not IsDBNull(ds.Tables(0).Rows(0).Item("event_website")) Then
                        txt_website.Text = Trim(ds.Tables(0).Rows(0).Item("event_website"))
                    End If

                    If Not IsDBNull(ds.Tables(0).Rows(0).Item("event_map")) Then
                        txt_map.Text = Trim(ds.Tables(0).Rows(0).Item("event_map"))
                    End If

                    If Not IsDBNull(ds.Tables(0).Rows(0).Item("event_comments")) Then
                        txt_comments.Text = Trim(ds.Tables(0).Rows(0).Item("event_comments"))
                    End If

                    If Not IsDBNull(ds.Tables(0).Rows(0).Item("event_image")) Then
                        lblTimg.Text = "<img src='/brwimages/" & Trim(ds.Tables(0).Rows(0).Item("event_image")) & "' width='150' height='150'></img>"
                    End If


                End If

            End If

        Catch ex As Exception
            Response.Write(ex.ToString())


        End Try


    End Sub


    Public Function getmaxid() As Int32
        'Get Max cat_id 
        Dim maxid As Int32 = 0

        Dim strdata As str_cust_events
        Dim conobj As clsCon
        Dim custname As String = ""
        Dim Dbobject As New BusinessLayer.DBClass
        Dim ds As New DataSet


        conobj = Session("con")
        Dbobject.Connectionstring = conobj.Connectionstring
        Dbobject.Connect()
        With strdata
            .querytype = 5

        End With
        ds = Dbobject.sp_cust_events(strdata, 2, "events")
        Dbobject.close()
        If ds.Tables(0).Rows.Count > 0 Then
            If Not ISDBNUll(ds.Tables(0).Rows(0).Item(0)) Then
                maxid = ds.Tables(0).Rows(0).Item(0)
            End If
        End If

        Return maxid
    End Function

    Public Sub clearall()
        txt_name.Text = ""
        '  txtDesc.Text = ""
        'chkhide.Checked = False

    End Sub

    Function checkUniqueCode(ByVal ccode As String, ByVal id As String) As Boolean
        'check for unique name

        Dim strdata As str_cust_events
        Dim conobj As clsCon
        Dim custname As String = ""
        Dim Dbobject As New BusinessLayer.DBClass
        Dim mydscat As New DataSet


        conobj = Session("con")
        Dbobject.Connectionstring = conobj.Connectionstring
        Dbobject.Connect()
        With strdata
            .querytype = 14
            ' .page_id = id

            .event_id = Request.QueryString("id")
            .event_name = ccode

        End With
        mydscat = Dbobject.sp_cust_events(strdata, 2, "events")

        Dbobject.close()
        If mydscat.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function


    Public Function uploadFile(ByVal name As String, ByVal Fle As Object) As Boolean
        Try
            Dim str1, ext As String
            Dim flext As String
            Dim flength As Long
            flength = 1048576
            flext = LCase(Path.GetExtension(Fle.Value))
            If (flext = ".gif") Or (flext = ".jpg") Or (flext = ".jpeg") Or (flext = ".png") Then
                ext = LCase(Path.GetExtension(Fle.Value))
                Dim myFile As HttpPostedFile = Fle.PostedFile
                If Not (Fle.PostedFile Is Nothing) Then
                    If myFile.ContentLength Then
                        str1 = Server.MapPath(".") & "\Eventimages\" & name & ext
                        Fle.PostedFile.SaveAs(str1)
                        Return True
                    Else
                        Return False
                    End If
                End If
            Else
                'lblmessage.Visible = True
                'lblmessage.Text = "Only .gif or .jpg or .png files are allowed"
                Return False
            End If
        Catch ex As Exception
            'lblmessage.Text = "Problem with uploading " & ex.ToString
        End Try
    End Function




    Protected Sub btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Response.Redirect("admin_events.aspx")
    End Sub

    Protected Sub lnkBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkBack.Click
        Response.Redirect("admin_events.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	
        If  IsNothing(Session("custid")) Then
            Response.Redirect("model_login.aspx")
        End If
        If Not IsPostBack Then
		
ddCountry_click(1,dd_state)
            BindData()
        End If
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
        cmb.SelectedIndex = -1

End Sub
Public Sub State_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dd_State.SelectedIndexChanged
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
        dd_City.SelectedIndex = -1


End Sub


End Class
