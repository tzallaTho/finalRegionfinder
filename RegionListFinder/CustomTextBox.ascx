<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomTextBox.ascx.cs" Inherits="RegionListFinder.ModalPopUp" %>


    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
<script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
<link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
    rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $("[id*=btnPopup]").live("click", function () {
        $("#dialog").dialog({
            title: "jQuery Dialog Popup",
            buttons: {
                Close: function () {
                    $(this).dialog('close');
                }
            }
        });
        return false;
    });
</script>

<div id="dialog" style="display: none" >
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
     <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
</div>
   