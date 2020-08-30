using System;
using System.Collections.Generic;
using System.Text;

namespace IcecreamShopFileImplement.Models
{
    public class IcecreamAdditive
    {
        public int Id { get; set; }
        public int IcecreamId { get; set; }
        public int AdditiveId { get; set; }
        public int Count { get; set; }
    }
}
