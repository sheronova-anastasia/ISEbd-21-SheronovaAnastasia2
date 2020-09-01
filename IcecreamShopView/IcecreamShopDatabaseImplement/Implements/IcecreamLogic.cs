using Microsoft.EntityFrameworkCore;
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
    public class IcecreamLogic : IIcecreamLogic
    {
        public void CreateOrUpdate(IcecreamBindingModel model)
        {
            using (var context = new IcecreamShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Icecream element = context.Icecreams.FirstOrDefault(rec =>
                       rec.IcecreamName == model.IcecreamName && rec.Id != model.Id);
                        if (element != null)
                        {
                            throw new Exception("Уже есть добавка с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.Icecreams.FirstOrDefault(rec => rec.Id ==
                           model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                        {
                            element = new Icecream();
                            context.Icecreams.Add(element);
                        }
                        element.IcecreamName = model.IcecreamName;
                        element.Price = model.Price;
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var productComponents = context.IcecreamAdditives.Where(rec
                           => rec.IcecreamId == model.Id.Value).ToList();
                            // удалили те, которых нет в модели
                            context.IcecreamAdditives.RemoveRange(productComponents.Where(rec =>
                            !model.IcecreamAdditives.ContainsKey(rec.AdditiveId)).ToList());
                            context.SaveChanges();
                            // обновили количество у существующих записей
                            foreach (var updateComponent in productComponents)
                            {
                                updateComponent.Count =
                               model.IcecreamAdditives[updateComponent.AdditiveId].Item2;

                                model.IcecreamAdditives.Remove(updateComponent.AdditiveId);
                            }
                            context.SaveChanges();
                        }
                        // добавили новые
                        foreach (var pc in model.IcecreamAdditives)
                        {
                            context.IcecreamAdditives.Add(new IcecreamAdditive
                            {
                                IcecreamId = element.Id,
                                AdditiveId = pc.Key,
                                Count = pc.Value.Item2
                            });
                            context.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(IcecreamBindingModel model)
        {
            using (var context = new IcecreamShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.IcecreamAdditives.RemoveRange(context.IcecreamAdditives.Where(rec =>
                        rec.IcecreamId == model.Id));
                        Icecream element = context.Icecreams.FirstOrDefault(rec => rec.Id
                       == model.Id);
                        if (element != null)
                        {
                            context.Icecreams.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public List<IcecreamViewModel> Read(IcecreamBindingModel model)
        {
            using (var context = new IcecreamShopDatabase())
            {
                return context.Icecreams
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
               .Select(rec => new IcecreamViewModel
               {
                   Id = rec.Id,
                   IcecreamName = rec.IcecreamName,
                   Price = rec.Price,
                   IcecreamAdditives = context.IcecreamAdditives
                .Include(recPC => recPC.Additive)
               .Where(recPC => recPC.IcecreamId == rec.Id)
               .ToDictionary(recPC => recPC.AdditiveId, recPC =>
                (recPC.Additive?.AdditiveName, recPC.Count))
               })
               .ToList();
            }
        }
    }
}
