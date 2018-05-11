using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_Seminario1
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            String CadConexion = "Server=tcp:dbserverseminario1.database.windows.net,1433;Initial Catalog=dbseminario1;Persist Security Info=False;User ID=seminario1;Password=Seminario200925014;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            //Data Source=dbserverseminario1.database.windows.net;Initial Catalog=dbseminario1;Integrated Security=False;User ID=seminario1;Password=Seminario200925014;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False
            SqlConnection Conexion = new SqlConnection(CadConexion);
            
            String Nombre = txtNombre.Text;
            String Comentario = TextAreaComentario.Text;

            if (Nombre.Trim() != "" && Comentario.Trim() != "")
            {
                SqlCommand Comandos = new SqlCommand();
                Comandos.Connection = Conexion;
                Comandos.CommandText = "INSERT INTO comentarios (nombre,comentario) VALUES (@nombre,@comentario)";
                Comandos.Parameters.Add("@nombre", SqlDbType.VarChar, 200).Value = Nombre;
                Comandos.Parameters.Add("@comentario", SqlDbType.VarChar, 250).Value = Comentario;
                Conexion.Open();
                Comandos.ExecuteNonQuery();

                Response.Redirect("index.aspx");

            }
            }




    }
}