using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebServiceInfinity.Models
{
    public class Deposito
    {
        
            public Planeta planeta { get; set; }

            [ForeignKey("planeta"),Key]
            public int planetaFK { get; set; }
        

    }
}