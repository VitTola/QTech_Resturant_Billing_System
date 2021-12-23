using QTech.Base;
using QTech.Base.BaseModels;
using QTech.Base.Helpers;
using QTech.Base.Models;
using QTech.Base.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QTech.Db.MasterLogic;

namespace QTech.Db.Logics
{
    public class CurrencyLogic : DbLogic<Currency, CurrencyLogic>
    {
        public override Currency AddAsync(Currency entity)
        {
            var result = base.AddAsync(entity);
            if (result != null)
            {
                AuditTrailLogic.Instance.AddManualAuditTrail<Currency, int, Currency>(entity, null, GeneralProcess.Add);
            }
            return result;
        }
        public override Currency UpdateAsync(Currency entity)
        {
            var oldEntity = base.GetOldEntityAsync(entity).Result;
            var result = base.UpdateAsync(entity);
            if (result != null)
            {
                AuditTrailLogic.Instance.AddManualAuditTrail<Currency, int, Currency>(entity, oldEntity, GeneralProcess.Update);
            }
            return result;
        }
    }
}
