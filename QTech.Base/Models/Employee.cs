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
    public class Employee : ActiveBaseModel
    {
        [AuditData(Ignored: true)]
        public string Code { get; set; }
        [AuditData(resourceName: "Name", index: 1)]
        public string Name { get; set; }
        [AuditData(resourceName: "Phone", index: 1)]
        public string Phone { get; set; }
        [AuditData(Ignored: true)]
        public int PositionId { get; set; }
        [AuditData(resourceName: "Note", index: 1)]
        public string Note { get; set; }
    }

    public class Position : ActiveBaseModel
    {
        [AuditData(Ignored:true)]
        public string Code { get; set; }
        [AuditData(resourceName: "Name", index: 1)]
        public string Name { get; set; }
        [AuditData(resourceName: "Note", index: 2)]
        public string Note { get; set; }
    }
}
