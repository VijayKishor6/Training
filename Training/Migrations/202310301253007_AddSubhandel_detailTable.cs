namespace Training.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubhandel_detailTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Staff_details",
                c => new
                    {
                        Staff_id = c.Int(nullable: false, identity: true),
                        Staff_name = c.String(),
                        Staff_contact = c.String(),
                        Staff_salary = c.Int(nullable: false),
                        Staff_native = c.String(),
                        Staff_years = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Staff_id);
            
            CreateTable(
                "dbo.Subhandel_detail",
                c => new
                    {
                        Staff_id = c.Int(nullable: false),
                        Staff_sub = c.String(),
                    })
                .PrimaryKey(t => t.Staff_id)
                .ForeignKey("dbo.Staff_details", t => t.Staff_id)
                .Index(t => t.Staff_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subhandel_detail", "Staff_id", "dbo.Staff_details");
            DropIndex("dbo.Subhandel_detail", new[] { "Staff_id" });
            DropTable("dbo.Subhandel_detail");
            DropTable("dbo.Staff_details");
        }
    }
}
