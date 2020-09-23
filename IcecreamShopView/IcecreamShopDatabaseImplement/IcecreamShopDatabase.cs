using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using IcecreamShopDatabaseImplement.Models;

namespace IcecreamShopDatabaseImplement
{
    public class IcecreamShopDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-9BTVFQR\SQLEXPRESS;Initial Catalog=IcecreamShopDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Additive> Additives { set; get; }
        public virtual DbSet<Icecream> Icecreams { set; get; }
        public virtual DbSet<IcecreamAdditive> IcecreamAdditives { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<Client> Clients { set; get; }
        public virtual DbSet<Implementer> Implementers { set; get; }
    }
}
