namespace Subscriber
{
    using System;
    using System.Threading.Tasks;
    using NServiceBus;

    class Program
    {
        static async Task Main()
        {
            Console.Title = "Samples.StepByStep.Subscriber";
            var endpointConfiguration = new EndpointConfiguration("Samples.StepByStep.Subscriber");
            endpointConfiguration.UseSerialization<XmlSerializer>();
            endpointConfiguration.UsePersistence<LearningPersistence>();
            endpointConfiguration.UseTransport<LearningTransport>();

            var endpointInstance = await Endpoint.Start(endpointConfiguration)
                .ConfigureAwait(false);
            try
            {
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
            finally
            {
                await endpointInstance.Stop()
                    .ConfigureAwait(false);
            }
        }
    }
}
