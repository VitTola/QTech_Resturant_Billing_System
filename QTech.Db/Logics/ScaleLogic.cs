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
    public class ScaleLogic : DbLogic<Scale, ScaleLogic>
    {
        public override Scale FindAsync(int id)
        {
            var result = All().FirstOrDefault(x => x.Active && x.Id == id);
            return result;
        }
        public override bool CanRemoveAsync(Scale entity)
        {
            return All().Any(x => x.Id == entity.Id);
        }
        public override bool CanRemoveAsync(int id)
        {
            return true;
        }
        public override List<Scale> SearchAsync(ISearchModel model)
        {
            var result = Search(model).ToList();
            return result;
        }
        public override IQueryable<Scale> Search(ISearchModel model)
        {
            var param = model as ScaleSearch;
            var q = All();
            if (!string.IsNullOrEmpty(param?.Search))
            {
                q = q.Where(x => x.Name.ToLower().Contains(param.Search.ToLower()));
            }
            return q;
        }
        public override Scale AddAsync(Scale entity)
        {
            var result = base.AddAsync(entity);
            if (result != null)
            {
                AuditTrailLogic.Instance.AddManualAuditTrail<Scale, int, Scale>(entity, null, GeneralProcess.Add);
            }
            return result;
        }
        public override Scale UpdateAsync(Scale entity)
        {
            var oldEntity = base.GetOldEntityAsync(entity).Result;
            var result = base.UpdateAsync(entity);
            if (result != null)
            {
                AuditTrailLogic.Instance.AddManualAuditTrail<Scale, int, Scale>(entity, oldEntity, GeneralProcess.Update);
            }
            return result;
        }

        public List<Scale> GetScaleByIds(List<int> Ids)
        {
            return _db.Scales.Where(x => x.Active && Ids.Contains(x.Id)).ToList();
        }
    }
}
