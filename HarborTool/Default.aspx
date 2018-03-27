<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="formBookings" runat="server">
    <a href="NeueBuchung.aspx">Neue Buchung</a>
    <div>
        <h2>Buchungen</h2>
        
      
        <asp:Repeater ID="RepeaterBookings" runat="server" onitemcommand="RepeaterBookings_ItemCommand">
            <ItemTemplate>
                <b>BuchungId: </b><span><%# Eval("Id") %></span><br />
                <b>SchiffId: </b><span><%# Eval("BoatId") %></span><br />
                <b>PierId: </b><span><%# Eval("DockId") %></span><br />
                <b>Zeitraum: </b><span>vom <%# Eval("Arrival") %> bis <%# Eval("Departure") %></span><br />
                <asp:LinkButton ID="LinkButtonDelete" runat="server"  CommandName="Delete" CommandArgument='<%# Eval("Id") %>'>Lösche Buchung</asp:LinkButton>            
                <br/><br/>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</form>
</body>
</html>
