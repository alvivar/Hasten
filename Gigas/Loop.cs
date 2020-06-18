//  This is an unfinished experimental list of callbacks, to accomplish patterns
//  like Tweens or IEnumerators but in Data Oriented patterns.

using System.Collections.Generic;

public class Loop
{
    Arrayx<Loopx> queue;

    public void Get()
    {

    }

    public void Add()
    {

    }

    public void Run()
    {

    }
}

public class Loopx
{
    public float time;
    public System.Action callback;
    public Loopx next;

    public Loopx(float time = 0, System.Action callback = null)
    {
        this.callback = callback;
        this.time = time;
    }
}

// A cache for the general structure, probably!

// Dictionary<string, Arrayx<Loopx>> cache = new Dictionary<string, Arrayx<Loopx>>();

// public Arrayx<Loopx> Get(string id)
// {
//     if (cache.ContainsKey(id))
//         return cache[id];

//     if (cache[id] == null)
//         cache[id] = new Arrayx<Loopx>();

//     var loop = new Loopx();
//     cache[id].Add(loop);

//     return cache[id];
// }