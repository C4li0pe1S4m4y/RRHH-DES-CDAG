using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using CapaLN;
using CapaAD;
using System.Web.Security;
using System.Text.RegularExpressions;

namespace AplicacionSIPA1
{
    public partial class Login : System.Web.UI.Page
    {

        LogeoLN mstLogeo;

        public bool VerificaUsuarioRRHH(string idusr)
        {
            bool Valor = false;
            UsuarioAD Datos = new UsuarioAD();
            DataTable Usuario = Datos.usuarioRRHH(idusr);
            if (Usuario.Rows.Count == 0)
            {
                Valor = true;
            }
            return Valor;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.TextUsuario.Focus();
            //Response.Redirect("http://192.9.200.247/");
        }

        protected void btniniciar_Click(object sender, EventArgs e)

        {

            Regex val = new Regex("^[a-zA-Z0-9ñÑáéíóúÁÉÍÓÚ]+$");

            if (val.IsMatch(this.TextUsuario.Text) && val.IsMatch(this.TextContraseña.Text))
            {
                
                try
                {
                    //VARIABLES DE SESIÓN           
                    this.Session["usuar"] = this.TextUsuario.Text;
                    this.Session["Usuario"] = this.TextUsuario.Text;

                    mstLogeo = new LogeoLN();

                    if (mstLogeo.Logearse(this.TextUsuario.Text, this.TextContraseña.Text) > 0)
                    {
                        FormsAuthentication.RedirectFromLoginPage(this.TextUsuario.Text, false);
                        if (VerificaUsuarioRRHH(this.TextUsuario.Text)) {
                            Response.Redirect("~/RH/Empleado/EditarFicha.aspx?id=" + this.TextUsuario.Text);
                        } else
                        {
                            Response.Redirect("~/Inicio.aspx");
                           // Response.Redirect("~/RH/Vacaciones/Crear.aspx");
                        }
                    }
                    else
                    {
                        this.resultado.Text = "Usuario no autorizado...";
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "Error en inicio de sesión");
                    if (ex.Message != "Thread was being aborted.")
                    {
                        Response.Redirect("~/Error.aspx?No=" + ex.Message);
                    }
                   
                    throw;
                }

            }
            else
            {
                this.resultado.Text = "Usuario no autorizado...";
                this.TextUsuario.Text = "";
                this.TextContraseña.Text = "";
                this.TextUsuario.Focus();
            }



        }//termina evento

    }

   


}