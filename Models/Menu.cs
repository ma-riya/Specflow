using Newtonsoft.Json;

namespace SpecflowTests.Models
{
        public class Menu
        {
            [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }


        [JsonProperty("enabled")]
        public bool enabled { get; set; }
    }

}
