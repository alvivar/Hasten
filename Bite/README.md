# C# Bite

C# client library for [**BITE**](https://github.com/alvivar/bite). Should work fine with Unity.

To **connect**.

    Bite bite = new Bite("127.0.0.1", 1984);

To **send**.

    bite.Send("s author Andrés Villalobos");
    bite.Send("g author");

You can use a **System.Action<Byte[]>** callback on **Send** to deal directly with the **response**.

    bite.Send("g author", response => {
        // Handle your response.
    });

You also have a **System.Action<Byte[]>** to subscribe.

    bite.OnResponse += YourOnResponse;

Bonus: There are some static utility to deal with string to ints, floats or longs.

    int i = Bitf.Int("Try or default ->", 1984);

Check out the **Unity** [**Analytics.cs**](https://github.com/alvivar/bite/blob/master/.csharp/Analytics.cs) example!
