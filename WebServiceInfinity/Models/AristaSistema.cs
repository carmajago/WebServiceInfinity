using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebServiceInfinity.Models
{
    public class AristaSistema
    {
        [Key]
        public int id { get; set; }

        [JsonIgnore]
        [ForeignKey("origenFK")]
        public SistemaPlanetario origen { get; set; }

        [JsonIgnore]
        [ForeignKey("destinoFK")]
        public SistemaPlanetario destino { get; set; }

        [JsonIgnore]
        [ForeignKey("nebulosaFK")]
        public Nebulosa nebulosa { get; set; }



        public int origenFK { get; set; }
        public int destinoFK { get; set; }
        public int nebulosaFK { get; set; }
    }
}