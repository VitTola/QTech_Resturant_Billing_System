
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
        public void AddManualAuditTrail<T, TKey, TChild>(T entity, T oldObject, GeneralProcess flag) where T :
            TBaseModel<TKey> where TKey : struct where TChild : TBaseModel<TKey>
        {
            var type = entity.GetType() as Type;
            var name = type.ToString().Split('.').LastOrDefault();
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

            var changlogs = GetChangeLog<T, TKey, TChild>(entity, oldObject, flag);

            var changes = JsonConvert.SerializeObject(changlogs);
            if (changes != "[]")
            {
                auditTrail.ChangeJson = changes;
                AuditTrailLogic.Instance.AddAsync(auditTrail);
            }
        }

        public override IQueryable<AuditTrail> Search(ISearchModel model)
        {
            var param = model as AuditTrailHistorySearch;
            var q = All();
            q = q.Where(x =>
                   x.TableName == param.TableName &&
                   x.TablePK == param.Pk && x.TransactionDate >= param.FromDate && x.TransactionDate <= param.ToDate);
            //var test = q.ToList();
            //if (param.Paging?.IsPaging == true)
            //{
            //    q = q.GetPaged(param.Paging.CurrentPage, param.Paging.PageSize, true, true).Results;
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

        public List<ChangeLog> GetLevel2ChangeLogs<TChild, TKey>(List<TChild> listObjects, List<TChild> oldObjects, GeneralProcess flag)
            where TChild : TBaseModel<TKey> where TKey : struct 
        {
            var changeLogs = new List<ChangeLog>();
            foreach (var c in listObjects)
            {
                var changeLog = new ChangeLog();

                if (flag == GeneralProcess.Add)
                {
                    changeLog.DisplayName = BaseResource.Add;
                    changeLog.Details = GetChangeLog<TChild, TKey, TChild>(c, null, flag);
                    changeLogs.Add(changeLog);
                }
                else
                {
                    var oldO = oldObjects?.FirstOrDefault(x => x.Id.ToString() == c.Id.ToString());
                    changeLog.DisplayName = oldO == null ? BaseResource.Add : BaseResource.Update;
                    c.RowDate = new DateTime(1900, 01, 01);
                    if(oldO != null) oldO.RowDate = new DateTime(1900, 01, 01);
                    var jObj = JsonConvert.SerializeObject(c);
                    var jOldObj = JsonConvert.SerializeObject(oldO);
                    if (jObj != jOldObj)
                    {
                        changeLog.Details = GetChangeLog<TChild, TKey, TChild>(c, oldO, flag);
                        changeLogs.Add(changeLog);
                    }
                    int idex = oldObjects.FindIndex(x => x.Id.ToString() == c.Id.ToString());
                    if (idex >= 0 && oldObjects.Count >= idex)oldObjects.RemoveAt(idex); 

                }
            }
            if (oldObjects?.Any() ?? false)
            {
                foreach (var old in oldObjects)
                {
                    var changeLog = new ChangeLog();
                    changeLog.DisplayName = BaseResource.Remove;

                    changeLog.Details = GetChangeLog<TChild, TKey, TChild>(old, null, flag);
                    //Reverse old to new 
                    if (changeLog.Details?.Any() ?? false)
                    {
                        for (int i = 0; i < changeLog.Details.Count; i++)
                        {
                            var ol = changeLog.Details[i].NewValue;
                            changeLog.Details[i].NewValue = changeLog.Details[i].OldValue;
                            changeLog.Details[i].OldValue = ol; 
                        }
                    }

                    changeLogs.Add(changeLog);
                }
            }

            return changeLogs;
        }


        public List<ChangeLog> GetChangeLog<T, TKey, TChild>(T entity, T oldObject, GeneralProcess flag) where T
            : TBaseModel<TKey> where TKey : struct where TChild : TBaseModel<TKey>
        {
            var changeLogs = new List<ChangeLog>();
            var properties = entity.GetType().GetProperties()
                .Where(x => ((QTech.Base.Helpers.AuditDataAttribute)x.GetCustomAttributes
            (typeof(QTech.Base.Helpers.AuditDataAttribute), true).Cast<QTech.Base.Helpers.AuditDataAttribute>().SingleOrDefault())?.Ignored == false)
                .OrderBy(x => ((QTech.Base.Helpers.AuditDataAttribute)x.GetCustomAttributes
            (typeof(QTech.Base.Helpers.AuditDataAttribute), true).Cast<QTech.Base.Helpers.AuditDataAttribute>().SingleOrDefault())?.Index ?? 0);

            foreach (var property in properties)
            {
                dynamic newValue = null;
                dynamic oldValue = null;
                var changeLog = new ChangeLog();
                changeLog.DisplayName = null;

                //IN CASE PROPERTY IS LIST OF OBJECT
                if (property.PropertyType.IsGenericType)
                {
                    var opName = flag == GeneralProcess.Add ? BaseResource.Add :
                        flag == GeneralProcess.Update ? BaseResource.Update : BaseResource.Remove;
                    DisplayNameAttribute dp = property.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>().SingleOrDefault();
                    changeLog.DisplayName = (!string.IsNullOrEmpty(dp?.DisplayName ?? ""))
                        ? $"{opName} {ResourceHelper.Translate(dp.DisplayName)}"
                        : $"{opName} {ResourceHelper.Translate(property.Name)}";

                    List<TChild> oldChildValue = null;
                    if (oldObject != null)
                    {
                        oldChildValue = (List<TChild>)property.GetValue(oldObject);
                    }
                    var childValue = (List<TChild>)property.GetValue(entity);
                    var logs = GetLevel2ChangeLogs<TChild, TKey>(childValue, oldChildValue, flag);
                    changeLog.Details = new List<ChangeLog>();
                    if (logs.Any())
                    {
                        changeLog.Details​ = logs;
                    }
                }


                //IN CASE PROPERTY IS ID
                if (property.Name.EndsWith("Id"))
                {
                    var _entityName = property.Name?.Replace("Id", string.Empty);
                    int _id = Parse.ToInt(property.GetValue(entity)?.ToString() ?? "0");
                    newValue = GetEntityNameById(_entityName, _id);
                    if (flag != GeneralProcess.Add)
                    {
                        if (oldObject != null)
                        {
                            int _oId = Parse.ToInt(property.GetValue(oldObject)?.ToString() ?? "0");
                            oldValue = GetEntityNameById(_entityName, _oId);
                        }
                    }
                    else if (flag == GeneralProcess.Remove)
                    {
                        newValue = null;
                    }
                }
                //IN CASE PROPERTY IS NONE OF ABOVE
                else
                {
                    if (!property.PropertyType.IsGenericType)
                    {
                        newValue = property.GetValue(entity)?.ToString() ?? "";
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
                    }
                }

                var propertyType = (property.GetValue(entity) == null)
                    ? typeof(object)
                    : property.GetValue(entity).GetType();

                if (typeof(decimal) == propertyType)
                {
                    var decOldVaue = Parse.ToDecimal(oldValue);
                    var decNewValue = Parse.ToDecimal(newValue);
                    oldValue = decOldVaue == 0 ? "" : decOldVaue.ToString();
                    newValue = decNewValue == 0 ? "" : decNewValue.ToString();
                }
                if (oldValue != newValue || (property.PropertyType.IsGenericType && changeLog.Details.Any()))
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
                    var displayname = (!string.IsNullOrEmpty(dp?.DisplayName ?? ""))
                        ? dp.DisplayName
                        : property.Name;
                    changeLog.DisplayName = string.IsNullOrEmpty(changeLog.DisplayName) ? $"{displayname}" : changeLog.DisplayName;
                    changeLog.NewValue = newValue;
                    changeLog.OldValue = oldValue;
                    changeLog.Index = ((QTech.Base.Helpers.AuditDataAttribute)property.GetCustomAttribute(typeof(QTech.Base.Helpers.AuditDataAttribute), true))?.Index ?? 0;

                    changeLogs.Add(changeLog);
                }
            }
            return changeLogs;
        }

        private string GetEntityNameById(string modelName, int entityId)
        {
            switch (modelName)
            {
                case nameof(Category):
                    return CategoryLogic.Instance.FindAsync(entityId)?.Name ?? string.Empty;
                case nameof(Product):
                    return ProductLogic.Instance.FindAsync(entityId)?.Name ?? string.Empty;
                case nameof(Customer):
                    return CustomerLogic.Instance.FindAsync(entityId)?.Name ?? string.Empty;
                case nameof(Employee):
                    return EmployeeLogic.Instance.FindAsync(entityId)?.Name ?? string.Empty;
                case nameof(Table):
                    return TableLogic.Instance.FindAsync(entityId)?.Name ?? string.Empty;
                case nameof(Position):
                    return PositionLogic.Instance.FindAsync(entityId)?.Name ?? string.Empty;
                case nameof(Scale):
                    return ScaleLogic.Instance.FindAsync(entityId)?.Name ?? string.Empty;
                case nameof(Currency):
                    return CurrencyLogic.Instance.FindAsync(entityId)?.Name ?? string.Empty;
            }

            return string.Empty;
        }

    }

}
