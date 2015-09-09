<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Course_Add.aspx.cs" Inherits="WebApplication1.Admin.Course.Course_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <h1>
                <asp:Label ID="AddCourseHeader" runat="server">Add Course:</asp:Label></h1>
            <section class="featured">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="LabelAddCourse" runat="server">Course Name:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="AddCourseName" runat="server" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="* Course Name required." ControlToValidate="AddCourseName" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="LabelAddCourseCreditHours" runat="server">Course Credit Hours:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="AddCourseCreditHours" runat="server" Width="50" MaxLength="3"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="* Course Credit Hours required (0-100)." ControlToValidate="AddCourseCreditHours"
                                SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeFieldValidator" runat="server" Text="* Course Credit Hours must be between 0 and 100."
                                ControlToValidate="AddCourseCreditHours" SetFocusOnError="true" Display="Dynamic" Type="Integer"
                                MinimumValue="0" MaximumValue="100"></asp:RangeValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="LabelAddCourseDiscontinued" runat="server">Course Discontinued:</asp:Label></td>
                        <td>
                            <asp:DropDownList ID="AddCourseDiscontinued" runat="server">
                                <asp:ListItem Text="False" Value="0"></asp:ListItem>
                                <asp:ListItem Text="True" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </section>
            <p></p>
            <p></p>
            <asp:Button ID="AddCourseButton" runat="server" Text="Add Course" OnClick="AddCourseButton_Click" CausesValidation="true" />
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>