<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Enrollment_Display.aspx.cs" Inherits="WebApplication1.Chief.Enrollment.Enrollment_Display" %>

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
                <h1>Enrollments: </h1>
            </div>
            <section class="featured">
                <asp:GridView runat="server" ID="EnrollmentInfo" Width="800px"
                    ItemType="WebApplication1.HalonModels.Enrollment" DataKeyNames="Enrollment_ID" AllowPaging="false" AutoGenerateColumns="false" AllowSorting="false"
                    SelectMethod="GetEnrollments" BorderWidth="1px" OnRowDataBound="Enrollments_RowDataBound" OnRowCommand="OrderSellItemList_RowCommand">

                    <Columns>
                        <asp:BoundField HeaderText="Enrollment ID" DataField="Enrollment_ID" />
                        <asp:BoundField HeaderText="Firefighter ID" DataField="Firefighter_ID" />
                        <asp:HyperLinkField HeaderText="Firefighter Name" Text=""
                            DataNavigateUrlFields="Firefighter_ID"
                            DataNavigateUrlFormatString="/Firefighter/Firefighter_Display.aspx?Firefighter_ID={0}" />
                        <asp:BoundField HeaderText="Class ID" DataField="Class_ID" />
                        <asp:HyperLinkField HeaderText="Class Name" Text=""
                            DataNavigateUrlFields="Class_ID"
                            DataNavigateUrlFormatString="/Class/Class_Display.aspx?Class_ID={0}" />
                        <asp:TemplateField HeaderText="Edit/Delete">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="editDeleteBox" onclick="CheckSingleCheckbox(this)" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="PDF" runat="server"
                                    CommandName="AA"
                                    CommandArgument='<%# Eval("Enrollment_ID") %>'
                                    Text="Admission Application" CausesValidation="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </section>
            <asp:Button ID="EditEnrollmentButton" runat="server" Text="Edit Enrollment" OnClick="EditEnrollmentButton_Click" CausesValidation="true" />
            <asp:Button ID="DeleteEnrollmentButton" runat="server" Text="Delete Enrollment" OnClick="DeleteEnrollmentButton_Click" CausesValidation="true" />
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>