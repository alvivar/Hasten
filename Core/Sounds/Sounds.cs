
// Sound library.

// Andrés Villalobos ^ andresalvivar@gmail.com ^ twitter.com/matnesis
// 2015/10/19 04:48 PM


using UnityEngine;
using matnesis.TeaTime;


public class Sounds : MonoBehaviour
{
    public AudioClip[] backgroundClips;

    public AudioSource background;
    public AudioSource sounds;


    void Start()
    {
        AudioSource[] audios = GetComponents<AudioSource>();
        background = audios[0];
        sounds = audios[1];


        // Play the soundtrack sounds one after the other
        if (backgroundClips.Length < 1)
            return;

        int bgMark = 0;
        this.tt("backgroundPlay").Add((ttHandler t) =>
        {
            t.WaitFor(backgroundClips[bgMark].length * 0.8f);
            background.PlayOneShot(backgroundClips[bgMark]);
            bgMark = (bgMark + 1) % backgroundClips.Length;
        })
        .Repeat();
    }
}
