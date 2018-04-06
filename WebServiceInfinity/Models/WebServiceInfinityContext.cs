using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebServiceInfinity.Models
{
    public class WebServiceInfinityContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WebServiceInfinityContext() : base("name=WebServiceInfinityContext")
        {
        }

       
        public System.Data.Entity.DbSet<WebServiceInfinity.Models.SistemaPlanetario> SistemaPlanetarios { get; set; }

        public System.Data.Entity.DbSet<WebServiceInfinity.Models.Nebulosa> Nebulosas { get; set; }

        public System.Data.Entity.DbSet<WebServiceInfinity.Models.ViaLactea> ViaLacteas { get; set; }

        public System.Data.Entity.DbSet<WebServiceInfinity.Models.Planeta> Planetas { get; set; }

        public System.Data.Entity.DbSet<WebServiceInfinity.Models.Teletransportador> Teletransportadors { get; set; }

        public System.Data.Entity.DbSet<WebServiceInfinity.Models.Deposito> Depositoes { get; set; }
    }
}
