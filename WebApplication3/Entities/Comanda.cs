using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Entities
{
    public class Comanda
    {
        [Key]
        public int ComandaId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Produs> Produse { get; set; }
    }
}
