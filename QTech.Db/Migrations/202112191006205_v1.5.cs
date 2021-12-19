namespace QTech.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v15 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "PositionId", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "PositionId", c => c.String());
        }
    }
}
