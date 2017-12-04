using System;
using System.Data;
using Dapper;
using PentaStagione.Domain.Models;
using PentaStagione.Domain.Repository;

namespace PentaStagione.Repository.Dapper.WriteRepositories
{
    public class PizzaIngredientRepository : IPizzaIngredientRepository
    {
        private readonly IDbConnection _dbConnection;

        public PizzaIngredientRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void Save(PizzaIngredient pizzaIngredient)
        {
            var command = @"INSERT INTO PizzaIngredients ([Id],[Name],[Price]) VALUES (@Id,@Name,@Price)";
            using (_dbConnection)
            {
                _dbConnection.Execute(command, new { pizzaIngredient.Id, pizzaIngredient.Name, pizzaIngredient.Price });
            }
        }
    }
}