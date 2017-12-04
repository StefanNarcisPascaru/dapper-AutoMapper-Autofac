﻿using System;
using System.Web.Http;
using PentaStagione.Services.Contracts;

namespace PentaStagione.WebApi1.Controllers
{
    [Route("api/ingredient")]
    public class IngredientController:ApiController
    {
        private readonly IPizzaIngredientsService _pizzaIngredientService;

        public IngredientController(IPizzaIngredientsService pizzaIngredientsService)
        {
            _pizzaIngredientService = pizzaIngredientsService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_pizzaIngredientService.Get());
        }

        [HttpGet]
        public dynamic Get(Guid id)
        {
            var pizza = _pizzaIngredientService.GetById(id);
            return pizza;
        }

        [HttpPost]
        public void Post(dynamic pizza)
        {
            _pizzaIngredientService.Save(pizza);
        }
    }
}