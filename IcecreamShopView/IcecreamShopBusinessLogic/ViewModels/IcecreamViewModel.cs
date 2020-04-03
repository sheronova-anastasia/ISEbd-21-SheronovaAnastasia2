using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace IcecreamShopBusinessLogic.ViewModels
{
    public class IcecreamViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название мороженого")]
        public string IcecreamName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> IcecreamAdditives { get; set; }
    }
}
