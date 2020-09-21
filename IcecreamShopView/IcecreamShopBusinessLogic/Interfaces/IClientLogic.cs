﻿using System;
using System.Collections.Generic;
using System.Text;
using IcecreamShopBusinessLogic.BindingModels;
using IcecreamShopBusinessLogic.ViewModels;

namespace IcecreamShopBusinessLogic.Interfaces
{
    public interface IClientLogic
    {
        List<ClientViewModel> Read(ClientBindingModel model);
        void CreateOrUpdate(ClientBindingModel model);
        void Delete(ClientBindingModel model);
    }
}
