namespace TelegramBotNet.DTOs
{
    using Newtonsoft.Json;

    public class Contact
    {
        [JsonProperty(PropertyName = "phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }
    }
}