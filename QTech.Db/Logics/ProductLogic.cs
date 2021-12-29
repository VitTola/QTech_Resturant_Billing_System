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
using System.Runtime;
using Storm.Domain.Helpers;

namespace QTech.Db.Logics
{
    public class ProductLogic:DbLogic<Product,ProductLogic>
    {
        public ProductLogic()
        {
        }
        public override Product FindAsync(int id)
        {
            var result = All().FirstOrDefault(x => x.Active && x.Id == id);
            return result;
        }
        public override bool CanRemoveAsync(Product entity)
        {
            if (!All().Any(x =>x.Active && x.Id == entity.Id))
            {
                return false;
            }
            else if (_db.SaleDetails.Any(x=>x.Active && x.ProductId ==entity.Id))
            {
                return false;
            }
            return true;
        }
        public override List<Product> SearchAsync(ISearchModel model)
        {
            var result = Search(model).ToList();
            return result;
        }
        public override IQueryable<Product> Search(ISearchModel model)
        {
            var param = model as ProductSearch;
            var q = All();
            if (!string.IsNullOrEmpty(param.Search))
            {
                q = q.Where(x => x.Name.ToLower().Contains(param.Search.ToLower()));
            }
            if (param.categoryId != 0)
            {
                q = q.Where(x => x.CategoryId == param.categoryId);
                  
            }
            return q;
        }
        public override bool IsExistsAsync(Product entity)
        {
            return All().Any(x => x.Name == entity.Name​ && x.Id != entity.Id);
        }

        public override Product AddAsync(Product entity)
        {
            var result = base.AddAsync(entity);
            if (result != null)
            {
                AuditTrailLogic.Instance.AddManualAuditTrail<Product, int,ProductPrice>(entity, null, GeneralProcess.Add);
            }

            entity.ProductPrices?.ForEach(x =>
            {
                x.ProductId = result.Id;
                ProductPriceLogic.Instance.AddAsync(x);
            });

            return result;
        }

        public override Product UpdateAsync(Product entity)
        {
            var oldObject = ProductLogic.Instance.FindAsync(entity.Id);
            oldObject.ProductPrices = ProductPriceLogic.Instance.SearchAsync(new ProductPriceSearch { ProductId = entity.Id });
            var result = base.UpdateAsync(entity);
            if (result != null)
            {

                var newEntity = new Product();
                    entity.CopyTo<Product>(newEntity);
                newEntity.ProductPrices = newEntity.ProductPrices.Where(x => x.Active).ToList();
                AuditTrailLogic.Instance.AddManualAuditTrail<Product, int,ProductPrice>(newEntity, oldObject, GeneralProcess.Update);
            }
            if (entity.ProductPrices?.Any() ?? false)
            {
                foreach (var s in entity.ProductPrices)
                {
                    var isExist = ProductPriceLogic.Instance.IsExistsAsync(s);
                    if (isExist)
                    {
                        ProductPriceLogic.Instance.UpdateAsync(s);
                    }
                    else
                    {
                        s.ProductId = result.Id;
                        ProductPriceLogic.Instance.AddAsync(s);
                    }
                }
            }

            return result;
        }
      
    }
}
