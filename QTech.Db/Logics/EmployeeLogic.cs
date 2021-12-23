using QTech.Base;
using QTech.Base.BaseModels;
using QTech.Base.Enums;
using QTech.Base.Helpers;
using QTech.Base.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QTech.Db.MasterLogic;

namespace QTech.Db.Logics
{
    public class EmployeeLogic: DbLogic<Employee,EmployeeLogic>
    {
        public override Employee FindAsync(int id)
        {
            var result = All().FirstOrDefault(x => x.Active && x.Id == id);
            return result;
        }
        public override Employee AddAsync(Employee entity)
        {
            var result = base.AddAsync(entity);
            if (result != null)
            {
                AuditTrailLogic.Instance.AddManualAuditTrail<Employee, int, Employee>(entity, null, GeneralProcess.Add);
            }
            return result;
        }
        public override Employee UpdateAsync(Employee entity)
        {
            var oldEntity = base.GetOldEntityAsync(entity).Result;
            var result = base.UpdateAsync(entity);
            if (result != null)
            {
                AuditTrailLogic.Instance.AddManualAuditTrail<Employee, int, Employee>(entity, oldEntity, GeneralProcess.Update);
            }
            return result;
        }
        public override Employee RemoveAsync(Employee entity)
        {
            var employee = base.RemoveAsync(entity);
            return employee;
        }
        public override bool CanRemoveAsync(Employee entity)
        {
            return true;
        }
        public override List<Employee> SearchAsync(ISearchModel model)
        {
            var result = Search(model)?.ToList() ?? new List<Employee>();
            return result;
        }
        public override IQueryable<Employee> Search(ISearchModel model)
        {
            var param = model as EmployeeSearch;
            var q = All();
            if (!string.IsNullOrEmpty(param.Search))
            {
                q = q.Where(x => x.Name.ToLower().Contains(param.Search.ToLower()));
            }
            return q;
        }
        public List<Employee> GetEmployeesByIds(List<int>ids)
        {
            return _db.Employees.Where(x => x.Active && ids.Any(i => i == x.Id)).ToList();
        }
    }
}
