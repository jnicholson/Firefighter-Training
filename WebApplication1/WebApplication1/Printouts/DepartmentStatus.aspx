<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DepartmentStatus.aspx.cs" Inherits="WebApplication1.Printouts.DepartmentStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <div id="DepartmentListTitle" runat="server" class="ContentHead">
                <h1>Department Status: </h1>
            </div>
            <section class="featured">
                <asp:GridView runat="server" ID="StatusInfo" Width="100%"
                    AutoGenerateColumns="false" GridLines="None">

                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                    <HeaderStyle CssClass="GridviewScrollHeader" />
                    <RowStyle CssClass="GridviewScrollItem" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>
                <br />
                <br />
                <asp:Label runat="server">Firefighters:</asp:Label>
                <asp:Label runat="server" ID="firefighterCount"></asp:Label><br />
                <asp:Label runat="server">Percent Complete:</asp:Label>
                <asp:Label runat="server" ID="percentLabel"></asp:Label><br />
                <asp:Label runat="server">Total Department Hours(Lifetime):</asp:Label>
                <asp:Label runat="server" ID="totalLabel"></asp:Label><br />
                <asp:DropDownList runat="server" ID="yearDrop"></asp:DropDownList><asp:Button runat="server" Text="Change Year" OnClick="Change_Year_Click" />
                <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
                <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.9.1/jquery-ui.min.js"></script>
                <script type="text/javascript" src="../Scripts/gridviewScroll.min.js"></script>
                <script type="text/javascript">
                    $(document).ready(function () {
                        gridviewScroll();

                    });

                    console.log("We are Here3!");
                    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function (evt, args) {
                        gridviewScroll();
                    });
                    function gridviewScroll() {
                        console.log("We are Here1!");
                        $("#<%=StatusInfo.ClientID%>").gridviewScroll({
                            width: 660,
                            height: 200,
                            freezesize: 1
                        });
                    }
                </script>
            </section>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>