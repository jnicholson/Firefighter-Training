<%@ Page Title="Print Call Roster" Language="C#" MasterPageFile="~/Print.Master" AutoEventWireup="true" CodeFile="Print_Call_Roster.aspx.cs" Inherits="WebApplication1.User.Department.Print_Call_Roster" %>

<asp:Content runat="server" ContentPlaceHolderID="FeaturedContent">

    <div id="PrintCallRosterTitle">
        <h1 style="width: 900px">Call Roster -
                    <asp:Label ID="FilterLabel" runat="server" Text="All Departments"></asp:Label>
        </h1>
    </div>
    <section class="featured">

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
</asp:Content>