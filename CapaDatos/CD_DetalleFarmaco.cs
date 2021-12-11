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
    public class CD_DetalleFarmaco
    {
        public static CD_DetalleFarmaco _instancia = null;

        private CD_DetalleFarmaco()
        {

        }

        public static CD_DetalleFarmaco Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_DetalleFarmaco();
                }
                return _instancia;
            }
        }


        public List<DetalleFarmaco> ObtenerDetalleFarmaco()
        {
            List<DetalleFarmaco> rptListaDetalleFarmaco = new List<DetalleFarmaco>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerDetalleFarmaco", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaDetalleFarmaco.Add(new DetalleFarmaco()
                        {
                            IdDetalleFarmaco = Convert.ToInt32(dr["IdDetalleFarmaco"].ToString()),
                            IdProducto = Convert.ToInt32(dr["IdProducto"].ToString()),
                            oProducto = new Producto() { NombreGenerico = dr["NombreGenerico"].ToString() },
                            IdFormaFarmaceutica = Convert.ToInt32(dr["IdFormaFarmaceutica"].ToString()),
                            oFormaFarmaceutica = new Forma_Farmaceutica() { FormaFarmaceutica = dr["FormaFarmaceutica"].ToString() },
                            IdViaAdministracion = Convert.ToInt32(dr["IdViaAdministracion"].ToString()),
                            oViaAdministracion = new Via_Administracion() { ViaAdministracion = dr["ViaAdministracion"].ToString() },
                            IdLaboratorio = Convert.ToInt32(dr["IdLaboratorio"].ToString()),
                            oLaboratorio = new Laboratorio() { NombreLaboratorio = dr["NombreLaboratorio"].ToString() },
                            IdProveedor = Convert.ToInt32(dr["IdProveedor"].ToString()),
                            oProveedor = new Proveedor() { RazonSocial = dr["RazonSocial"].ToString() },
                            NombreComercial = dr["NombreComercial"].ToString(),
                            Concentracion = dr["Concentracion"].ToString(),
                            FechaVencimiento = dr["FechaVencimiento"].ToString(),
                            NumeroLote = dr["NumeroLote"].ToString(),
                            PrescripcionMedica = Convert.ToBoolean(dr["PrescripcionMedica"]),

                        });
                    }
                    dr.Close();

                    return rptListaDetalleFarmaco;

                }
                catch (Exception)
                {
                    rptListaDetalleFarmaco = null;
                    return rptListaDetalleFarmaco;
                }
            }
        }


        public bool RegistrarDetalleFarmaco(DetalleFarmaco oDetalleFarmaco)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarDetalleFarmaco", oConexion);
                    cmd.Parameters.AddWithValue("IdProducto", oDetalleFarmaco.IdProducto);
                    cmd.Parameters.AddWithValue("IdFormaFarmaceutica", oDetalleFarmaco.IdFormaFarmaceutica);
                    cmd.Parameters.AddWithValue("IdViaAdministracion", oDetalleFarmaco.IdViaAdministracion);
                    cmd.Parameters.AddWithValue("IdLaboratorio", oDetalleFarmaco.IdLaboratorio);
                    cmd.Parameters.AddWithValue("IdProveedor", oDetalleFarmaco.IdProveedor);
                    cmd.Parameters.AddWithValue("NombreComercial", oDetalleFarmaco.NombreComercial);
                    cmd.Parameters.AddWithValue("Concentracion", oDetalleFarmaco.Concentracion);
                    cmd.Parameters.AddWithValue("FechaVencimiento", oDetalleFarmaco.FechaVencimiento);
                    cmd.Parameters.AddWithValue("NumeroLote", oDetalleFarmaco.NumeroLote);
                    cmd.Parameters.AddWithValue("PrescripcionMedica", oDetalleFarmaco.PrescripcionMedica);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
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

        public bool ModificarDetalleFarmaco(DetalleFarmaco oDetalleFarmaco)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_ModificarDetalleFarmaco", oConexion);
                    cmd.Parameters.AddWithValue("IdDetalleFarmaco", oDetalleFarmaco.IdDetalleFarmaco);
                    cmd.Parameters.AddWithValue("IdProducto", oDetalleFarmaco.IdProducto);
                    cmd.Parameters.AddWithValue("IdFormaFarmaceutica", oDetalleFarmaco.IdFormaFarmaceutica);
                    cmd.Parameters.AddWithValue("IdViaAdministracion", oDetalleFarmaco.IdViaAdministracion);
                    cmd.Parameters.AddWithValue("IdLaboratorio", oDetalleFarmaco.IdLaboratorio);
                    cmd.Parameters.AddWithValue("IdProveedor", oDetalleFarmaco.IdProveedor);
                    cmd.Parameters.AddWithValue("NombreComercial", oDetalleFarmaco.NombreComercial);
                    cmd.Parameters.AddWithValue("Concentracion", oDetalleFarmaco.Concentracion);
                    cmd.Parameters.AddWithValue("FechaVencimiento", oDetalleFarmaco.FechaVencimiento);
                    cmd.Parameters.AddWithValue("NumeroLote", oDetalleFarmaco.NumeroLote);
                    cmd.Parameters.AddWithValue("PrescripcionMedica", oDetalleFarmaco.PrescripcionMedica);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
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

        public bool EliminarDetalleFarmaco(int id)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EliminarDetalleFarmaco", oConexion);
                    cmd.Parameters.AddWithValue("IdDetalleFarmaco", id);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception )
                {
                    respuesta = false;
                }

            }

            return respuesta;

        }


    }
}
