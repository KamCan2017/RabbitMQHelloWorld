using Common;
using RabbitMQ.Client;
using System;
using System.Text;

namespace Publisher
{
    class Send
    {
        static void Main(string[] args)
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

                    string message = "Hello World!";
                    var body = (byte[])MessageEnCoder.CodeMessage(message, RoutingKeys.HelloChannel);

                    channel.BasicPublish(exchange: "",
                                         routingKey: RoutingKeys.HelloChannel,
                                         basicProperties: null,
                                         body: body);
                    Console.WriteLine(" [x] Sent {0}", message);
                }

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }    
}
