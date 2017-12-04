using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PentaStagione.Domain.Models;
using PentaStagione.Domain.Repository;

namespace PentaStagione.Repository.EntityFramwork.WriteRepositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly DbContext _context;

        public PizzaRepository(DbContext context)
        {
            _context = context;
        }

        public void Save(Pizza pizzaAggregate)
        {
            
            var ingredients = new List<PizzaIngredient>();
            foreach (var ingredient in pizzaAggregate.Ingredients)
            {
                ingredients.Add(_context.Set<PizzaIngredient>().Find(ingredient.Id));
            }
            pizzaAggregate.Ingredients.Clear();
            foreach (var ingredient in ingredients)
            {
                pizzaAggregate.Ingredients.Add(ingredient);
            }
            _context.Set<Pizza>().Add(pizzaAggregate);
            _context.SaveChanges();
        }
    }
}