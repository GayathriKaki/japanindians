<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="store_search.aspx.vb" Inherits="store_search" title="2300 Gladwick " %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table cellpadding="0"  width="952" cellspacing="0" border="0" height="360" >
    <tr>
         <td width="80%"   valign="top" align="center" class="color">
		 <table width="100%" cellpadding="0" cellspacing="0">
		 
            <tr>
              <td height="25" align="left" class="blue">&nbsp;&nbsp;&raquo;&nbsp;
                <asp:Label ID="lblcat" runat="server"></asp:Label>
                 </td>
            </tr>
			 <tr><td>&nbsp;</td></tr>
		 
		 <tr><td align="center"><font   size="+2"><asp:Label ID="lblSearch" runat="server" Text=""></asp:Label></font></td></tr>
		  
         <tr> 
            <td width="100%" align="center"><br /><br />
				   <b><asp:Label ID="lblname" runat="server" Text=""></asp:Label></b><br />
				  </td>
              </tr>
              
      
        
       <%-- <tr>
          <td height="25" align="right">&nbsp;&nbsp;
      <asp:TextBox ID="txtsearch" runat="server" />&nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server"  Text="Search"/>
            &nbsp;&nbsp; </td>
        </tr>--%>
        <tr>
          <td height="25" align="right">&nbsp;&nbsp;
         &nbsp;&nbsp; </td>
        </tr>
        
        <tr>
        <td align="center">
            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
 <asp:datalist ID="storeslist" runat="server"  RepeatColumns="3" BorderWidth="1">
					<ItemTemplate>			  
						<table cellspacing="0"  width="300"  cellpadding="1"  align="left" border="0">
					            <tr>
                                  <td  valign="Top" align="left"  width="100%"  >
								   <font size="2"  face="Arial, Helvetica, sans-serif"><b><%# DataBinder.Eval(Container.DataItem, "s_name") %></b>
             
              	<br />Address:<br><%# DataBinder.Eval(Container.DataItem, "s_address") %>             
			  <br><%# DataBinder.Eval(Container.DataItem, "s_city") %>	&nbsp; , &nbsp;<%#GetState(DataBinder.Eval(Container.DataItem, "state_id"), "state_id")%>&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "s_zip") %>
				  <br><%#GetCountry(DataBinder.Eval(Container.DataItem, "country_id"))%>
              	  <%#GetData(DataBinder.Eval(Container.DataItem, "s_phone"), "<br>Phone number: ")%>
              	   <%# GetData(DataBinder.Eval(Container.DataItem, "s_contact"),"<br>Contact Person:") %>
                  <a href="mailto:<%# DataBinder.Eval(Container.DataItem, "s_email") %>"><%#GetData(DataBinder.Eval(Container.DataItem, "s_email"), "<br>Email:")%></a>                     
                  <a href="http://<%# Convert.toString(DataBinder.Eval(Container.DataItem, "s_website")).Replace("http://","") %>" target="_blank"><%#GetData(DataBinder.Eval(Container.DataItem, "s_website"), "<br>")%></a>
                 
			
             </font>
			  <br><br>
			  </td>
			 
                                  
                                </tr>                          
                                
                              </table>
							</ItemTemplate>
	</asp:datalist>
	 </td>
    </tr>
    
        <tr > 
            <td width="100%" align="center">
				  &nbsp;<br />
				  </td>
              </tr>
			  
			  <tr > 
            <td width="100%" align="center">
			<img src="images/btn_back-to-back.gif" style="cursor:pointer;" onclick="javascript:location.href='findstore.aspx'" width="212" height="39" />
				  
				  </td>
              </tr>
        
		
		  <tr > 
            <td width="100%" align="center">&nbsp;
			
				  
				  </td>
              </tr>
    
    <%-- <tr > 
            <td width="100%" align="center" class="blue">
				   <b>International Stores</b><br />
				  </td>
              </tr>
        
         
      <tr> 
            <td width="100%">
				    <table width="800px" align="center" border="0" cellpadding="5" cellspacing="5">
				        <tr>
				            <td align="left" >						
                                <asp:Label ID="lblState" runat="server" Text="State" ></asp:Label>			
                               <asp:Label ID="lblCountry" runat="server" Text="Country"></asp:Label>	
				            </td>
				        </tr>
				    </table>
				  </td>
              </tr>     --%>  
    
  </table>

 
 
   </td>
  </tr>
  </table>
 
 
 
 </asp:Content>


