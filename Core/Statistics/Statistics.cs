
// Component that collects all kind of data from the game and save it into
// PlayerPrefs.

// @matnesis
// 2016/06/03 09:32 PM


using UnityEngine;
using matnesis.TeaTime;

public class Statistics : MonoBehaviour
{
    public float seconds = 0;

    public int deads = 0;
    public int gems = 0;

    public const string ID = "@matnesis.Statistics.";


    void Start()
    {
        // Loading
        seconds = Prefs.Float(ID + "seconds");
        deads = Prefs.Int(ID + "deads");
        gems = Prefs.Int(ID + "gems");


        // @
        // Time counter
        this.tt().Add(1, (ttHandler t) => seconds += 1).Repeat();
    }


    public void Save()
    {
        Prefs.Float(ID + "seconds", seconds);
        Prefs.Int(ID + "deads", deads);
        Prefs.Int(ID + "gems", gems);
    }
}
