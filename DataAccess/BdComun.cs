﻿using System.Data.SqlClient;

namespace Taller.DataAccess
{
    public class BdComun
    {

       public static SqlConnection ObtenerConexion()
       {
           SqlConnection conectar = new SqlConnection("Data Source=ROCIO\\ROCIO;Initial Catalog=Taller;Integrated Security=true;");

           conectar.Open();
           return conectar;
       }

    }
}
