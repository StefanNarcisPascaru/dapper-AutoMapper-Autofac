using System;

namespace PentaStagione.Services.Contracts
{
    public interface IPizzaService
    {
        void Save(object pizza);
        object GetById(Guid id);
        object Get();
    }
}