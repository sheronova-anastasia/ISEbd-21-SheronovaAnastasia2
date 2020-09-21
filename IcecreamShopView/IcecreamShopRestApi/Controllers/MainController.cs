using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IcecreamShopBusinessLogic.BindingModels;
using IcecreamShopBusinessLogic.BusinessLogics;
using IcecreamShopBusinessLogic.Interfaces;
using IcecreamShopBusinessLogic.ViewModels;

namespace IcecreamShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        private readonly IIcecreamLogic _icecream;
        private readonly MainLogic _main;
        public MainController(IOrderLogic order, IIcecreamLogic icecream, MainLogic main)
        {
            _order = order;
            _icecream = icecream;
            _main = main;
        }
        [HttpGet]
        public List<IcecreamModel> GetIcecreamList() => _icecream.Read(null)?.Select(rec =>
      Convert(rec)).ToList();
        [HttpGet]
        public IcecreamModel GetIcecream(int IcecreamId) => Convert(_icecream.Read(new
       IcecreamBindingModel
        { Id = IcecreamId })?[0]);
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new
       OrderBindingModel
        { ClientId = clientId });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) =>
       _main.CreateOrder(model);
        private IcecreamModel Convert(IcecreamViewModel model)
        {
            if (model == null) return null;
            return new IcecreamModel
            {
                Id = model.Id,
                IcecreamName = model.IcecreamName,
                Price = model.Price
            };
        }
    }
}
