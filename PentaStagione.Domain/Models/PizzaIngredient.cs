using System;
using System.Collections.Generic;
using PentaStagione.Infrastracture.Domain.BaseModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace PentaStagione.Domain.Models
{
    public class PizzaIngredient : Entity
    {
        public PizzaIngredient()
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            Pizzas=new List<Pizza>();
        }
        public PizzaIngredient(Guid id):base(id)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            Pizzas=new List<Pizza>();
        }

        public string Name { get; set; }
        public double Price { get; set; }

        public virtual IList<Pizza> Pizzas { get; set; }
    }
}
