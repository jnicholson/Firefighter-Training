<%@ Page Title="Users Display" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Display_Users.aspx.cs" Inherits="WebApplication1.Admin.Users.Display_Users" %>

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
            <section class="featured">
                <div id="UserListTitle" runat="server" class="ContentHead">
                    <h1>Users: </h1>
                </div>
                <asp:GridView ID="UserGrid" runat="server" DataSourceID="objAllUsers" OnRowDataBound="Classes_RowDataBound" Width="900px" AutoGenerateColumns="false" BorderWidth="1px">
                    <Columns>
                        <asp:TemplateField HeaderText="Firefighter Name">
                            <ItemTemplate>
                                <asp:Label ID="FirefighterName" runat="server"
                                    CausesValidation="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="UserName" DataField="UserName" />
                        <asp:TemplateField HeaderText="Role">
                            <ItemTemplate>
                                <asp:Label ID="FirefighterRole" runat="server"
                                    CausesValidation="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="ProviderName" DataField="ProviderName" Visible="false" />
                        <asp:BoundField HeaderText="IsOnline" DataField="IsOnline" Visible="false" />
                        <asp:BoundField HeaderText="LastPasswordChangedDate" DataField="LastPasswordChangedDate" Visible="false" />
                        <asp:BoundField HeaderText="PasswordQuestion" DataField="PasswordQuestion" Visible="false" />
                        <asp:BoundField HeaderText="IsLockedOut" DataField="IsLockedOut" Visible="false" />
                        <asp:BoundField HeaderText="Comment" DataField="Comment" Visible="false" />
                        <asp:BoundField HeaderText="Email" DataField="Email" />
                        <asp:BoundField HeaderText="CreationDate" DataField="CreationDate" />
                        <asp:BoundField HeaderText="IsApproved" DataField="IsApproved" Visible="false" />
                        <asp:BoundField HeaderText="LastLockoutDate" DataField="LastLockoutDate" Visible="false" />
                        <asp:BoundField HeaderText="LastLoginDate" DataField="LastLoginDate" />
                        <asp:BoundField HeaderText="LastActivityDate" DataField="LastActivityDate" Visible="false" />
                        <asp:TemplateField HeaderText="Edit/Delete">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="editDeleteBox" onclick="CheckSingleCheckbox(this)" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <asp:ObjectDataSource ID="objAllUsers" runat="server" SelectMethod="GetAllUsers" TypeName="System.Web.Security.Membership"></asp:ObjectDataSource>
            </section>
            <asp:Button ID="AddUserButton" runat="server" Text="Add User" OnClick="AddUserButton_Click" CausesValidation="false" />
            <asp:Button ID="UpdateUserButton" runat="server" Text="Edit User" OnClick="UpdateUserButton_Click" CausesValidation="false" />
            <asp:Button ID="DeleteUserButton" runat="server" Text="Delete User" OnClick="DeleteUserButton_Click" CausesValidation="false" />
            <asp:Label ID="LabelAddStatus" runat="server"></asp:Label>
        </div>
    </section>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>