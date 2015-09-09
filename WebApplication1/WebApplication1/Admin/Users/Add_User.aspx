<%@ Page Title="Add Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add_User.aspx.cs" Inherits="WebApplication1.Admin.Users.Add_User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <h1>
                <asp:Label ID="AddUserHeader" runat="server">Add User:</asp:Label></h1>
            <section class="featured">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="LabelAddUsername" runat="server">Username:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="AddUsername" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="* Userame required." ControlToValidate="AddUsername" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="LabelAddUserPassword" runat="server">Password:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="AddUserPassword" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="* Password required." ControlToValidate="AddUserPassword"
                                SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="LabelAddUserEmail" runat="server">E-mail:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="AddUserEmail" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="* Email required." ControlToValidate="AddUserEmail"
                                SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </section>
            <p></p>
            <p></p>
            <asp:Button ID="AddUserButton" runat="server" Text="Add User" OnClick="AddUserButton_Click" CausesValidation="true" />
            <asp:Label ID="LabelAddStatus" runat="server"></asp:Label>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>