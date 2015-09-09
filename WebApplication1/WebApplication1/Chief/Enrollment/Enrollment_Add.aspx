<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Enrollment_Add.aspx.cs" Inherits="WebApplication1.Chief.Enrollment.Enrollment_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <div id="enrollmentAddTitle" runat="server" class="ContentHead">
                <h1>Add Enrollment</h1>
            </div>
            <section class="featured">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="LabelAddFirefighter" runat="server">Firefighter ID:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="AddFirefighterID" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="* Firefighter ID required." ControlToValidate="AddFirefighterID" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelAddClass" runat="server">Class ID:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="AddClassID" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="* Class ID required." ControlToValidate="AddClassID" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </section>
            <p></p>
            <p></p>
            <asp:Button ID="AddEnrollmentButton" runat="server" OnClick="AddEnrollmentButton_Click" CausesValidation="true" />
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>