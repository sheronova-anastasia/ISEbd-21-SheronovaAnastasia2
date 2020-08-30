using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcecreamShopDatabaseImplement.Models
{
    public class Icecream
    {
        public int Id { get; set; }
        [Required]
        public string IcecreamName { get; set; }
        [ForeignKey("IcecreamId")]
        [Required]
        public decimal Price { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<IcecreamAdditive> IcecreamAdditives { get; set; }
    }
}
