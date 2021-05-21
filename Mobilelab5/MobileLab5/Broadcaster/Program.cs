﻿using System;
using Shared;

namespace Broadcaster
{
    public class Program
    {
        private static void Main(string[] args)
        {
            string hostName = "localhost";
            var rabbitMqManager = new RabbitMqManager(hostName);
            while (true)
            {
                Console.WriteLine(">>> Enter a message which you want to send or type 'q' to exist app. <<<");
                string userMessage = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userMessage))
                {
                    Console.WriteLine("You have to type a message.");
                    continue;
                }

                if (userMessage == "q")
                    return;

                Console.WriteLine("[Start]");
                try
                {
                    rabbitMqManager.SendMessage(QueueNames.HELLO_WORLD, userMessage);
                    Console.WriteLine("[Done]");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Something went wrong: {ex.Message}]");
                    Console.ReadKey();
                    return;
                }
            }
        }
    }
}
