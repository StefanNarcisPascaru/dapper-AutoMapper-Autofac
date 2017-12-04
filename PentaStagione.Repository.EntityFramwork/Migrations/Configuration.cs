using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using PentaStagione.Domain.Models;
using PentaStagione.Repository.EntityFramwork.Context;
using PentaStagione.Common;

namespace PentaStagione.Repository.EntityFramwork.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<PizzaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PizzaContext context)
        {
            if (!context.PizzaIngredients.Any())
            {
                context.PizzaIngredients.AddRange(
                    new List<PizzaIngredient>
                        {
                            new PizzaIngredient(Guid.Parse("FF9A5222-17FD-48D0-A2E4-C8A266838302"))
                            {
                                Name = "Gorgonzolla",
                                Price = 3.5
                            },
                            new PizzaIngredient(Guid.Parse("C15FA5E8-4919-46A5-AA09-E2366B871BA7"))
                            {
                                Name = "Bacon",
                                Price = 3.0
                            }
                        }
                );
            }

            if (!context.Pizzas.Any())
            {
                context.Pizzas.Add(new Pizza
                {
                    Name = "Espagnola",
                    Size = PizzaSize.Medium,
                    Ingredients = new List<PizzaIngredient>
                    {
                        context.PizzaIngredients.Find(Guid.Parse("FF9A5222-17FD-48D0-A2E4-C8A266838302")),
                        context.PizzaIngredients.Find(Guid.Parse("C15FA5E8-4919-46A5-AA09-E2366B871BA7"))
                    }
                });
            }


        }
    }
}
