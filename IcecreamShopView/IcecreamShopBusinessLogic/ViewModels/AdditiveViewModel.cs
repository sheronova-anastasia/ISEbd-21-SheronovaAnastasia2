using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace IcecreamShopBusinessLogic.ViewModels
{
    public class AdditiveViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название добавки")]
        public string AdditiveName { get; set; }
    }
}
