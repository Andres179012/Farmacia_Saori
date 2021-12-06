using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaModelo;

namespace CapaDatos
{
    public class CD_FormaPago
    {
        public static CD_FormaPago _instancia = null;

        private CD_FormaPago()
        {
        }

        public static CD_FormaPago Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_FormaPago();
                }
                return _instancia;
            }
        }

        public List<Forma_Pago> ObtenerFormaPago()
        {
            var rptListaFormaPago = new List<Forma_Pago>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("USP_FormaPagoObtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaFormaPago.Add(new Forma_Pago()
                        {
                            IdFormaPago = Convert.ToInt32(dr["IdFormaPago"].ToString()),
                            FormaPago = dr["FormaPago"].ToString(),
                            Activo = Convert.ToBoolean(dr["Activo"].ToString())
                        });
                    }
                    dr.Close();

                    return rptListaFormaPago;

                }
                catch
                {
                    rptListaFormaPago = null;
                    return rptListaFormaPago;
                }
            }
        }

        public bool RegistrarFormaPago(Forma_Pago oFormaPago)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_FormaPagoRegistrar", oConexion);
                    cmd.Parameters.AddWithValue("FormaPago", oFormaPago.FormaPago);
                    cmd.Parameters.AddWithValue("Activo", oFormaPago.Activo);
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

        public bool ModificarFormaPago(Forma_Pago oFormaPago)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_FormaPagoModificar", oConexion);
                    cmd.Parameters.AddWithValue("IdFormaPago", oFormaPago.IdFormaPago);
                    cmd.Parameters.AddWithValue("FormaPago", oFormaPago.FormaPago);
                    cmd.Parameters.AddWithValue("Activo", oFormaPago.Activo);
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

        public bool EliminarFormaPago(int IdFormaPago)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_FormaPagoEliminar", oConexion);
                    cmd.Parameters.AddWithValue("IdFormaPago", IdFormaPago);
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
