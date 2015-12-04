namespace TelegramBotNet.DTOs
{
    using Newtonsoft.Json;

    public class Document
    {
        [JsonProperty(PropertyName = "file_id")]
        public string FileId { get; set; }

        [JsonProperty(PropertyName = "thumb")]
        public PhotoSize Thumb { get; set; }

        [JsonProperty(PropertyName = "file_name")]
        public string Filename { get; set; }

        [JsonProperty(PropertyName = "mime_type")]
        public string MimeType { get; set; }

        [JsonProperty(PropertyName = "file_size")]
        public int FileSize { get; set; }
    }
}