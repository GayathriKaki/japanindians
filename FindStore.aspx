<%@ Page Language="VB" MasterPageFile="PWIP_MasterPage.master" AutoEventWireup="false" CodeFile="Findstore.aspx.vb" Inherits="FindStore" title="2300 Gladwick " %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form id="frmSearchstore" runat="server">
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="background-color:White">
              <tr><td>&nbsp;</td></tr>
              <tr> 
                <td   align="center"><strong style="color:#0000FF; font-size:16px; color:#024C83;">Find Indian Store/Restaurant/Service Near You</strong><%--<img src="images/header-find-shop2.gif" border="0" width="559" height="38" alt="Find shop" />--%><%--<b>Find A Quilt Shop near you</b>--%></td>
              </tr>
              <tr><td>&nbsp;</td></tr>
             
              <tr> 
                <td>&nbsp;</td>
              </tr>
              <tr>
                <td align="center" style="font-size:12px; ">
				      								
								<table width="70%" border="0">
								
								<tr>
    <td align="right" width="14%" valign="top"><strong>State/Prefecture : </strong></td>
    <td align="left" width="14%" valign="top">
        <asp:DropDownList ID="dd_state" OnSelectedIndexChanged="State_click" runat="server" AutoPostBack="true" ></asp:DropDownList>&nbsp;</td>
 
    <td align="right" width="14%" valign="top"><strong>City :</strong> </td>
    <td align="left" width="14%" valign="top">
        <asp:DropdownList ID="dd_city" runat="server" ></asp:DropdownList>&nbsp;</td>
		<td width="14%" valign="top">&nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server"  Text="Search" /></td>
  </tr>
								
								
								
								
								
								
								
								
								
								
								
								
								
                            
                            </tr>
                          </table>
				    
				  </td>
              </tr> 
              <tr><td>&nbsp;</td></tr>
              <tr> 
                <td    align="center" ><strong style="color:#0000FF; font-size:16px; color:#024C83;">Store/Restaurant Owners</strong>
                </td>
              </tr>
              <tr><td>&nbsp;</td></tr>
             
              <tr> 
                <td align="center">&nbsp;<a href="store_register.aspx"> <b>Click here to Register Your store</b></a></td>
              </tr>
            
         
			
			 <tr> 
                <td>
				    <table width="85%" align="center">
				        <tr>
				            <td align="Center">
					        	        <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
				            </td>
				        </tr>
			        </table>
				</td>
              </tr>
			<tr>
			<td>
			
 <asp:datalist ID="storeslist" runat="server" ItemStyle-VerticalAlign="middle" Width="100%" RepeatColumns="1"  CellSpacing="5"    RepeatDirection="Horizontal" BorderWidth="0">
					<ItemTemplate>			  
						  <table    border="0" bordercolor="#ffffff" width="100%"  cellspacing="5" cellpadding="9"  bgcolor="lightblue">
         
            <tr>
              <td  >
			  <%#GetImgURL(DataBinder.Eval(Container.DataItem, "s_image"), DataBinder.Eval(Container.DataItem, "cust_id"))%>
			  
			
              
           	 </td>
			 <td align="left" width="100%">
			 <table width="100%">
			 	<tr>
                    <td  valign="Top" align="left"  width="100%"  >
					<font size="2"  face="Arial, Helvetica, sans-serif"><b><%# DataBinder.Eval(Container.DataItem, "s_name") %></b>
            <br><%# DataBinder.Eval(Container.DataItem, "s_desc") %>
              		<br />Address:<br><%# DataBinder.Eval(Container.DataItem, "s_address") %>
					             
				  <br><%#Getcity(DataBinder.Eval(Container.DataItem, "s_city")) %>	&nbsp; , 
				  &nbsp;<%#GetState(DataBinder.Eval(Container.DataItem, "state_id"))%>&nbsp;&nbsp;
				  <%# DataBinder.Eval(Container.DataItem, "s_zip") %>
				  <br>
              	  <%#GetData(DataBinder.Eval(Container.DataItem, "s_phone"), "<br>Phone number: ")%>
              	   <%# GetData(DataBinder.Eval(Container.DataItem, "s_contact"),"<br>Contact Person:") %>
                  <a href="mailto:<%# DataBinder.Eval(Container.DataItem, "s_email") %>"><%#GetData(DataBinder.Eval(Container.DataItem, "s_email"), "<br>Email:")%></a>                     
                  <a href="http://<%# Convert.toString(DataBinder.Eval(Container.DataItem, "s_website")).Replace("http://","") %>" target="_blank"><%#GetData(DataBinder.Eval(Container.DataItem, "s_website"), "<br>")%></a>
                 
			
             </font>
			  <br><br>
			  </td>
			 
                                  
                                </tr>                          
                                
                              </table><td></tr></table>
							</ItemTemplate>
	</asp:datalist>
	</td>
	</tr>
			
             </table>
             
         </form>
	 </asp:content>



