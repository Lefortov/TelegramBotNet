namespace TelegramBotNet.DTOs
{
    using Newtonsoft.Json;

    public class File
    {
        [JsonProperty(PropertyName = "file_id")]
        public string FileId { get; set; }

        [JsonProperty(PropertyName = "file_size")]
        public int FileSize { get; set; }

        [JsonProperty(PropertyName = "file_path")]
        public string FilePath { get; set; }
    }
}