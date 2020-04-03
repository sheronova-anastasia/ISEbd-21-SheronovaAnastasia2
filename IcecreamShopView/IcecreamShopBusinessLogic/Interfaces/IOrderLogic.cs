﻿using IcecreamShopBusinessLogic.BindingModels;
using IcecreamShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace IcecreamShopBusinessLogic.Interfaces
{
    public interface IOrderLogic
    {
        List<OrderViewModel> Read(OrderBindingModel model);
        void CreateOrUpdate(OrderBindingModel model);
        void Delete(OrderBindingModel model);
    }
}
