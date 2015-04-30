<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AskRegionData.aspx.cs" 
    MasterPageFile="~/Site.Master"
    Inherits="RegionListFinder.AskRegionData" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>ευρεση πληροφοριών απο web υπηρεσία</h1>
            </hgroup>
            <p>
                &nbsp;</p>
        </div>
    </section>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <div>
        <asp:label runat="server" Text="Ευρεση Πληροφοριών Νομού"></asp:label>
        <asp:TextBox  runat="server" id="txtState" Width="193px"></asp:TextBox>
        <asp:Button runat="server" Width="130px" id="btnFind" Text="Αναζήτηση" OnClick="btnFind_Click" />
        </div>
    <div>
        </div>
    </asp:Content>