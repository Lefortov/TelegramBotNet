namespace TelegramBotNet
{
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using TelegramBotNet.Core;
    using TelegramBotNet.DTOs;
    using File = TelegramBotNet.DTOs.File;
    public class TelegramBotApi
    {
        private readonly string _token;

        public TelegramBotApi(string token)
        {
            _token = token;
        }

        public List<Update> GetUpdates(string offset = "", string limit = "", string timeout = "")
        {
            var coll = new NameValueCollection
            {
                {"offset", offset},
                {"limit", limit},
                {"timeout", timeout}
            };
            var update =
                JsonConvert.DeserializeObject<RootObject<List<Update>>>(
                    RequestCore.Get("getUpdates", _token, coll).Result).Result;
            return update;
        }

        public async Task<string> SetWebhook(string url, X509Certificate2 cert)
        {
            var certBytes = cert.Export(X509ContentType.Pkcs12);
            var httpClient = new HttpClient();
            var form = new MultipartFormDataContent();
            form.Add(new StringContent(url), "url");
            form.Add(new ByteArrayContent(certBytes, 0, certBytes.Count()), "certificate", "kek");
            var response =
                await httpClient.PostAsync(string.Format("https://api.telegram.org/bot{0}/setWebhook", _token), form);
            response.EnsureSuccessStatusCode();
            httpClient.Dispose();
            var result = response.Content.ReadAsStringAsync().Result;
            return result;
        }


        public User GetMe()
        {
            var user = JsonConvert
                .DeserializeObject<RootObject<User>>(RequestCore.Get("getMe", _token, new NameValueCollection()).Result)
                .Result;
            return user;
        }

        public void SendMessage(string chatId, string text, string parseMode = "", string disableWebPagePreview = "",
            string replyToMessageId = "", string replyMarkup = "")
        {
            var coll = new NameValueCollection
            {
                {"chat_id", chatId},
                {"text", text},
                {"parse_mode", parseMode},
                {"disable_web_page_preview", disableWebPagePreview},
                {"reply_to_message_id", replyToMessageId},
                {"reply_markup", replyMarkup}
            };
            RequestCore.Get("sendMessage", _token, coll).Wait();
        }

        public void ForwardMessage(string chatId, string fromChatId, string messageId)
        {
            var coll = new NameValueCollection
            {
                {"chat_id", chatId},
                {"from_chat_id", fromChatId},
                {"message_id", messageId}
            };
            var kek = RequestCore.Get("forwardMessage", _token, coll).Result;
        }

        public async Task<string> SendPhoto(string chatId, byte[] localPhoto, string caption = "",
            string replyToMessageId = "", string replyMarkup = "")
        {
            var httpClient = new HttpClient();
            var form = new MultipartFormDataContent();
            form.Add(new StringContent(chatId), "chat_id");
            form.Add(new StringContent(caption), "caption");
            form.Add(new StringContent(replyToMessageId), "reply_to_message_id");
            form.Add(new StringContent(replyMarkup), "reply_markup");
            form.Add(new ByteArrayContent(localPhoto, 0, localPhoto.Count()), "photo", "kek.jpg");
            var response =
                await httpClient.PostAsync(string.Format("https://api.telegram.org/bot{0}/sendPhoto", _token), form);
            response.EnsureSuccessStatusCode();
            httpClient.Dispose();
            var result = response.Content.ReadAsStringAsync().Result;
            return result;
        }

        public void SendPhotoById(string chatId, string photoId, string caption = "",
            string replyToMessageId = "", string replyMarkup = "")
        {
            var coll = new NameValueCollection
            {
                {"chat_id", chatId},
                {"photo", photoId},
                {"caption", caption},
                {"reply_to_message_id", replyToMessageId},
                {"reply_markup", replyMarkup}
            };
            RequestCore.Get("sendPhoto", _token, coll).Wait();
        }

        public async Task<string> SendAudio(string chatId, byte[] audio, string duration = "", string performer = "",
            string title = "", string replyToMessageId = "", string replyMarkup = "")
        {
            var httpClient = new HttpClient();
            var form = new MultipartFormDataContent();
            form.Add(new StringContent(chatId), "chat_id");
            form.Add(new StringContent(duration), "duration");
            form.Add(new StringContent(performer), "performer");
            form.Add(new StringContent(title), "title");
            form.Add(new StringContent(replyToMessageId), "reply_to_message_id");
            form.Add(new StringContent(replyMarkup), "reply_markup");
            form.Add(new ByteArrayContent(audio, 0, audio.Count()), "audio", "kek.mp3");
            var response =
                await httpClient.PostAsync(string.Format("https://api.telegram.org/bot{0}/sendAudio", _token), form);
            response.EnsureSuccessStatusCode();
            httpClient.Dispose();
            var result = response.Content.ReadAsStringAsync().Result;
            return result;
        }

        public void SendAudioById(string chatId, string audioId, string duration = "", string performer = "",
            string title = "", string replyToMessageId = "", string replyMarkup = "")
        {
            var coll = new NameValueCollection
            {
                {"chat_id", chatId},
                {"audio", audioId},
                {"duration", duration},
                {"performer", performer},
                {"title", title},
                {"reply_to_message_id", replyToMessageId},
                {"reply_markup", replyMarkup}
            };
            RequestCore.Get("sendAudio", _token, coll).Wait();
        }

        public void SendVoiceById(string chatId, string voiceId, string duration, string replyToMessageId,
            string replyMarkup)
        {
            var coll = new NameValueCollection
            {
                {"chat_id", chatId},
                {"voice", voiceId},
                {"duration", duration},
                {"reply_to_message_id", replyToMessageId},
                {"reply_markup", replyMarkup}
            };
            RequestCore.Get("sendVoice", _token, coll).Wait();
        }

        public async Task<string> SendDocument(string chatId, byte[] document, string fileName,
            string replyToMessageId = "", string replyMarkup = "")
        {
            var httpClient = new HttpClient();
            var form = new MultipartFormDataContent();
            form.Add(new StringContent(chatId), "chat_id");
            form.Add(new StringContent(replyToMessageId), "reply_to_message_id");
            form.Add(new StringContent(replyMarkup), "reply_markup");
            form.Add(new ByteArrayContent(document, 0, document.Count()), "document", fileName);
            var response =
                await httpClient.PostAsync(string.Format("https://api.telegram.org/bot{0}/sendDocument", _token), form);
            response.EnsureSuccessStatusCode();
            httpClient.Dispose();
            var result = response.Content.ReadAsStringAsync().Result;
            return result;
        }

        public void SendSticker(string chatId, string sticker, string replyToMessage = "", string replyMarkup = "")
        {
            var coll = new NameValueCollection
            {
                {"chat_id", chatId},
                {"sticker", sticker},
                {"reply_to_message_id", replyToMessage},
                {"reply_markup", replyMarkup}
            };

            RequestCore.Get("sendSticker", _token, coll).Wait();
        }

        public async Task<string> SendVideo(string chatId, byte[] video, string duration = "", string caption = "",
            string replyToMessageId = "", string replyMarkUp = "")
        {
            var httpClient = new HttpClient();
            var form = new MultipartFormDataContent();
            form.Add(new StringContent(chatId), "chat_id");
            form.Add(new StringContent(replyToMessageId), "reply_to_message_id");
            form.Add(new StringContent(duration), "duration");
            form.Add(new StringContent(caption), "caption");
            form.Add(new ByteArrayContent(video, 0, video.Count()), "video", "kek.mp4");
            var response =
                await httpClient.PostAsync(string.Format("https://api.telegram.org/bot{0}/sendVideo", _token), form);
            response.EnsureSuccessStatusCode();
            httpClient.Dispose();
            var result = response.Content.ReadAsStringAsync().Result;
            return result;
        }

        public void SendVideoById(string chatId, string videoId, string duration = "", string caption = "",
            string replyToMessageId = "", string replyMarkUp = "")
        {
            var coll = new NameValueCollection
            {
                {"chat_id", chatId},
                {"video", videoId},
                {"duration", duration},
                {"caption", caption},
                {"reply_to_message_id", replyToMessageId},
                {"reply_markup", replyMarkUp}
            };

            RequestCore.Get("sendVideo", _token, coll).Wait();
        }

        public void SendLocation(string chatId, string latitude, string longitude, string replyToMessageId = "",
            string replyMarkUp = "")
        {
            var coll = new NameValueCollection
            {
                {"chat_id", chatId},
                {"latitude", latitude},
                {"longitude", longitude},
                {"reply_to_message_id", replyToMessageId},
                {"reply_markup", replyMarkUp}
            };
            RequestCore.Get("sendLocation", _token, coll).Wait();
        }

        public void SendChatAction(string chatId, ChatAction action)
        {
            var actionDictionary = new Dictionary<int, string>
            {
                {1, "typing"},
                {2, "upload_photo"},
                {3, "record_video"},
                {4, "upload_video"},
                {5, "record_audio"},
                {6, "upload_audio"},
                {7, "upload_document"},
                {8, "find_location"}
            };
            string currentAction;
            actionDictionary.TryGetValue((int) action, out currentAction);

            var coll = new NameValueCollection
            {
                {"chat_id", chatId},
                {"action", currentAction}
            };
            RequestCore.Get("sendChatAction", _token, coll).Wait();
        }

        public void DownloadFile(string filePath, string path)
        {
            var remoteUri = string.Format("https://api.telegram.org/bot{0}/{1}", _token, filePath);
            var fileName = string.Format("{0}/{1}", path, Path.GetRandomFileName());

            using (var myWebClient = new WebClient())
            {
                myWebClient.DownloadFile(remoteUri, fileName);
            }
        }

        public UserProfilePhotos GetUserProfilePhotos(string userId, string offset = "", string limit = "")
        {
            var coll = new NameValueCollection
            {
                {"file_id", userId},
                {"file_id", offset},
                {"file_id", limit}
            };
            var photos = JsonConvert
                .DeserializeObject<RootObject<UserProfilePhotos>>(
                    RequestCore.Get("getUserProfilePhotos", _token, coll).Result)
                .Result;
            return photos;
        }

        public File GetFile(string fileId)
        {
            var coll = new NameValueCollection
            {
                {"file_id", fileId}
            };
            var file = JsonConvert
                .DeserializeObject<RootObject<File>>(RequestCore.Get("getFile", _token, coll).Result)
                .Result;
            return file;
        }
    }

    public enum ChatAction
    {
        Typing = 1,
        UploadPhoto = 2,
        RecordVideo = 3,
        UploadVideo = 4,
        RecordAudio = 5,
        UploadAudio = 6,
        UploadDocument = 7,
        FindLocation = 8
    }
}