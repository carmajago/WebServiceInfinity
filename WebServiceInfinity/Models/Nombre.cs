using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebServiceInfinity.Models
{
    public class Nombre
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
    }
}