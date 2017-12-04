using System.Data.Entity.Migrations;

namespace PentaStagione.Repository.EntityFramwork.Migrations
{
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pizzas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Batter = c.Int(nullable: false),
                        Tuna = c.Int(nullable: false),
                        Mozzarella = c.Int(nullable: false),
                        Bacon = c.Int(nullable: false),
                        Pineapple = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pizzas");
        }
    }
}
