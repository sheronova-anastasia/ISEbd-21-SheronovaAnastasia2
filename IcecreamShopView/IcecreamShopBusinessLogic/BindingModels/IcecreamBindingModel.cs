using System;
using System.Collections.Generic;
using System.Text;

namespace IcecreamShopBusinessLogic.BindingModels
{
    public class IcecreamBindingModel
    {
        public int? Id { get; set; }
        public string IcecreamName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> IcecreamAdditives { get; set; }
    }
}
