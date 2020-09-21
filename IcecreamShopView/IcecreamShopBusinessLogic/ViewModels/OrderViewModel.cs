using IcecreamShopBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace IcecreamShopBusinessLogic.ViewModels
{
    [DataContract]
    public class OrderViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        [DisplayName("ID")]
        public int IcecreamId { get; set; }
        [DataMember]
        [DisplayName("Клиент")]
        public string ClientFIO { get; set; }
        [DataMember]
        [DisplayName("Мороженое")]
        public string IcecreamName { get; set; }
        [DisplayName("Количество")]
        [DataMember]
        public int Count { get; set; }
        [DisplayName("Сумма")]
        [DataMember]
        public decimal Sum { get; set; }
        [DisplayName("Статус")]
        [DataMember]
        public OrderStatus Status { get; set; }
        [DisplayName("Дата создания")]
        [DataMember]
        public DateTime DateCreate { get; set; }
        [DisplayName("Дата выполнения")]
        [DataMember]
        public DateTime? DateImplement { get; set; }
    }
}
