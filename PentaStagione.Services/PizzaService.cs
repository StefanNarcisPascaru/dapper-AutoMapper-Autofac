using System;
using AutoMapper;
using Newtonsoft.Json;
using PentaStagione.Domain.Models;
using PentaStagione.Domain.Repository;
using PentaStagione.Repository.Contracts.ReadModel.DTOs;
using PentaStagione.Repository.Contracts.ReadModel.Repositories;
using PentaStagione.Services.Contracts;

namespace PentaStagione.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository _repository;
        private readonly IPizzaReadRepository _readRepository;
        private readonly IMapper _mapper;

        public PizzaService(IPizzaRepository repository, IPizzaReadRepository readRepository, IMapper mapper)
        {
            _repository = repository;
            _readRepository = readRepository;
            _mapper = mapper;
        }

        public void Save(object pizzaDto)
        {
            PizzaDto pizzaDtoObj = JsonConvert.DeserializeObject<PizzaDto>(pizzaDto.ToString());
            Pizza pizzaAggregate = _mapper.Map<Pizza>(pizzaDtoObj);
            _repository.Save(pizzaAggregate);
        }
        
        public object GetById(Guid id)
        {
            return _readRepository.GetById(id);
        }
        public object Get()
        {
            return _readRepository.Get();
        }
    }
}