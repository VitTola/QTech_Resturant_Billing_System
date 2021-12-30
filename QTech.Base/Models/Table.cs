using QTech.Base.Enums;
using QTech.Base.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base.Models
{
    public class Table : ActiveBaseModel
    {
        [AuditData(Ignored:true)]
        public string Code { get; set; }
        [AuditData(resourceName:"Name",index:1)]
        public string Name { get; set; }
        [AuditData(resourceName: "Note", index: 2)]
        public string Note { get; set; }
        [AuditData(Ignored:true)]
        public TableStatus TableStus { get; set; }
        [AuditData(resourceName: "Usable", index: 1)]
        public bool IsUseable { get; set; }
        [AuditData(Ignored: true)]
        public int CurrentSaleId { get; set; }
    }
}
