using IcecreamShopBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IcecreamShopBusinessLogic.BindingModels
{
    public class OrderBindingModel
    {
        public int? Id { get; set; }
        public int IcecreamId { get; set; }
        public int Amount { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
    }
}
