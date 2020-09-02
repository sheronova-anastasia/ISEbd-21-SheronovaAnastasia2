﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using IcecreamShopBusinessLogic.ViewModels;

namespace IcecreamShopBusinessLogic.HelperModels
{
    class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<IGrouping<DateTime, OrderViewModel>> Orders { get; set; }
    }
}
