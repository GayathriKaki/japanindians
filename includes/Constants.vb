Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports BusinessLayer.Struclass
Imports BusinessLayer.DBClass
Imports ConnectionServices
' Created on        Created By
' Dec 10,2008        Gayathri
Namespace BusinessLayer
    
    Public Class Constants
        Public ffmpegpath As String
        Enum RESULT
            NO_ERROR = 1
            INSERT_ERROR = 2
            DELETE_ERROR = 3
            UPDATE_ERROR = 4
            OTHER_ERROR = 5
            LOGIN_SUCCESSFUL = 6
            LOGIN_UNSUCCESSFUL = 7
            CONNECTION_SUCCESSFUL = 8
            CONNECTION_UNSUCCESSFUL = 9

        End Enum

        Public Function dbcheck(ByVal val As Object)
            If Not IsDBNull(val) Then
                Return val
            Else
                Return ""
            End If
        End Function


      

    End Class


    

End Namespace
