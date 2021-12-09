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
    public class CD_ViaAdministracion
    {
        public static CD_ViaAdministracion _instancia = null;

        private CD_ViaAdministracion()
        {

        }

        public static CD_ViaAdministracion Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_ViaAdministracion();
                }
                return _instancia;
            }
        }


        public List<Via_Administracion> ObtenerViaAdministracion()
        {
            List<Via_Administracion> rptListaVia = new List<Via_Administracion>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("USP_ViaAdministracionObtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaVia.Add(new Via_Administracion()
                        {
                            IdViaAdministracion = Convert.ToInt32(dr["IdViaAdministracion"].ToString()),
                            ViaAdministracion = dr["ViaAdministracion"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            Activo = Convert.ToBoolean(dr["Activo"])

                        });
                    }
                    dr.Close();

                    return rptListaVia;

                }
                catch (Exception ex)
                {
                    rptListaVia = null;
                    return rptListaVia;
                }
            }
        }


        public bool RegistrarViaAdministracion(Via_Administracion oViaAdministracion)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_ViaAdministracionRegistrar", oConexion);
                    cmd.Parameters.AddWithValue("ViaAdministracion", oViaAdministracion.ViaAdministracion);
                    cmd.Parameters.AddWithValue("Descripcion", oViaAdministracion.Descripcion);
                    cmd.Parameters.AddWithValue("Activo", oViaAdministracion.Activo);
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

        public bool ModificarViaAdministracion(Via_Administracion oViaAdministracion)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_ViaAdministracionModificar", oConexion);
                    cmd.Parameters.AddWithValue("IdViaAdministracion", oViaAdministracion.IdViaAdministracion);
                    cmd.Parameters.AddWithValue("ViaAdministracion", oViaAdministracion.ViaAdministracion);
                    cmd.Parameters.AddWithValue("Descripcion", oViaAdministracion.Descripcion);
                    cmd.Parameters.AddWithValue("Activo", oViaAdministracion.Activo);
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

        public bool EliminarViaAdministracion(int id)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_ViaAdministracionEliminar", oConexion);
                    cmd.Parameters.AddWithValue("IdViaAdministracion", id);
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
