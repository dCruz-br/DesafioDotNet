using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;


namespace KhipoAPI.Repositorio
{
    public static class ConexaoBanco
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ConexaoSQL"].ConnectionString;
            }

        } 

    }
}