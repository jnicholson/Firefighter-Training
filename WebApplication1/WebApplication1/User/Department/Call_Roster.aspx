<%@ Page Title="Call Roster" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Call_Roster.aspx.cs" Inherits="WebApplication1.User.Department.Call_Roster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            position: relative;
            width: 500px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <div id="FirefighterDetailsTitle" runat="server" class="ContentHead">
                <h1 style="width: 900px">Call Roster -
                    <asp:Label ID="FilterLabel" runat="server" Text="All Departments"></asp:Label>
                </h1>
            </div>
            <section class="featured">
                <table>
                    <tr>
                        <td style="vertical-align: middle">
                            <asp:Label ID="SelectDeptLabel" runat="server" Text="Display Department: " />

                            <asp:DropDownList ID="DeptDD" runat="server" ItemType="WebApplication1.HalonModels.Department"
                                SelectMethod="GetDepartments" AppendDataBoundItems="true"
                                DataTextField="Dept_Name" DataValueField="Dept_ID" Style="" Font-Size="Larger">
                                <asp:ListItem Value="0" Text="All" />
                            </asp:DropDownList>

                            <asp:Button runat="server" ID="SubmitButton" Text="Go" OnClick="GetRoster_Click" ToolTip="Show only the personnel in the selected department." Height="25px" />
                        </td>
                        <td style="top: 0px; left: 340px;" class="auto-style1">
                            <a href="Print_Call_Roster.aspx" target="_blank">
                                <asp:Label ID="Label1" runat="server" Text="Printable Version"></asp:Label></a>
                        </td>
                    </tr>
                </table>

                <asp:GridView ID="FFRoster" runat="server" AutoGenerateColumns="False" ShowFooter="True" CellPadding="4"
                    ItemType="WebApplication1.HalonModels.Firefighter" CssClass="CartListItem" SelectMethod="GetFirefighters" Width="900px" Font-Size="Larger">
                    <AlternatingRowStyle CssClass="CartListItemAlt" />
                    <Columns>
                        <asp:BoundField DataField="Firefighter_Rank" HeaderText="Rank" HeaderStyle-Font-Size="Medium" HeaderStyle-BackColor="Gray" HeaderStyle-ForeColor="Control" SortExpression="FirefighterRank" />
                        <asp:BoundField DataField="Firefighter_Lname" HeaderText="Last Name" HeaderStyle-Font-Size="Medium" HeaderStyle-BackColor="Gray" HeaderStyle-ForeColor="Control" SortExpression="FirefighterLname" />
                        <asp:BoundField DataField="Firefighter_Fname" HeaderText="First Name" HeaderStyle-Font-Size="Medium" HeaderStyle-BackColor="Gray" HeaderStyle-ForeColor="Control" SortExpression="FirefighterFname" />
                        <asp:BoundField DataField="Firefighter_Home_Ph" HeaderText="Home" HeaderStyle-Font-Size="Medium" HeaderStyle-BackColor="Gray" HeaderStyle-ForeColor="Control" SortExpression="FirefighterHomePh" />
                        <asp:BoundField DataField="Firefighter_Cell_Ph" HeaderText="Cell" HeaderStyle-Font-Size="Medium" HeaderStyle-BackColor="Gray" HeaderStyle-ForeColor="Control" SortExpression="FirefighterCellPh" />
                        <asp:BoundField DataField="Firefighter_Emer_Ph" HeaderText="Emergency" HeaderStyle-Font-Size="Medium" HeaderStyle-BackColor="Gray" HeaderStyle-ForeColor="Control" SortExpression="FirefighterEmerPh" />
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