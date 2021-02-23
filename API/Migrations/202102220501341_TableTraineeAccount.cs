namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableTraineeAccount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tb_M_Account",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tb_M_Trainee", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Tb_M_Trainee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Birth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tb_M_Account", "Id", "dbo.Tb_M_Trainee");
            DropIndex("dbo.Tb_M_Account", new[] { "Id" });
            DropTable("dbo.Tb_M_Trainee");
            DropTable("dbo.Tb_M_Account");
        }
    }
}
