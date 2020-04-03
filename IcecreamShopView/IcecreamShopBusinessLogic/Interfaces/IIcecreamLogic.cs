using IcecreamShopBusinessLogic.BindingModels;
using IcecreamShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace IcecreamShopBusinessLogic.Interfaces
{
    public interface IIcecreamLogic
    {
        List<IcecreamViewModel> Read(IcecreamBindingModel model);
        void CreateOrUpdate(IcecreamBindingModel model);
        void Delete(IcecreamBindingModel model);
    }
}
