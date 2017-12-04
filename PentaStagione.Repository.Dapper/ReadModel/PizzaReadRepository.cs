using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AutoMapper;
using Dapper;
using PentaStagione.Domain.Models;
using PentaStagione.Repository.Contracts.ReadModel.DTOs;
using PentaStagione.Repository.Contracts.ReadModel.Repositories;

namespace PentaStagione.Repository.Dapper.ReadModel
{
    public class PizzaReadRepository : IPizzaReadRepository
    {
        private readonly IDbConnection _dbConnection;
        private readonly IMapper _mapper;

        public PizzaReadRepository(IDbConnection dbConnection, IMapper mapper)
        {
            _dbConnection = dbConnection;
            _mapper = mapper;
        }

        public PizzaDto GetById(Guid pizzaId)
        {
            PizzaDto pizza;

            using (_dbConnection)
            {
                pizza = _mapper.Map<PizzaDto>(_dbConnection.Query<Pizza>("Select * from Pizzas where Id=@Id", new {Id=pizzaId}).FirstOrDefault());
                var query = @"select Id, Name, Price from PizzaIngredients as I 
                            join Pizza_Ingredient as P_I on I.Id = P_I.IngredientId
                            where P_I.PizzaId = @Id";
                pizza.Ingredients = _dbConnection.Query<PizzaIngredient>(query, new { Id = pizza.Id }).Select(_mapper.Map<PizzaIngredientDto>).ToList();
            }
            return pizza;
        }

        public ICollection<PizzaDto> Get()
        {

            ICollection<PizzaDto> pizzas;

            var query=@"Select * from Pizzas";

            using (_dbConnection)
            {
                pizzas = _dbConnection.Query<Pizza>(query).Select(_mapper.Map<PizzaDto>).ToList();
                query = @"select Id, Name, Price from PizzaIngredients as I 
                            join Pizza_Ingredient as P_I on I.Id = P_I.IngredientId
                            where P_I.PizzaId = @Id";
                foreach (var pizza in pizzas)
                    {
                        pizza.Ingredients = _dbConnection.Query<PizzaIngredient>(query, new {Id = pizza.Id}).Select(_mapper.Map<PizzaIngredientDto>).ToList();
                    }    
            }

            return pizzas;
            
        }
    }
}