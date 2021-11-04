<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebVentas.aspx.cs" Inherits="AppWebVentas.WebVentas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
            Id:<asp:TextBox ID="txtId" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>:
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <br />
            Apellido:<asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
            <br />
            DNI:<asp:TextBox ID="txtDNI" runat="server"></asp:TextBox>
                <br />
            Comision:<asp:TextBox ID="txtComision" runat="server"></asp:TextBox>
                <br />
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                <asp:Button ID="btnTraer" runat="server" Text="Traer por Id" OnClick="btnTraer_Click" />
                
            <br />
            <asp:Label ID="lblFiltro" runat="server" Text="Filtro por comision"></asp:Label>
            <asp:DropDownList ID="ddlFiltro" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFiltro_SelectedIndexChanged"></asp:DropDownList>
            <br />
            <asp:GridView ID="gridVendedor" runat="server">
            </asp:GridView>
        </div>
        </div>
    </form>
</body>
</html>
