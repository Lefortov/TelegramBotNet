# TelegramBotNet
This is a simple C# wrapper for telegram bot-API methods(https://core.telegram.org/bots/api)

Download from Nu-get:

Usage:

```TelegramBotApi api = new TelegramBotApi("Your bot token here, for example: 152319005:AAGgDQzm9Us3pPoWHc9gE4tFUIzSqNBjLsk");```

```var updates = api.GetUpdates(); ```
```var chatId = updates[0].Message.Chat.Id.ToString();```
```api.SendMessage(chatId, "Example");```
