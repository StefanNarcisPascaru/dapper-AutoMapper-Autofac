using System;
using System.Collections.Generic;
using PentaStagione.Infrastracture.Domain.BaseModels;
using PentaStagione.Common;

namespace PentaStagione.Domain.Models
{
    public class Pizza : Entity
    {
        public Pizza()
        {
            Name = "CustomPizza";
            Size = PizzaSize.Medium;
            // ReSharper disable once VirtualMemberCallInConstructor
            Ingredients=new List<PizzaIngredient>();
        }
        public Pizza(Guid id):base(id)
        {
            Name = "CustomPizza";
            Size = PizzaSize.Medium;
            // ReSharper disable once VirtualMemberCallInConstructor
            Ingredients=new List<PizzaIngredient>();
        }

        public string Name { get; set; }
        public PizzaSize Size { get; set; }

        public virtual IList<PizzaIngredient> Ingredients { get; set; }
    }
}
