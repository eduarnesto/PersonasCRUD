using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAL
{
    internal class ClsConnection
    {
        public static SqlConnection getConexion()
        {
            SqlConnection miConexion = new SqlConnection();

            try

            {

                miConexion.ConnectionString = "server=eduardo.database.windows.net;database=EduardoDB;uid=usuario;pwd=LaCampana123;trustServerCertificate = true;";

                miConexion.Open();

            }
            catch (Exception ex)
            {
                throw;
            }


            return miConexion;


        }
    }
}
