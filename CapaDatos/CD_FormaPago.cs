using System;
using System.Collections.Generic;
using System.Text;
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

        public List<Forma_Pagos> ObtenerFormaPago()
        {
            var rptListaFormaPago = new List<Forma_Pagos>();
            using (SqlConnection oConexion = new SqlConnection("Server=.;Database=FarmaciaSaoriDB;User Id=sa;Password=123"))
            {
                SqlCommand cmd = new SqlCommand("USP_FormaPagoObtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaFormaPago.Add(new Forma_Pagos()
                        {
                            Id_FormaPago = Convert.ToInt32(dr["Id_FormaPago"].ToString()),
                            Forma_Pago = dr["Forma_Pago"].ToString(),
                            Estado = Convert.ToBoolean(dr["Estado"].ToString())
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

        public bool RegistrarFormaPago(Forma_Pagos oFormaPago)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection("Server=.;Database=FarmaciaSaoriDB;User Id=sa;Password=123"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_FormaPagoRegistrar", oConexion);
                    cmd.Parameters.AddWithValue("FormaPago", oFormaPago.Forma_Pago);
                    cmd.Parameters.AddWithValue("Estado", oFormaPago.Estado);
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

        public bool ModificarFormaPago(Forma_Pagos oFormaPago)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection("Server=.;Database=FarmaciaSaoriDB;User Id=sa;Password=123"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_FormaPagoModificar", oConexion);
                    cmd.Parameters.AddWithValue("IdFormaPago", oFormaPago.Id_FormaPago);
                    cmd.Parameters.AddWithValue("FormaPago", oFormaPago.Forma_Pago);
                    cmd.Parameters.AddWithValue("Estado", oFormaPago.Estado);
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
            using (SqlConnection oConexion = new SqlConnection("Server =.; Database = FarmaciaSaoriDB; User Id = sa; Password = 123"))
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
