<%@ Application Language="VB" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="BusinessLayer.DBClass" %>
<%@ Import Namespace="BusinessLayer.clsDataAccess" %>
<%@ Import Namespace="ConnectionServices" %>
<%@ Import Namespace="BusinessLayer.Struclass" %>



<script runat="server">

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup
    End Sub
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub
        
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
        
        'Dim err As System.Exception
        'err = Server.GetLastError()
        'If err.Message = "File does not exist." Then
        '    Dim Oldpath As String
        '    Dim NewPath As String
        '    Dim Incomming As HttpContext
        '    Dim str() As String
        '    Dim couplename As String
        '    Dim name As String
        
        '    Incomming = HttpContext.Current
        '    Oldpath = Incomming.Request.Path
        '    str = Split(Oldpath, "/")
        '    name = str(str.Length - 3)
        '    couplename = str(str.Length - 1)
        '    ' If InStr(Incomming.Request.Path, "index.aspx") = 0 Then
        '    ' If name = "mywedding" Then
        '    Oldpath = Oldpath.Replace("mywedding/", "")
        '    Oldpath = Oldpath.Replace(couplename, "")
        '    Oldpath = Oldpath.Replace("//", "/")
        '    NewPath = Oldpath & "index.aspx?name=" & couplename & ""
            
        '    Server.ClearError()
        '    Me.Context.RewritePath(NewPath)
            
        '    'Incomming.RewritePath(NewPath)
               
        '    'End If
        '    'End If
        
        'End If
        
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
    try
        ' Code that runs when a new session is started
            Dim s As New ConnectionServices
            Dim con As New clsCon
            con = s.GetConInfo("server=DELL; UID=sa; Password=infy@319; Database=japanIndians")
            Application("strCon") = "server=DELL; UID=sa; Password=infy@319; Database=japanIndians;"
           
            session("appurl")="http://www.japan-indians.com/"
          
            Session("con") = con
          
        Catch ex As Exception
            Response.Write(ex.Message)
            Response.End()
    end try
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
    End Sub
     
    Protected Sub Application_BeginRequest(ByVal sender As Object, ByVal e As System.EventArgs)
        
        'Dim err As System.Exception
        'err = Server.GetLastError()
        
        
        '' If Regex.IsMatch(Request.Url.AbsoluteUri, "404;") Then
        ''Session("fcustid")  is Nothing  
            
        'Dim Oldpath As String
        'Dim NewPath As String
        'Dim Incomming As HttpContext
        'Dim str() As String
        'Dim couplename As String
        'Dim name As String
        
        'Incomming = HttpContext.Current
        'Oldpath = Incomming.Request.Path
        
        'str = Split(Oldpath, "/")
        'name = str(str.Length - 3)
        'couplename = str(str.Length - 2)
        'Dim pagename As String
        'pagename = str(str.Length - 1)
        'Dim diff As String
        'Dim urlpath As String
        'urlpath = Request.ServerVariables("url")
        'Response.Write("urlpath=" & urlpath)
        
        'diff = InStr(Oldpath, "itccontent")
        'If InStr(Oldpath, "itccontent") > 0 Then
        '    Incomming.RewritePath("/website1/" & pagename)
        '    Exit Sub
        'End If
            
        'If name = "mywedding" Then
        '    Oldpath = Oldpath.Replace("mywedding/", "")
        '    Oldpath = Oldpath.Replace(couplename & "/", "")
        '    NewPath = Oldpath & "index.aspx?name=" & couplename & ""
        '    Incomming.RewritePath(NewPath)
               
        'End If
            
        'If InStr(Incomming.Request.Path, "index.aspx") = 0 Then
        '    If name = "mywedding" Then
        '        Oldpath = Oldpath.Replace("mywedding/", "")
        '        Oldpath = Oldpath.Replace(couplename & "/", "")
        '        NewPath = Oldpath & "index.aspx?name=" & couplename & ""
        '        Incomming.RewritePath(NewPath)
               
        '    End If
        'End If
        ''End If
    End Sub
</script>