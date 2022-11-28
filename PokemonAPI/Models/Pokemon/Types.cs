namespace PokemonAPI.Models.Pokemon
{
    public class Types
    {
        public Type? type { get; set; }
    }
    
 
    public class Type
    {
        public string? name { get; set; }
        public string? url { get; set; }
    }

    public class GetTypesList
    {
        public List<Types>? types { get; set; }
    }

}
