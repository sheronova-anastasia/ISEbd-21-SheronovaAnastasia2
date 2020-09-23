using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using IcecreamShopBusinessLogic.Enums;
using IcecreamShopFileImplement.Models;

namespace IcecreamShopFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string AdditiveFileName = "C:\\Users\\Настя\\Document\\IcecreamShop\\Additive.xml";
        private readonly string OrderFileName = "C:\\Users\\Настя\\Document\\IcecreamShop\\Order.xml";
        private readonly string IcecreamFileName = "C:\\Users\\Настя\\Document\\IcecreamShop\\Icecream.xml";
        private readonly string IcecreamAdditiveFileName = "C:\\Users\\Настя\\Document\\IcecreamShop\\IcecreamAdditive.xml";
        private readonly string ClientFileName = "C:\\Users\\Настя\\Document\\IcecreamShop\\Client.xml";
        private readonly string ImplementerFileName = "C:\\Users\\Настя\\Document\\IcecreamShop\\Implementer.xml";
        public List<Additive> Additives { get; set; }
        public List<Order> Orders { get; set; }
        public List<Icecream> Icecreams { get; set; }
        public List<IcecreamAdditive> IcecreamAdditives { get; set; }
        public List<Client> Clients { get; set; }
        public List<Implementer> Implementers { get; set; }
        private FileDataListSingleton()
        {
            Additives = LoadAdditives();
            Orders = LoadOrders();
            Icecreams = LoadIcecreams();
            IcecreamAdditives = LoadIcecreamAdditives();
            Clients = LoadClients();
            Implementers = LoadImplementers();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        ~FileDataListSingleton()
        {
            SaveAdditives();
            SaveOrders();
            SaveIcecreams();
            SaveIcecreamAdditives();
            SaveClients();
            SaveImplementers();
        }
        private List<Additive> LoadAdditives()
        {
            var list = new List<Additive>();
            if (File.Exists(AdditiveFileName))
            {
                XDocument xDocument = XDocument.Load(AdditiveFileName);
                var xElements = xDocument.Root.Elements("Additive").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Additive
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        AdditiveName = elem.Element("AdditiveName").Value
                    });
                }
            }
            return list;
        }
        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        IcecreamId = Convert.ToInt32(elem.Element("IcecreamId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus),
                        elem.Element("Status").Value),
                        DateCreate =
                         Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement =
                   string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null :
                   Convert.ToDateTime(elem.Element("DateImplement").Value),
                    });
                }
            }
            return list;
        }
        private List<Icecream> LoadIcecreams()
        {
            var list = new List<Icecream>();
            if (File.Exists(IcecreamFileName))
            {
                XDocument xDocument = XDocument.Load(IcecreamFileName);
                var xElements = xDocument.Root.Elements("Icecream").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Icecream
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        IcecreamName = elem.Element("IcecreamName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value)
                    });
                }
            }
            return list;
        }
        private List<IcecreamAdditive> LoadIcecreamAdditives()
        {
            var list = new List<IcecreamAdditive>();
            if (File.Exists(IcecreamAdditiveFileName))
            {
                XDocument xDocument = XDocument.Load(IcecreamAdditiveFileName);
                var xElements = xDocument.Root.Elements("IcecreamAdditive").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new IcecreamAdditive
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        IcecreamId = Convert.ToInt32(elem.Element("IcecreamId").Value),
                        AdditiveId = Convert.ToInt32(elem.Element("AdditiveId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value)
                    });
                }
            }
            return list;
        }
        private List<Client> LoadClients()
        {
            var list = new List<Client>();
            if (File.Exists(ClientFileName))
            {
                XDocument xDocument = XDocument.Load(ClientFileName);
                var xElements = xDocument.Root.Elements("Client").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Client
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ClientFIO = elem.Element("ClientFIO").Value,
                        Email = elem.Element("Email").Value,
                        Password = elem.Element("Password").Value
                    });
                }
            }
            return list;
        }
        private void SaveAdditives()
        {
            if (Additives != null)
            {
                var xElement = new XElement("Additives");
                foreach (var additive in Additives)
                {
                    xElement.Add(new XElement("Additive",
                    new XAttribute("Id", additive.Id),
                    new XElement("AdditiveName", additive.AdditiveName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(AdditiveFileName);
            }
        }
        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("IcecreamId", order.IcecreamId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SaveIcecreams()
        {
            if (Icecreams != null)
            {
                var xElement = new XElement("Icecreams");
                foreach (var icecream in Icecreams)
                {
                    xElement.Add(new XElement("Icecream",
                    new XAttribute("Id", icecream.Id),
                    new XElement("IcecreamName", icecream.IcecreamName),
                    new XElement("Price", icecream.Price)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(IcecreamFileName);
            }
        }
        private void SaveIcecreamAdditives()
        {
            if (IcecreamAdditives != null)
            {
                var xElement = new XElement("IcecreamAdditives");
                foreach (var icecreamAdditive in IcecreamAdditives)
                {
                    xElement.Add(new XElement("IcecreamAdditive",
                    new XAttribute("Id", icecreamAdditive.Id),
                    new XElement("IcecreamId", icecreamAdditive.IcecreamId),
                    new XElement("AdditiveId", icecreamAdditive.AdditiveId),
                    new XElement("Count", icecreamAdditive.Count)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(IcecreamAdditiveFileName);
            }
        }
        private void SaveClients()
        {
            if (Clients != null)
            {
                var xElement = new XElement("Clients");
                foreach (var client in Clients)
                {
                    xElement.Add(new XElement("Client",
                    new XAttribute("Id", client.Id),
                    new XElement("ClientFIO", client.ClientFIO),
                    new XElement("Email", client.Email),
                    new XElement("Password", client.Password)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ClientFileName);
            }
        }
        private List<Implementer> LoadImplementers()
        {
            var list = new List<Implementer>();
            if (File.Exists(ImplementerFileName))
            {
                XDocument xDocument = XDocument.Load(ImplementerFileName);
                var xElements = xDocument.Root.Elements("Implementer").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Implementer
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ImplementerFIO = elem.Element("ImplementerFIO").Value,
                        WorkingTime = Convert.ToInt32(elem.Element("WorkingTime").Value),
                        PauseTime = Convert.ToInt32(elem.Element("PauseTime").Value)
                    });
                }
            }
            return list;
        }
        private void SaveImplementers()
        {
            if (Implementers != null)
            {
                var xElement = new XElement("Implementers");
                foreach (var implementer in Implementers)
                {
                    xElement.Add(new XElement("Implementer",
                    new XAttribute("Id", implementer.Id),
                    new XElement("ImplementerFIO", implementer.ImplementerFIO),
                    new XElement("WorkingTime", implementer.WorkingTime),
                    new XElement("PauseTime", implementer.PauseTime)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ImplementerFileName);
            }
        }
    }
}
