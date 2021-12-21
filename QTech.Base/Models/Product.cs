using QTech.Base.Helpers;
using QTech.Db.Logics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base.Models
{
    public class Product : ActiveBaseModel
    {
        [AuditData(Ignored:true)]
        public string Code { get; set; }
        [AuditData(resourceName:"Name",index:1)]
        public string Name { get; set; }
        [AuditData(resourceName:"UnitPrice",index:2)]
        public decimal UnitPrice { get; set; }
        [AuditData(resourceName:"Note",index:3)]
        public string Note { get; set; }
        [AuditData(index: 4)]
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        [AuditData(Ignored: true)]
        public byte [] Photo { get; set; }
        [AuditData(resourceName:"PhotoPath",index:5)]
        public string PhotoPath { get; set; }


    }
}
