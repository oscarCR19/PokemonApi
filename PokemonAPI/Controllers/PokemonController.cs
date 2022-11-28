using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PokemonAPI.Models.Pokemon;
using System.Collections.Generic;
using System.Net.Http;

namespace PokemonAPI.Controllers
{
    public class PokemonController : Controller
    {
        // GET: PokemonController
        public async Task<ActionResult> pokemon()
        {

            string apiResponse = "";
            GetPokemonList results = null;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://pokeapi.co/api/v2/pokemon?limit=151"))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    results = JsonConvert.DeserializeObject<GetPokemonList>(apiResponse);
                }
                    
            }

            int count = 1;//Aqui sale el id
            
            Root root = null;
            GetTypesList types = null;

            List<Pokemon> pokemons = new List<Pokemon>();
            

            foreach (var result in results.results)
            {   //de aqui sale la photo
                using (var httpClient3 = new HttpClient())
                {
                    using (var response = await httpClient3.GetAsync("https://pokeapi.co/api/v2/pokemon/"+count+"/"))
                    {
                        apiResponse = await response.Content.ReadAsStringAsync();
                        root = JsonConvert.DeserializeObject<Root>(apiResponse);
                    }

                }
                // de aqui sale el tipo
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("https://pokeapi.co/api/v2/pokemon/"+count+"/"))
                    {
                        apiResponse = await response.Content.ReadAsStringAsync();
                        types = JsonConvert.DeserializeObject<GetTypesList>(apiResponse);
                        
                    }

                }
                

                Pokemon pokemon = new Pokemon();
                pokemon.Id = count;
                pokemon.Name = result.name;
                pokemon.Photo=Convert.ToString(root.Sprites.Other.Dream_World.front_default);

                
                int countVar=0;
                List<string> list = new List<string>();

                foreach (var item in types.types)
                {
                    list.Add(item.type.name);
                    countVar++;
                 };
               
                pokemon.Types =list;

                pokemons.Add(pokemon);
                count++;
            }

           



           
            ViewBag.Pokemons= pokemons;
            
            return View();
        }

                // GET: PokemonController/Details/5
         public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PokemonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PokemonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PokemonController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PokemonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PokemonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PokemonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
