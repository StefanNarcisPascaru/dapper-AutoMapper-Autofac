using PentaStagione.Services.Contracts;
using System;
using AutoMapper;
using Newtonsoft.Json;
using PentaStagione.Domain.Models;
using PentaStagione.Domain.Repository;
using PentaStagione.Repository.Contracts.ReadModel.DTOs;
using PentaStagione.Repository.Contracts.ReadModel.Repositories;

namespace PentaStagione.Services
{
    class PizzaIngredientService : IPizzaIngredientsService
    {
        private readonly IPizzaIngredientRepository _ingredientRepository;
        private readonly IPizzaIngredientReadRepository _ingredientReadRepository;
        private readonly IMapper _mapper;

        public PizzaIngredientService(IPizzaIngredientRepository repository, IPizzaIngredientReadRepository readRepository, IMapper mapper)
        {
            _ingredientRepository= repository;
            _ingredientReadRepository = readRepository;
            _mapper = mapper;
        }

        public void Save(object pizzaIngredientDto)
        {
            PizzaIngredientDto pizzaIngredientDtoObj = JsonConvert.DeserializeObject<PizzaIngredientDto>(pizzaIngredientDto.ToString());
            PizzaIngredient pizzaIngredientAggregate = _mapper.Map<PizzaIngredient>(pizzaIngredientDtoObj);
            _ingredientRepository.Save(pizzaIngredientAggregate);
        }

        public object GetById(Guid id)
        {
            return _ingredientReadRepository.GetById(id);
        }
        public object Get()
        {
            return _ingredientReadRepository.Get();
        }
    }
}