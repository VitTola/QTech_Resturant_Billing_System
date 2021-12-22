namespace QTech.Db
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    using QTech.Base;
    using QTech.Base.Helpers;
    using QTech.Base.Models;
    using QTech.Db.Configs;
    using QTech.Db.Migrations;

    public class QTechDbContext : DbContext
    {
        //public QTechDbContext()
        //    : base("QTechDbContext")
        //{
        //}
       
        public QTechDbContext()
            : base("data source="+DataBaseSetting.config.DataSource+";initial catalog="+DataBaseSetting.config.DataBase+";" +
                  "integrated security=True;MultipleActiveResultSets=True;" +"App=EntityFramework")
        {
            Database.SetInitializer<QTechDbContext>(new MigrateDatabaseToLatestVersion<QTechDbContext, Configuration>());
        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<SaleDetail> SaleDetails { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<QTech.Base.Models.User> Users { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<UserPermission> UserPermissions { get; set; }
        public virtual DbSet<IncomeExpense> IncomeExpenses { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<AuditTrail> AuditTrails { get; set; }
        public virtual DbSet<ApplicationSetting> ApplicationSettings { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<Scale> Scales { get; set; }
        public virtual DbSet<ProductPrice> ProductPrices { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            QTechDbConfigs.ConfigureDatabase(modelBuilder);
        }
    }

    public static class DataBaseSetting
    {
        public static DbConfig config = new DbConfig() {
            DataSource = ".",
            DataBase = "QTech_ResturantDb",
            Theme = ShareValue.User?.Theme ?? QTech.Base.Enums.Theme.Template1
            
        };

        public static void ReadSetting()
        {
            try
            {
                var jsonData = File.ReadAllText("Setting.json");
                config = JsonConvert.DeserializeObject<DbConfig>(jsonData);
            }
            catch (Exception ex)
            {
                
            }
        }
        
        public static void WriteSetting()
        {
            config = new DbConfig()
            {
                DataSource = DataBaseSetting.config.DataSource,
                DataBase = DataBaseSetting.config.DataBase,
                Theme = ShareValue.User?.Theme ?? QTech.Base.Enums.Theme.Template1
            };
            var jsonData = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText("Setting.json", jsonData);
        }
    }
}