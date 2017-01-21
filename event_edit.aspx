<%@ Page Language="VB" MasterPageFile="PWIP_MasterPage.master" AutoEventWireup="false" CodeFile="event_edit.aspx.vb" Inherits="event_edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script language="javascript" type="text/javascript" src="js/datetimepicker.js"></script>
<form id="frmAddEvent" runat="server">
  <table width="100%" border="0" cellspacing="1" cellpadding="2"  class="main" align="center" >
  <tr><td colspan="2" align="left">
      <asp:LinkButton ID="lnkBack" runat="server" Font-Bold="true" Visible="false" CausesValidation="False"><< Back</asp:LinkButton></td></tr>
      
      <tr>
      <td colspan="2" align="center" class="tblhead"><b><font color="#000000">Manage Events </font></b></td>
    </tr>
   
    <tr>
      <td colspan="2" align="center"><asp:Label  id="lblWarning" Visible="false" Font-Bold="true" Text="lbl" runat="server"></asp:Label></td>
    </tr>
    <tr>
      <td colspan="2" align="center">&nbsp;</td>
    </tr>
    <tr>
      <td align="right" width="50%"><strong>Event Name :</strong></td>
      <td  align="left"><asp:TextBox ID="txt_name" runat="server"   Width="230"/></td>
    </tr>
   
   
     <tr>
      <td align="right"><strong>Event Date :</strong></td>
      <td  align="left"><asp:TextBox ID="txt_date" runat="server"   Width="230"/>&nbsp; <a href="javascript:NewCal('ctl00_ContentPlaceHolder1_txt_date','ddmmmyyyy',true,12)"><img src="images/cal.gif" width="16" height="16" border="0"></a></td>
    </tr>
    
    
      <tr>
      <td align="right"><strong>Event Time :</strong></td>
      <td  align="left"><asp:TextBox ID="txt_time" runat="server"   Width="230"/></td>
    </tr>
      <tr>
      <td align="right"><strong>Event Location :</strong></td>
      <td  align="left"><asp:TextBox ID="txt_location" runat="server"   Width="230"/></td>
    </tr>
   
     <tr>
      <td align="right"><strong>Telephone :</strong></td>
      <td  align="left"><asp:TextBox ID="txt_telephone" runat="server"   Width="230"/></td>
    </tr>
    
      <tr>
      <td align="right"><strong>Event Address :</strong></td>
      <td  align="left"><asp:TextBox ID="txt_address" TextMode ="multiLine" Rows ="5" Columns ="10" runat="server"   Width="230"/></td>
    </tr>
    
    <tr>
    <td align="right"><strong>State/Prefecture :</strong> </td>
    <td align="left">
        <asp:DropDownList ID="dd_state" OnSelectedIndexChanged="State_click" runat="server" AutoPostBack="true" ></asp:DropDownList>&nbsp;</td>
  </tr>
  
  <tr>
    <td align="right"><strong>City : </strong></td>
    <td align="left">
        <asp:DropdownList ID="dd_city" runat="server" ></asp:DropdownList>&nbsp;</td>
  </tr>
    
      <tr>
      <td align="right"><strong>Zip code :</strong></td>
      <td  align="left"><asp:TextBox ID="txt_zip" runat="server"   Width="230"/></td>
    </tr>
    
      <tr>
      <td align="right"><strong>Website URL :</strong></td>
      <td  align="left"><asp:TextBox ID="txt_website" runat="server"   Width="230"/></td>
    </tr>
    
      <tr>
      <td align="right"><strong>Map :</strong></td>
      <td  align="left"><asp:TextBox ID="txt_map" runat="server"   Width="230"/></td>
    </tr>
    
      <tr>
      <td align="right"><strong>Comments :</strong></td>
      <td  align="left"><asp:TextBox ID="txt_comments" Rows="4" Columns="27" TextMode="MultiLine" runat="server"   Width="230"/></td>
    </tr>
    
    <tr>
      <td align="right" style="height: 45px"><strong>Upload Picture:</strong></td>
      <td align="left" style="height: 45px"><input type="file" name="FImgThumb" id="FImgThumb"  runat="server"/>
        &nbsp;
        <asp:Label ID="lblTimg" runat="server"></asp:Label>  <br />      
       </td>
    </tr>
   
    
    <tr>
      <td>&nbsp;</td>
      <td align="left"><asp:Button ID="btnSubmit" Text="Submit" runat="server" />
        &nbsp;
        <asp:Button ID="btncancel" Text="&nbsp;Back&nbsp;" runat="server" />
          &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
    </tr>
    <tr >
      <td colspan="2">&nbsp;</td>
    </tr>
</table>

</form>

</asp:Content>

