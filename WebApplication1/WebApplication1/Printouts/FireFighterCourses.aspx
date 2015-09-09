<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FireFighterCourses.aspx.cs" Inherits="WebApplication1.Printouts.FireFighterCourses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <div id="FirefighterDetailsTitle" runat="server" class="ContentHead">
                <h1>
                    <asp:Literal ID="litHeader" runat="server" />
                </h1>
            </div>
            <h3>
                <asp:Literal ID="hours" runat="server" /></h3>
            <section class="featured">

                <div style="overflow: auto">
                    <asp:GridView ID="Classes" runat="server" AutoGenerateColumns="False"
                        CellPadding="3" Width="750px" BorderStyle="None" BorderColor="#DEBA84" BorderWidth="1px"
                        BackColor="#DEBA84" CellSpacing="10">
                        <AlternatingRowStyle CssClass="CartListItemAlt" />
                        <Columns>
                            <asp:TemplateField HeaderText=" Class ID ">
                                <ItemTemplate>
                                    <asp:Label ID="Class_ID" runat="server" Enabled="False"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Course_Name" HeaderText=" Course Name" SortExpression="CourseName" />
                            <asp:BoundField DataField="Course_Discontinued" HeaderText=" Course Discontinued " SortExpression="CourseDiscontinued" />
                            <asp:BoundField DataField="Course_Credit_Hours" HeaderText=" Course Credit " SortExpression="CourseCredit" />
                            <asp:TemplateField HeaderText=" Class Date ">
                                <ItemTemplate>
                                    <asp:Label ID="Class_Date" runat="server" Enabled="False"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BorderStyle="Solid" />
                        <FooterStyle CssClass="CartListFooter" BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <HeaderStyle CssClass="CartListHead" BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                    </asp:GridView>
                </div>
            </section>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>