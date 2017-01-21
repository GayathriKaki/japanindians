Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Data.SqlClient
Imports System.Web.Mail
Imports System.IO 
'Imports System.Data.Odbc

' Created on        Created By
' Dec 10,2008        Gayathri

Public Class SendMail

    Sub New()

    End Sub
	
    Sub MailSend(ByVal toaddr As String, ByVal fromaddr As String, ByVal subject As String, ByVal bdy As String)
        Try

        
            'Dim mailObj As New System.Web.Mail.MailMessage
'
'            mailObj.From = fromaddr
'            mailObj.To = toaddr
'            mailObj.Subject = subject
'            mailObj.BodyFormat = MailFormat.Html
'            mailObj.Body = bdy
'
'            SmtpMail.SmtpServer = "smtp.gmail.com"
'			'SmtpMail.Smtpport=587
'
'            SmtpMail.Send(mailObj)



         Dim oMessage As New System.Web.Mail.MailMessage()

     

        oMessage.To = toaddr
         oMessage.From = "info@japan-indians.com"

     

        oMessage.Subject = subject
        oMessage.BodyFormat = MailFormat.Html
        oMessage.Body = bdy

        oMessage.Fields.Item("http://schemas.microsoft.com/cdo/configuration/sendusing") = 2
        'oMessage.Fields.Item("http://schemas.microsoft.com/cdo/configuration/smtpserver") = "localhost"
        oMessage.Fields.Item("http://schemas.microsoft.com/cdo/configuration/smtpserver") = "relay-hosting.secureserver.net"
        'oMessage.Fields.Item("http://schemas.microsoft.com/cdo/configuration/smtpserver") = "mail.kkmerchandise.com"

       'oMessage.Fields.Item("http://schemas.microsoft.com/cdo/configuration/smtpserverport") = 25
        
        oMessage.Fields.Item("http://schemas.microsoft.com/cdo/configuration/sendusername") = "info@japan-indians.com"
        oMessage.Fields.Item("http://schemas.microsoft.com/cdo/configuration/sendpassword") = "phani@319"
        oMessage.Fields.Item("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate") = 1
         'System.Web.Mail.SmtpMail.SmtpServer = "localhost"
       'System.Web.Mail.SmtpMail.SmtpServer = "mail.kkmerchandise.com"
         System.Web.Mail.SmtpMail.SmtpServer = "relay-hosting.secureserver.net"
  
        System.Web.Mail.SmtpMail.Send(oMessage)





        Catch ex As Exception

        End Try
    End Sub
	
	
    'Sub MailSend(ByVal strMessageTo As String, ByVal strMessageFrom As String, ByVal strMessageSubject As String, ByVal strMessageBody As String)
'
'
'
'
'         Dim oMessage As New System.Web.Mail.MailMessage()
'
'     
'
'        oMessage.To = strMessageTo
'        oMessage.From = strMessageFrom
'
'     
'
'        oMessage.Subject = strMessageSubject
'        oMessage.BodyFormat = MailFormat.Html
'        oMessage.Body = strMessageBody
'
'        oMessage.Fields.Item("http://schemas.microsoft.com/cdo/configuration/sendusing") = 2
'        'oMessage.Fields.Item("http://schemas.microsoft.com/cdo/configuration/smtpserver") = "localhost"
'        oMessage.Fields.Item("http://schemas.microsoft.com/cdo/configuration/smtpserver") = "localhost"
'        'oMessage.Fields.Item("http://schemas.microsoft.com/cdo/configuration/smtpserver") = "mail.kkmerchandise.com"
'
'        oMessage.Fields.Item("http://schemas.microsoft.com/cdo/configuration/smtpserverport") = 25
'        
'        'oMessage.Fields.Item("http://schemas.microsoft.com/cdo/configuration/sendusername") = "info@kkmerchandise.com"
'        'oMessage.Fields.Item("http://schemas.microsoft.com/cdo/configuration/sendpassword") = "jack21"
'        oMessage.Fields.Item("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate") = 1
'         'System.Web.Mail.SmtpMail.SmtpServer = "localhost"
'       'System.Web.Mail.SmtpMail.SmtpServer = "mail.kkmerchandise.com"
'        'System.Web.Mail.SmtpMail.SmtpServer = "relay-hosting.secureserver.net"
'  
'        System.Web.Mail.SmtpMail.Send(oMessage)
'
'
'
'
'    End Sub
'
'    Sub SendMyMail(ByVal toaddr As String, ByVal fromaddr As String, ByVal subject As String, ByVal bdy As String)
'        Try
'
'        
'            Dim mailObj As New System.Web.Mail.MailMessage
'
'            mailObj.From = fromaddr
'            mailObj.To = toaddr
'            mailObj.Subject = subject
'            mailObj.BodyFormat = MailFormat.Html
'            mailObj.Body = bdy
'
'            SmtpMail.SmtpServer = "localhost"
'            SmtpMail.Send(mailObj)
'        Catch ex As Exception
'
'        End Try
'    End Sub
	
 
End Class
