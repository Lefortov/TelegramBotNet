using Newtonsoft.Json;

namespace TelegramBotNet.DTOs
{
    public class Voice
    {
        [JsonProperty(PropertyName = "file_id")]
        public string FileId { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public int Duration { get; set; }

        [JsonProperty(PropertyName = "mime_type")]
        public string MimeType { get; set; }

        [JsonProperty(PropertyName = "file_size")]
        public int FileSize { get; set; }
    }
}