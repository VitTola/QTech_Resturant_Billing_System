namespace QTech.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v13 : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AuditTrails");
        }
    }
}
