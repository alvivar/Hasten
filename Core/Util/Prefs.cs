
// Wrapper (kind of) of PlayerPrefs that works as I like.

// @matnesis
// 2016/06/03 09:45 PM


using UnityEngine;

public class Prefs
{
    // ^
    // Boolean

    public static bool Bool(string id)
    {
        int val = 0;

        if (PlayerPrefs.HasKey(id)) val = PlayerPrefs.GetInt(id);
        else PlayerPrefs.SetInt(id, val);

        return val == 0 ? false : true;
    }

    public static void Bool(string id, bool data)
    {
        PlayerPrefs.SetInt(id, data ? 1 : 0);
    }


    // ^
    // Int

    public static int Int(string id)
    {
        int val = 0;

        if (PlayerPrefs.HasKey(id)) val = PlayerPrefs.GetInt(id);
        else PlayerPrefs.SetInt(id, val);

        return val;
    }

    public static void Int(string id, int data)
    {
        PlayerPrefs.SetInt(id, data);
    }


    // ^
    // Float

    public static float Float(string id)
    {
        float val = 0;

        if (PlayerPrefs.HasKey(id)) val = PlayerPrefs.GetFloat(id);
        else PlayerPrefs.SetFloat(id, val);

        return val;
    }

    public static void Float(string id, float data)
    {
        PlayerPrefs.SetFloat(id, data);
    }
}
