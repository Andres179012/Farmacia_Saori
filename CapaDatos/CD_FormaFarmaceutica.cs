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
    public class CD_FormaFarmaceutica
    {
        public static CD_FormaFarmaceutica _instancia = null;

        private CD_FormaFarmaceutica()
        {

        }

        public static CD_FormaFarmaceutica Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_FormaFarmaceutica();
                }
                return _instancia;
            }
        }


        public List<Forma_Farmaceutica> ObtenerFormaFarmaceutica()
        {
            List<Forma_Farmaceutica> rptListaFormaFarmaceutica = new List<Forma_Farmaceutica>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("USP_FormaFarmaceuticaObtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaFormaFarmaceutica.Add(new Forma_Farmaceutica()
                        {
                            IdFormaFarmaceutica = Convert.ToInt32(dr["IdFormaFarmaceutica"].ToString()),
                            FormaFarmaceutica = dr["FormaFarmaceutica"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            Activo = Convert.ToBoolean(dr["Activo"])

                        });
                    }
                    dr.Close();

                    return rptListaFormaFarmaceutica;

                }
                catch (Exception ex)
                {
                    rptListaFormaFarmaceutica = null;
                    return rptListaFormaFarmaceutica;
                }
            }
        }


        public bool RegistrarFormaFarmaceutica(Forma_Farmaceutica oFormaFarmaceutica)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_FormaFarmaceuticaRegistrar", oConexion);
                    cmd.Parameters.AddWithValue("FormaFarmaceutica", oFormaFarmaceutica.FormaFarmaceutica);
                    cmd.Parameters.AddWithValue("Descripcion", oFormaFarmaceutica.Descripcion);
                    cmd.Parameters.AddWithValue("Activo", oFormaFarmaceutica.Activo);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }

            }

            return respuesta;

        }

        public bool ModificarFormaFarmaceutica(Forma_Farmaceutica oFormaFarmaceutica)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_FormaFarmaceuticaModificar", oConexion);
                    cmd.Parameters.AddWithValue("IdFormaFarmaceutica", oFormaFarmaceutica.IdFormaFarmaceutica);
                    cmd.Parameters.AddWithValue("FormaFarmaceutica", oFormaFarmaceutica.FormaFarmaceutica);
                    cmd.Parameters.AddWithValue("Descripcion", oFormaFarmaceutica.Descripcion);
                    cmd.Parameters.AddWithValue("Activo", oFormaFarmaceutica.Activo);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }

            return respuesta;

        }

        public bool EliminarFormaFarmaceutica(int id)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_FormaFarmaceuticaEliminar", oConexion);
                    cmd.Parameters.AddWithValue("IdFormaFarmaceutica", id);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }

            }

            return respuesta;

        }


    }
}
