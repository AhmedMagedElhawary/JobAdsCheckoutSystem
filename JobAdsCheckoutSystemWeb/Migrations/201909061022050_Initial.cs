namespace JobAdsCheckoutSystemWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public overrIde voId Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.GuId(nullable: false),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Description = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public overrIde voId Down()
        {
            DropTable("dbo.Products");
        }
    }
}
