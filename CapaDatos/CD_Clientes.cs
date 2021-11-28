using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CapaModelo;

namespace CapaDatos
{
    public class CD_Clientes
    {
        public static CD_Clientes _instancia = null;

        private CD_Clientes()
        {
        }

        public static CD_Clientes Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_Clientes();
                }
                return _instancia;
            }
        }

        public List<Clientes> ObtenerClientes()
        {
            var rptListaCliente = new List<Clientes>();
            using (SqlConnection oConexion = new SqlConnection("Server=.;Database=FarmaciaSaoriDB;User Id=sa;Password=123"))
            {
                SqlCommand cmd = new SqlCommand("USP_ClienteObtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaCliente.Add(new Clientes()
                        {
                            Id_Cliente = Convert.ToInt32(dr["Id_Cliente"].ToString()),
                            Nombre_Cliente = dr["Nombre_Cliente"].ToString(),
                            Apellido_Paterno = dr["Apellido_Paterno"].ToString(),
                            Apellido_Materno = dr["Apellido_Materno"].ToString(),
                            Direccion = dr["Direccion"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Identificacion = dr["Identificacion"].ToString(),
                            Estado = Convert.ToBoolean(dr["Estado"].ToString())
                        });
                    }
                    dr.Close();

                    return rptListaCliente;

                }
                catch
                {
                    rptListaCliente = null;
                    return rptListaCliente;
                }
            }
        }

        public bool RegistrarCliente(Clientes oCliente)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection("Server=.;Database=FarmaciaSaoriDB;User Id=sa;Password=123"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_ClienteRegistrar", oConexion);
                    cmd.Parameters.AddWithValue("NombreCliente", oCliente.Nombre_Cliente);
                    cmd.Parameters.AddWithValue("ApellidoPaterno", oCliente.Apellido_Paterno);
                    cmd.Parameters.AddWithValue("ApellidoMaterno", oCliente.Apellido_Materno);
                    cmd.Parameters.AddWithValue("Direccion", oCliente.Direccion);
                    cmd.Parameters.AddWithValue("Telefono", oCliente.Telefono);
                    cmd.Parameters.AddWithValue("Identificacion", oCliente.Identificacion);
                    cmd.Parameters.AddWithValue("Estado", oCliente.Estado);
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

        public bool ModificarCliente(Clientes oCliente)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection("Server=.;Database=FarmaciaSaoriDB;User Id=sa;Password=123"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_ClienteModificar", oConexion);
                    cmd.Parameters.AddWithValue("IdCliente", oCliente.Nombre_Cliente);
                    cmd.Parameters.AddWithValue("NombreCliente", oCliente.Nombre_Cliente);
                    cmd.Parameters.AddWithValue("ApellidoPaterno", oCliente.Apellido_Paterno);
                    cmd.Parameters.AddWithValue("ApellidoMaterno", oCliente.Apellido_Materno);
                    cmd.Parameters.AddWithValue("Direccion", oCliente.Direccion);
                    cmd.Parameters.AddWithValue("Telefono", oCliente.Telefono);
                    cmd.Parameters.AddWithValue("Identificacion", oCliente.Identificacion);
                    cmd.Parameters.AddWithValue("Estado", oCliente.Estado);
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

        public bool EliminarCliente(int IdCliente)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection("Server =.; Database = FarmaciaSaoriDB; User Id = sa; Password = 123"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_ClienteEliminar", oConexion);
                    cmd.Parameters.AddWithValue("IdCliente", IdCliente);
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
