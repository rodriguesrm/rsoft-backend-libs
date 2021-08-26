# **RSoft.Lib.Messaging**

RSoft.Lib.Messaging is a provider of send/publish messages and assign queues using [MassitTransport](https://masstransit-project.com/).

### **Available transports**

  - RabbitMQ

### **Available Persistence (for Saga)**

  - _Not available_

### **Installation**

 - PackageManage: Install-Package `RSoft.Lib.Messaging -Version x.x.x`
 - .NET Cli: dotnet add package `RSoft.Lib.Messaging --version x.x.x`
 - Package Reference: `<PackageReference Include="RSoft.Lib.Messaging" Version="x.x.x" />`
 - Paket Cli: `paket add RSoft.Lib.Messaging --version x.x.x`

### **Configuration**

  The configuration of all the mechanisms of this package are done through the appsettings.json of the application, in the section `Messaging` complete complete below

```json
"Messaging": {
  "Server": {
    "ServerAddress": "127.0.0.1",
    "VirtualHost": "YourVirtualHostName",
    "Username": "your-username",
    "Password": "your-password"
  }
}
```

### **Implementation in your application**

You need register services in `Startup.cs` in ASP.NET Application or `Program.cs` in Host Application (Worker, etc).

**Registering services**

```c#
// Import namespace
using RSoft.Lib.Messaging.Abstractions;
```

Add the services like the model below on service register section:

```c#
// Only register bus
services.AddMassTransitUsingRabbitMq(Configuration);

// Register bus and consumers
services.AddMassTransitUsingRabbitMq(Configuration, cfg => 
{

  // Command consumers
  cfg.AddCommandConsumerEndpoint<PlaceOrderCommand, PlaceOrderCommandConsumer>();

  // Event consumers
  cfg.AddEventConsumerEndpoint<OrderPlacedEvent, OrderPlacedEventConsumer>();
  cfg.AddEventConsumerEndpoint<OrderDeliveredEvent, OrderDeliveredEventConsumer>();
});

```

> **_NOTE:_**  `Configuration` is a instance of `IConfiguration`.

**Create Contracts**

For sending commands and publishing events it's necessary to use models/contracts. To ensure that the correct type is being used in the different operations, two interfaces are used:

```c#
namespace RSoft.Lib.Messaging.Contracts
{

    /// <summary>
    /// Interface to control command message
    /// </summary>
    public interface IMessageCommand
    {
    }

    /// <summary>
    /// Interface to control event message
    /// </summary>
    public interface IMessageEvent
    {
    }

}
```

Thus, to create contracts that will be used in messages that direct a command, use the `IMessageCommand` interface and if it is messages that publish events, use the `IMessageEvent` interface.

> **NOTE:** A *command* is a message that can be sent from one or more senders and is processed by a single receiver. An *event* is a message that is published from a single sender, and is processed by (potentially) many receivers.

Let's take a look at these differences side-by-side:

| |Command|Event
------------|------------| -------------
Interface | IMessageCommand | IMessageEvent
Logical Sender | One or more (1-N) | Just one (1)
Logical Receiver | Just one (1) | Zero or more (0-N)
Purpose | "Please do something" |   "Something has happened"
Naming (Tense) | Imperative | Past
Examples | `PlaceOrderCommand`, `DeliverOrderCommand` | `OrderPlacedEvent`, `OrderDeliveredEvent` 

From this comparison, it's clear that commands and events will sometimes come in pairs. A command will arrive, perhaps from a website UI, telling the system to DoSomething. The system does that work, and as a result, publishes a SomethingHappened event, which other components in the system can react to.

**Contracts examples**

```c#
// Command contract
public class PlaceOrderCommand : IMessageCommand
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CustomerName { get; set; }
}

// Event contract
public class OrderPlacedEvent : IMessageEvent
{
    public Guid Id { get; set; }
    public DateTime PlacedAt { get; set; }
}
```

**Send Commands**
```c#
public class YourClassName
{

    private readonly IBusControl _bus;

    public YourClassName(IBusControl bus)
    {
      // Injecting IBusControl
        _bus = bus;
    }

    public async Task PlaceOrder(PlaceOrderCommand placeOrderCommand)
    {
        await _bus.SendCommand(placeOrderCommand);
    }

}
```

**Publish/Raise events**

```c#
public class YourCommandConsumer : IConsumeCommand<YourCommand>
{
    public Task Consume(ConsumeContext<YourCommand> context)
    {
        // process your command and do something
        return context.RaiseEvent(new YourEvent());
    }
}
```

### Consumers

To handle the received messages, command or event, Needs create a consumer so that it subscribes to the respective queue where the messages will be delivered.

There are two consumers types:

- Command Consumer: Handles command messages (`IMessageCommand`).
- Event Consumer: Handls event messages (`IMessageEvent`).

To create the message handlers, the same premise applied when creating the contracts is also used to create these consumers.

```c#
// Command consumer interface
public interface IConsumeCommand<TMessage> : IConsumer<TMessage>
  where TMessage : class, IMessageCommand
{
}

// Event consumer interface
public interface IConsumeEvent<TMessage> : IConsumer<TMessage>
  where TMessage : class, IMessageEvent
{
}
```

**Consumers examples**

```c#
// Command consumer class
public class PlaceOrderCommandConsumer : IConsumeCommand<PlaceOrderCommand>
{

    public Task Consume(ConsumeContext<PlaceOrderCommand> context)
    {
        // Do something
        return Task.CompletedTask;
    }
}

// Event consumer class
public class OrderPlacedEventConsumer : IConsumeCommand<OrderPlacedEvent>
{

    public Task Consume(ConsumeContext<OrderPlacedEvent> context)
    {
        // Do something
        return Task.CompletedTask;
    }
}
```

That is all! If you need help send me a message.