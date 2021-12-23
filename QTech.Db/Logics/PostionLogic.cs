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

    public class PositionLogic : DbLogic<Position, PositionLogic>
    {
        public override List<Position> SearchAsync(ISearchModel model)
        {
            return Search(model).ToList();
        }
        public override IQueryable<Position> Search(ISearchModel model)
        {
            var param = model as PositionSearch;
            var q = All();
            if (!string.IsNullOrEmpty(param?.Search))
            {
                q = q.Where(x => x.Name.ToLower().Contains(param.Search.ToLower()));
            }
            return q;

        }
        public override Position AddAsync(Position entity)
        {
            var result = base.AddAsync(entity);
            if (result != null)
            {
                AuditTrailLogic.Instance.AddManualAuditTrail<Position, int, Position>(entity, null, GeneralProcess.Add);
            }
            return result;
        }
        public override Position UpdateAsync(Position entity)
        {
            var oldEntity = base.GetOldEntityAsync(entity).Result;
            var result = base.UpdateAsync(entity);
            if (result != null)
            {
                AuditTrailLogic.Instance.AddManualAuditTrail<Position, int, Position>(entity, oldEntity, GeneralProcess.Update);
            }
            return result;
        }
    }
}
