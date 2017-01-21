Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Text
Imports System.Configuration
Imports BusinessLayer.DBClass
Imports JumpyForum.clsDataAccess

Namespace JumpyForum
    
    ''' <summary>
    ''' Summary description for Forum.
    ''' </summary>
    Public Class Forum
        Inherits System.Web.UI.Page
        
        Private articleId As Integer = 0
        
      '  Protected lblnewmessage As System.Web.UI.WebControls.Label
        
       ' Protected lblPaging As System.Web.UI.WebControls.Label
        
        'Protected ltlPost As System.Web.UI.WebControls.Literal
        
        'Protected lbldate As System.Web.UI.WebControls.Label
        
        Private currentCount As Integer = 1
        
        'Protected btnsetpaging As System.Web.UI.WebControls.Button
        
        'Protected myform As System.Web.UI.HtmlControls.HtmlForm
        
        'Protected txtpagesize As System.Web.UI.WebControls.DropDownList
        
        'private int pagesize= 20;
        Public Property PageSize As Integer
            Get
                Dim o As Object = ViewState("PageSize")
                If (o Is Nothing) Then
                    Return 20
                End If
                Return Integer.Parse(o.ToString)
            End Get
            Set
                ViewState("PageSize") = value
            End Set
        End Property
        
        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
            ' Put user code to initialize the page here
            'If Page.IsPostBack Then
'                PageSize = Convert.ToInt32(txtpagesize.SelectedItem.Text)
'                'Response.Write ("<h1>" &txtpagesize.SelectedItem.Text & "::" & PageSize &"</h1>");
'            ElseIf (Not (Request.QueryString("pagesize")) Is Nothing) Then
'                Me.PageSize = Convert.ToInt32(Request.QueryString("pagesize"))
'            End If
           ' txtpagesize.ClearSelection
'            txtpagesize.Items.FindByText(Me.PageSize.ToString).Selected = true
'            Response.Write(("<h1>"  & (PageSize & "</h1>")))
            deletetemp
		
            LoadData
        End Sub
        
        Public Sub deletetemp()
           
            Dim myC As SqlConnection = New SqlConnection
            myC.ConnectionString = ConfigurationSettings.AppSettings("ConnectionString")
            Dim sqlQuery As String = "Delete from TempTable"
            myC.Open
            Dim myCommand As SqlCommand = New SqlCommand
            myCommand.CommandText = sqlQuery
            myCommand.Connection = myC
            Dim i As Integer = myCommand.ExecuteNonQuery
            myC.Close
        End Sub
        
        Private Sub LoadData()
            Dim lastVisit As DateTime = DateTime.Now
            Dim sb As StringBuilder = New StringBuilder
            'string myQuery ="";
            If (Not (Request.QueryString("id")) Is Nothing) Then
                articleId = Convert.ToInt32(Request.QueryString("id"))
            Else
                articleId = 1
            End If
            'Response.Write ("<hr>" & myQuery & "<hr>");
            lblnewmessage.Text = ("<A title='Add a new message to the Article "  _
                        & (articleId & ("' href='newmessage.aspx?id="  _
                        & (articleId & ("'><b><FONT face='Arial' size='2'>New Topic</FONT></b></A>")))))
            Dim myclass1 As New JumpyForum.clsDataAccess
			
				
            myclass1.openConnection
            Dim myReader As SqlDataReader = myclass1.getForumData(articleId)
            Dim mycount As Integer = 1
			
			'response.end()
            If (sb.Length > 0) Then
                sb.Remove(0, sb.Length)
            End If
            
            While myReader.Read
                Dim dt1 As DateTime = DateTime.Now
                Dim dt2 As DateTime = Convert.ToDateTime(myReader("DateAdded").ToString)
                If (mycount = 1) Then
                    lastVisit = Convert.ToDateTime(myReader("DateAdded").ToString)
                ElseIf (DateTime.Compare(lastVisit, dt2) < 0) Then
                    lastVisit = dt2
                End If
                Dim ts As TimeSpan = dt1.Subtract(dt2)
                Dim mytimeago As String = ""
                If (Convert.ToInt32(ts.TotalDays) <> 0) Then
                    mytimeago = (""  _
                                & (Math.Abs(Convert.ToInt32(ts.TotalDays)) & " Days ago"))
                ElseIf ((Convert.ToInt32(ts.TotalMinutes) < 5)  _
                            AndAlso (Convert.ToInt32(ts.TotalHours) = 0)) Then
                    mytimeago = "Just Posted"
                ElseIf ((Convert.ToInt32(ts.TotalMinutes) > 5)  _
                            AndAlso (Convert.ToInt32(ts.TotalHours) = 0)) Then
                    mytimeago = ((Convert.ToInt32(ts.TotalMinutes) Mod 60)  _
                                & " Mins ago")
                ElseIf (Convert.ToInt32(ts.TotalHours) <> 0) Then
                    mytimeago = (""  _
                                & (Convert.ToInt32(ts.TotalHours) & (" Hours "  _
                                & ((Convert.ToInt32(ts.TotalMinutes) Mod 60)  _
                                & " Mins ago"))))
                Else
                    mytimeago = ((Convert.ToInt32(ts.TotalMinutes) Mod 60)  _
                                & " Mins ago")
                End If
                Dim newimg As String = ""
                If (String.Compare(mytimeago, "Just Posted") = 0) Then
                    newimg = "<img src='images/new.gif' border='0' alt=''>"
                End If
                'if(mycount==1)
                'sb.Append("<tr bgcolor='#b7dfd5' id='K1745932k" & mycount & "kOFF'>");
                'else
                If (Not (Request.QueryString("current")) Is Nothing) Then
                    currentCount = Convert.ToInt32(Request.QueryString("current"))
                Else
                    currentCount = 1
                End If
                Dim myMaxCount As Integer = (currentCount + Convert.ToInt32(Me.PageSize))
                Dim myStartCount As Integer = currentCount
                If (currentCount = -1) Then
                    myStartCount = 0
                    myMaxCount = 999
                End If
                If ((mycount < myMaxCount)  _
                            AndAlso (mycount >= myStartCount)) Then
                    sb.Append(("<tr bgcolor='#EDF8F4' id='K1745932k"  _
                                    & (mycount & "kOFF'>")))
                    sb.Append("<td width='100%' colspan='1'>")
                    sb.Append("<table border='0' cellspacing='0' cellpadding='0' width='100%'>")
					if Convert.ToInt32(myReader("parentid")) = 0 Then
					 sb.Append("<tr ><td Colspan='5'  bgcolor='#ffffff'>&nbsp;</td></tr>")
					End IF
                    sb.Append("<tr>")
                    Dim myindent As Integer = 4
                    If (Convert.ToInt32(myReader("Indent") + 1) <= 4) Then
                        myindent = (16 * Convert.ToInt32(myReader("Indent") + 1))
                    ElseIf (Convert.ToInt32(myReader("Indent") + 1) <= 8) Then
                        myindent = (15 * Convert.ToInt32(myReader("Indent") + 1))
                    ElseIf (Convert.ToInt32(myReader("Indent") + 1) <= 16) Then
                        myindent = (14 * Convert.ToInt32(myReader("Indent") + 1))
                    ElseIf (Convert.ToInt32(myReader("Indent") + 1) <= 20) Then
                        myindent = Convert.ToInt32((13.5 * Convert.ToDouble(myReader("Indent"))))
                    ElseIf (Convert.ToInt32(myReader("Indent") + 1) <= 24) Then
                        myindent = (13 * Convert.ToInt32(myReader("Indent") + 1))
                    ElseIf (Convert.ToInt32(myReader("Indent") + 1) <= 28) Then
                        myindent = Convert.ToInt32((12.7 * Convert.ToDouble(myReader("Indent"))))
                    ElseIf (Convert.ToInt32(myReader("Indent") + 1) <= 32) Then
                        myindent = Convert.ToInt32((12.4 * Convert.ToDouble(myReader("Indent"))))
                    End If
                    sb.Append(("<td bgcolor='white' width='2%' align='left'><a name='xxK1745932k"  _
                                    & (mycount & ("kxx'></a><img height='1' width='"  _
                                    & (myindent & "' src='images/ind.gif' alt=''>")))))
                    If (Convert.ToInt32(myReader("CommentType").ToString) = 1) Then
                        sb.Append("<img align='left' src='images/general.gif' alt=''></td>")
                    End If
                    If (Convert.ToInt32(myReader("CommentType").ToString) = 2) Then
                        sb.Append("<img align='left' src='images/info.gif' alt=''> </td>")
                    End If
                    If (Convert.ToInt32(myReader("CommentType").ToString) = 3) Then
                        sb.Append("<img align='left' src='images/answer.gif' alt=''> </td>")
                    End If
                    If (Convert.ToInt32(myReader("CommentType").ToString) = 4) Then
                        sb.Append("<img align='left' src='images/question.gif' alt=''> </td>")
                    End If
                    If (Convert.ToInt32(myReader("CommentType").ToString) = 5) Then
                        sb.Append("<img align='left' src='images/game.gif' alt=''> </td>")
                    End If
                    sb.Append(("<td width='70%' align='left' ><a  id='LinkTrigger"  _
                                    & (mycount & ("' name='K1745932k"  _
                                    & (mycount & ("k' href='K1745932#xxK1745932k"  _
                                    & (mycount & "kxx'>")))))))
                    If (Convert.ToInt32(myReader("Indent") + 1) = 0) Then
                        sb.Append(("<b><FONT face='Arial' size='2'> "  _
                                        & (myReader("Title").ToString & ("</FONT></b></a>"  _
                                        & (newimg & "</td>")))))
                    Else
                        sb.Append(("<FONT face='Arial' size='2'> "  _
                                        & (myReader("Title").ToString & ("</FONT></a>"  _
                                        & (newimg & "</td>")))))
                    End If
                    'DateTime dt = DateTime.Now.CompareTo(Convert.ToDateTime(myReader["DateAdded"].ToString()));
                    sb.Append(("<td valign='bottom' align='right' width='5%' nowrap><a href='"  _
                                    & (myReader("UserProfile").ToString & "'> <img src='images/userinfo.gif'  alt='' title='Click for User Profile' border='0' width='14' height"& _ 
                                    "='15'></a> </td>")))
                    sb.Append(("<td width='10%' align='left' nowrap><font ><b><FONT face='Arial' size='2'>"  _
                                    & (myReader("UserName").ToString & "</FONT></b> </font></td>")))
                    sb.Append(("<td nowrap align='right' width='10%'><font ><b><FONT face='Arial' size='2'>" & mytimeago))
                    sb.Append("</FONT></b> </font></td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append(("<tr id='K1745932k"  _
                                    & (mycount & "kON' style='DISPLAY:none'>")))
                    sb.Append("<td colspan='1' width='100%'>")
                    sb.Append("<table border='0' cellspacing='0' cellpadding='0' width='100%'>")
                    sb.Append("<tr>")
                    sb.Append(("<td><img height='1' width='"  _
                                    & (myindent & "' src='images/ind.gif' alt=''><img align='middle' src='images/blank.gif' height='30' width='28' alt='"& _ 
                                    "'> </td>")))
                    sb.Append("<td bgcolor='#EDF8F4' width='100%'><table border='0' cellspacing='5' cellpadding='0' width='100%'>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table border='0' cellspacing='0' cellpadding='0' width='100%'>")
                    sb.Append("<tr>")
                    sb.Append("<td colspan='2'>")
                    sb.Append(("<font face = 'arial' size='2'>"  _
                                    & (myReader("Description").ToString & "</font>")))
                    '" Time Now:" & dt1 & " DBTime:" &  dt2 &"
                    sb.Append("<br>")
                    sb.Append(" </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr valign='top'>")
                    sb.Append(("<td >[<a href='Reply.aspx?id="  _
                                    & (articleId & ("&CID="  _
                                    & (myReader("ID").ToString & "' title='Reply to this current thread'><font face = arial size=2>Reply</font></a>]")))))
                   
                    sb.Append("</td>")
                    sb.Append(("<td align='right' >[<a href='Delete.aspx?id="  _
                                    & (articleId & ("&CID="  _
                                    & (myReader("ID").ToString & "' ")))))
                    sb.Append("title='Delete this current thread'><font face = arial size=2>Delete</font></a>]")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td colspan='1'><img src='images/t.gif' border='0' width='1' height='6' alt=''></td>")
                    sb.Append("</tr>")
					
                End If
                mycount = (mycount + 1)
                
            End While
            myReader.Close
            myclass1.closeConnection
            If (currentCount = -1) Then
                lblPaging.Text = ("<a title ='First "  _
                            & (Me.PageSize & ("' href='Forum.aspx?id="  _
                            & (articleId & ("&current=" & (1 & ("&pagesize="  _
                            & (Me.PageSize & ("'>First</a>  Prev  <a title='Show All' href='Forum.aspx?id="  _
                            & (articleId & ("&current=-1" & ("&pagesize="  _
                            & (Me.PageSize & ("'><b>"  _
                            & ((mycount - 1) & ("</b> records</a>  Next  <a href='Forum.aspx?id="  _
                            & (articleId & ("&current="  _
                            & ((mycount - Convert.ToInt32(Me.PageSize)) & ("&pagesize="  _
                            & (Me.PageSize & ("' title ='Last "  _
                            & (Me.PageSize & "' >Last</a>  ")))))))))))))))))))))))
            ElseIf (currentCount = 1) Then
                lblPaging.Text = ("First  Prev  <a title='Show All' href='Forum.aspx?id="  _
                            & (articleId & ("&current=-1&pagesize="  _
                            & (Me.PageSize & ("'><b>"  _
                            & ((mycount - 1) & ("</b> records</a>  <a href='Forum.aspx?id="  _
                            & (articleId & ("&current="  _
                            & ((Convert.ToInt32(Me.PageSize) + 1) & ("&pagesize="  _
                            & (Me.PageSize & ("' title ='Next "  _
                            & (Me.PageSize & ("'>Next</a>  <a href='Forum.aspx?id="  _
                            & (articleId & ("&current="  _
                            & ((mycount - Convert.ToInt32(Me.PageSize)) & ("&pagesize="  _
                            & (Me.PageSize & ("' title ='Last "  _
                            & (Me.PageSize & "'>Last</a>  "))))))))))))))))))))))
            ElseIf (currentCount  _
                        = (mycount - Convert.ToInt32(Me.PageSize))) Then
                lblPaging.Text = ("<a href='Forum.aspx?id="  _
                            & (articleId & ("&current=" & (1 & ("&pagesize="  _
                            & (Me.PageSize & ("'>First</a>  <a href='Forum.aspx?&pagesize="  _
                            & (Me.PageSize & ("'  title ='Previous "  _
                            & (Me.PageSize & ("'>Prev</a>  <a title='Show All' href='Forum.aspx?id="  _
                            & (articleId & ("&current=-1&pagesize="  _
                            & (Me.PageSize & ("'><b>"  _
                            & ((mycount - 1)  _
                            & "</b> records</a>  Next  Last  "))))))))))))))))
            ElseIf (mycount  _
                        > (Convert.ToInt32(Me.PageSize) + currentCount)) Then
                If ((currentCount - Convert.ToInt32(Me.PageSize))  _
                            < 0) Then
                    lblPaging.Text = ("<a  title ='First "  _
                                & (Me.PageSize & ("' href='Forum.aspx?id="  _
                                & (articleId & ("&current=" & (1 & ("&pagesize="  _
                                & (Me.PageSize & ("'>First</a>  Prev  <a title='Show All' href='Forum.aspx?id="  _
                                & (articleId & ("&current=-1&pagesize="  _
                                & (Me.PageSize & ("'><b>"  _
                                & ((mycount - 1) & ("</b> records</a>  <a href='Forum.aspx?id="  _
                                & (articleId & ("&current="  _
                                & ((Convert.ToInt32(Me.PageSize) + currentCount) & ("&pagesize="  _
                                & (Me.PageSize & ("' title ='Next "  _
                                & (Me.PageSize & ("'>Next</a>  <a href='Forum.aspx?id="  _
                                & (articleId & ("&current="  _
                                & ((mycount - Convert.ToInt32(Me.PageSize)) & ("&pagesize="  _
                                & (Me.PageSize & ("' title ='Last "  _
                                & (Me.PageSize & "'>Last</a>  "))))))))))))))))))))))))))))))
                Else
                    lblPaging.Text = ("<a  title ='First "  _
                                & (Me.PageSize & ("' href='Forum.aspx?id="  _
                                & (articleId & ("&current=" & (1 & ("&pagesize="  _
                                & (Me.PageSize & ("'>First</a>  <a href='Forum.aspx?id="  _
                                & (articleId & ("&pagesize="  _
                                & (Me.PageSize & ("&current="  _
                                & ((currentCount - Convert.ToInt32(Me.PageSize)) & ("' title ='Previous "  _
                                & (Me.PageSize & ("'>Prev</a>  <a title='Show All' href='Forum.aspx?id="  _
                                & (articleId & ("&current=-1&pagesize="  _
                                & (Me.PageSize & ("'><b>"  _
                                & ((mycount - 1) & ("</b> records</a>  <a href='Forum.aspx?id="  _
                                & (articleId & ("&current="  _
                                & ((Convert.ToInt32(Me.PageSize) + currentCount) & ("&pagesize="  _
                                & (Me.PageSize & ("'  title ='Next "  _
                                & (Me.PageSize & ("'>Next</a>  <a href='Forum.aspx?id="  _
                                & (articleId & ("&current="  _
                                & ((mycount - Convert.ToInt32(Me.PageSize)) & ("&pagesize="  _
                                & (Me.PageSize & ("' title ='Last "  _
                                & (Me.PageSize & "'>Last</a>  "))))))))))))))))))))))))))))))))))))))
                End If
            ElseIf ((currentCount - Convert.ToInt32(Me.PageSize))  _
                        < 0) Then
                lblPaging.Text = ("<a  title ='First "  _
                            & (Me.PageSize & ("' href='Forum.aspx?id="  _
                            & (articleId & ("&current=" & (1 & ("&pagesize="  _
                            & (Me.PageSize & ("'>First</a>  Prev  <a title='Show All' href='Forum.aspx?id="  _
                            & (articleId & ("&current=-1&pagesize="  _
                            & (Me.PageSize & ("'><b>"  _
                            & ((mycount - 1) & ("</b> records</a>  Next  <a href='Forum.aspx?id="  _
                            & (articleId & ("&current="  _
                            & ((mycount - Convert.ToInt32(Me.PageSize)) & ("&pagesize="  _
                            & (Me.PageSize & ("' title ='Last "  _
                            & (Me.PageSize & "'>Last</a>  "))))))))))))))))))))))
            Else
                lblPaging.Text = ("<a  title ='First "  _
                            & (Me.PageSize & ("' href='Forum.aspx?id="  _
                            & (articleId & ("&current=" & (1 & ("&pagesize="  _
                            & (Me.PageSize & ("'>First</a>  <a href='Forum.aspx?id="  _
                            & (articleId & ("&pagesize="  _
                            & (Me.PageSize & ("&current="  _
                            & ((currentCount - Convert.ToInt32(Me.PageSize)) & ("' title ='Previous "  _
                            & (Me.PageSize & ("'>Prev</a>  <a title='Show All' href='Forum.aspx?id="  _
                            & (articleId & ("&current=-1&pagesize="  _
                            & (Me.PageSize & ("'><b>"  _
                            & ((mycount - 1) & ("</b> records</a>  Next  <a href='Forum.aspx?id="  _
                            & (articleId & ("&current="  _
                            & ((mycount - Convert.ToInt32(Me.PageSize)) & ("&pagesize="  _
                            & (Me.PageSize & ("' title ='Last "  _
                            & (Me.PageSize & "'>Last</a>  "))))))))))))))))))))))))))))))
            End If
            ltlPost.Text = sb.ToString
            lbldate.Text = ("Last Visit: "  _
                        & (lastVisit.ToLongTimeString & (",  " & lastVisit.ToLongDateString)))
        End Sub
        #Region "Web Form Designer generated code"
        
        Protected Overrides Sub OnInit(ByVal e As EventArgs)
            '
            ' CODEGEN: This call is required by the ASP.NET Web Form Designer.
            '
            InitializeComponent
            MyBase.OnInit(e)
        End Sub
        
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            AddHandler txtpagesize.SelectedIndexChanged, AddressOf Me.txtpageSize_SelectedIndexChanged
            AddHandler btnsetpaging.Click, AddressOf Me.btnsetpaging_Click
            AddHandler ltlPost.Init, AddressOf Me.ltlPost_Init
            AddHandler Load, AddressOf Me.Page_Load
        End Sub
        #End Region
        
        Private Sub ltlPost_Init(ByVal sender As Object, ByVal e As System.EventArgs)
            
        End Sub
        
        Private Sub btnsetpaging_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            
        End Sub
        
        Private Sub txtpageSize_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            
        End Sub
    End Class
End Namespace

