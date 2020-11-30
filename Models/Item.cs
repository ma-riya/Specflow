using Newtonsoft.Json;

namespace SpecflowTests.Models
{
    public class Item
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("price")]
        public string Price { get; set; }
        
        [JsonProperty("available")]
        public bool Available { get; set; }
    }
}