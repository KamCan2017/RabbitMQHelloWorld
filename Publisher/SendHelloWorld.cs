using Common;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publisher
{
    class SendHelloWorld
    {
        public static void Init()
        {
            //create a connection to the server
            //The connection abstracts the socket connection,
            //and takes care of protocol version negotiation and authentication 
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                //create a channel
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: RoutingKeys.HelloChannel,
                                  durable: false,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);

                    Console.WriteLine("Type stop to stop the message sending.");

                    string message = string.Empty;
                    while (message.ToLower() != "stop")
                    {
                        Console.WriteLine("Send a message:");

                        message = Console.ReadLine();
                        if (message.ToLower() == "stop")
                            continue;

                        var body = MessageEnCoder.CodeMessage(message);

                        channel.BasicPublish(exchange: "",
                                             routingKey: RoutingKeys.HelloChannel,
                                             basicProperties: null,
                                             body: body);
                        Console.WriteLine(" [x] Sent {0}", message);
                    }
                }

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }

        }
    }
}
