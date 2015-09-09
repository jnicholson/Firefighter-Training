<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClassRoster.aspx.cs" Inherits="WebApplication1.TrainingOfficer.Class.ClassRoster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <div id="FirefighterDetailsTitle" runat="server" class="ContentHead">
                <h1 style="width: 900px">Class Roster -
                    <asp:Label ID="FilterLabel" runat="server" Text="All Enrollment"></asp:Label>
                </h1>
            </div>
            <section class="featured">
                <table>
                    <tr>
                        <td style="vertical-align: middle">
                            <asp:Label ID="SelectDeptLabel" runat="server" Text="Display Classes: " />

                            <asp:DropDownList ID="ClassDD" runat="server" ItemType="WebApplication1.HalonModels.Class"
                                SelectMethod="GetClasses" AppendDataBoundItems="true"
                                DataTextField="Class_ID" DataValueField="Class_ID" Style="" Font-Size="Larger">
                                <asp:ListItem Value="0" Text="All" />
                            </asp:DropDownList>

                            <asp:Button runat="server" ID="SubmitButton" Text="Go" OnClick="GetRoster_Click" ToolTip="Show enrollments for this class." Height="25px" />
                        </td>
                    </tr>
                </table>

                <asp:GridView ID="FFRoster" runat="server" AutoGenerateColumns="False" ShowFooter="True" CellPadding="4"
                    ItemType="WebApplication1.HalonModels.Enrollment" CssClass="CartListItem" SelectMethod="GetEnrollments" Width="900px" Font-Size="Larger">
                    <AlternatingRowStyle CssClass="CartListItemAlt" />
                    <Columns>
                        <asp:BoundField HeaderText="Enrollment ID" DataField="Enrollment_ID" />
                        <asp:BoundField DataField="Class.Course.Course_Name" HeaderText="Class Name" HeaderStyle-Font-Size="Medium" HeaderStyle-BackColor="Gray" HeaderStyle-ForeColor="Control" SortExpression="ClassName" />
                        <asp:BoundField DataField="Firefighter.Firefighter_Lname" HeaderText="Last Name" HeaderStyle-Font-Size="Medium" HeaderStyle-BackColor="Gray" HeaderStyle-ForeColor="Control" SortExpression="FirefighterLname" />
                        <asp:TemplateField HeaderText="Edit/Delete">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="editDeleteBox" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle CssClass="CartListFooter" />
                    <HeaderStyle CssClass="CartListHead" />
                </asp:GridView>
            </section>
            <asp:Button ID="DeleteEnrollmentButton" runat="server" Text="Delete Enrollment" OnClick="DeleteEnrollmentButton_Click" CausesValidation="true" />
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>