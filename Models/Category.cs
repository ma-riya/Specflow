using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpecflowTests.Models
{
    public class Category
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }
}