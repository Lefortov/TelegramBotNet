namespace TelegramBotNet.DTOs
{
    using Newtonsoft.Json;

    public class RootObject<T>
    {
        [JsonProperty(PropertyName = "ok")]
        public bool Ok { get; set; }

        [JsonProperty(PropertyName = "result")]
        public T Result { get; set; }
    }
}