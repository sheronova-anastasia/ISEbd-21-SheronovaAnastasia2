using System;
using System.Collections.Generic;
using System.Text;
using IcecreamShopBusinessLogic.ViewModels;

namespace IcecreamShopBusinessLogic.HelperModels
{
    class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportIcecreamAdditiveViewModel> IcecreamAdditives { get; set; }
    }
}
