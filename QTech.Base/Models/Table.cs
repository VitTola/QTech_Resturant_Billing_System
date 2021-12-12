using QTech.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base.Models
{
    public class Table : ActiveBaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public TableStatus TableStus { get; set; }
        public bool IsUseable { get; set; }
    }
}
