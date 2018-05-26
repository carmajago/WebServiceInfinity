using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebServiceInfinity.Models
{
    public class SistemaPlanetario
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Nombre")]
        public string nombre { get; set; }


        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }

        [JsonIgnore]
        public  List<Nodo> nodos { get; set; }

        public virtual List<AristaNodo> grafo { get; set; }

        [ForeignKey("nebulosa")]
        public int nebulosaFK { get; set; }
        [JsonIgnore]
        public Nebulosa nebulosa { get; set; }

        [JsonIgnore]
        public AristaSistema arista { get; set; }
    }
}