namespace QTech.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v10 : DbMigration
    {
        public override void Up()
        {
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
                        Active = c.Boolean(nullable: false),
                        RowDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Sales", "TableId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales", "TableId");
            DropTable("dbo.Tables");
        }
    }
}
