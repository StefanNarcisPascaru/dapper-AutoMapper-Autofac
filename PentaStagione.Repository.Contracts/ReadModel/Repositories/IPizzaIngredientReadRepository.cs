using System;
using System.Collections.Generic;
using PentaStagione.Repository.Contracts.ReadModel.DTOs;

namespace PentaStagione.Repository.Contracts.ReadModel.Repositories
{
    public interface IPizzaIngredientReadRepository
    {
        PizzaIngredientDto GetById(Guid ingredientId);
        ICollection<PizzaIngredientDto> Get();
    }
}
