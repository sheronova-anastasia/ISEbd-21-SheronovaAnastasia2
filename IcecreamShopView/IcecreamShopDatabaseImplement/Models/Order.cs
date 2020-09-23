using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using IcecreamShopBusinessLogic.Enums;

namespace IcecreamShopDatabaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int IcecreamId { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public decimal Sum { get; set; }
        public int? ImplementerId { get; set; }
        public OrderStatus Status { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public virtual Icecream Icecream { get; set; }
        public Client Client { get; set; }
        public Implementer Implementer { get; set; }
    }
}
