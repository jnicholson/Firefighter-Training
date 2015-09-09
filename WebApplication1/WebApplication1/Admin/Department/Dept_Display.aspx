<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dept_Display.aspx.cs" Inherits="WebApplication1.Admin.Department.Dept_Display" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <div id="DepartmentListTitle" runat="server" class="ContentHead">
                <h1>Departments: </h1>
            </div>
            <section class="featured">
                <asp:GridView ID="DeptList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Both" CellPadding="4"
                    ItemType="WebApplication1.HalonModels.Department" CssClass="CartListItem" SelectMethod="GetDepartments" Width="600">
                    <AlternatingRowStyle CssClass="CartListItemAlt" />
                    <Columns>
                        <asp:BoundField DataField="Dept_ID" HeaderText="ID" SortExpression="DeptID" />
                        <asp:BoundField DataField="Dept_FDID" HeaderText="FDID" SortExpression="DeptFDID" />
                        <asp:BoundField DataField="Dept_Name" HeaderText="Name" SortExpression="DeptName" />
                        <asp:BoundField DataField="Dept_Tel_No" HeaderText="Tel" SortExpression="DeptTel" />
                        <asp:TemplateField HeaderText="Edit/Remove">
                            <ItemTemplate>
                                <asp:CheckBox ID="RemoveDept" runat="server"></asp:CheckBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Department Status">
                            <ItemTemplate>
                                <asp:HyperLink ID="DepartStatLink" runat="server" ImageUrl="~/Images/class.jpg" NavigateUrl='<%# Eval("Dept_ID", "~/Printouts/DepartmentStatus?departmentId={0}") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Label runat="server" ID="LabelRemoveStatus"></asp:Label>
                <asp:Label runat="server" ID="LabelEditStatus"></asp:Label>
            </section>
            <asp:Button ID="UpdateDepartmentButton" runat="server" Text="Update Department" OnClick="UpdateDepartmentButton_Click" CausesValidation="false" />
            <asp:Button ID="RemoveDepartmentButton" runat="server" Text="Remove Department" OnClick="RemoveDepartmentButton_Click" CausesValidation="false" />
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>