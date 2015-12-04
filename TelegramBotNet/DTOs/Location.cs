namespace TelegramBotNet.DTOs
{
    using Newtonsoft.Json;

    public class Location
    {
        [JsonProperty(PropertyName = "longitude")]
        public float Longitude { get; set; }

        [JsonProperty(PropertyName = "latitude")]
        public float Latitude { get; set; }
    }
}