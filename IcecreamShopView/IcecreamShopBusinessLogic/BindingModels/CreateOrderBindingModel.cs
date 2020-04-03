using System;
using System.Collections.Generic;
using System.Text;

namespace IcecreamShopBusinessLogic.BindingModels
{
    public class CreateOrderBindingModel
    {
        public int IcecreamId { get; set; }
        public int Amount { get; set; }
        public decimal Sum { get; set; }
    }
}
