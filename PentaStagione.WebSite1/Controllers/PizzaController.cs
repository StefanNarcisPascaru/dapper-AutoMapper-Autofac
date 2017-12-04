using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using PentaStagione.Repository.Contracts.ReadModel.DTOs;
using PentaStagione.Services.Contracts;

namespace PentaStagione.WebSite1.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaService _pizzaService;
        private readonly string _baseAdress= "http://localhost:38171/";
        // spanacapiapp.azurewebsites.net     localhost:38171

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        public async Task<ActionResult> All()
        {
            var pizzas=new List<PizzaDto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAdress);
                HttpResponseMessage response = await client.GetAsync("api/pizza");
                if (response.IsSuccessStatusCode)
                {
                    var pizza= await response.Content.ReadAsStringAsync();
                    pizzas = JsonConvert.DeserializeObject<List<PizzaDto>>(pizza);
                }

            }
            return View(pizzas);
        }

        public async Task<ActionResult> Create()
        {
            var pizza = new PizzaDto();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAdress);
                HttpResponseMessage response = await client.GetAsync("api/ingredient");
                if (response.IsSuccessStatusCode)
                {
                    var pizzaString = await response.Content.ReadAsStringAsync();
                    pizza.Ingredients = JsonConvert.DeserializeObject<List<PizzaIngredientDto>>(pizzaString);
                }

            }
            return View(pizza);
        }

        [HttpPost]
        public async Task<ActionResult> Create(PizzaDto pizza)
        {
            if (!ModelState.IsValid)
            {
                return View(pizza);
            }
            var allIngredients=new List<PizzaIngredientDto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAdress);
                HttpResponseMessage response = await client.GetAsync("api/ingredient");
                if (response.IsSuccessStatusCode)
                {
                    var pizzaString = await response.Content.ReadAsStringAsync();
                    allIngredients = JsonConvert.DeserializeObject<List<PizzaIngredientDto>>(pizzaString);
                }

            }
            pizza.Ingredients.Clear();
            for (int i=0;i<pizza.IngredientsBool.Count;i++)
            {
                if (pizza.IngredientsBool[i])
                {
                    pizza.Ingredients.Add(allIngredients[i]);
                }
            }

            //_pizzaService.Save(pizza);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAdress);
                var serPizza= new StringContent(JsonConvert.SerializeObject(pizza), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("api/pizza", serPizza);
                if (response.IsSuccessStatusCode)
                {
                    var pizzaString = await response.Content.ReadAsStringAsync();
                }

            }

            ////
            var pizzas = new List<PizzaDto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAdress);
                HttpResponseMessage response = await client.GetAsync($"api/pizza");
                if (response.IsSuccessStatusCode)
                {
                    var pizzasString = await response.Content.ReadAsStringAsync();
                    pizzas = JsonConvert.DeserializeObject<List<PizzaDto>>(pizzasString);
                }

            }
            return View("All",pizzas);
        }
    }
}