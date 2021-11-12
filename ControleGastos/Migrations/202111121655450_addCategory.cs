namespace ControleGastos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Gasto", "CategoriaId", c => c.Int());
            CreateIndex("dbo.Gasto", "CategoriaId");
            AddForeignKey("dbo.Gasto", "CategoriaId", "dbo.Categoria", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gasto", "CategoriaId", "dbo.Categoria");
            DropIndex("dbo.Gasto", new[] { "CategoriaId" });
            DropColumn("dbo.Gasto", "CategoriaId");
            DropTable("dbo.Categoria");
        }
    }
}
