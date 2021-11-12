namespace ControleGastos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeNameGasto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gasto", "Nome", c => c.String());
            DropColumn("dbo.Gasto", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Gasto", "Name", c => c.String());
            DropColumn("dbo.Gasto", "Nome");
        }
    }
}
