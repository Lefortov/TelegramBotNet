namespace TelegramBotNet.Interfaces
{
    internal interface IBotApi
    {
        void GetUpdates();
        void SetWebhook();
    }
}