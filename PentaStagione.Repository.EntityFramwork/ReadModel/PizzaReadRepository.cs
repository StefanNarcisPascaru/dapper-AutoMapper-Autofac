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
    public class PizzaReadRepository : IPizzaReadRepository
    {
        private readonly DbContext _context;
        private readonly IMapper _mapper;

        public PizzaReadRepository(DbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public PizzaDto GetById(Guid pizzaId)
        {
            var pizza = _context.Set<Pizza>().FirstOrDefault(p=>p.Id==pizzaId);
            var pizzaDto = _mapper.Map<PizzaDto>(pizza);
            return pizzaDto;
        }
        public ICollection<PizzaDto> Get()
        {
            return _context.Set<Pizza>().Include(p=>p.Ingredients).Select(_mapper.Map<PizzaDto>).ToList();
        }
    }
}