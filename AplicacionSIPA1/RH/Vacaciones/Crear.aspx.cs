using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaAD;

namespace AplicacionSIPA1.RH.Vacaciones
{
    public partial class Ingresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Datos();
            DateTime Hoy = DateTime.Now;
            this.fecha.Value = Hoy.ToString("dd/MM/yyyy");
        }


        public void Datos()
        {
            String sUsuario = this.Session["Usuario"].ToString();
            UsuarioAD Datos = new UsuarioAD();
            DataTable DatosUser = Datos.DatosEmpleadoByUsuario(sUsuario);
            Datos = null;
            this.txtnombre_completo.Value = DatosUser.Rows[0]["nombres"].ToString();
            this.txtcodigo.Value = DatosUser.Rows[0]["id_empleado"].ToString();
            txtcargo.Value = DatosUser.Rows[0]["puesto"].ToString();
            txtunidad.Value = DatosUser.Rows[0]["unidad_administrativa"].ToString();
            txtdireccion.Value = DatosUser.Rows[0]["direccion"].ToString();
            txttelefono.Value = DatosUser.Rows[0]["telefono"].ToString();
        }

    }
}