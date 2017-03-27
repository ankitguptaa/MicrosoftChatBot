using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot_Application.Models
{
    public class LUISData
    {
        [JsonProperty(PropertyName = "query")]
        public string query { get; set; }

        [JsonProperty(PropertyName = "topScoringIntent")]
        public Topscoringintent topScoringIntent { get; set; }
        [JsonProperty(PropertyName = "intents")]
        public Intent[] intents { get; set; }

        [JsonProperty(PropertyName = "entities")]
        public Entity[] entities { get; set; }
    }

    public class Topscoringintent
    {
        [JsonProperty(PropertyName = "intent")]
        public string intent { get; set; }

        [JsonProperty(PropertyName = "score")]
        public float score { get; set; }
    }

    public class Intent
    {
        [JsonProperty(PropertyName = "intent")]
        public string intent { get; set; }

        [JsonProperty(PropertyName = "score")]
        public float score { get; set; }
    }

    public class Entity
    {
        [JsonProperty(PropertyName = "entity")]
        public string entity { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string type { get; set; }

        [JsonProperty(PropertyName = "startIndex")]
        public int startIndex { get; set; }

        [JsonProperty(PropertyName = "endIndex")]
        public int endIndex { get; set; }

        [JsonProperty(PropertyName = "score")]
        public float score { get; set; }
    }
}