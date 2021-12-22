using QTech.Base;
using QTech.Base.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Db.Configs
{
    public static class QTechDbConfigs
    {
        public static void ConfigureDatabase(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>().Property(x => x.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Sale>().Ignore(x => x.SaleDetails);
            modelBuilder.Entity<QTech.Base.Models.User>().Ignore(x => x.UserPermissions);
            modelBuilder.Entity<QTech.Base.Models.Product>().Ignore(x => x.ProductPrices);

            //AuditTail's config
            //modelBuilder.Entity<AuditTrail>().Property(x => x.ClientAddress).HasMaxLength(200).IsRequired();
            //modelBuilder.Entity<AuditTrail>().Property(x => x.OperatorGroup).HasMaxLength(200).IsRequired();
            //modelBuilder.Entity<AuditTrail>().Property(x => x.TablePK).HasMaxLength(100).IsRequired();
            //modelBuilder.Entity<AuditTrail>().Property(x => x.TableValue).HasMaxLength(1000).IsRequired();
            //modelBuilder.Entity<AuditTrail>().Property(x => x.ChangeJson).HasColumnType("NTEXT").IsRequired();

        }
    }
}
