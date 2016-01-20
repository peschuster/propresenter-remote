using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ProPresenterRemote
{
    public class ProPresenterTimer
    {
        public ProPresenterTimer()
        {
            this.Index = -1;
        }

        [JsonIgnore]
        public int Index { get; set; }

        [JsonProperty("clockName")]
        public string Name { get; set; }

        [JsonProperty("clockType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TimerType TimerType { get; set; }

        [JsonProperty("clockDuration")]
        public string Duration { get; set; }

        [JsonProperty("clockEndTime")]
        public string EndTime { get; set; }

        [JsonProperty("clockTime")]
        public string Time { get; set; }

        [JsonProperty("clockState")]
        [JsonConverter(typeof(BoolConverter))]
        public bool Running { get; set; }

        [JsonProperty("clockOverrun")]
        [JsonConverter(typeof(BoolConverter))]
        public bool Overrun { get; set; }

        [JsonProperty("clockIsPM")]
        public object ClockIsPm { get; set; }
    }
}
