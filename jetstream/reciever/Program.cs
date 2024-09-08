
using NATS.Client.Core;
using NATS.Client.JetStream;
using NATS.Client.JetStream.Models;

await using var nats = new NatsConnection();
var js = new NatsJSContext(nats);

// Create a consumer on a stream to receive the messages
var consumer = await js.CreateOrUpdateConsumerAsync("orders", new ConsumerConfig("order_processor"));

await foreach (var jsMsg in consumer.ConsumeAsync<string>())
{
    Console.WriteLine($"Processed: {jsMsg.Data}");
    await jsMsg.AckAsync();
}