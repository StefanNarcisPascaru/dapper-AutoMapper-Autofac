using System;
using System.Web.Http;
using PentaStagione.Services.Contracts;

namespace PentaStagione.WebApi1.Controllers
{
    [Route("api/pizza")]
    public class PizzaController : ApiController
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_pizzaService.Get());
        }

        [HttpGet]
        //[Route("{id}")]
        public dynamic Get(Guid id)
        {
            var pizza= _pizzaService.GetById(id);
            return pizza;
        }

        [HttpPost]
        public void Post(dynamic pizza)
        {
            _pizzaService.Save(pizza);
        }
    }
}