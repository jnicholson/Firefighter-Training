<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpcomingClasses.aspx.cs" Inherits="WebApplication1.User.Class.UpcomingClasses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function CheckSingleCheckbox(ob) {
            var grid = ob.parentNode.parentNode.parentNode;
            var inputs = grid.getElementsByTagName("input");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox") {
                    if (ob.checked && inputs[i] != ob && inputs[i].checked) {
                        inputs[i].checked = false;
                    }
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <div id="EnrollmentListTitle" runat="server" class="ContentHead">
                <h1>Upcoming Classes</h1>
            </div>
            <section class="featured">
                <asp:GridView runat="server" ID="ClassInfo" Width="800px"
                    ItemType="WebApplication1.HalonModels.Class" DataKeyNames="Class_ID" AllowPaging="false" AutoGenerateColumns="false" AllowSorting="false"
                    SelectMethod="GetClasses" BorderWidth="1px" OnRowDataBound="Classes_RowDataBound">

                    <Columns>
                        <asp:BoundField HeaderText="Class ID" DataField="Class_ID" />
                        <asp:HyperLinkField HeaderText="Teacher Name" Text="" />
                        <asp:BoundField HeaderText="Class Date" DataField="Class_Date" />
                        <asp:HyperLinkField HeaderText="Course Name" Text="" />
                        <asp:BoundField HeaderText="Class Note" DataField="Class_Note" />
                        <asp:TemplateField HeaderText="Enroll">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="enrollBox" onclick="CheckSingleCheckbox(this)" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </section>
            <asp:Button ID="EnrollmentButton" runat="server" Text="Enroll" OnClick="EnrollButton_Click" CausesValidation="true" />
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>