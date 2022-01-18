using QTech.Base;
using QTech.Base.BaseModels;
using QTech.Base.Enums;
using QTech.Base.Helpers;
using QTech.Base.Models;
using QTech.Base.OutFaceModels;
using QTech.Base.SearchModels;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static QTech.Db.MasterLogic;

namespace QTech.Db.Logics
{
    public class SaleLogic : DbLogic<Sale, SaleLogic>
    {
        List<string>ignoreProperties=null;
        public SaleLogic()
        {
            
        }
        private string NewInvoiceNumber()
        {
            string invoiceNo;
            try
            {
                var lastInvoiceNo = _db.Sales.Max(x => x.InvoiceNo);

                if (lastInvoiceNo == null)
                {
                    invoiceNo = "SYSINV-000001";
                }
                else
                {
                    int interval = int.Parse(lastInvoiceNo.Substring(7, 6));
                    interval = interval + 1;
                    invoiceNo = string.Format("SYSINV-{0:000000}", interval);
                }
                return invoiceNo;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override Sale AddAsync(Sale entity)
        {
            entity.InvoiceNo = NewInvoiceNumber();
            var result = base.AddAsync(entity);
            entity.SaleDetails.ForEach(x => {
                x.SaleId = result.Id;
                SaleDetailLogic.Instance.AddAsync(x);
            });

            //Update TableStatus
            var table = TableLogic.Instance.FindAsync(entity.TableId);
            if (table!=null)
            {
                table.CurrentSaleId = result.Id;
                table.TableStus = TableStatus.Occupy;
                _db.Tables.Attach(table);
                _db.Entry(table).Property(x => x.TableStus).IsModified = true;
                _db.Entry(table).Property(x => x.CurrentSaleId).IsModified = true;
                _db.SaveChanges();
            }

            return result;
        }
        public override Sale UpdateAsync(Sale entity)
        {
            //Update Table Status to Free In case No Order
            if (!entity.SaleDetails.Any(x=>x.Quantity > 0))
            {
                entity.Active = false;
                var _table = TableLogic.Instance.FindAsync(entity.TableId);
                _table.TableStus = TableStatus.Free;
                _table.CurrentSaleId = 0;
                TableLogic.Instance.UpdateAsync(_table);
            }
            var result = base.UpdateAsync(entity);

            UpdateSaleDetail(result.SaleDetails, result);
            return result;
        }
        private void UpdateSaleDetail(List<SaleDetail> saleDetails, Sale sale)
        {
            if (saleDetails?.Any() ?? false)
            {
                foreach (var s in saleDetails)
                {
                    if (s.Id != 0)
                    {
                        SaleDetailLogic.Instance.UpdateAsync(s);
                    }
                    else
                    {
                        s.SaleId = sale.Id;
                        SaleDetailLogic.Instance.AddAsync(s);
                    }
                }
            }
        }
        public override Sale FindAsync(int id)
        {
            var sale = All().FirstOrDefault(x => x.Active && x.Id == id);
            if (sale != null)
            {
                sale.SaleDetails = _db.SaleDetails?.Where(x => x.SaleId == sale.Id)?.ToList();
            }
            return sale;
        }
        public override bool CanRemoveAsync(Sale entity)
        {
            if (!All().Any(x => x.Active && x.Id == entity.Id))
            {
                return false;
            }
            return true;
        }
        public override List<Sale> SearchAsync(ISearchModel model)
        {
            var result = Search(model).ToList();
            return result;
        }
        public override IQueryable<Sale> Search(ISearchModel model)
        {
            var param = model as SaleSearch;
            var _saleSearchKey = param.saleSearchKey;
            var q = All().Where(x => x.Active);
            if (_saleSearchKey == SaleSearchKey.InvoiceNo && !string.IsNullOrEmpty(param.Search))
            {
                q = q.Where(x => x.InvoiceNo.ToLower().Contains(param.Search.ToLower()));
            }
            if (param.payStatus == PayStatus.Paid)
            {
                q = q.Where(x => x.PayStatus == PayStatus.Paid);
            }
            else if (param.payStatus == PayStatus.NotYetPaid)
            {
                q = q.Where(x => x.PayStatus == PayStatus.NotYetPaid);
            }
            else if (param.payStatus == PayStatus.WaitPayment)
            {
                q = q.Where(x => x.PayStatus == PayStatus.WaitPayment);
            }
            if (param?.Paging?.IsPaging == true)
            {
                q = q.GetPaged(param.Paging).Results.OrderBy(x => x.Id);
            }
            return q;
        }
        public List<Sale> GetSaleByIds(List<int> saleIds)
        {
            var q = All().Where(x => x.Active);
            q = q.Where(s => saleIds.Any(i => i == s.Id));
            return q.ToList();
        }
        public override Sale RemoveAsync(Sale entity)
        {
            var result = base.RemoveAsync(entity);
            entity.SaleDetails.ForEach(x => SaleDetailLogic.Instance.RemoveAsync(x));
            return result;
        }
       
        public override bool CanRemoveAsync(int id)
        {
            var entity = base.FindAsync(id);
            if (entity.PayStatus != PayStatus.NotYetPaid)
            {
                return false;
            }
            return true;
        }
       
        public bool IsExistedInvoiceNo(Sale sale)
        {
            return _db.Sales.Any(x => x.Active && x.InvoiceNo == sale.InvoiceNo && x.Id != sale.Id);
        }

        public override bool IsExistsAsync(Sale entity)
        {
            return _db.Sales.Any(x=>x.Active && x.Id == entity.Id);
        }
    }
}
