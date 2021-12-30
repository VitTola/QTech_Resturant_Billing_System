namespace QTech.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v18 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SaleDetails", "Qauntity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SaleDetails", "Qauntity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
