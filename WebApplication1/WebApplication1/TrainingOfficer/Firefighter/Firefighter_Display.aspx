<%@ Page Title="Firefighter Display" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Firefighter_Display.aspx.cs" Inherits="WebApplication1.TrainingOfficer.Firefighter.Firefighter_Display" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <div id="FirefighterListTitle" runat="server" class="ContentHead">
                <h1>Firefighters: </h1>
            </div>
            <section class="featured">
                <asp:GridView ID="FirefighterList" runat="server" AutoGenerateColumns="False" ShowFooter="True" CellPadding="4"
                    ItemType="WebApplication1.HalonModels.Firefighter" CssClass="CartListItem" SelectMethod="GetFirefighters" Width="600px">
                    <AlternatingRowStyle CssClass="CartListItemAlt" />
                    <Columns>
                        <asp:BoundField DataField="Firefighter_ID" HeaderText="ID" SortExpression="FirefighterID" />
                        <asp:BoundField DataField="Firefighter_Rank" HeaderText="Rank" SortExpression="FirefighterRank" />
                        <asp:BoundField DataField="Firefighter_Lname" HeaderText="Last Name" SortExpression="FirefighterLname" />
                        <asp:BoundField DataField="Firefighter_Fname" HeaderText="First Name" SortExpression="FirefighterFname" />
                        <asp:TemplateField HeaderText="Completed Courses">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/Images/class.jpg" NavigateUrl='<%# Eval("Firefighter_ID", "~/Printouts/FireFighterCourses?Firefighter_ID={0}") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle CssClass="CartListFooter" />
                    <HeaderStyle CssClass="CartListHead" />
                </asp:GridView>
            </section>
        </div>
    </section>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>