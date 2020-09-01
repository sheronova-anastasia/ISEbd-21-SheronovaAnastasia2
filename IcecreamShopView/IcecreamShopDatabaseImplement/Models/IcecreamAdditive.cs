using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IcecreamShopDatabaseImplement.Models
{
    public class IcecreamAdditive
    {
        public int Id { get; set; }
        public int IcecreamId { get; set; }
        public int AdditiveId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Additive Additive { get; set; }
        public virtual Icecream Icecream { get; set; }
    }
}
