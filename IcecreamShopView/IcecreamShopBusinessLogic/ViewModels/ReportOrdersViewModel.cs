using System;
using System.Collections.Generic;
using System.Text;
using IcecreamShopBusinessLogic.Enums;

namespace IcecreamShopBusinessLogic.ViewModels
{
    public class ReportOrdersViewModel
    {
        public DateTime DateCreate { get; set; }
        public string IcecreamName { get; set; }
        public string AdditiveName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
    }
}
