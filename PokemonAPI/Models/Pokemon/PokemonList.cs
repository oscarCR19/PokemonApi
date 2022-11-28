using System.Web.Helpers;

namespace PokemonAPI.Models.Pokemon
{
    public class PokemonList
    {
        
        public string? name { get; set; }
        public string? photo { get; set; }
        
     }

   public class GetPokemonList
    {
       public List<PokemonList>? results { get; set; }// siempre nombrar esta variable con el nombre de la clave en la que estamos mapeando
    }
}
