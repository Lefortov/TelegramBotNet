namespace TelegramBotNet.DTOs
{
    using Newtonsoft.Json;

    public class Sticker
    {
        [JsonProperty(PropertyName = "file_id")]
        public string FileId { get; set; }

        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }

        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }

        [JsonProperty(PropertyName = "thumb")]
        public PhotoSize Thumb { get; set; }

        [JsonProperty(PropertyName = "file_size")]
        public int FileSize { get; set; }
    }
}