using System;
using System.Collections.Generic;

namespace PentaStagione.Repository.Contracts.ReadModel.DTOs
{
    public class PizzaIngredientDto
    {
        public PizzaIngredientDto()
        {
            Id=Guid.NewGuid();
            Name = "New ingredient";
        }

        public Guid Id { get; set; }        
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
