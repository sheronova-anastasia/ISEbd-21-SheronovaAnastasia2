using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IcecreamShopDatabaseImplement.Models
{
    public class Additive
    {
        public int Id { get; set; }
        [Required]
        public string AdditiveName { get; set; }
        [ForeignKey("AdditiveId")]
        public virtual List<IcecreamAdditive> IcecreamAdditives { get; set; }

    }
}
