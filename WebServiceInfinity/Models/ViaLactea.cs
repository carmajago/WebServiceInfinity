using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebServiceInfinity.Models
{
    public class ViaLactea
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        
        
        public virtual List<Nebulosa> Nebulosas { get; set; }

        public int totalNebulosas
        {
            get 
            {
                if (Nebulosas!=null)
                return Nebulosas.Count();
                return -1;
            }
        }
    }
}