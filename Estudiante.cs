using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace Modelo
{
    public class Estudiante{
        ConexionBD conectar;
        private DataTable drop_tipo_de_sangre(){
            DataTable tabla = new DataTable();
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string consulta = string.Format("select id_tipo_de_sangre as id_tipo_de_sangre,puesto from tipo_de_sangre;");
            MySqlDataAdapter query = new MySqlDataAdapter(consulta, conectar.conectar);
            query.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        private DataTable grid_estudiantes(){
            DataTable tabla = new DataTable();
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string consulta = string.Format("select e.id_Estudiantes as id,e.carnet,e.nombres,e.apellidos,e.dirección,e.telefono,e.fecha_nacimiento,p.tipo_de_sangre,e.id_tipo_de_sangre");
            MySqlDataAdapter query = new MySqlDataAdapter(consulta, conectar.conectar);
            query.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public void grid_estudiantes(System.Web.UI.WebControls.GridView grid_estudiantes)
        {
            throw new NotImplementedException();
        }

        public void grid_estudiante(System.Web.UI.WebControls.GridView grid_estudiantes)
        {
            throw new NotImplementedException();
        }

        public void drop_tipo_de_sangre(DropDownList drop){
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppenDataBoundItems = true;
            drop.Items.Add("<< Elige el  tipo de sangre >>");
            drop.Items[0].Value = "0";
            drop.DataSource = drop_tipo_de_sangre();
            drop.DataTextField = "tipo_de_sangre";
            drop.DataValueField = "id";
            drop.DataBind();
        }
        public void grid_estudiantes(GridView grid){
            grid.DataSource = grid_estudiantes();
            grid.DataBind();
        }
        public int crear(string carnet, string nombre, string apellidos, string direccion, string telefono, string fecha,int id_tipo_de_sangre)
        {
            int no = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string consulta = string.Format("INSERT INTO estudiantes(carnet,nombres,apellidos,direccion,telefono,fecha_nacimiento VALUES ('{0}','{1}','{2}','{3}','{4}','{5}',{6});",carnet,nombre,apellidos,direccion,telefono,fecha, id_tipo_de_sangre);
            MySqlCommand query = new MySqlCommand(consulta, conectar.conectar);
            query.Connection = conectar.conectar;
            no = query.ExecuteNonQuery();
            conectar.CerrarConexion();
            return no;

        }
        public int actualizar(int id,string carnet, string nombre, string apellidos, string direccion, string telefono, string fecha, int id_tipo_de_sangre)
        {
            int no = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string consulta = string.Format("UPDATE estudiantes set carnet='{0}',nombres='{1}',apellidos='{2}',direccion='{3}',telefono='{4}',fecha_nacimiento='{5}',id_tipo_de_sangre={6} where id_estudiante ={7};", carnet, nombre, apellidos, direccion, telefono, fecha, id_tipo_de_sangre, id);
            MySqlCommand query = new MySqlCommand(consulta, conectar.conectar);
            query.Connection = conectar.conectar;
            no = query.ExecuteNonQuery();
            conectar.CerrarConexion();
            return no;
        }
        public int borrar(int id)
        {
            int no = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string consulta = string.Format("DELETE from estudiantes where id_estudiante ={0};",id);
            MySqlCommand query = new MySqlCommand(consulta, conectar.conectar);
            query.Connection = conectar.conectar;
            no = query.ExecuteNonQuery();
            conectar.CerrarConexion();
            return no;
        }

    }
}
