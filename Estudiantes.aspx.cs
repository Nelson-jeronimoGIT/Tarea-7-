using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pr_web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Estudiante estudiante;
        protected void Page_Load(object sender, EventArgs e){
            if (!IsPostBack)
            {
                estudiante = new Estudiante();
                estudiantes.drop_tipo_de_sangre(drop_tipo_de_sangre);
                estudiantes.grid_estudiantes(grid_estudiantes);
            }
        }

        protected void btn_crear_Click(object sender, EventArgs e){
            estudiante = new Estudiante();
            if (estudiante.crear(txt_carnet.Text,txt_nombres.Text, txt_apellidos.Text, txt_direccion.Text, txt_telefono.Text, txt_fn.Text,Convert.ToInt32 (drop_tipo_de_sangre.SelectedValue)) > 0){
                lbl_mensaje.Text = "Datos Ingresados Exitosamente...";
                estudiantes.grid_estudiantes(grid_estudiantes);
            }
        }

        protected void grid_estudiantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_carnet.Text = grid_estudiantes.SelectedRow.Cells[2].Text;
            txt_nombres.Text = grid_estudiantes.SelectedRow.Cells[3].Text;
            txt_apellidos.Text = grid_estudiantes.SelectedRow.Cells[4].Text;
            txt_direccion.Text = grid_estudiantes.SelectedRow.Cells[5].Text;
            txt_telefono.Text = grid_estudiantes.SelectedRow.Cells[6].Text;
            DateTime fecha = Convert.ToDateTime(grid_estudiantes.SelectedRow.Cells[7].Text);
            txt_fn.Text = fecha.ToString("yyyy-mm-dd");
            int indice = grid_estudiantes.SelectedRow.RowIndex;
            drop_tipo_de_sangre.SelectedValue = grid_estudiantes.DataKeys[indice].Values["id_tipo_de_sangre"].ToString();
            btn_actualizar.Visible = true;
        }
        protected void grid_estudiantes_RowDeleting(object sender, GridViewCancelEditEventArgs e) 
        {
            estudiante = new Estudiante ();
            if (estudiante.borrar(Convert.ToInt32(e.Keys["id"])) > 0)
            {
                lbl_mensaje.Text = "Borrado Exitoso...";
                estudiantes.grid_estudiantes(grid_estudiantes);
            }

        }
        protected void btn_actualizar_Click(object sender, EventArgs e) 
        { 
            estudiante = new Estudiante();
            if (estudiante.actualizar(Convert.ToInt32(grid_estudiantes.SelectedValue) ,txt_carnet.Text, txt_nombres.Text, txt_apellidos.Text, txt_direccion.Text, txt_telefono.Text, txt_fn.Text, Convert.ToInt32(drop_tipo_de_sangre.SelectedValue)) > 0)
            {
                lbl_mensaje.Text = "Modificacion Exitoso...";
                estudiantes.grid_estudiantes(grid_estudiantes);
            }
        }
    }
}