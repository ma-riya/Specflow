using Newtonsoft.Json;

namespace SpecflowTests
{
        public class Menu
        {
        [JsonIgnore]
        public string id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }


        [JsonProperty("enabled")]
        public bool enabled { get; set; }
    }

}
