
using QTech.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using QTech.Base.Helpers;
using QTech.Base;
using BaseResource = QTech.Base.Properties.Resources;
using Newtonsoft.Json;
using QTech.Base.BaseModels;
using QTech.Base.SearchModels;
using System.Reflection;

using System.Collections;
using EasyServer.Domain.Helpers;
using EDomain = EasyServer.Domain;
using Easy.Domain.Helpers;
using System.ComponentModel;
using System.Data.Entity;
using QTech.Component;

namespace QTech.Db.Logics
{
    public class AuditTrailLogic : LongDbLogic<AuditTrail, AuditTrailLogic>
    {
        public AuditTrailLogic()
        {

        }
        public void AddManualAuditTrail<T, TKey>(T entity, T oldObject, GeneralProcess flag) where T : TBaseModel<TKey> where TKey : struct
        {
            var type = entity.GetType() as Type;
            var name = type.ToString().Split('.').LastOrDefault();
            if (!string.IsNullOrEmpty(name))
            {
                //name = ResourceHelper.Translate($"{name}_op");
            }
            
            var auditTrail = new AuditTrail();
            auditTrail.ClientAddress = GetMacAddress();
            auditTrail.ClientName = Environment.MachineName;
            auditTrail.CreatedBy = ShareValue.User.Name;
            auditTrail.UserId = ShareValue.User.Id;
            auditTrail.UserName = ShareValue.User.Name;
            auditTrail.TransactionDate = DateTime.Now;
            auditTrail.TablePK = entity.Id.ToString();
            auditTrail.TableName = $"{type.FullName}s";
            auditTrail.TableShortName = $"{type.Name}s";
            var opName = flag == GeneralProcess.Add ? BaseResource.Add :
               flag == GeneralProcess.Update ? BaseResource.Update : BaseResource.Remove;
            auditTrail.OperatorName = $"{opName} {ResourceHelper.Translate(name)}";

            var changlogs = GetChangeLog<T,TKey>(entity,oldObject,flag);

            var changes = JsonConvert.SerializeObject(changlogs);
            auditTrail.ChangeJson = changes;

            AuditTrailLogic.Instance.AddAsync(auditTrail);


            //_db.Entry(auditTrail).State = EntityState.Detached;
            //entity.RowDate = DateTime.Now;
            //base.SetActive(auditTrail, true);
            //_db.Entry(auditTrail).State = EntityState.Added;
            //_db.SaveChanges();
        }
        
        public override IQueryable<AuditTrail> Search(ISearchModel model)
        {
            var param = model as AuditTrailHistorySearch;
            var q = All();
            q = q.Where(x =>
                   x.TableName == param.TableName &&
                   x.TablePK == param.Pk && x.TransactionDate >= param.FromDate && x.TransactionDate <= param.ToDate);
            var test = q.ToList();
            //if (param.Paging?.IsPaging == true)
            //{
            //    q = q.GetPaged(param.Paging.CurrentPage, param.Paging.PageSize,true,true).Results;
            //}

            return q;
        }
        public override List<AuditTrail> SearchAsync(ISearchModel model)
        {
            return Search(model).OrderByDescending(x => x.TransactionDate).ToList();
        }

        static string _macAddress = null;
        public static string GetMacAddress()
        {
            if (_macAddress != null)
            {
                return _macAddress;
            }

            foreach (System.Net.NetworkInformation.NetworkInterface nic in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up)
                {
                    _macAddress += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }
            if (_macAddress == null)
            {
                _macAddress = "Unknown";
            }
            return _macAddress;
        }
      
        //public List<ChangeLog> GetChangeLogs<T, TKey>(T entity, T oldEntity, GeneralProcess flag, List<string> ignoredFields) where T : TBaseModel<TKey> where TKey : struct
        //{
        //    var changeLogs = new List<ChangeLog>();
        //    var properties = entity.GetType().GetProperties().OrderBy(x => ((QTech.Base.Helpers.AuditDataAttribute)x.GetCustomAttributes
        //    (typeof(QTech.Base.Helpers.AuditDataAttribute), true).Cast<QTech.Base.Helpers.AuditDataAttribute>().SingleOrDefault())?.Index ?? 0);
        //    foreach (var propertyInfo in properties)
        //    {
        //        if (propertyInfo.Name.EndsWith("Id") || ignoredFields.Contains(propertyInfo.Name)) continue;
        //        var changelog = GetChangeLog<T, TKey>(entity, oldEntity, propertyInfo, flag);
        //        if (changelog != null)
        //        {
        //            changeLogs.Add(changelog);
        //        }
        //    }
        //    return changeLogs;
        //}

        private List<ChangeLog> GetChangeLog<T, TKey>(T entity, T oldObject, GeneralProcess flag) where T : TBaseModel<TKey> where TKey : struct
        {
            var changeLogs = new List<ChangeLog>();
            var properties = entity.GetType().GetProperties()
                .Where(x => ((QTech.Base.Helpers.AuditDataAttribute)x.GetCustomAttributes
            (typeof(QTech.Base.Helpers.AuditDataAttribute), true).Cast<QTech.Base.Helpers.AuditDataAttribute>().SingleOrDefault())?.Ignored == false)
                .OrderBy(x => ((QTech.Base.Helpers.AuditDataAttribute)x.GetCustomAttributes
            (typeof(QTech.Base.Helpers.AuditDataAttribute), true).Cast<QTech.Base.Helpers.AuditDataAttribute>().SingleOrDefault())?.Index ?? 0);
            foreach (var property in properties) 
            {
                if (property.Name.EndsWith("Id")) continue;
                dynamic newValue = property.GetValue(entity)?.ToString() ?? "";
                dynamic oldValue = null;
                if (flag != GeneralProcess.Add)
                {
                    if (oldObject != null)
                    {
                        oldValue = property.GetValue(oldObject)?.ToString() ?? "";
                    }
                }
                else if (flag == GeneralProcess.Remove)
                {
                    newValue = null;
                }
                var propertyType = (property.GetValue(entity) == null)
                    ? typeof(object)
                    : property.GetValue(entity).GetType();

                if (propertyType.IsGenericType &&
                        (propertyType.GetGenericTypeDefinition() == typeof(List<>) || propertyType.GetGenericTypeDefinition() == typeof(IQueryable<>))) { return null; }

                if (typeof(decimal) == propertyType)
                {
                    oldValue = Parse.ToDecimal(oldValue);
                    newValue = Parse.ToDecimal(newValue);
                }
                if (oldValue != newValue)
                {
                    if (propertyType.BaseType == typeof(Enum))
                    {
                        oldValue = DomainResourceHelper.Translate(oldValue ?? "");
                        newValue = DomainResourceHelper.Translate(newValue ?? "");
                    }
                    else if (typeof(DateTime) == propertyType)
                    {
                        oldValue = (oldValue == null) ? Consts.MIN_DATE : DateTime.Parse(oldValue);
                        newValue = (newValue == null) ? Consts.MIN_DATE : DateTime.Parse(newValue);

                        oldValue = DateTime.Parse(oldValue);
                        newValue = DateTime.Parse(newValue);
                        if (oldValue == Consts.MIN_DATE || oldValue == Consts.MIN_DATE)
                        {
                            oldValue = EDomain.Resources.MinDate;
                        }
                        else if (oldValue == Consts.MAX_DATE)
                        {
                            oldValue = EDomain.Resources.MaxedDate;
                        }
                        else
                        {
                            oldValue = (oldValue.TimeOfDay.TotalSeconds == 0) ? oldValue.ToString("dd/MM/yyyy") : oldValue.ToString("dd/MM/yyyy hh:mm:ss tt");
                        }
                        if (newValue == Consts.MIN_DATE || oldValue == Consts.MIN_DATE)
                        {
                            newValue = EDomain.Resources.MinDate;
                        }
                        else if (newValue == Consts.MAX_DATE)
                        {
                            newValue = EDomain.Resources.MaxedDate;
                        }
                        else
                        {
                            newValue = (oldValue.TimeOfDay.TotalSeconds == 0) ? oldValue.ToString("dd/MM/yyyy") : oldValue.ToString("dd/MM/yyyy hh:mm:ss tt");
                        }
                    }
                    DisplayNameAttribute dp = property.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>().SingleOrDefault();
                    var displayname = (!string.IsNullOrEmpty(dp?.DisplayName ?? "")) ? dp.DisplayName : property.Name;
                    changeLogs.Add(new ChangeLog()
                    {
                        DisplayName = $"{displayname}",
                        NewValue = newValue,
                        OldValue = oldValue,
                        Index = ((QTech.Base.Helpers.AuditDataAttribute)property.GetCustomAttribute(typeof(QTech.Base.Helpers.AuditDataAttribute), true))?.Index ?? 0
                    });
                }
            }
            return changeLogs;
        }
        public class AuditTrailIsNullReturnValueAllField
        {
            /// <summary>
            /// ZoroValueAllFields = if field type is object and value = null and flag not remove for newValue and flag not add for oldValue =>  return value ALl + Type.Name ; eg AllCompany,AllBranch.....
            /// </summary>
            public static List<string> IsNullReturnValueAllFields = new List<string>()
            {
              
            };
        }
    }

}
