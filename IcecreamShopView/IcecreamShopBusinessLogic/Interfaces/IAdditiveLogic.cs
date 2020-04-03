using IcecreamShopBusinessLogic.BindingModels;
using IcecreamShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace IcecreamShopBusinessLogic.Interfaces
{
    public interface IAdditiveLogic
    {
        List<AdditiveViewModel> Read(AdditiveBindingModel model);
        void CreateOrUpdate(AdditiveBindingModel model);
        void Delete(AdditiveBindingModel model);
    }
}
