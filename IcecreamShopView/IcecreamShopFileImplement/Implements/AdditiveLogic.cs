using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IcecreamShopBusinessLogic.BindingModels;
using IcecreamShopBusinessLogic.Interfaces;
using IcecreamShopBusinessLogic.ViewModels;
using IcecreamShopFileImplement.Models;

namespace IcecreamShopFileImplement.Implements
{
    public class AdditiveLogic : IAdditiveLogic
    {
        private readonly FileDataListSingleton source;
        public AdditiveLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(AdditiveBindingModel model)
        {
            Additive element = source.Additives.FirstOrDefault(rec => rec.AdditiveName
           == model.AdditiveName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть добавка с таким названием");
            }
            if (model.Id.HasValue)
            {
                element = source.Additives.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Additives.Count > 0 ? source.Additives.Max(rec =>
               rec.Id) : 0;
                element = new Additive { Id = maxId + 1 };
                source.Additives.Add(element);
            }
            element.AdditiveName = model.AdditiveName;
        }
        public void Delete(AdditiveBindingModel model)
        {
            Additive element = source.Additives.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                source.Additives.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public List<AdditiveViewModel> Read(AdditiveBindingModel model)
        {
            return source.Additives
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
