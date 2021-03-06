﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Team3ADProject.Protected.Dashboard1" %>

<%-- Written by: Chua Khiong Yang 
    
    The dashboard is the first page the user lands on after logging in.
    It provides useful information and shortcuts to the user.

    --%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="<%=ResolveUrl("~/Content/Sites/Dashboard.css")%>" />
    <%@ Import Namespace="Team3ADProject.Code" %>
    <%if (Roles.IsUserInRole(Constants.ROLES_STORE_CLERK) || Roles.IsUserInRole(Constants.ROLES_STORE_SUPERVISOR))
        { %>
    <h1>Dashboard</h1>
    <%} %>

    <!-- If user is a store type employee, display dashboard information -->
    <%if (Roles.IsUserInRole(Constants.ROLES_STORE_CLERK) || Roles.IsUserInRole(Constants.ROLES_STORE_MANAGER) || Roles.IsUserInRole(Constants.ROLES_STORE_SUPERVISOR))
        { %>
    <div class="dashboard-flexbox-container-outer">
        <!--Flex item 1: Table for low stock items -->
        <div class="dashboard-flexbox-item">
            <h3>Low stock items:</h3>
            <asp:GridView ID="LowStockItemGridView" runat="server" CssClass="table table-hover" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="item_number" HeaderText="Item ID" />
                    <asp:BoundField DataField="description" HeaderText="Description" />
                    <asp:BoundField DataField="current_quantity" HeaderText="Current Quantity" />
                    <asp:BoundField DataField="reorder_level" HeaderText="Reorder Level" />
                </Columns>
            </asp:GridView>

            <%if (Roles.IsUserInRole(Constants.ROLES_STORE_CLERK))
                { %>
            <asp:LinkButton ID="RequisitionOrder_Link" runat="server" CssClass="btn btn-success" OnClick="RequisitionOrder_Link_Click">Go to Inventory Listing</asp:LinkButton>
            <%} %>
        </div>

        <!--Flex item 2: Chart -->
        <div class="dashboard-flexbox-item">
            <h3>Pending purchase orders by suppliers:</h3>
            <div id="pendingPurchaseOrderCountBySupplierChart" style="height: 60vh; width: 30vw; margin-bottom: 2.5vh"></div>
            <%if (Roles.IsUserInRole(Constants.ROLES_STORE_CLERK))
                { %>
            <asp:LinkButton ID="PurchaseOrder_Link" runat="server" CssClass="btn btn-success" OnClick="PurchaseOrder_Link_Click">Go to Purchase Order Listing</asp:LinkButton>
            <%} %>
        </div>

    </div>
    <%} %>

    <%else
        { %>
    <!-- If user is an employee, show them instructions -->
    <div class="flexbox-column dashboard-flexbox-user">
        <h1>Welcome!</h1>
        <div>Please start through the navigation bar above</div>
    </div>
    <% }%>
</asp:Content>
