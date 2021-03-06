using QTech.Base;
using QTech.Base.BaseModels;
using QTech.Base.Models;
using QTech.Base.OutFaceModels;
using QTech.Base.SearchModels;
using QTech.ReportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QTech.Db.MasterLogic;

namespace QTech.Db.Logics
{
    public class SaleDetailLogic:DbLogic<SaleDetail, SaleDetailLogic>
    {
        public SaleDetailLogic()
        {
        }
        public override SaleDetail AddAsync(SaleDetail entity)
        {
            return base.AddAsync(entity);
        }
        public override SaleDetail UpdateAsync(SaleDetail entity)
        {
            return base.UpdateAsync(entity);
        }
        public override SaleDetail FindAsync(int id)
        {
            var result = All().FirstOrDefault(x => x.Active && x.Id == id);
            return result;
        }
        public override bool CanRemoveAsync(SaleDetail entity)
        {
            return All().Any(x => x.Id == entity.Id);
        }
        public override bool IsExistsAsync(SaleDetail entity)
        {
            var result = _db.SaleDetails.Any(x => x.Id == entity.Id);
            return result;
        }
        public List<SaleDetail> GetSaleDetailBySaleId(int s)
        {
            var result = _db.SaleDetails.Where(x => x.SaleId == s && x.Active).ToList();
            return result;
        }
        public override List<SaleDetail> SearchAsync(ISearchModel model)
        {
            var result = Search(model).ToList();
            return result;
        }
        public override IQueryable<SaleDetail> Search(ISearchModel model)
        {
            var param = model as SaleDetailSearch;
            var q = All().Where(x => x.Active);
            if (param.SaleId != 0)
            {
                q = q.Where(x => x.SaleId == param.SaleId);
            }
            return q;
        }
        public List<EmployeeBillOutFace> GetEmployeeBillOutFaces(ISearchModel model)
        {
            var param = model as EmployeeBillSearch;
            var q = All();
            if (param.CustomerId == -1)
            {
                var result = from saleDetail in q
                             join employee in _db.Employees.Where(x=>x.Active) on saleDetail.EmployeeId equals employee.Id
                             join sale in _db.Sales.Where(x => x.Active && x.SaleType == Base.Enums.SaleType.General) on saleDetail.SaleId equals sale.Id
                             join product in _db.Products.Where(x => x.Active) on saleDetail.ProductId equals product.Id
                             join category in _db.Categories.Where(x => x.Active) on product.CategoryId equals category.Id

                             where param.EmployeeBillId != 0 ?
                             (saleDetail.EmployeeBillId == param.EmployeeBillId && saleDetail.Active)
                             :
                             (sale.SaleDate >= param.D1 && sale.SaleDate <= param.D2
                             && (param.DriverId == 0 ? true : employee.Id == param.DriverId)
                             && (saleDetail.PayStatus == Base.Enums.PayStatus.NotYetPaid)
                             && saleDetail.Active)

                             select new EmployeeBillOutFace()
                             {
                                 PurchaseOrderNo = string.Empty,
                                 InvoiceNo = sale.InvoiceNo,
                                 ToCompany = sale.CustomerName,
                                 ToSite = string.Empty,
                                 SaleDate = sale.SaleDate,
                                 Product = product.Name,
                                 Category = category.Name,
                                 ImportPrice = saleDetail.ImportPrice,
                                 Qauntity = saleDetail.Qauntity,
                                 ImportTotalAmount = saleDetail.ImportTotalAmount,
                                 saleDetail = saleDetail
                             };

                var res = result.GroupBy(x => x.saleDetail).Select(y => y.FirstOrDefault()).ToList();
                return res;
            }
            else if(param.CustomerId == 0)
            {
                var result = from saleDetail in q
                             join employee in _db.Employees.Where(x => x.Active) on saleDetail.EmployeeId equals employee.Id
                             join sale in _db.Sales.Where(x => x.Active && x.SaleType == Base.Enums.SaleType.Company) on saleDetail.SaleId equals sale.Id
                             join customer in _db.Customers.Where(x => x.Active) on sale.CompanyId equals customer.Id into cusotmers
                             from cusResult in cusotmers.DefaultIfEmpty()
                             join site in _db.Sites.Where(x => x.Active) on sale.SiteId equals site.Id into sites
                             from sitResult in sites.DefaultIfEmpty()
                             join product in _db.Products.Where(x => x.Active) on saleDetail.ProductId equals product.Id
                             join category in _db.Categories.Where(x => x.Active) on product.CategoryId equals category.Id
                             join p in _db.PurchaseOrders.Where(p => p.Active) on sale.PurchaseOrderId equals p.Id

                             where param.EmployeeBillId != 0 ?
                             (saleDetail.EmployeeBillId == param.EmployeeBillId && saleDetail.Active)
                             :
                             (sale.SaleDate >= param.D1 && sale.SaleDate <= param.D2
                             && (param.DriverId == 0 ? true : employee.Id == param.DriverId)
                             && (param.CustomerId == 0 ? true : cusResult.Id == param.CustomerId)
                             && (param.SiteId == 0 ? true : sitResult.Id == param.SiteId)
                             && (saleDetail.PayStatus == Base.Enums.PayStatus.NotYetPaid)
                             && saleDetail.Active)

                             select new EmployeeBillOutFace()
                             {
                                 PurchaseOrderNo = p.Name,
                                 InvoiceNo = sale.InvoiceNo,
                                 ToCompany = cusResult.Name,
                                 ToSite = sitResult.Name,
                                 SaleDate = sale.SaleDate,
                                 Product = product.Name,
                                 Category = category.Name,
                                 ImportPrice = saleDetail.ImportPrice,
                                 Qauntity = saleDetail.Qauntity,
                                 ImportTotalAmount = saleDetail.ImportTotalAmount,
                                 saleDetail = saleDetail
                             };

                var result1 = from saleDetail in q
                             join employee in _db.Employees.Where(x => x.Active) on saleDetail.EmployeeId equals employee.Id
                             join sale in _db.Sales.Where(x => x.Active && x.SaleType == Base.Enums.SaleType.General) on saleDetail.SaleId equals sale.Id
                             join product in _db.Products.Where(x => x.Active) on saleDetail.ProductId equals product.Id
                             join category in _db.Categories.Where(x => x.Active) on product.CategoryId equals category.Id

                             where param.EmployeeBillId != 0 ?
                             (saleDetail.EmployeeBillId == param.EmployeeBillId && saleDetail.Active)
                             :
                             (sale.SaleDate >= param.D1 && sale.SaleDate <= param.D2
                             && (param.DriverId == 0 ? true : employee.Id == param.DriverId)
                             && (saleDetail.PayStatus == Base.Enums.PayStatus.NotYetPaid)
                             && saleDetail.Active)

                             select new EmployeeBillOutFace()
                             {
                                 PurchaseOrderNo = string.Empty,
                                 InvoiceNo = sale.InvoiceNo,
                                 ToCompany = sale.CustomerName,
                                 ToSite = string.Empty,
                                 SaleDate = sale.SaleDate,
                                 Product = product.Name,
                                 Category = category.Name,
                                 ImportPrice = saleDetail.ImportPrice,
                                 Qauntity = saleDetail.Qauntity,
                                 ImportTotalAmount = saleDetail.ImportTotalAmount,
                                 saleDetail = saleDetail
                             };

                var res = result.Union(result1).GroupBy(x => x.saleDetail).Select(y => y.FirstOrDefault()).ToList();
                return res;
            }
            else
            {
                var result = from saleDetail in q
                             join employee in _db.Employees on saleDetail.EmployeeId equals employee.Id
                             join sale in _db.Sales on saleDetail.SaleId equals sale.Id
                             join customer in _db.Customers on sale.CompanyId equals customer.Id into cusotmers
                             from cusResult in cusotmers.DefaultIfEmpty()
                             join site in _db.Sites on sale.SiteId equals site.Id into sites
                             from sitResult in sites.DefaultIfEmpty()
                             join product in _db.Products on saleDetail.ProductId equals product.Id
                             join category in _db.Categories on product.CategoryId equals category.Id
                             join p in _db.PurchaseOrders.Where(p => p.Active) on sale.PurchaseOrderId equals p.Id

                             where param.EmployeeBillId != 0 ?
                             (saleDetail.EmployeeBillId == param.EmployeeBillId && saleDetail.Active)
                             :
                             (sale.SaleDate >= param.D1 && sale.SaleDate <= param.D2
                             && (param.DriverId == 0 ? true : employee.Id == param.DriverId)
                             && (param.CustomerId == 0 ? true : cusResult.Id == param.CustomerId)
                             && (param.SiteId == 0 ? true : sitResult.Id == param.SiteId)
                             && (saleDetail.PayStatus == Base.Enums.PayStatus.NotYetPaid)
                             && saleDetail.Active)

                             select new EmployeeBillOutFace()
                             {
                                 PurchaseOrderNo = p.Name,
                                 InvoiceNo = sale.InvoiceNo,
                                 ToCompany = cusResult.Name,
                                 ToSite = sitResult.Name,
                                 SaleDate = sale.SaleDate,
                                 Product = product.Name,
                                 Category = category.Name,
                                 ImportPrice = saleDetail.ImportPrice,
                                 Qauntity = saleDetail.Qauntity,
                                 ImportTotalAmount = saleDetail.ImportTotalAmount,
                                 saleDetail = saleDetail
                             };

                var res = result.GroupBy(x => x.saleDetail).Select(y => y.FirstOrDefault()).ToList();
                return res;
            }
           
        }
        
        public List<MonthlyInvoice> GetMonthlyInvoiceBySaleIds(List<int> saleIds)
        {
            if (saleIds.Count==0)
            {
                return new List<MonthlyInvoice>(); 
            }
            var result = from sale in _db.Sales.Where(s => s.Active && saleIds.Any(r => r == s.Id))
                         join site in _db.Sites.Where(x=>x.Active) on sale.SiteId equals site.Id into sites
                         from siteResult in sites.DefaultIfEmpty()
                         join sd in _db.SaleDetails.Where(x => x.Active) on sale.Id equals sd.SaleId
                         join pro in _db.Products.Where(x => x.Active) on sd.ProductId equals pro.Id
                         join cat in _db.Categories.Where(x => x.Active) on pro.CategoryId equals cat.Id
                         select new MonthlyInvoice()
                         {
                             SaleDate = sale.SaleDate,
                             InvoiceNo = sale.InvoiceNo,
                             Qauntity = sd.Qauntity,
                             UnitPrice = sd.SalePrice,
                             TotalInUSD = sd.Total,
                             PurchaseOrderNo = sale.PurchaseOrderNo,
                             Site =string.IsNullOrEmpty(siteResult.Name) ? sale.CustomerName : siteResult.Name,
                             Product = pro.Name+cat.Name
                         };
            return result.ToList();
        }
       

    }
}
