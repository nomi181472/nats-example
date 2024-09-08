using NATS.Client.Core;



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
