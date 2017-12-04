using PentaStagione.Common;
using System;
using System.Collections.Generic;

namespace PentaStagione.Repository.Contracts.ReadModel.DTOs
{
    public class PizzaDto
    {
        public PizzaDto()
        {
            Name = "New Pizza";
            Id = Guid.NewGuid();
            Ingredients=new List<PizzaIngredientDto>();
        }

        public Guid Id { get; set; }
        
        public string Name { get; set; }
        public PizzaSize Size { get; set; }

        public IList<PizzaIngredientDto> Ingredients { get; set; }
        public IList<bool> IngredientsBool { get; set; }
    }
}