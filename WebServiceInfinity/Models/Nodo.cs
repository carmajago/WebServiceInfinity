using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebServiceInfinity.Models
{
    public abstract class Nodo
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }

        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }

        public string idModelo { get; set; }

        [ForeignKey("sistemaPlanetario")]
        public int sistemaPlanetarioFK { get; set; }
        [JsonIgnore]
        public SistemaPlanetario sistemaPlanetario { get; set; }
    }
}