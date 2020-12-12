using System;
using RabbitMQ.Client;
using System.Text;

class Send
{
    public static void Main()
    {
        var factory = new ConnectionFactory() { HostName = "" };
        factory.UserName = "";
        factory.Password = "";
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "hello2",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            string message="";
            var body= Encoding.UTF8.GetBytes(message);
            for (int i = 0; i < 5000; i++)
            {
                message = "Hello World! " + i.ToString();
                 body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "",
                                  routingKey: "hello",
                                  basicProperties: null,
                                  body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }

            
          
           
        }

        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
    }
}