﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEN;
using CapaLN;
using System.Data;
using System.Drawing;

namespace AplicacionSIPA1.RH.Catalogos.Estado_Contrato
{
    public partial class ListadoEstadoContrato : System.Web.UI.Page
    {
        /// <summary>
        /// Se cargan todas los estados de contratos existentes en el catálogo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            EstadoContratoLN estadocontratoLN = new EstadoContratoLN();
            DataTable dt = estadocontratoLN.ObtenerEstadoContrato();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int fil = i + 1;

                int id = Convert.ToInt32(dt.Rows[i]["id_estado_contrato"]);
                tabla_estado_contrato.Rows.Add(new TableRow());
                tabla_estado_contrato.Rows[fil].Cells.Add(new TableCell());
                tabla_estado_contrato.Rows[fil].Cells.Add(new TableCell());

                if ((fil % 2) == 0)
                    tabla_estado_contrato.Rows[fil].BackColor = Color.LightBlue;
                else
                    tabla_estado_contrato.Rows[fil].BackColor = Color.White;

                tabla_estado_contrato.Rows[fil].Cells[0].Text = dt.Rows[i]["descripcion"].ToString();
                tabla_estado_contrato.Rows[fil].Cells[1].Width = 100;
                tabla_estado_contrato.Rows[fil].Cells[1].Controls.Add(BotonEditar(id));
                tabla_estado_contrato.Rows[fil].Cells[1].Controls.Add(BotonEliminar(id));

            }

        }

        /// <summary>
        /// Botón para redireccionar a una nueva página donde se edita el estado del contrato seleccionado
        /// </summary>
        /// <param name="id">Id del estado del contrato a editar</param>
        /// <returns></returns>
        private ImageButton BotonEditar(int id)
        {
            ImageButton button = new ImageButton();
            button.PostBackUrl = "Editar.aspx?id=" + id;
            button.ImageUrl = "~/img/24_bits/edit.png";
            button.Attributes.Add("data-id", id.ToString());
            return button;
        }

        /// <summary>
        /// Botón para redireccionar a una nueva página donde se elimina el estado del contrato seleccionado
        /// </summary>
        /// <param name="id">Id del estado del contrato a eliminar</param>
        /// <returns></returns>
        private ImageButton BotonEliminar(int id)
        {
            ImageButton button = new ImageButton();
            button.PostBackUrl = "Eliminar.aspx?id=" + id;
            button.ImageUrl = "~/img/24_bits/trash.png";
            button.Attributes.Add("data-id", id.ToString());
            return button;
        }

        /// <summary>
        /// Obtiene la descripción del estado del contrato y lo crea/agrega
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Crear(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(descripcion.Text))
            {
                string estado_contrato = descripcion.Text.Trim().ToUpper();
                EstadoContratoLN estadocontratoLN = new EstadoContratoLN();
                if (!estadocontratoLN.CrearEstadoContrato(estado_contrato).HasErrors)
                {
                    Response.Redirect("ListadoEstadoContrato.aspx");
                }
                else
                {
                }
            }
        }

    }
}