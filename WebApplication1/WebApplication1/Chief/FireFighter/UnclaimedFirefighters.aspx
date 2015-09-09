<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UnclaimedFirefighters.aspx.cs" Inherits="WebApplication1.Chief.FireFighter.UnclaimedFirefighters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function CheckSingleCheckbox(ob) {
            var grid = ob.parentNode.parentNode.parentNode;
            var inputs = grid.getElementsByTagName("input");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox") {
                    if (ob.checked && inputs[i] != ob && inputs[i].checked) {
                        inputs[i].checked = false;
                    }
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <div id="FirefighterListTitle" runat="server" class="ContentHead">
                <h1>Firefighters: </h1>
            </div>
            <section class="featured">
                <asp:GridView ID="FirefighterList" runat="server" AutoGenerateColumns="False" ShowFooter="True" CellPadding="4"
                    ItemType="WebApplication1.HalonModels.Firefighter" CssClass="CartListItem" SelectMethod="GetFirefighters" Width="600px">
                    <AlternatingRowStyle CssClass="CartListItemAlt" />
                    <Columns>
                        <asp:BoundField DataField="Firefighter_ID" HeaderText="ID" SortExpression="FirefighterID" />
                        <asp:BoundField DataField="Firefighter_Rank" HeaderText="Rank" SortExpression="FirefighterRank" />
                        <asp:BoundField DataField="Firefighter_Lname" HeaderText="Last Name" SortExpression="FirefighterLname" />
                        <asp:BoundField DataField="Firefighter_Fname" HeaderText="First Name" SortExpression="FirefighterFname" />
                        <asp:TemplateField HeaderText="Claim Firefighter">
                            <ItemTemplate>
                                <asp:CheckBox ID="ClaimBox" runat="server"></asp:CheckBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle CssClass="CartListFooter" />
                    <HeaderStyle CssClass="CartListHead" />
                </asp:GridView>
            </section>
            <asp:Button ID="ClaimFirefighterButton" runat="server" Text="Claim" OnClick="ClaimFirefighter" CausesValidation="false" />
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>