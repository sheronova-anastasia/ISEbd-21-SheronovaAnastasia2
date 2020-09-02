using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using IcecreamShopBusinessLogic.Interfaces;
using IcecreamShopBusinessLogic.BindingModels;
using IcecreamShopBusinessLogic.ViewModels;
using IcecreamShopBusinessLogic.HelperModels;

namespace IcecreamShopBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IAdditiveLogic AdditiveLogic;
        private readonly IIcecreamLogic IcecreamLogic;
        private readonly IOrderLogic orderLogic;
        public ReportLogic(IIcecreamLogic IcecreamLogic, IAdditiveLogic AdditiveLogic,
       IOrderLogic orderLogic)
        {
            this.IcecreamLogic = IcecreamLogic;
            this.AdditiveLogic = AdditiveLogic;
            this.orderLogic = orderLogic;
        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        public List<ReportIcecreamAdditiveViewModel> GetIcecreamAdditive()
        {
            var Icecreams = IcecreamLogic.Read(null);
            var list = new List<ReportIcecreamAdditiveViewModel>();
            foreach (var icecream in Icecreams)
            {
                foreach (var vt in icecream.IcecreamAdditives)
                {
                    var record = new ReportIcecreamAdditiveViewModel
                    {
                        IcecreamName = icecream.IcecreamName,
                        AdditiveName = vt.Value.Item1,
                        Count = vt.Value.Item2
                    };
                    list.Add(record);
                }
            }
            return list;
        }
        public List<IGrouping<DateTime, OrderViewModel>> GetOrders(ReportBindingModel model)
        {
            var list = orderLogic
            .Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .GroupBy(rec => rec.DateCreate.Date)
            .OrderBy(recG => recG.Key)
            .ToList();

            return list;
        }
        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveIcecreamsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список добавок",
                Icecreams = IcecreamLogic.Read(null)
            });
        }
        /// <summary>
        /// Сохранение закусок с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetOrders(model)
            });
        }
        /// <summary>
        /// Сохранение закусок с продуктами в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        [Obsolete]
        public void SaveIcecreamsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список добавок по мороженому",
                IcecreamAdditives = GetIcecreamAdditive(),
            });
        }
    }
}
