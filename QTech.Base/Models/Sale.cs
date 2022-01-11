using EasyServer.Domain.Models;
using QTech.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base
{
    public class Sale: ActiveBaseModel
    {
        public DateTime SaleDate { get; set; }
        public string InvoiceNo { get; set; }
        public int EmployeeId { get; set; }
        public List<SaleDetail> SaleDetails{ get; set; }
        public decimal Total { get; set; }
        public decimal PaymentRecieve { get; set; }
        public decimal PaymentLeft { get; set; }
        public PayStatus PayStatus { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public decimal Profit { get; set; }
        public int TableId { get; set; }

    }

    public class SaleDetail : ActiveBaseModel
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int ScaleId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total{ get; set; }
    }
}






