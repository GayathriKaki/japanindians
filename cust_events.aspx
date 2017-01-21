<%@ Page Language="VB" MasterPageFile="PWIP_MasterPage.master" AutoEventWireup="false" CodeFile="cust_events.aspx.vb" Inherits="cust_events"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width ="100%" id="tblEvents" border="2" bordercolor="#FFFFFF">
 <tr><td align="center" bgcolor="lightblue" colspan="2">

<a href ="event_edit.aspx?action=add"><strong style="font-size:12px; color:#000000; ">Add New Event</strong></a>
</td></tr>
 <tr><td colspan="2"><asp:Label ID ="lblmsg" runat ="server" ></asp:Label></td></tr>

<tr><td colspan="2" valign="middle">



   <asp:datalist id="catlist" runat="server" ItemStyle-HorizontalAlign ="left" DataKeyField ="event_id"  Width ="100%"  RepeatColumns="1 	"   RepeatDirection="horizontal" ItemStyle-VerticalAlign="middle" >
          <ItemTemplate>
         
          <table    border="5" bordercolor="#FFFFFF" width="100%"  cellspacing="2" cellpadding="5"  bgcolor="lightblue">
         
            <tr>
              <td  >
			  <%#GetImgURL(DataBinder.Eval(Container.DataItem, "event_image"), DataBinder.Eval(Container.DataItem, "cust_id"))%>
			  
			
              
           	 </td>
			 <td align="left" width="100%"><table width="100%">
					
					
					  <tr>
					  <td  ><b><%#getedate(DataBinder.Eval(Container.DataItem, "event_date"), DataBinder.Eval(Container.DataItem, "event_time"))%></b>&nbsp;&nbsp;&nbsp;
					  
					 </td>
					</tr>
					<tr>
					  <td  ><b><%#DataBinder.Eval(Container.DataItem, "event_name")%></b>&nbsp;&nbsp;&nbsp;
					  
					 </td>
					</tr>
				   
					
				   
					<tr>
					  <td  ><b><%#DataBinder.Eval(Container.DataItem, "event_location")%></b>&nbsp;&nbsp;&nbsp;
					  
					 </td>
					</tr>
				   
						<tr>
					  <td  ><b>Contact # : <%#DataBinder.Eval(Container.DataItem, "event_telephone")%></b>&nbsp;&nbsp;&nbsp;
					  
					 </td>
					</tr>
					
					 <tr>
					  <td  ><b>Address : <%#DataBinder.Eval(Container.DataItem, "event_address")%></b>&nbsp;&nbsp;&nbsp;
					  
					 </td>
					</tr>
					<tr>
					  <td  ><b><%#getaddr(DataBinder.Eval(Container.DataItem, "event_state"),DataBinder.Eval(Container.DataItem, "event_city"),DataBinder.Eval(Container.DataItem, "event_zip"))%></b>&nbsp;&nbsp;&nbsp;
					  
					 </td>
					</tr>
					 <tr>
					  <td  ><b><a href ='<%#DataBinder.Eval(Container.DataItem, "event_map")%>' target ="_blank" >View Map</a></b>&nbsp;&nbsp;&nbsp;
					  
					 </td>
					</tr>
					
					  <tr>
					  <td  ><b><%#DataBinder.Eval(Container.DataItem, "event_comments")%></b>&nbsp;&nbsp;&nbsp;
					  
					 </td>
					</tr>
				   </table>
				   </td>
				   </tr>
            </table>
          
            
          </ItemTemplate>

        </asp:datalist>
        </td></tr></table>
</asp:Content>

