<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertOrUpdate.aspx.cs"   MasterPageFile="~/Site.Master"
    Inherits="RegionListFinder.InsertOrUpdate" %>





<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>Δεδομένα Περιοχής</h1>
            </hgroup>
            <p>
                &nbsp;</p>
        </div>
    </section>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <div>
        <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" ForeColor="Red"
           
                ValidationGroup="RegionValidationGroup" /> 
        <table style="width:500px">
            <tr><td>
                 <asp:Label  CssClass="label" runat="server" style="text-align:left" text="Νομός :"></asp:Label>

                </td> <td>  <asp:dropdownlist id="ddlStates" runat="server"  
                     AutoPostBack="true"  Height="20px" Width="100%" OnSelectedIndexChanged="ddlStates_SelectedIndexChanged1" 
                      />    </td> <td></td></tr>
            <tr><td> <asp:Label  CssClass="label" runat="server" text="TK:" style="text-align:left"></asp:Label></td><td>
                 <asp:dropdownlist id="ddlZips" runat="server"  EnableViewState="true" Height="20px" Width="100%"  />  
               
                                                                   </td><td></td></tr>
            <tr>
                <td style="width:auto">
                    <asp:Label ID="Label1" runat="server" CssClass="label" Text="Ονομασία Περιοχής:" Width="100%"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtState"  runat="server" Width="100%" ></asp:TextBox>
                    </td><td></td>
                 </tr>
            <tr><td> <asp:RequiredFieldValidator runat="server" ForeColor="Red" Font-Size="Large" 
                 ID="RequiredFieldValidator1"
                    ControlToValidate="txtState" ErrorMessage="Υποχρεωτικό πεδίο,Ελληνικοί χαρακτήρες"
                 ToolTip="Υποχρεωτικό πεδίο."
                    ValidationGroup="RegionValidationGroup">*</asp:RequiredFieldValidator></td><td><td></td></tr>
                    
             
                
           
        </table>
 
               
    </div>
    <footer>
        <asp:Button ID="btnInsDeviceOk" runat="server" Width="20%" class="button" Text="Προσθήκη"
                    
                    ValidationGroup="RegionValidationGroup" OnClick="btnInsDeviceOk_Click" /> 

        <br />
        <asp:Label ID="lblResult" runat="server" Text="Label" Visible="false"></asp:Label>

    </footer>
  </asp:Content>
