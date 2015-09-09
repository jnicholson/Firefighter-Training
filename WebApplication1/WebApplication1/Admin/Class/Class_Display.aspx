<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Class_Display.aspx.cs" Inherits="WebApplication1.Admin.Class.Class_Display" %>

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
                <h1>Classes: </h1>
            </div>
            <section class="featured">
                <asp:GridView runat="server" ID="ClassInfo" Width="800px"
                    ItemType="WebApplication1.HalonModels.Class" DataKeyNames="Class_ID" AllowPaging="false" AutoGenerateColumns="false" AllowSorting="false"
                    SelectMethod="GetClasses" BorderWidth="1px" OnRowDataBound="Classes_RowDataBound" OnRowCommand="OrderSellItemList_RowCommand">

                    <Columns>
                        <asp:BoundField HeaderText="Class ID" DataField="Class_ID" />
                        <asp:BoundField HeaderText="Teacher ID" DataField="Firefighter_ID" />
                        <asp:HyperLinkField HeaderText="Teacher Name" Text=""
                            DataNavigateUrlFields="Firefighter_ID"
                            DataNavigateUrlFormatString="/Firefighter/Firefighter_Display.aspx?Firefighter_ID={0}" />
                        <asp:BoundField HeaderText="Course ID" DataField="Course_ID" />
                        <asp:HyperLinkField HeaderText="Course Name" Text=""
                            DataNavigateUrlFields="Course_ID"
                            DataNavigateUrlFormatString="/Class/Class_Display.aspx?Class_ID={0}" />
                        <asp:BoundField HeaderText="Class Date" DataField="Class_Date" />
                        <asp:BoundField HeaderText="Class Note" DataField="Class_Note" />
                        <asp:CheckBoxField HeaderText="Cancelled" DataField="Class_Cancelled" />
                        <asp:TemplateField HeaderText="Edit/Delete">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="editDeleteBox" onclick="CheckSingleCheckbox(this)" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="PDF" runat="server"
                                    CommandName="Label"
                                    CommandArgument='<%# Eval("Class_ID") %>'
                                    Text="Request Form" CausesValidation="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="PDF2" runat="server"
                                    CommandName="Label2"
                                    CommandArgument='<%# Eval("Class_ID") %>'
                                    Text="Class Roster" CausesValidation="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </section>
            <p></p>
            <p></p>

            <asp:Button ID="EditClassButton" runat="server" Text="Edit Class" OnClick="EditClassButton_Click" CausesValidation="true" />
            <asp:Button ID="DeleteClassButton" runat="server" Text="Delete Class" OnClick="DeleteClassButton_Click" CausesValidation="true" />
        </div>
    </section>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>