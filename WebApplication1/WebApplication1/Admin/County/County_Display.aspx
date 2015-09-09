<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="County_Display.aspx.cs" Inherits="WebApplication1.Admin.County.County_Display" %>

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
            <div id="DepartmentListTitle" runat="server" class="ContentHead">
                <h1>Departments: </h1>
            </div>
            <section class="featured">
                <asp:GridView ID="CountyList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Both" CellPadding="4"
                    ItemType="WebApplication1.HalonModels.County" OnRowDataBound="Counties_RowDataBound" CssClass="CartListItem" SelectMethod="GetCounties" Width="600">
                    <AlternatingRowStyle CssClass="CartListItemAlt" />
                    <Columns>
                        <asp:BoundField DataField="County_ID" HeaderText="ID" />
                        <asp:BoundField DataField="County_Name" HeaderText="Name" />
                        <asp:TemplateField>
                            <ItemTemplate>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit/Delete">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="editDeleteBox" onclick="CheckSingleCheckbox(this)" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </section>
            <asp:Button ID="UpdateCountyButton" runat="server" Text="Update County" OnClick="UpdateCountyButton_Click" CausesValidation="false" />
            <asp:Button ID="RemoveCountyButton" runat="server" Text="Remove County" OnClick="RemoveCountyButton_Click" CausesValidation="false" />
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>