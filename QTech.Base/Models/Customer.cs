using EasyServer.Domain.Models;
using QTech.Base.Helpers;
using QTech.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base
{
    public class Customer: QTech.Base.ActiveBaseModel
    {
        [AuditData(Ignored:true)]
        public string Code { get; set; }
        [AuditData(resourceName: "Name", index: 1)]
        public string Name { get; set; }
        [AuditData(resourceName: "Phone", index: 2)]
        public string Phone { get; set; }
        [AuditData(resourceName: "Note", index: 3)]
        public string Note { get; set; }
    }
}
