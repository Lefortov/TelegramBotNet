namespace TelegramBotNet.DTOs
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class UserProfilePhotos
    {
        [JsonProperty(PropertyName = "total_count")]
        public int TotalCount { get; set; }

        [JsonProperty(PropertyName = "photos")]
        public List<List<PhotoSize>> PhotoSizes { get; set;   }
    }
}