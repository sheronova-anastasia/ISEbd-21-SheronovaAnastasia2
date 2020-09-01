using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IcecreamShopBusinessLogic.BindingModels;
using IcecreamShopBusinessLogic.Interfaces;
using IcecreamShopBusinessLogic.ViewModels;
using IcecreamShopDatabaseImplement.Models;

namespace IcecreamShopDatabaseImplement.Implements
{
    public class AdditiveLogic : IAdditiveLogic
    {
        public void CreateOrUpdate(AdditiveBindingModel model)
        {
            using (var context = new IcecreamShopDatabase())
            {
                Additive element = context.Additives.FirstOrDefault(rec =>
               rec.AdditiveName == model.AdditiveName && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть добавка с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Additives.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Additive();
                    context.Additives.Add(element);
                }
                element.AdditiveName = model.AdditiveName;
                context.SaveChanges();
            }
        }
        public void Delete(AdditiveBindingModel model)
        {
            using (var context = new IcecreamShopDatabase())
            {
                Additive element = context.Additives.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Additives.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<AdditiveViewModel> Read(AdditiveBindingModel model)
        {
            using (var context = new IcecreamShopDatabase())
            {
                return context.Additives
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new AdditiveViewModel
                {
                    Id = rec.Id,
                    AdditiveName = rec.AdditiveName
                })
                .ToList();
            }
        }
    }
}
