<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SpaceXData.aspx.cs" Inherits="SetWorksProject.SpaceXData" %>

<!DOCTYPE html>
<html xmlns='http://www.w3.org/1999/xhtml'>
<head runat="server">
    <title>Telerik ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
   <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
     <telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="true" />
    <telerik:RadFormDecorator RenderMode="Lightweight" runat="server" DecorationZoneID="grid" DecoratedControls="All" EnableRoundedCorners="false"/>
        
        <%-- COULD NOT GET SORTING TO WORK UNTIL I ADDED THE ONNEEDDATASOURCE EVENT & ALLOW SORTING. ADDED ALLOW PAGING FOR EXTRA FUNCTIONALITY--%>
        <telerik:RadGrid ID="RadGrid2" runat="server" AllowSorting="true" OnNeedDataSource="RadGrid2_NeedDataSource" AllowPaging="true" AllowFilteringByColumn="true">
            <MasterTableView DataKeyNames="RocketName" CommandItemDisplay="Top" AutoGenerateColumns="false" AllowMultiColumnSorting="true">
                <SortExpressions>
                    <telerik:GridSortExpression FieldName="MissionDate" SortOrder="Ascending" />
                </SortExpressions>
                <Columns>
                    <telerik:GridBoundColumn DataField="RocketName" HeaderText="Rocket Name" ReadOnly="true">
                    </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="MissionDate" HeaderText="Mission Date" AllowSorting="true" DataType="System.DateTime" ReadOnly="true">
                    </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="LaunchSuccess" HeaderText="Launch Success" ReadOnly="true">
                    </telerik:GridBoundColumn>
                    <%-- UNCOMMENT BELOW TO INCLUDE COLUMNS FOR PAYLOADMASS AND RANK IF NEEDED --%>
                    <%--</telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PayloadMass" HeaderText="Payload Mass" AllowSorting="true" DataType="System.Double">--%>
                        <%--<telerik:GridBoundColumn DataField="Rank" HeaderText="Rank" ReadOnly="true">
                    </telerik:GridBoundColumn>--%>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </form>
</body>
</html>