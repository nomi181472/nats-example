using NATS.Client.Core;
using NATS.Client.JetStream;
using NATS.Client.JetStream.Models;
/*
await using var nats = new NatsConnection();
var js = new NatsJSContext(nats);

// Create a stream to store the messages
await js.CreateStreamAsync(new StreamConfig(name: "orders", subjects: new[] { "orders.*" }));

// Publish a message to the stream. The message will be stored in the stream
// because the published subject matches one of the the stream's subjects.
var ack = await js.PublishAsync(subject: "orders.new", data: "order 1");
ack.EnsureSuccess();

// Create a consumer on a stream to receive the messages
var consumer = await js.CreateOrUpdateConsumerAsync("orders", new ConsumerConfig("order_processor"));

await foreach (var jsMsg in consumer.ConsumeAsync<string>())
{
    Console.WriteLine($"Processed: {jsMsg.Data}");
    await jsMsg.AckAsync();
}*/

await using var nats = new NatsConnection();
Console.WriteLine("client is listening");
var cts = new CancellationTokenSource();

var subscription = Task.Run(async () =>
{
    await foreach (var msg in nats.SubscribeAsync<string>(subject: "test").WithCancellation(cts.Token))
    {
        Console.WriteLine($"Received: {msg.Data}");
    }
});


// Give subscription time to receive messages
await Task.Delay(1000);



await subscription;
