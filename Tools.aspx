<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tools.aspx.cs" Inherits="Tools" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Text="工具名:"></asp:Label>

        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

        <br />
         <asp:Label ID="Label2" runat="server" Text="所在工具包:"></asp:Label>

        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

        <br />
         <asp:Label ID="Label3" runat="server" Text="货架:"></asp:Label>

        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>

        <br />
         <asp:Label ID="Label4" runat="server" Text="层号:"></asp:Label>

        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>

        <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="添加" />
        <br />
        <asp:GridView ID="GridView1" runat="server" style="margin-top:20px;">
        </asp:GridView>

        <br />
    </div>
    </form>
</body>
</html>
