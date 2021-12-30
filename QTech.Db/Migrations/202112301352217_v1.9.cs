namespace QTech.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v19 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SaleDetails", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.SaleDetails", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.SaleDetails", "Qauntity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SaleDetails", "Qauntity", c => c.Int(nullable: false));
            DropColumn("dbo.SaleDetails", "UnitPrice");
            DropColumn("dbo.SaleDetails", "Quantity");
        }
    }
}
