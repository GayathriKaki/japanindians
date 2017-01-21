

<%@ Page Language="VB" MasterPageFile="PWIP_MasterPage.master"  AutoEventWireup="false" CodeFile="CustRegister.aspx.vb" Inherits="CustRegister"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<form id="frm_register"  runat="server">
<table width="100%" border="0" style=" vertical-align :middle; ">
<tr><td colspan="2" align="center"><asp:Label ID="lblwarning" runat="server" Text="Registration Form" Font-Bold="True"></asp:Label></td></tr>
  <tr>
    <td width="50%" align="right">User Full Name :</td>
    <td align="left">
        <asp:TextBox ID="txt_username" runat="server"></asp:TextBox>&nbsp;</td>
  </tr>
 
  
 
 
  <tr>
    <td align="right">Country : </td>
    <td align="left">
        <asp:DropDownList ID="dd_country" runat="server" Width="100"  AutoPostBack="true" ></asp:DropDownList>&nbsp;</td>
  </tr>
   <tr>
    <td align="right">State/Prefecture : </td>
    <td align="left">
        <asp:DropDownList ID="dd_state" OnSelectedIndexChanged="State_click" runat="server" AutoPostBack="true" ></asp:DropDownList>&nbsp;</td>
  </tr>
  <tr>
    <td align="right">City : </td>
    <td align="left">
        <asp:DropdownList ID="dd_city" runat="server" ></asp:DropdownList>&nbsp;</td>
  </tr>
   
  
  
   <tr>
    <td width="50%" align="right" valign="top">Mobile #  :</td>
    <td align="left">
       <asp:TextBox ID="txt_mobile" runat="server"></asp:TextBox>&nbsp;</td>
  </tr>
   <tr>
    <td width="50%" height="54" align="right" valign="top">Address  :</td>
    <td align="left">
       <asp:TextBox ID="txt_address" runat="server" TextMode="MultiLine" Columns="30" Rows="10"></asp:TextBox>&nbsp;</td>
  </tr>
      
  <tr>
    <td	 align="right" >Profile Picture: </td>
    <td style="height: 17px" align="left">&nbsp;<input id="photo5"  runat="server"  name="FImgThumb" type="file" />
   <asp:Label   ID="LblTimg5" runat="server" />
    <asp:HiddenField ID="Hid5" runat="server"   />
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="Chkdel5"  Font-Bold="true"  Text="Delete" runat="server" /> 
    </td>
  </tr>
  
  
  <tr>
    <td align="right">Email : </td>
    <td align="left">
        <asp:TextBox ID="txt_email" runat="server" ></asp:TextBox>&nbsp;</td>
  </tr>
   <tr>
    <td align="right">Password : </td>
    <td align="left">
        <asp:TextBox ID="txt_password" runat="server" TextMode="Password"></asp:TextBox>&nbsp;</td>
  </tr>
 
  <tr>
    <td>&nbsp;</td>
    <td align="left">
        <asp:Button ID="btn_submit" runat="server" Text="Submit" />&nbsp;</td>
  </tr>
</table>
</form>
</asp:Content>

