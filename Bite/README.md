# C# Bite

C# client library for [**Bite**](https://github.com/alvivar/bite). Compatible
with Unity.

To **connect**.

    Bite bite = new Bite("127.0.0.1", 1984);

To **send**.

    bite.Send("s author Andrés Villalobos");
    bite.Send("g author");

You can use a **System.Action<string>** callback on **Send** to deal directly
with the **response**.

    bite.Send("g author", response => {
        // Handle your response.
    });

You also have a couple **System.Action<string>** to subscribe.

    bite.OnResponse += YourOnResponse;
    bite.OnError += YourOnError;

Bonus: There are some static utility to deal with string to ints, floats or
longs.

    int i = Bite.Int("Try or default ->", 1984);

Check out the **Unity**
[**Analytics.cs**](https://github.com/alvivar/bite/blob/master/.csharp/Analytics.cs)
example!
