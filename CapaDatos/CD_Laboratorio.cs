using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaModelo;

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
                            Id_Laboratorio = Convert.ToInt32(dr["Id_Categoria"].ToString()),
                            Nombre_Laboratorio = dr["Nombre_Laboratorio"].ToString(),
                            Direccion = dr["Direccion"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Politica_Vencimiento = dr[" Politica_Vencimiento"].ToString(),
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

      /*  public bool RegistrarCategoria(Categorias oCategoria)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection("Server=.;Database=FarmaciaSaoriDB;User Id=sa;Password=123"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_CategoriaRegistrar", oConexion);
                    cmd.Parameters.AddWithValue("Categoria", oCategoria.Categoria);
                    cmd.Parameters.AddWithValue("Descripcion", oCategoria.Descripcion = (oCategoria.Descripcion != null ? oCategoria.Descripcion : ""));
                    cmd.Parameters.AddWithValue("Estado", oCategoria.Estado);
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

        public bool ModificarCategoria(Categorias oCategoria)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection("Server=.;Database=FarmaciaSaoriDB;User Id=sa;Password=123"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_CategoriaModificar", oConexion);
                    cmd.Parameters.AddWithValue("IdCategoria", oCategoria.Id_Categoria);
                    cmd.Parameters.AddWithValue("Categoria", oCategoria.Categoria);
                    cmd.Parameters.AddWithValue("Descripcion", oCategoria.Descripcion = (oCategoria.Descripcion != null ? oCategoria.Descripcion : ""));
                    cmd.Parameters.AddWithValue("Estado", oCategoria.Estado);
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

        public bool EliminarCategoria(int IdCategoria)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection("Server =.; Database = FarmaciaSaoriDB; User Id = sa; Password = 123"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_CategoriaEliminar", oConexion);
                    cmd.Parameters.AddWithValue("IdCategoria", IdCategoria);
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
      
        }*/
    }
}
