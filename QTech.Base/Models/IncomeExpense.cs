using QTech.Base.Enums;
using QTech.Base.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base.Models
{
    public class IncomeExpense : QTech.Base.ActiveBaseModel
    {
        [AuditData(resourceName: "MisNo", index: 1)]
        public string MiscNo { get; set; }
        [AuditData(resourceName: "DoDate", index: 2)]
        public DateTime DoDate { get; set; }
        [AuditData(resourceName: "Note", index: 3)]
        public string Note { get; set; }
        [AuditData(resourceName: "Amount", index: 4)]
        public decimal Amount { get; set; }
        [AuditData(resourceName: "MiscellaneousType", index: 5)]
        public MiscellaneousType MiscellaneousType { get; set; }
    }
}
