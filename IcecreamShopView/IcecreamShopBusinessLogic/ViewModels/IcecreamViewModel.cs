using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;
using IcecreamShopBusinessLogic.Attributes;

namespace IcecreamShopBusinessLogic.ViewModels
{
    [DataContract]
    public class IcecreamViewModel : BaseViewModel
    {
        [Column(title: "Название путевки", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string IcecreamName { get; set; }
        [Column(title: "Цена", width: 50)]
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> IcecreamAdditives { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "IcecreamName",
            "Price"
        };
    }
}
