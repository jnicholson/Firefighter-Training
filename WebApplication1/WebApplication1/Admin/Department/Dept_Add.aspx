<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dept_Add.aspx.cs" Inherits="WebApplication1.Admin.Department.Dept_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <div id="deptAddTitle" runat="server" class="ContentHead">
                <h1>Add Department</h1>
            </div>
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
                            <asp:TextBox ID="AddDept_FDID" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="Validator1" runat="server" Text="* Department FDID required." ControlToValidate="AddDept_FDID" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelDept_Name" runat="server">Department Name:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="AddDept_Name" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="Validator2" runat="server" Text="* Department Name required." ControlToValidate="AddDept_Name" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelDept_Address" runat="server">Department Address:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="AddDept_Address" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="Validator3" runat="server" Text="* Department Address required." ControlToValidate="AddDept_Address" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelDept_City" runat="server">Department City:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="AddDept_City" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="Validator4" runat="server" Text="* Department City required." ControlToValidate="AddDept_City" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelDept_Tel_No" runat="server">Department Phone(with dash):</asp:Label></td>
                        <td>
                            <asp:TextBox ID="AddDept_Tel_No" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="Validator5" runat="server" Text="* Department Phone Number required." ControlToValidate="AddDept_Tel_No" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelDept_Zip" runat="server">Department Zip:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="AddDept_Zip" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="Validator6" runat="server" Text="* Department Zip required." ControlToValidate="AddDept_Zip" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelDept_Firefighter_ID" runat="server">Department Chief Firefighter ID:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="AddDept_Firefighter_ID" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="Validator7" runat="server" Text="* Department Chief ID required." ControlToValidate="AddDept_Firefighter_ID" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelDept_Count_ID" runat="server">Department County:</asp:Label></td>
                        <td>
                            <asp:DropDownList ID="CountyDD" runat="server" ItemType="WebApplication1.HalonModels.County"
                                SelectMethod="GetCounties" AppendDataBoundItems="true"
                                DataTextField="County_Name" DataValueField="County_ID" Style="" Font-Size="Larger" Width="175px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelDept_Callsign" runat="server">Department Callsign:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="AddDept_Callsign" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="Validator9" runat="server" Text="* Department Callsign required." ControlToValidate="AddDept_Callsign" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </section>
            <asp:Button ID="AddDeptButton" runat="server" Text="Add Department" OnClick="AddDept_Click" CausesValidation="true" />
            <asp:Button ID="UpdateDeptButton" runat="server" Text="Update Department" OnClick="UpdateDept_Click" CausesValidation="true" />
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>