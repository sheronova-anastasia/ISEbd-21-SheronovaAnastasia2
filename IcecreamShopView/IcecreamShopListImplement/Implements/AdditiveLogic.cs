using IcecreamShopBusinessLogic.BindingModels;
using IcecreamShopBusinessLogic.Interfaces;
using IcecreamShopBusinessLogic.ViewModels;
using IcecreamShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IcecreamShopListImplement.Implements
{
    public class AdditiveLogic : IAdditiveLogic
    {
        private readonly DataListSingleton source;
        public AdditiveLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(AdditiveBindingModel model)
        {
            Additive tempAdditive = model.Id.HasValue ? null : new Additive
            {
                Id = 1
            };
            foreach (var additive in source.Additives)
            {
                if (additive.AdditiveName == model.AdditiveName && additive.Id !=
               model.Id)
                {
                    throw new Exception("Уже есть добавка с таким названием");
                }
                if (!model.Id.HasValue && additive.Id >= tempAdditive.Id)
                {
                    tempAdditive.Id = additive.Id + 1;
                }
                else if (model.Id.HasValue && additive.Id == model.Id)
                {
                    tempAdditive = additive;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempAdditive == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempAdditive);
            }
            else
            {
                source.Additives.Add(CreateModel(model, tempAdditive));
            }
        }
        public void Delete(AdditiveBindingModel model)
        {
            for (int i = 0; i < source.Additives.Count; ++i)
            {
                if (source.Additives[i].Id == model.Id.Value)
                {
                    source.Additives.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        public List<AdditiveViewModel> Read(AdditiveBindingModel model)
        {
            List<AdditiveViewModel> result = new List<AdditiveViewModel>();
            foreach (var additive in source.Additives)
            {
                if (model != null)
                {
                    if (additive.Id == model.Id)
                    {
                        result.Add(CreateViewModel(additive));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(additive));
            }
            return result;
        }
        private Additive CreateModel(AdditiveBindingModel model, Additive additive)
        {
            additive.AdditiveName = model.AdditiveName;
            return additive;
        }
        private AdditiveViewModel CreateViewModel(Additive additive)
        {
            return new AdditiveViewModel
            {
                Id = additive.Id,
                AdditiveName = additive.AdditiveName
            };
        }
    }
}
