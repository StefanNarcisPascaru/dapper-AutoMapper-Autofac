using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using PentaStagione.Domain.Models;
using PentaStagione.Repository.Contracts.ReadModel.DTOs;
using PentaStagione.Repository.Contracts.ReadModel.Repositories;

namespace PentaStagione.Repository.EntityFramwork.ReadModel
{
    public class PizzaIngredientReadRepository :IPizzaIngredientReadRepository
    {
        private readonly DbContext _context;
        private readonly IMapper _mapper;

        public PizzaIngredientReadRepository(DbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public ICollection<PizzaIngredientDto> Get()
        {
            return _context.Set<PizzaIngredient>().Select(_mapper.Map<PizzaIngredientDto>).ToList();

        }

        public PizzaIngredientDto GetById(Guid ingredientId)
        {
            var ingredient = _context.Set<PizzaIngredient>().FirstOrDefault(p => p.Id == ingredientId);
            var pizzaIngredientDto = _mapper.Map<PizzaIngredientDto>(ingredient);
            return pizzaIngredientDto;
        }
    }
}
