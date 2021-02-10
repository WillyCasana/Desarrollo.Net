using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppRestWinService
{
   public static class WinServiceRepo
    {
       static string cadConexion = @"Server=DESKTOP-4KPFF10\SVR2016;Database=Prueba;UID=admin;PWD=clave654321";

        public static void RegistrarLog(string mensaje)
        {
            using(SqlConnection sqlConn = new SqlConnection(cadConexion))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("usp_logWinServiceInsert", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mensaje", mensaje);
                int r = cmd.ExecuteNonQuery();
            }
        }

    }
}
