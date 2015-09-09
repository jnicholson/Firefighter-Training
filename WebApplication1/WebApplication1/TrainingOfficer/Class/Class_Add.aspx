<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Class_Add.aspx.cs" Inherits="WebApplication1.TrainingOfficer.Class.Class_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <div id="classAddTitle" runat="server" class="ContentHead">
                <h1>Add Class</h1>
            </div>
            <section class="featured">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="LabelAddCourse" runat="server">Course:</asp:Label></td>
                        <td>
                            <asp:DropDownList ID="DropDownAddCourse" runat="server"
                                ItemType="WebApplication1.HalonModels.Course"
                                SelectMethod="GetCourses" DataTextField="Course_Name"
                                DataValueField="Course_ID">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelAddInstructor" runat="server">Instructor:</asp:Label></td>
                        <td>
                            <asp:DropDownList ID="DropDownAddTeacher" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelAddDate" runat="server">Date:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="AddClassDate" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="* Class Date required." ControlToValidate="AddClassDate" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelAddNote" runat="server">Description:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="AddClassNote" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="* Description required." ControlToValidate="AddClassNote" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelAddCancelled" runat="server">Cancel:</asp:Label></td>
                        <td>
                            <asp:CheckBox ID="AddClassCancel" runat="server"></asp:CheckBox>
                        </td>
                    </tr>
                </table>
            </section>
            <p></p>
            <p></p>
            <asp:Button ID="AddClassButton" runat="server" Text="Add Class" OnClick="AddClassButton_Click" CausesValidation="true" />
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>