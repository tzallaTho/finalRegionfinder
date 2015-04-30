<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RegionListFinder._Default" %>

 

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>Βασική Οθόνη Περιοχών</h1>
            </hgroup>
            <p>
                &nbsp;</p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Βασικός Πίνακας Περιοχών:</h3>
    
    <table><tr>
    <td>
            
<asp:DataGrid ID="GridViewBasic" runat="server" PageSize="10" AllowPaging="True"
     AutoGenerateColumns="False" CellPadding="20" ForeColor="#333333" 
    AllowSorting="True" BorderColor="Black" BorderWidth="3px" ShowFooter="True" OnItemCommand="GridViewBasic_ItemCommand">

<Columns>
    
<asp:BoundColumn HeaderText="Ονομασία Περιοχής" DataField="name" ReadOnly="True">
    <HeaderStyle Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" />
    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" />
    </asp:BoundColumn>
        <asp:BoundColumn HeaderText="Νομός" DataField="descr" ReadOnly="True">
            <HeaderStyle Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" />
    </asp:BoundColumn>
            
        <asp:BoundColumn DataField="zipId" Visible="False"></asp:BoundColumn>
    <asp:BoundColumn DataField="stateId" Visible="False"></asp:BoundColumn>
    <asp:BoundColumn DataField="zipDesc" HeaderText="TK"></asp:BoundColumn>
            
        <asp:ButtonColumn  CommandName="Edit" HeaderText="Μεταβολή" Text="Select" >
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" />
    </asp:ButtonColumn>
            
        </Columns>



<SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />

<PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" Mode="NumericPages" />

<AlternatingItemStyle BackColor="Silver" />

<ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />

<HeaderStyle BackColor="WhiteSmoke" Font-Bold="True" ForeColor="Black" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />

</asp:DataGrid>
        
      
            </td><td><a id="lnkInsertDevice"  href="InsertOrUpdate.aspx" 
                 style="color:#461b1b; large;vertical-align:top;margin-top:2px;margin-right:2px;"
                  >Προσθήκη Περιοχής</a></td> 
</tr></table>
 

    
</asp:Content>
