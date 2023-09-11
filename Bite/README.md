# C# BITE Client

C# client library for [**BITE**](https://github.com/alvivar/bite). Should work fine with Unity.

To **connect**.

    Bite bite = new Bite("127.0.0.1", 1984);

To **send**.

    bite.Send("s author Andrés Villalobos");
    bite.Send("g author");

You can use a **System.Action<Frame[]>** callback on **Send** to deal directly with the **response**.

    bite.Send("g author", frame => {
        // The frame is the abstraction with the result.
    });

You also have a couple of **System.Action<Frame[]>** to subscribe.

    bite.OnConnected += YourOnConnected; // Once, when connected.
    bite.OnFrameReceived += YourOnFrameReceived; // Every time a frame is received.

Bonus: There is a static utility to deal with common conversions, check out **Bitf.cs**.

    int i = Bitf.Int("Try or default ->", 1984);
