<%@ Page Language="VB" MasterPageFile="PWIP_MasterPage.master" AutoEventWireup="false" CodeFile="forgot_password.aspx.vb" Inherits="forgot_password" title="Japan Indians" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form id="frmforgotpwd" runat="server">
<table width="100%" height="400px" bgcolor="#FFFFFF" border="0">
<tr><td>&nbsp;</td></tr>
<tr><td  valign="top">
	<table cellpadding="0" cellspacing="0" border="0" width="40%" align="center">
		 <tr>
			<td height="25" colspan="3" align="center" class="login1">
			<asp:Label ID="lbllogin" ForeColor="#000000" runat="server"></asp:Label>&nbsp;</td>
		 </tr>
		 <tr>       
			<td align="center" colspan="3" style="height: 25px;"><span class="login">
			  <asp:Label ID="lblError" runat="server" ForeColor="#000000">&nbsp;</asp:Label>
			</span>
			</td>
     	</tr>
		<tr>
			<td>	
			<table width="100%" align="center" border="1" cellspacing="1" cellpadding="2"  class="main" >
			  <tr class="news">       
				<td  align="center"  colspan="3" >Please Enter your Email Id </td>
			  </tr>
			  <tr>
				<td width="193" height="35" align="right" class="login1" style="width: 100%;text-align :right" >E-mail&nbsp;:&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" Font-Size="8" ControlToValidate="txtUid" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator></td>
				<td width="171" colspan="2" style="width: 167px; text-align:left"><asp:TextBox ID="txtUid" runat="server" Width="160px" /></td>
			  </tr>
			  <tr>
				<td height="25" style="width: 100%;text-align :right" class="login1">&nbsp;</td>
				<td colspan="2" style="width: 167px; text-align:left"><asp:ImageButton ID="image" runat="server"  ImageUrl="images/go.jpg"/></td>
			  </tr>
    		</table>
	
			</td>
		</tr>
	</table>
	</td>
	</tr>
	</table>
</form>
		</asp:Content>


