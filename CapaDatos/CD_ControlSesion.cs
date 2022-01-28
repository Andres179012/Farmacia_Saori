using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_ControlSesion
    {

        public static CD_ControlSesion _instancia = null;

        private CD_ControlSesion()
        {

        }

        public static CD_ControlSesion Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_ControlSesion();
                }
                return _instancia;
            }
        }


        public bool RegistrarInicioSesion(ControlSesion oControlSesion)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarInicioSesion", oConexion);
                    cmd.Parameters.AddWithValue("Correo", oControlSesion.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }


    }
}
