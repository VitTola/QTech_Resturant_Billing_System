using QTech.Base;
using QTech.Base.BaseModels;
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
    public class ProductPriceLogic : DbLogic<ProductPrice, ProductPriceLogic>
    {
        public override List<ProductPrice> SearchAsync(ISearchModel model)
        {
            return Search(model).ToList();
        }
        public override IQueryable<ProductPrice> Search(ISearchModel model)
        {
            var param = model as ProductPriceSearch;
            var q = All();
            if (param.ProductId != 0)
            {
                q = q.Where(x => x.ProductId == param.ProductId);
            }
            return q;
        }
        public override bool IsExistsAsync(ProductPrice entity)
        {
            return All().Any(x => x.Id == entity.Id);
        }

    }
}
