namespace PentaStagione.Repository.EntityFramwork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RedesingedModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PizzaIngredients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pizza_Ingredient",
                c => new
                    {
                        PizzaId = c.Guid(nullable: false),
                        IngredientId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.PizzaId, t.IngredientId })
                .ForeignKey("dbo.Pizzas", t => t.PizzaId, cascadeDelete: true)
                .ForeignKey("dbo.PizzaIngredients", t => t.IngredientId, cascadeDelete: true)
                .Index(t => t.PizzaId)
                .Index(t => t.IngredientId);
            
            AddColumn("dbo.Pizzas", "Name", c => c.String());
            AddColumn("dbo.Pizzas", "Size", c => c.Int(nullable: false));
            DropColumn("dbo.Pizzas", "Batter");
            DropColumn("dbo.Pizzas", "Tuna");
            DropColumn("dbo.Pizzas", "Mozzarella");
            DropColumn("dbo.Pizzas", "Bacon");
            DropColumn("dbo.Pizzas", "Pineapple");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pizzas", "Pineapple", c => c.Int(nullable: false));
            AddColumn("dbo.Pizzas", "Bacon", c => c.Int(nullable: false));
            AddColumn("dbo.Pizzas", "Mozzarella", c => c.Int(nullable: false));
            AddColumn("dbo.Pizzas", "Tuna", c => c.Int(nullable: false));
            AddColumn("dbo.Pizzas", "Batter", c => c.Int(nullable: false));
            DropForeignKey("dbo.Pizza_Ingredient", "IngredientId", "dbo.PizzaIngredients");
            DropForeignKey("dbo.Pizza_Ingredient", "PizzaId", "dbo.Pizzas");
            DropIndex("dbo.Pizza_Ingredient", new[] { "IngredientId" });
            DropIndex("dbo.Pizza_Ingredient", new[] { "PizzaId" });
            DropColumn("dbo.Pizzas", "Size");
            DropColumn("dbo.Pizzas", "Name");
            DropTable("dbo.Pizza_Ingredient");
            DropTable("dbo.PizzaIngredients");
        }
    }
}
