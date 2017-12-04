using PentaStagione.Domain.Models;

namespace PentaStagione.Domain.Repository
{
    public interface IPizzaIngredientRepository
    {
        void Save(PizzaIngredient pizzaIngredient);
    }
}
