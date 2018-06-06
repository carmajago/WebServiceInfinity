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

       
        public virtual List<Planeta> nodos { get; set; }

        public virtual List<AristaNodo> grafo { get; set; }

        [ForeignKey("nebulosa")]
        public int nebulosaFK { get; set; }
        [JsonIgnore]
        public Nebulosa nebulosa { get; set; }

        [JsonIgnore]
        public AristaSistema arista { get; set; }

        public float iridioTotal { get{return ObtIridioTotal(); } }

        public float platinoTotal { get { return ObtPlatinoTotal(); } }

        public float paladioTotal { get { return ObtPaladioTotal(); } }

        public float elementoZeroTotal { get { return ObtElementoZeroTotal(); } }

      
        private float ObtIridioTotal()
        {
            float total = 0;
            if (nodos != null)
            {
                foreach (var item in nodos)
                {
                   if(item is Planeta)
                    {
                       Planeta planeta = (Planeta)item;
                        total = total + (float)planeta.iridio;
                    }
                }
                return total;
            }
            return -1;
        }

        private float ObtPlatinoTotal()
        {
            float total = 0;
            if (nodos != null)
            {
                foreach (var item in nodos)
                {
                    if (item is Planeta)
                    {
                        Planeta planeta = (Planeta)item;
                        total = total + (float)planeta.platino;
                    }
                }
                return total;
            }
            return -1;
        }

        private float ObtPaladioTotal()
        {
            float total = 0;
            if (nodos != null)
            {
                foreach (var item in nodos)
                {
                    if (item is Planeta)
                    {
                        Planeta planeta = (Planeta)item;
                        total = total + (float)planeta.paladio;
                    }
                }
                return total;
            }
            return -1;
        }

        private float ObtElementoZeroTotal()
        {
            float total = 0;
            if (nodos != null)
            {
                foreach (var item in nodos)
                {
                    if (item is Planeta)
                    {
                        Planeta planeta = (Planeta)item;
                        total = total + (float)planeta.elementoZero;
                    }
                }
                return total;
            }
            return -1;
        }

    }
}