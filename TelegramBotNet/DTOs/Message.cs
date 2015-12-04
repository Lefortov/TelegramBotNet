namespace TelegramBotNet.DTOs
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Message
    {
        [JsonProperty(PropertyName = "message_id")]
        public int MessageId { get; set; }

        [JsonProperty(PropertyName = "from")]
        public User From { get; set; }

        [JsonProperty(PropertyName = "date")]
        public int Date { get; set; }

        [JsonProperty(PropertyName = "chat")]
        public Chat Chat { get; set; }

        [JsonProperty(PropertyName = "forward_from")]
        public User ForwardFrom { get; set; }

        [JsonProperty(PropertyName = "forward_date")]
        public int ForwardDate { get; set; }

        [JsonProperty(PropertyName = "reply_to_message")]
        public Message ReplyToMessage { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "audio")]
        public Audio Audio { get; set; }

        [JsonProperty(PropertyName = "document")]
        public Document Document { get; set; }

        [JsonProperty(PropertyName = "photo")]
        public List<PhotoSize> Photo { get; set; }

        [JsonProperty(PropertyName = "sticker")]
        public Sticker Sticker { get; set; }

        [JsonProperty(PropertyName = "video")]
        public Video Video { get; set; }

        [JsonProperty(PropertyName = "voice")]
        public Voice Voice { get; set; }

        [JsonProperty(PropertyName = "caption")]
        public string Caption { get; set; }

        [JsonProperty(PropertyName = "contact")]
        public Contact Contact { get; set; }

        [JsonProperty(PropertyName = "location")]
        public Location Location { get; set; }

        [JsonProperty(PropertyName = "new_chat_participant")]
        public User NewChatParticipant { get; set; }

        [JsonProperty(PropertyName = "left_chat_participant")]
        public User LeftChatParticipant { get; set; }

        [JsonProperty(PropertyName = "new_chat_title")]
        public string NewChatTitle { get; set; }

        [JsonProperty(PropertyName = "new_chat_photo")]
        public List<PhotoSize> NewChatPhoto { get; set; }

        [JsonProperty(PropertyName = "delete_chat_photo")]
        public bool DeleteChatPhoto { get; set; }

        [JsonProperty(PropertyName = "group_chat_created")]
        public bool GroupChatCreated { get; set; }

        [JsonProperty(PropertyName = "supergroup_chat_created")]
        public bool SuperGroupChatCreated { get; set; }

        [JsonProperty(PropertyName = "channel_chat_created")]
        public bool ChangelChatCreated { get; set; }

        [JsonProperty(PropertyName = "migrate_to_chat_id")]
        public int MigrateToChatId { get; set; }

        [JsonProperty(PropertyName = "migrate_from_chat_id")]
        public int MigrateFromChatId { get; set; }
    }
}