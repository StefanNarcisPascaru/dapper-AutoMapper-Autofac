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
    public class PizzaIngredientReadRepository :IPizzaIngredientReadRepository
    {
        private readonly IDbConnection _dbConnection;
        private readonly IMapper _mapper;

        public PizzaIngredientReadRepository(IDbConnection dbConnection, IMapper mapper)
        {
            _dbConnection = dbConnection;
            _mapper = mapper;
        }

        public ICollection<PizzaIngredientDto> Get()
        {
            ICollection<PizzaIngredientDto> ingredients;

            using (_dbConnection)
            {
                ingredients = _dbConnection.Query<PizzaIngredient>("Select * from PizzaIngredients").Select(_mapper.Map<PizzaIngredientDto>).ToList();
            }
            return ingredients;
        }

        public PizzaIngredientDto GetById(Guid ingredientId)
        {
            PizzaIngredient pizzaIngredient;

            using (_dbConnection)
            {
                pizzaIngredient = _dbConnection.Query<PizzaIngredient>("Select * from Ingredients where Id=@Id", new { Id = ingredientId }).FirstOrDefault();
            }
            var pizzaDto = _mapper.Map<PizzaIngredientDto>(pizzaIngredient);
            return pizzaDto;
        }
    }
}
