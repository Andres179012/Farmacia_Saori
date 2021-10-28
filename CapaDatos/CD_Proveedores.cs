using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CapaModelo;

namespace CapaDatos
{
    public class CD_Proveedores
    {
        public static CD_Proveedores _instancia = null;

        private CD_Proveedores()
        {

        }

        public static CD_Proveedores Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_Proveedores();
                }
                return _instancia;
            }
        }

        //Obtener Proveedores
        public List<Proveedores> ObtenerProveedores()
        {
            var rptListaProveedores = new List<Proveedores>();
            using (SqlConnection oConexion = new SqlConnection("Server=.;Database=FarmaciaSaoriDB;User Id=sa;Password=123"))
            {
                SqlCommand cmd = new SqlCommand("USP_ProveedorObtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaProveedores.Add(new Proveedores()
                        {
                            Id_Proveedor = Convert.ToInt32(dr["Id_Proveedor"].ToString()),
                            Proveedor = dr["Proveedor"].ToString(),
                            Visitador = dr["Visitador"].ToString(),
                            Direccion = dr["Direccion"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Estado = Convert.ToBoolean(dr["Estado"].ToString())
                        });
                    }
                    dr.Close();

                    return rptListaProveedores;

                }
                catch
                {
                    rptListaProveedores = null;
                    return rptListaProveedores;
                }
            }
        }

        public bool RegistrarProveedores(Proveedores oProveedor)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection("Server=.;Database=FarmaciaSaoriDB;User Id=sa;Password=123"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_ProveedorRegistrar", oConexion);
                    cmd.Parameters.AddWithValue("Proveedor", oProveedor.Proveedor);
                    cmd.Parameters.AddWithValue("Visitador", oProveedor.Visitador);
                    cmd.Parameters.AddWithValue("Direccion", oProveedor.Direccion);
                    cmd.Parameters.AddWithValue("Telefono", oProveedor.Telefono);
                    cmd.Parameters.AddWithValue("Estado", oProveedor.Estado);
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

        public bool ModificarProveedor(Proveedores oProveedor)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection("Server=.;Database=FarmaciaSaoriDB;User Id=sa;Password=123"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_ProveedorModificar", oConexion);
                    cmd.Parameters.AddWithValue("IdProveedor", oProveedor.Id_Proveedor);
                    cmd.Parameters.AddWithValue("Proveedor", oProveedor.Proveedor);
                    cmd.Parameters.AddWithValue("Visitador", oProveedor.Visitador);
                    cmd.Parameters.AddWithValue("Direccion", oProveedor.Direccion);
                    cmd.Parameters.AddWithValue("Telefono", oProveedor.Telefono);
                    cmd.Parameters.AddWithValue("Estado", oProveedor.Estado);
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

        public bool EliminarProveedor(int IdProveedor)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection("Server =.; Database = FarmaciaSaoriDB; User Id = sa; Password = 123"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_ProveedorEliminar", oConexion);
                    cmd.Parameters.AddWithValue("IdProveedor", IdProveedor);
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
