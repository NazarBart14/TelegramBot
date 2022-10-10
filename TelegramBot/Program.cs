using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;

namespace TelegramBotExperiments
{

    class Program
    {
        static ITelegramBotClient bot = new TelegramBotClient("5662965815:AAF0PzwZlWOO8QtzC89zTe5fOxxvqoGe4zA");
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = update.Message;
                
                if (message.Text.ToLower() == "/start")
                {
                    await botClient.SendTextMessageAsync(message.Chat, "Ласкаво просимо на борт, добрий мандрівник!");
                    await botClient.SendTextMessageAsync(message.Chat, "Ви можете вибрати такі варіанти запиту: ");
                    await botClient.SendTextMessageAsync(message.Chat, "Карта");
                    await botClient.SendTextMessageAsync(message.Chat, "/map");
                    await botClient.SendTextMessageAsync(message.Chat, "Рандомайзер ");
                    await botClient.SendTextMessageAsync(message.Chat, "/rand");
                    await botClient.SendTextMessageAsync(message.Chat, "Офіціальний сайт Геншену");
                    await botClient.SendTextMessageAsync(message.Chat, "/genshin");
                    return;
                }
                

                else if (message.Text.ToLower() == "/map")
                {
                    await botClient.SendTextMessageAsync(message.Chat, "https://www.google.com/url?sa=t&rct=j&q=&esrc=s&source=web&cd=&ved=2ahUKEwicx5i82876AhWLuIsKHRO5BckQFnoECAwQAQ&url=https%3A%2F%2Fgenshin-info.ru%2Finteraktivnaya-karta%2F&usg=AOvVaw3lBB9y8rG3HXJADxyCrswS");
                    return;
                }
                else if (message.Text.ToLower() == "/   ")
                {
                    await botClient.SendTextMessageAsync(message.Chat, "");
                    return;
                }
                else if (message.Text.ToLower() == "/genshin")
                {
                    await botClient.SendTextMessageAsync(message.Chat, "https://www.google.com/url?sa=t&rct=j&q=&esrc=s&source=web&cd=&cad=rja&uact=8&ved=2ahUKEwjT0eyN3M76AhXo-yoKHfJCAmgQFnoECB8QAQ&url=https%3A%2F%2Fgenshin.hoyoverse.com%2Fru%2F&usg=AOvVaw0kjnbLAHyHOaP-R6av_1x8");
                    return;
                }
            }
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {

             Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }


        static void Main(string[] args)
        {


            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }, 
            };
            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
            Console.ReadLine();
        }

    }
}