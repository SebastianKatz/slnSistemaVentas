using Datos.Admin;
using Datos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppWebVentas
{
    public partial class WebVentas : System.Web.UI.Page
    {
         protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MostrarVendedores();
            }
        }
        private void MostrarVendedores()
        {
            gridVendedores.DataSource = AdmVendedor.Listar();
            gridVendedores.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Vendedor vendedor = new Vendedor( txtNombre.Text, txtApellido.Text, txtDni.Text, Convert.ToDecimal(txtComision.Text));
            int filasafectadas = AdmVendedor.Insertar(vendedor);
            if (filasafectadas > 0)
            {
                MostrarVendedores();
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Vendedor vendedor = new Vendedor()
            {
                Nombre=txtNombre.Text,Apellido= txtApellido.Text,DNI= txtDni.Text,Comision= Convert.ToDecimal(txtComision.Text),Id=Convert.ToInt32(txtId.Text)
            };
            int filasafectadas = AdmVendedor.Modificar(vendedor);
            if (filasafectadas > 0)
            {
                MostrarVendedores();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            int filasafectadas = AdmVendedor.Eliminar(id);
            if (filasafectadas > 0)
            {
                MostrarVendedores();
            }
        }

        protected void btnTraerPorID_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            gridVendedores.DataSource=AdmVendedor.TraerPorId(id);
            gridVendedores.DataBind();
        }

        protected void btnTraerPorComision_Click(object sender, EventArgs e)
        {
            decimal comision = Convert.ToDecimal(txtComision.Text);
            gridVendedores.DataSource=AdmVendedor.TraerPorComision(comision);
            gridVendedores.DataBind();
        }

        protected void btnTraerTodos_Click(object sender, EventArgs e)
        {
            MostrarVendedores();
        }
    }
}