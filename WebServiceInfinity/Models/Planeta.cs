using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebServiceInfinity.Models
{
    public class Planeta
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        public string idModelo { get; set; }

      

        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }

        public double iridio { get; set; }
        public double platino  { get; set; }
        public double paladio { get; set; }
        public double elementoZero { get; set; }


        [ForeignKey("sistemaPlanetario")]
        public int sistemaPlanetarioFK { get; set; }

        public SistemaPlanetario sistemaPlanetario { get; set; }

    }
}