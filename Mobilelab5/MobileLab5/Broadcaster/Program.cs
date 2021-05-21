using System;
using Shared;

namespace Broadcaster
{
    class Program
    {
        private static void Main()
        {
            var hostName = "localhost";
            var rabbitMQManager = new RabbitMqManager(hostName);
            var newMessage = false;
            var connection = rabbitMQManager.Factory.CreateConnection();
            var channel = connection.CreateModel();
            rabbitMQManager.SubscribeQueue(channel, QueueNames.HELLO_DAN,
                (message) =>
                {
                    Console.WriteLine($">>> Wiadomość użytkownika: '{message}' <<<");
                    newMessage = true;
                });
            while (true)
            {
                Console.WriteLine(">>> Wciśnij 'q' by wyjść lub inny przycisk by kontynuować <<<");
                var userMessage = Console.ReadLine();

                if (userMessage == "q")
                    return;

                Console.WriteLine("[Start]");

                rabbitMQManager.SendMessage(QueueNames.HELLO_WORLD, "Witaj użytkowniku, przestaw się");
                while (!newMessage)
                {
                }

                newMessage = false;
                Console.WriteLine("[Done]");
            }
        }
    }
}