using System;
using System.Collections.Generic;
using PentaStagione.Repository.Contracts.ReadModel.DTOs;

namespace PentaStagione.Repository.Contracts.ReadModel.Repositories
{
    public interface IPizzaReadRepository
    {
        PizzaDto GetById(Guid pizzaId);
        ICollection<PizzaDto> Get();
    }
}