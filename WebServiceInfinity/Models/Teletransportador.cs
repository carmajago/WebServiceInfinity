using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebServiceInfinity.Models
{
    public class Teletransportador
    {
    
        

        [Display(Name = "Nombre")]
        public string nombre { get; set; }



        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }

        [Key,ForeignKey("sistemaPlanetario")]
        public int sistemaFK { get; set; }

        public SistemaPlanetario sistemaPlanetario { get; set; }
    }
}