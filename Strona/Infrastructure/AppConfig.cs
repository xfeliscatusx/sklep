using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Strona.Infrastructure
{
    public class AppConfig
    {
        private static string _obrazkiFolderWzgledny = System.Configuration.ConfigurationManager.AppSettings["ObrazkiFolder"];

        
        public static string ObrazkiFolderWzgledny
        {
            get
            {
                return _obrazkiFolderWzgledny;
            }
        }

        
    }
}