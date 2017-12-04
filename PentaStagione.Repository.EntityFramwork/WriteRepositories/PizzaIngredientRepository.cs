using System.Data.Entity;
using System.Linq;
using PentaStagione.Domain.Models;
using PentaStagione.Domain.Repository;

namespace PentaStagione.Repository.EntityFramwork.WriteRepositories
{
    public class PizzaIngredientRepository : IPizzaIngredientRepository
    {
        private readonly DbContext _context;

        public PizzaIngredientRepository(DbContext context)
        {
            _context = context;
        }

        public void Save(PizzaIngredient pizzaIngredient)
        {
            if (!_context.Set<PizzaIngredient>().Any(i => i.Name == pizzaIngredient.Name))
            {
                _context.Set<PizzaIngredient>().Add(pizzaIngredient);
                _context.SaveChanges();
            }
        }
    }
}