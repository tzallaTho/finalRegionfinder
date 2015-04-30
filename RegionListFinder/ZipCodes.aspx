<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZipCodes.aspx.cs"
     MasterPageFile="~/Site.Master" 
     Inherits="RegionListFinder.ZipCodes" %>



<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>Ταχυδρομικόι Κωδικοί</h1>
            </hgroup>
            <p>
                &nbsp;</p>
        </div>
    </section>
</asp:Content>



<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <table>
        <tr style="width:300px">
            <td>
            <div  style="text-align:left">Νομός :
                  <asp:DropDownList AutoPostBack="true" runat="server" ID="ddlStates" 
                      onselectedindexchanged="myListDropDown_Change" 
                   Height="20px" Width="140px" />
                </div>
       
               </td>
            <td>
                <div style="text-align:left">TK :
                    <asp:textbox id="txtZip" runat="server" Height="15px"  Width="100px"/>
  
                    <asp:RegularExpressionValidator ID="regexpName" runat="server"  ErrorMessage="5 ΑΡΙΘΜΟΙ" 
                                    ControlToValidate="txtZip" ValidationExpression="^\d{5}$" />

               </div>
            </td>
            <td>
                <div style="text-align:left">Ευρεση Νομού :
                    <asp:textbox id="txtState" runat="server"   Height="15px"  Width="100px"/> </div>
            </td>
        </tr>
       
        
    </table>
  
     
    
    <div>
        <asp:Button ID="addZip" Font-Size="Small" runat="server" Text="Προσθήκη ΤΚ" 
             Width="148px" Height="36px" OnClick="addZip_Click"/>

         <asp:Button ID="btnSearchZip" Font-Size="Small" runat="server" Text="Αναζήτηση ΤΚ" 
             Width="152px" Height="36px" OnClick="btnSearchZip_Click" />
    
    </div>
           
<asp:DataGrid ID="GridViewZips" runat="server" PageSize="10"
     AllowPaging="True" AutoGenerateColumns="False" CellPadding="20"
     ForeColor="#333333" AllowSorting="True" BorderColor="Black" BorderWidth="3px" >
    <Columns>
        <asp:BoundColumn DataField="zip_Desc" HeaderText="Ταχυδρομικός Κωδικός">
            <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:BoundColumn>
        <asp:BoundColumn DataField="nomos" HeaderText="Νομός">
            <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:BoundColumn>
        <asp:BoundColumn DataField="stateId" Visible="False"></asp:BoundColumn>
    </Columns>

    
<SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
<PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" Mode="NumericPages" />
<AlternatingItemStyle BackColor="Silver" />
<ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />
<HeaderStyle BackColor="WhiteSmoke" Font-Bold="True" ForeColor="Black" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
    </asp:DataGrid>

  </asp:Content>
