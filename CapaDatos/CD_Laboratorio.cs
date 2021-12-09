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
    public class CD_Laboratorio
    {
        public static CD_Laboratorio _instancia = null;

        private CD_Laboratorio()
        {

        }

        public static CD_Laboratorio Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_Laboratorio();
                }
                return _instancia;
            }
        }


        public List<Laboratorio> ObtenerLaboratorio()
        {
            List<Laboratorio> rptListaLaboratorio = new List<Laboratorio>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("USP_LaboratorioObtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaLaboratorio.Add(new Laboratorio()
                        {
                            IdLaboratorio = Convert.ToInt32(dr["IdLaboratorio"].ToString()),
                            NombreLaboratorio = dr["NombreLaboratorio"].ToString(),
                            RUC = dr["RUC"].ToString(),
                            RazonSocial = dr["RazonSocial"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Direccion = dr["Direccion"].ToString(),
                            PoliticaVencimiento = dr["PoliticaVencimiento"].ToString(),
                            CantidadMeses = Convert.ToInt32(dr["CantidadMeses"].ToString()),
                            Activo = Convert.ToBoolean(dr["Activo"])

                        });
                    }
                    dr.Close();

                    return rptListaLaboratorio;

                }
                catch (Exception ex)
                {
                    rptListaLaboratorio = null;
                    return rptListaLaboratorio;
                }
            }
        }


        public bool RegistrarLaboratorio(Laboratorio oLaboratorio)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_LaboratorioRegistrar", oConexion);
                    cmd.Parameters.AddWithValue("NombreLaboratorio", oLaboratorio.NombreLaboratorio);
                    cmd.Parameters.AddWithValue("RUC", oLaboratorio.RUC);
                    cmd.Parameters.AddWithValue("RazonSocial", oLaboratorio.RazonSocial);
                    cmd.Parameters.AddWithValue("Telefono", oLaboratorio.Telefono);
                    cmd.Parameters.AddWithValue("Correo", oLaboratorio.Correo);
                    cmd.Parameters.AddWithValue("Direccion", oLaboratorio.Direccion);
                    cmd.Parameters.AddWithValue("PoliticaVencimiento", oLaboratorio.PoliticaVencimiento);
                    cmd.Parameters.AddWithValue("CantidadMeses", oLaboratorio.CantidadMeses);
                    cmd.Parameters.AddWithValue("Activo", oLaboratorio.Activo);
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

        public bool ModificarLaboratorio(Laboratorio olaboratorio)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_LaboratorioModificar", oConexion);
                    cmd.Parameters.AddWithValue("IdLaboratorio", olaboratorio.IdLaboratorio);
                    cmd.Parameters.AddWithValue("NombreLaboratorio", olaboratorio.NombreLaboratorio);
                    cmd.Parameters.AddWithValue("RUC", olaboratorio.RUC);
                    cmd.Parameters.AddWithValue("RazonSocial", olaboratorio.RazonSocial);
                    cmd.Parameters.AddWithValue("Telefono", olaboratorio.Telefono);
                    cmd.Parameters.AddWithValue("Correo", olaboratorio.Correo);
                    cmd.Parameters.AddWithValue("Direccion", olaboratorio.Direccion);
                    cmd.Parameters.AddWithValue("PoliticaVencimiento", olaboratorio.PoliticaVencimiento);
                    cmd.Parameters.AddWithValue("CantidadMeses", olaboratorio.CantidadMeses);
                    cmd.Parameters.AddWithValue("Activo", olaboratorio.Activo);
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

        public bool EliminarLaboratorio(int id)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_LaboratorioEliminar", oConexion);
                    cmd.Parameters.AddWithValue("IdLaboratorio", id);
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
