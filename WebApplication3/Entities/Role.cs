using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Entities
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string Type { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
