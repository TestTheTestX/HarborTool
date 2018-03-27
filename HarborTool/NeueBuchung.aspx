<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NeueBuchung.aspx.cs" Inherits="NeueBuchung" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>Schiff:</td>
                <td><asp:DropDownList ID="DropDownListBoats" runat="server"/></td>
                <td></td>
            </tr>
            <tr>
                <td>Steg:</td>
                <td><asp:DropDownList ID="DropDownListDocks" runat="server"/></td>
                <td></td>
            </tr>
            <tr>
                <td>Zeitraum:</td>
                <td>von</td>
                <td>bis</td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Calendar ID="CalendarVon" runat="server"></asp:Calendar>
                </td>
                <td>
                    <asp:Calendar ID="CalendarBis" runat="server"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="ButtonBooking" runat="server" Text="Buchen" OnClick="ButtonBooking_Click" />
                </td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Rückmeldung Meldung:</td>
                <td colspan="2"><asp:Label ID="LabelMeldung" runat="server" Text="Label"></asp:Label></td>
            </tr>
        </table>
        
        <span><a href="Default.aspx">Zurück zur Übersicht</a></span>

     
        

     
    </form>
</body>
</html>
