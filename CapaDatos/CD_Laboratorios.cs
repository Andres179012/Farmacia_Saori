using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CapaModelo;

namespace CapaDatos
{
    public class CD_Laboratorios
    {
        public static CD_Laboratorios _instancia = null;

        private CD_Laboratorios()
        {

        }

        public static CD_Laboratorios Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_Laboratorios();
                }
                return _instancia;
            }
        }

        public List<Laboratorios> ObtenerLaboratorio()
        {
            var rptListaLaboratorio = new List<Laboratorios>();
            using (SqlConnection oConexion = new SqlConnection("Server=.;Database=FarmaciaSaoriDB;User Id=sa;Password=123"))
            {
                SqlCommand cmd = new SqlCommand("USP_LaboratorioObtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaLaboratorio.Add(new Laboratorios()
                        {
                            Id_Laboratorio = Convert.ToInt32(dr["Id_Laboratorio"].ToString()),
                            Nombre_Laboratorio = dr["Nombre_Laboratorio"].ToString(),
                            Direccion = dr["Direccion"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Politica_Vencimiento = dr["Politica_Vencimiento"].ToString(),
                            Cantidad_Meses = Convert.ToInt32(dr["Cantidad_Meses"].ToString()),
                            Estado = Convert.ToBoolean(dr["Estado"].ToString())
                        });
                    }
                    dr.Close();

                    return rptListaLaboratorio;

                }
                catch
                {
                    rptListaLaboratorio = null;
                    return rptListaLaboratorio;
                }
            }
        }

        public bool RegistrarLaboratorio(Laboratorios oLaboratorios)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection("Server=.;Database=FarmaciaSaoriDB;User Id=sa;Password=123"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_LaboratorioRegistrar", oConexion);
                    cmd.Parameters.AddWithValue("NombreLaboratorio", oLaboratorios.Nombre_Laboratorio);
                    cmd.Parameters.AddWithValue("Direccion", oLaboratorios.Direccion);
                    cmd.Parameters.AddWithValue("Telefono", oLaboratorios.Telefono);
                    cmd.Parameters.AddWithValue("PoliticaVencimiento", oLaboratorios.Politica_Vencimiento);
                    cmd.Parameters.AddWithValue("CantidadMeses", oLaboratorios.Cantidad_Meses);
                    cmd.Parameters.AddWithValue("Estado", oLaboratorios.Estado);
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

        public bool ModificarLaboratorio(Laboratorios oLaboratorios)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection("Server=.;Database=FarmaciaSaoriDB;User Id=sa;Password=123"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_LaboratorioModificar", oConexion);
                    cmd.Parameters.AddWithValue("IdLaboratorio", oLaboratorios.Id_Laboratorio);
                    cmd.Parameters.AddWithValue("Nombre_Laboratorio", oLaboratorios.Nombre_Laboratorio);
                    cmd.Parameters.AddWithValue("Direccion", oLaboratorios.Direccion);
                    cmd.Parameters.AddWithValue("Telefono", oLaboratorios.Telefono);
                    cmd.Parameters.AddWithValue("PoliticaVencimiento", oLaboratorios.Politica_Vencimiento);
                    cmd.Parameters.AddWithValue("CantidadMeses", oLaboratorios.Cantidad_Meses);
                    cmd.Parameters.AddWithValue("Estado", oLaboratorios.Estado);
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

        public bool EliminarLaboratorio(int IdLaboratorio)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection("Server =.; Database = FarmaciaSaoriDB; User Id = sa; Password = 123"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_LaboratorioEliminar", oConexion);
                    cmd.Parameters.AddWithValue("IdLaboratorio", IdLaboratorio);
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
