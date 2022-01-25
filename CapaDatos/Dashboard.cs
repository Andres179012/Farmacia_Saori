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
    public class Dashboard
    {
        public static Dashboard _instancia = null;

        private Dashboard()
        {

        }

        public static Dashboard Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Dashboard();
                }
                return _instancia;
            }
        }

        protected string Dashborad1()
        {
            DataTable Datos = new DataTable();
            Datos.Columns.Add(new DataColumn("task", typeof(string)));
            Datos.Columns.Add(new DataColumn("Hours", typeof(string)));

            Datos.Rows.Add(new Object[] { "work", 11 });
            Datos.Rows.Add(new Object[] { "Eat", 2 });
            Datos.Rows.Add(new Object[] { "Commute", 2 });
            Datos.Rows.Add(new Object[] { "work", 2 });
            Datos.Rows.Add(new Object[] { "Sleep", 7 });

            string srtDatos;
            srtDatos = "[['task','Hours'],";

            foreach (DataRow dr in Datos.Rows)
            {
                srtDatos = srtDatos + "[";
                srtDatos = srtDatos + "'"+dr[0]+"'"+","+dr[1];
                srtDatos = srtDatos + "],";
            }

            srtDatos = srtDatos + "]";

            return srtDatos;
        }
    }
}
