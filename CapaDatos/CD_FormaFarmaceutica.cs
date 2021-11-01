using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaModelo;

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

        public List<Forma_Farmaceuticas> ObtenerFormaFarmaceutica()
        {
            var rptListaFormaFarmaceutica = new List<Forma_Farmaceuticas>();
            using (SqlConnection oConexion = new SqlConnection("Server=.;Database=FarmaciaSaoriDB;User Id=sa;Password=123"))
            {
                SqlCommand cmd = new SqlCommand("USP_FormaFarmaceuticaObtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaFormaFarmaceutica.Add(new Forma_Farmaceuticas()
                        {
                            Id_FormaFarmaceutica = Convert.ToInt32(dr["Id_FormaFarmaceutica"].ToString()),
                            Forma_Faumaceutica = dr["Forma_Faumaceutica"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            Estado = Convert.ToBoolean(dr["Estado"].ToString())
                        });
                    }
                    dr.Close();

                    return rptListaFormaFarmaceutica;

                }
                catch
                {
                    rptListaFormaFarmaceutica = null;
                    return rptListaFormaFarmaceutica;
                }
            }
        }
        public bool RegistrarFormaFarmaceutica(Forma_Farmaceuticas oFormaFarmaceutica)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection("Server=.;Database=FarmaciaSaoriDB;User Id=sa;Password=123"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_FormaFarmaceuticaRegistrar", oConexion);
                    cmd.Parameters.AddWithValue("FormaFarmaceutica", oFormaFarmaceutica.Forma_Faumaceutica);
                    cmd.Parameters.AddWithValue("Descripcion", oFormaFarmaceutica.Descripcion = (oFormaFarmaceutica.Descripcion != null ? oFormaFarmaceutica.Descripcion : ""));
                    cmd.Parameters.AddWithValue("Estado", oFormaFarmaceutica.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public bool ModificarFormaFarmaceutica(Forma_Farmaceuticas oFormaFarmaceutica)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection("Server=.;Database=FarmaciaSaoriDB;User Id=sa;Password=123"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_FormaFarmaceuticaModificar", oConexion);
                    cmd.Parameters.AddWithValue("IdFormaFarmaceutica", oFormaFarmaceutica.Id_FormaFarmaceutica);
                    cmd.Parameters.AddWithValue("FormaFarmaceutica", oFormaFarmaceutica.Forma_Faumaceutica);
                    cmd.Parameters.AddWithValue("Descripcion", oFormaFarmaceutica.Descripcion = (oFormaFarmaceutica.Descripcion != null ? oFormaFarmaceutica.Descripcion : ""));
                    cmd.Parameters.AddWithValue("Estado", oFormaFarmaceutica.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch
                {
                    respuesta = false;
                }

            }

            return respuesta;

        }

        public bool EliminarFormaFarmaceutica(int IdFormaFarmaceutica)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection("Server =.; Database = FarmaciaSaoriDB; User Id = sa; Password = 123"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_FormaFarmaceuticaEliminar", oConexion);
                    cmd.Parameters.AddWithValue("IdFormaFarmaceutica", IdFormaFarmaceutica);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch
                {
                    respuesta = false;
                }

            }

            return respuesta;

        }
    }
}
