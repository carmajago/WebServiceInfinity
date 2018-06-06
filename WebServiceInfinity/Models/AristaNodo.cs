using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebServiceInfinity.Models
{
    public class AristaNodo
    {
        [Key]
        public int id { get; set; }

        
        [ForeignKey("origenFK")]
        public virtual Planeta origen { get; set; }
       
        [ForeignKey("destinoFK")]
        public virtual Planeta destino { get; set; }

        public int origenFK { get; set; }
        public int destinoFK { get; set; }


        [JsonIgnore]
        [ForeignKey("sistemaFK")]
        public SistemaPlanetario sistema { get; set; }

        public int sistemaFK { get; set; }

    }
}