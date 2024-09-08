using NATS.Client.Core;

await using var nats = new NatsConnection();

var cts = new CancellationTokenSource();


// Give subscription time to start
await Task.Delay(1000);

for (var i = 0; i < 100; i++)
{
    await nats.PublishAsync(subject: "test", data: $"Pos mq test {i}");
}

// Give subscription time to receive messages
await Task.Delay(1000);

// Unsubscribe
cts.Cancel();