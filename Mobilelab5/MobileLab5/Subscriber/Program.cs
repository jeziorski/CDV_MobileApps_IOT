using System;
using Shared;

namespace Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            string host = "localhost";
            string queue = QueueNames.HELLO_WORLD;

            Console.WriteLine("Welcome in ClientOne application. To quit press any key.");

            var rabbitMqManager = new RabbitMqManager(host);

            using (var connection = rabbitMqManager.Factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                rabbitMqManager.SubscribeQueue(channel, queue, (message) =>
                {
                    Console.WriteLine($">>> Received message: '{message}' <<<");
                });

                Console.ReadKey();
            }

        }
    }
}
