using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using IcecreamShopBusinessLogic.Attributes;

namespace IcecreamShopBusinessLogic.ViewModels
{
    public class AdditiveViewModel : BaseViewModel
    {
        [Column(title: "Добавка", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string AdditiveName { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "AdditiveName"
        };
    }
}
