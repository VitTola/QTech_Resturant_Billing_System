namespace QTech.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v10_IntializeDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppDownloadLink = c.String(),
                        CurrentAppVersion = c.String(),
                        CurrencyId = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        RowDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AuditTrails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClientAddress = c.String(),
                        ClientName = c.String(),
                        OperatorName = c.String(),
                        OperatorGroup = c.String(),
                        TableName = c.String(),
                        TablePK = c.String(),
                        ChangeJson = c.String(),
                        TableValue = c.String(),
                        TableShortName = c.String(),
                        TransactionDate = c.DateTime(nullable: false),
                        UserName = c.String(),
                        RowDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Note = c.String(),
                        Active = c.Boolean(nullable: false),
                        RowDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Note = c.String(),
                        Active = c.Boolean(nullable: false),
                        RowDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Phone = c.String(),
                        Note = c.String(),
                        Active = c.Boolean(nullable: false),
                        RowDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(),
                        PositionId = c.Int(nullable: false),
                        Note = c.String(),
                        Active = c.Boolean(nullable: false),
                        RowDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IncomeExpenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MiscNo = c.String(),
                        DoDate = c.DateTime(nullable: false),
                        Note = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MiscellaneousType = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        RowDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceNo = c.String(),
                        InvoicingDate = c.DateTime(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaidAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LeftAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoiceStatus = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        CustomerName = c.String(),
                        Active = c.Boolean(nullable: false),
                        RowDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Level = c.Int(nullable: false),
                        ParentId = c.Int(nullable: false),
                        PermissionType = c.Int(nullable: false),
                        UiActivator = c.String(),
                        AuthKey = c.Int(nullable: false),
                        Ordering = c.Int(nullable: false),
                        Note = c.String(),
                        Active = c.Boolean(nullable: false),
                        RowDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Note = c.String(),
                        Active = c.Boolean(nullable: false),
                        RowDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductPrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ScaleId = c.Int(nullable: false),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyId = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        RowDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note = c.String(),
                        CategoryId = c.Int(nullable: false),
                        Photo = c.Binary(),
                        PhotoPath = c.String(),
                        Active = c.Boolean(nullable: false),
                        RowDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SaleDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SaleId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ScaleId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Active = c.Boolean(nullable: false),
                        RowDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SaleDate = c.DateTime(nullable: false),
                        InvoiceNo = c.String(),
                        EmployeeId = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentRecieve = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentLeft = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PayStatus = c.Int(nullable: false),
                        CustomerName = c.String(),
                        Phone = c.String(),
                        Profit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TableId = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        RowDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Scales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Note = c.String(),
                        Active = c.Boolean(nullable: false),
                        RowDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Note = c.String(),
                        TableStus = c.Int(nullable: false),
                        IsUseable = c.Boolean(nullable: false),
                        CurrentSaleId = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        RowDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserPermissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PermissionId = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        RowDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FullName = c.String(),
                        PasswordHash = c.String(),
                        Note = c.String(),
                        Theme = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        RowDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.UserPermissions");
            DropTable("dbo.Tables");
            DropTable("dbo.Scales");
            DropTable("dbo.Sales");
            DropTable("dbo.SaleDetails");
            DropTable("dbo.Products");
            DropTable("dbo.ProductPrices");
            DropTable("dbo.Positions");
            DropTable("dbo.Permissions");
            DropTable("dbo.Invoices");
            DropTable("dbo.IncomeExpenses");
            DropTable("dbo.Employees");
            DropTable("dbo.Customers");
            DropTable("dbo.Currencies");
            DropTable("dbo.Categories");
            DropTable("dbo.AuditTrails");
            DropTable("dbo.ApplicationSettings");
        }
    }
}
