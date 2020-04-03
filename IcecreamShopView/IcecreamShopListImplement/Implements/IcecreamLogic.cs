using IcecreamShopBusinessLogic.BindingModels;
using IcecreamShopBusinessLogic.Interfaces;
using IcecreamShopBusinessLogic.ViewModels;
using IcecreamShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IcecreamShopListImplement.Implements
{
    public class IcecreamLogic : IIcecreamLogic
    {
        private readonly DataListSingleton source;
        public IcecreamLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(IcecreamBindingModel model)
        {
            Icecream tempIcecream = model.Id.HasValue ? null : new Icecream { Id = 1 };
            foreach (var icecream in source.Icecreams)
            {
                if (icecream.IcecreamName == model.IcecreamName && icecream.Id != model.Id)
                {
                    throw new Exception("Уже есть мороженое с таким названием");
                }
                if (!model.Id.HasValue && icecream.Id >= tempIcecream.Id)
                {
                    tempIcecream.Id = icecream.Id + 1;
                }
                else if (model.Id.HasValue && icecream.Id == model.Id)
                {
                    tempIcecream = icecream;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempIcecream == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempIcecream);
            }
            else
            {
                source.Icecreams.Add(CreateModel(model, tempIcecream));
            }
        }
        public void Delete(IcecreamBindingModel model)
        {
            for (int i = 0; i < source.IcecreamAdditives.Count; ++i)
            {
                if (source.IcecreamAdditives[i].IcecreamId == model.Id)
                {
                    source.IcecreamAdditives.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Icecreams.Count; ++i)
            {
                if (source.Icecreams[i].Id == model.Id)
                {
                    source.Icecreams.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Icecream CreateModel(IcecreamBindingModel model, Icecream icecream)
        {
            icecream.IcecreamName = model.IcecreamName;
            icecream.Price = model.Price;
            int maxPCId = 0;
            for (int i = 0; i < source.IcecreamAdditives.Count; ++i)
            {
                if (source.IcecreamAdditives[i].Id > maxPCId)
                {
                    maxPCId = source.IcecreamAdditives[i].Id;
                }
                if (source.IcecreamAdditives[i].IcecreamId == icecream.Id)
                {
                    if
                    (model.IcecreamAdditives.ContainsKey(source.IcecreamAdditives[i].AdditiveId))
                    {
                        source.IcecreamAdditives[i].Amount =
                        model.IcecreamAdditives[source.IcecreamAdditives[i].AdditiveId].Item2;
                        model.IcecreamAdditives.Remove(source.IcecreamAdditives[i].IcecreamId);
                    }
                    else
                    {
                        source.IcecreamAdditives.RemoveAt(i--);
                    }
                }
            }
            foreach (var ia in model.IcecreamAdditives)
            {
                source.IcecreamAdditives.Add(new IcecreamAdditive
                {
                    Id = ++maxPCId,
                    IcecreamId = icecream.Id,
                    AdditiveId = ia.Key,
                    Amount = ia.Value.Item2
                });
            }
            return icecream;
        }
        public List<IcecreamViewModel> Read(IcecreamBindingModel model)
        {
            List<IcecreamViewModel> result = new List<IcecreamViewModel>();
            foreach (var additive in source.Icecreams)
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
        private IcecreamViewModel CreateViewModel(Icecream icecream)
        {
            Dictionary<int, (string, int)> icecreamAdditives = new Dictionary<int, (string, int)>();
            foreach (var ia in source.IcecreamAdditives)
            {
                if (ia.IcecreamId == icecream.Id)
                {
                    string additiveName = string.Empty;
                    foreach (var additive in source.Additives)
                    {
                        if (ia.AdditiveId == additive.Id)
                        {
                            additiveName = additive.AdditiveName;
                            break;
                        }
                    }
                    icecreamAdditives.Add(ia.AdditiveId, (additiveName, ia.Amount));
                }
            }
            return new IcecreamViewModel
            {
                Id = icecream.Id,
                IcecreamName = icecream.IcecreamName,
                Price = icecream.Price,
                IcecreamAdditives = icecreamAdditives
            };
        }
    }
}
