using System;
using System.Collections.Generic;
using System.Text;
using IcecreamShopBusinessLogic.ViewModels;

namespace IcecreamShopBusinessLogic.HelperModels
{
    class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<IcecreamViewModel> Icecreams { get; set; }
    }
}
