using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioReactivoDesktop.Models
{
    public class Container
    {
        public Guid Id { get; set; }
        [NotMapped]
        public bool SoftDelete { get; set; }
        public bool Active { get; set; }             //Si el envase todavía contiene sustancia
        [DataType(DataType.Date)]
        public DateTime? DeleteDate { get; set; }
        public decimal Capacity { get; set; }
        public decimal? Purity { get; set; }
        public string Catalogue { get; set; }
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }
        public int ContainerID { get; set; }
        [MaxLength(20)]
        public string Location { get; set; }
        [MaxLength(20)]
        public string Last_Location { get; set; }
        [MaxLength(20)]
        public string Batch { get; set; }
        // Esta propiedad se utilizada para quitar el container de la posesion del usuario, para filtrarlos registros tambien
    }
}
