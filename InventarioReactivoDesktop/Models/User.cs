using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioReactivoDesktop.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string MiddleName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string Initials { get; set; }
        public bool Active { get; set; }

        public string UserIdentity { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }

        public int UserIDPedidos { get; set; }
    }
}
