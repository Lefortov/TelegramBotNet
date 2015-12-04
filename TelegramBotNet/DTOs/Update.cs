namespace TelegramBotNet.DTOs
{
    using Newtonsoft.Json;
    using System.Collections.Generic;


    public class Update
    {
        [JsonProperty(PropertyName = "update_id")]
        public int UpdateId { get; set; }

        [JsonProperty(PropertyName = "message")]
        public Message Message { get; set; }
    }
}