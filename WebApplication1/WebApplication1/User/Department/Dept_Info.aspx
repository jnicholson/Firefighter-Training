<%@ Page Title="Update" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dept_Info.aspx.cs" Inherits="WebApplication1.User.Department.Dept_Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <h1>Department Information</h1>
            <section class="featured">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelDept_FDID" runat="server">Department FDID:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="Dept_Info_FDID" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelDept_Name" runat="server">Department Name:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="Dept_Info_Name" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelDept_Address" runat="server">Department Address:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="Dept_Info_Address" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelDept_City" runat="server">Department City:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="Dept_Info_City" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelDept_Tel_No" runat="server">Department Phone(with dash):</asp:Label></td>
                        <td>
                            <asp:TextBox ID="Dept_Info_Tel_No" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelDept_Zip" runat="server">Department Zip:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="Dept_Info_Zip" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelDept_Firefighter_ID" runat="server">Department Chief Firefighter ID:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="Dept_Info_Firefighter_ID" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelDept_Count_ID" runat="server">Department County ID:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="Dept_Info_Count_ID" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelDept_Callsign" runat="server">Department Callsign:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="Dept_Info_Callsign" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </section>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>