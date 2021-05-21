using System;
using Shared;

namespace Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = "localhost";
            var newMessage = false;
            Console.WriteLine("Dzień dobry :)");

            var rabbitMQManager = new RabbitMqManager(host);

            var connection = rabbitMQManager.Factory.CreateConnection();
            var channel = connection.CreateModel();

            rabbitMQManager.SubscribeQueue(channel, QueueNames.HELLO_WORLD,
                (message) =>
                {
                    Console.WriteLine($">>> Otrzymana wiadomość: '{message}' <<<");
                    newMessage = true;
                });


            while (true)
            {
                if (newMessage)
                {
                    Console.Write($"Podaj jak sie nazywasz: ");
                    var userMessage = Console.ReadLine();
                    if (userMessage == "q")
                        return;
                    rabbitMQManager.SendMessage(QueueNames.HELLO_DAN, userMessage);
                    newMessage = false;
                }
            }
        }
    }
}