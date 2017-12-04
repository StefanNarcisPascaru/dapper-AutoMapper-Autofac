using System.Web.Mvc;
using PentaStagione.Repository.Contracts.ReadModel.DTOs;
using PentaStagione.Services.Contracts;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PentaStagione.WebSite1.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IPizzaIngredientsService _ingredientsService;
        private readonly string _baseAdress = "http://localhost:38171/";

        public IngredientController(IPizzaIngredientsService service)
        {
            _ingredientsService = service;
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(PizzaIngredientDto ingredient)
        {
            if (!ModelState.IsValid)
                return View(ingredient);

            //_ingredientsService.Save(ingredient);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAdress);
                var serIngredient = new StringContent(JsonConvert.SerializeObject(ingredient), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("api/ingredient", serIngredient);
            }

            return View();
        }
    }
}