using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebServiceInfinity.Models
{
    public class Nebulosa
    {
        [Key]
        public int id { get; set; }

        [Display(Name ="Nombre")]
        public string nombre { get; set; }


        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }


        public List<SistemaPlanetario> sistemasPlanetarios { get; set; }

        public int totalSistemas
        {
            get {
                int total=-1;
                if (sistemasPlanetarios != null)
                {
                    total = sistemasPlanetarios.Count;
                }
                return total; }
        }
      

        [ForeignKey("viaLactea")]
        public int ViaLacteaFK { get; set; }


        [JsonIgnore]
        public ViaLactea viaLactea { get; set; }
    }
}