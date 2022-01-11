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
    public class TableLogic : DbLogic<Table, TableLogic>
    {
        public override Table FindAsync(int id)
        {
            var result = All().FirstOrDefault(x => x.Active && x.Id == id);
            return result;
        }
        public override bool CanRemoveAsync(Table entity)
        {
            return All().Any(x => x.Id == entity.Id);
        }
        public override bool CanRemoveAsync(int id)
        {
            return true;
        }
        public override List<Table> SearchAsync(ISearchModel model)
        {
            var result = Search(model).ToList();
            return result;
        }
        public override IQueryable<Table> Search(ISearchModel model)
        {
            var param = model as TableSearch;
            var q = All().Where(x=>x.Active);
            if (!string.IsNullOrEmpty(param?.Search))
            {
                q = q.Where(x => x.Name.ToLower().Contains(param.Search.ToLower()));
            }
            return q;
        }
        public override bool IsExistsAsync(Table entity)
        {
            return All().Any(x=>x.Name.ToLower() == entity.Name.ToLower());
        }
        public override Table AddAsync(Table entity)
        {
            var result = base.AddAsync(entity);
            if (result != null)
            {
                AuditTrailLogic.Instance.AddManualAuditTrail<Table, int, Table>(entity, null, GeneralProcess.Add);
            }
            return result;
        }
        public override Table UpdateAsync(Table entity)
        {
            var oldEntity = base.GetOldEntityAsync(entity).Result;
            var result = base.UpdateAsync(entity);
            if (result != null)
            {
                AuditTrailLogic.Instance.AddManualAuditTrail<Table, int, Table>(entity, oldEntity, GeneralProcess.Update);
            }
            return result;
        }

        public bool SetTableToFree(int id)
        {
            try
            {
                var _table = FindAsync(id);
                if (_table != null)
                {
                    _table.CurrentSaleId = 0;
                    _table.TableStus = Base.Enums.TableStatus.Free;
                    _db.Tables.Attach(_table);
                    _db.Entry(_table).Property(x => x.TableStus).IsModified = true;
                    _db.Entry(_table).Property(x => x.CurrentSaleId).IsModified = true;
                    _db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }
    }
}
