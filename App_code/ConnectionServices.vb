Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports BusinessLayer.DBClass

<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class ConnectionServices
     Inherits System.Web.Services.WebService


    Private clsConobj As New clsCon
    <WebMethod()> Public Function GetConInfo(ByVal constring As String) As clsCon
        '---Returns the PlaneDetails serializable object
        clsConobj = New clsCon(constring)
        Return clsConobj
    End Function
    <WebMethod()> _
    Public Function ConnectionStatus(ByVal value As clsCon) As Boolean

        Try
            Dim Dbobject As New BusinessLayer.DBClass
            Dbobject.Connectionstring = value.Connectionstring
            Dbobject.Connect()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
<Serializable()> Public Class clsCon
    'non-default constructor, takes input parameters 
    Dim m_Connectionstring As String
  
    Public Property Connectionstring() As String
        Get
            Return m_Connectionstring
        End Get
        Set(ByVal value As String)
            m_Connectionstring = value
        End Set
    End Property
    Public Sub New(ByVal value As String)

        m_Connectionstring = value
    End Sub
    
     

    Public Sub New()

    End Sub

End Class



