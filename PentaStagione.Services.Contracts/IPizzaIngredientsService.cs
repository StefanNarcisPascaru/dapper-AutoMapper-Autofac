using System;

namespace PentaStagione.Services.Contracts
{
    public interface IPizzaIngredientsService
    {
        void Save(object ingredient);
        object GetById(Guid id);
        object Get();
    }
}
