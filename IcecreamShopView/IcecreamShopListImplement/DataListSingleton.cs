using IcecreamShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IcecreamShopListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Additive> Additives { get; set; }
        public List<Order> Orders { get; set; }
        public List<Icecream> Icecreams { get; set; }
        public List<IcecreamAdditive> IcecreamAdditives { get; set; }
        public List<Client> Clients { get; set; }
        private DataListSingleton()
        {
            Additives = new List<Additive>();
            Orders = new List<Order>();
            Icecreams = new List<Icecream>();
            IcecreamAdditives = new List<IcecreamAdditive>();
            Clients = new List<Client>();
        }

        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
