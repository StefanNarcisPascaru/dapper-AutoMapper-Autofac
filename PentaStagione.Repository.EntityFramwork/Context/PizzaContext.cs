using System.Data.Entity;
using PentaStagione.Domain.Models;

namespace PentaStagione.Repository.EntityFramwork.Context
{
    public class PizzaContext : DbContext
    {
        public PizzaContext() : base("PizzaDbEf")
        {
        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<PizzaIngredient> PizzaIngredients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>()
                .HasMany(p=>p.Ingredients)
                .WithMany(i=>i.Pizzas)
                .Map(cs =>
                {
                    cs.MapLeftKey("PizzaId");
                    cs.MapRightKey("IngredientId");
                    cs.ToTable("Pizza_Ingredient");
                });
        }
    }
}
