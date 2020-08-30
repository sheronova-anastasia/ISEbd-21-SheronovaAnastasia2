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
    public class IcecreamLogic : IIcecreamLogic
    {
        private readonly FileDataListSingleton source;
        public IcecreamLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(IcecreamBindingModel model)
        {
            Icecream element = source.Icecreams.FirstOrDefault(rec => rec.IcecreamName ==
           model.IcecreamName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть мороженое с таким названием");
            }
            if (model.Id.HasValue)
            {
                element = source.Icecreams.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Icecreams.Count > 0 ? source.Additives.Max(rec =>
               rec.Id) : 0;
                element = new Icecream { Id = maxId + 1 };
                source.Icecreams.Add(element);
            }
            element.IcecreamName = model.IcecreamName;
            element.Price = model.Price;
            // удалили те, которых нет в модели
            source.IcecreamAdditives.RemoveAll(rec => rec.IcecreamId == model.Id &&
           !model.IcecreamAdditives.ContainsKey(rec.AdditiveId));
            // обновили количество у существующих записей
            var updateAdditives = source.IcecreamAdditives.Where(rec => rec.IcecreamId ==
           model.Id && model.IcecreamAdditives.ContainsKey(rec.AdditiveId));
            foreach (var updateAdditive in updateAdditives)
            {
                updateAdditive.Count =
               model.IcecreamAdditives[updateAdditive.AdditiveId].Item2;
                model.IcecreamAdditives.Remove(updateAdditive.AdditiveId);
            }
            // добавили новые
            int maxPCId = source.IcecreamAdditives.Count > 0 ?
           source.IcecreamAdditives.Max(rec => rec.Id) : 0;
            foreach (var pc in model.IcecreamAdditives)
            {
                source.IcecreamAdditives.Add(new IcecreamAdditive
                {
                    Id = ++maxPCId,
                    IcecreamId = element.Id,
                    AdditiveId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
        }
        public void Delete(IcecreamBindingModel model)
        {
            // удаяем записи по турам при удалении путевки
            source.IcecreamAdditives.RemoveAll(rec => rec.IcecreamId == model.Id);
            Icecream element = source.Icecreams.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Icecreams.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public List<IcecreamViewModel> Read(IcecreamBindingModel model)
        {
            return source.Icecreams
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new IcecreamViewModel
            {
                Id = rec.Id,
                IcecreamName = rec.IcecreamName,
                Price = rec.Price,
                IcecreamAdditives = source.IcecreamAdditives
            .Where(recPC => recPC.IcecreamId == rec.Id)
            .ToDictionary(recPC => recPC.AdditiveId, recPC =>
            (source.Additives.FirstOrDefault(recC => recC.Id ==
           recPC.AdditiveId)?.AdditiveName, recPC.Count))
            })
            .ToList();
        }
    }
}
