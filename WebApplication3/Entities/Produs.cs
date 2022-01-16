using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Entities
{
    public class Produs
    {
        [Key]
        public int ProdusId { get; set; }
        public string Type { get; set; }
        public virtual Comanda Comanda { get; set; }
    }
}
