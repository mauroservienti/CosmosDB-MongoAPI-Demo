using NServiceBus;
using NServiceBus.MongoDB;
using System;
using System.Threading.Tasks;

namespace MongoCosmos
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var configuration = new EndpointConfiguration("MongoCosmos");
            configuration.UseTransport<LearningTransport>();
            configuration.SendFailedMessagesTo("error");
            var persistence = configuration.UsePersistence<MongoDBPersistence>();
            persistence.SetDatabaseName("nsb-data");
            persistence.SetConnectionString(@"mongodb://your-connection-string-here");

            var endpoint = await Endpoint.Start(configuration);

            await endpoint.Publish<SomethingHappened>(e => e.EventId = Guid.NewGuid().ToString());

            Console.WriteLine("Event published");
            Console.Read();
        }
    }
}
