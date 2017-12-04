using System.Data;
using AutoMapper;
using Dapper;
using PentaStagione.Domain.Models;
using PentaStagione.Domain.Repository;

namespace PentaStagione.Repository.Dapper.WriteRepositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly IDbConnection _dbConnection;
        private readonly IMapper _mapper;

        public PizzaRepository(IDbConnection dbConnection, IMapper mapper)
        {
            _dbConnection = dbConnection;
            _mapper = mapper;
        }

        public void Save(Pizza pizzaAggregate)
        {
            var command = @"INSERT INTO Pizzas ([Id],[Name],[Size]) VALUES (@Id,@Name,@Size)";
            using (_dbConnection)
            {
                _dbConnection.Execute(command,new { pizzaAggregate.Id, pizzaAggregate.Name, pizzaAggregate.Size});
                command = "INSERT INTO Pizza_Ingredient ([PizzaId],[IngredientId]) VALUES (@PizzaId,@IngredientId)";
                foreach (var ingredient in pizzaAggregate.Ingredients)
                {
                    _dbConnection.Execute(command, new { PizzaId=pizzaAggregate.Id, IngredientId=ingredient.Id});
                }
            }
        }
    }
}