
using NATS.Client.Core;
using NATS.Client.JetStream;
using NATS.Client.JetStream.Models;

await using var nats = new NatsConnection();
var js = new NatsJSContext(nats);

// Create a stream to store the messages
await js.CreateStreamAsync(new StreamConfig(name: "orders", subjects: new[] { "orders.*" }));

// Publish a message to the stream. The message will be stored in the stream
// because the published subject matches one of the the stream's subjects.
for (int i = 0; i < 10; i++)
{
    var ack = await js.PublishAsync(subject: "orders.new", data: $"order {i}");
    ack.EnsureSuccess();
}



