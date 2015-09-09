<%@ Page Title="Update User" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Update_User.aspx.cs" Inherits="WebApplication1.Admin.Users.Update_User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <h1>
                <asp:Label ID="UpdateUserHeader" runat="server">Update User:</asp:Label></h1>
            <section class="featured">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="LabelUpdateCourse" runat="server">Username:</asp:Label></td>
                        <td>
                            <asp:Label ID="LabelUsername" runat="server"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="LabelUpdateFFighter" runat="server">Firefighter:</asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownUpdateFireFighter" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="LabelUpdateRole" runat="server">Role:</asp:Label>
                        </td>

                        <td>
                            <asp:DropDownList ID="DropDownUpdateRole" runat="server" SelectMethod="GetRoles">
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="LabelUpdateUserEmail" runat="server">New E-mail:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="UpdateUserEmail" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="* Email required." ControlToValidate="UpdateUserEmail"
                                SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </section>
            <p></p>
            <p></p>
            <asp:Button ID="UpdateUserButton" runat="server" Text="Update User" OnClick="UpdateUserButton_Click" CausesValidation="true" />
            <asp:Label ID="LabelUpdateStatus" runat="server"></asp:Label>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>