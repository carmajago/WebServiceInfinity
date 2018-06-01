using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebServiceInfinity.Models
{
    public class Planeta:Nodo
    {
           

 

        public double iridio { get; set; }
        public double platino  { get; set; }
        public double paladio { get; set; }
        public double elementoZero { get; set; }

    }
}