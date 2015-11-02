
// Sound library.

// Andrés Villalobos ^ andresalvivar@gmail.com ^ twitter.com/matnesis
// 2015/10/19 04:48 PM


using UnityEngine;
using System.Collections;
using matnesis.TeaTime;


public class Sounds : MonoBehaviour
{
    public AudioClip[] bg;

    public AudioSource audioBg;
    public AudioSource audioSounds;

    // tt
    public TeaTime playBackground;


    void Start()
    {
        AudioSource[] audios = GetComponents<AudioSource>();
        audioBg = audios[0];
        audioSounds = audios[1];

        // Play the soundtrack sounds one after the other
        if (bg.Length < 1)
            return;

        int bgMark = 0;
        playBackground = this.tt().Add((ttHandler t) =>
        {
            audioBg.PlayOneShot(bg[bgMark]);
            bgMark = (bgMark + 1) % bg.Length;
            t.WaitFor(bg[bgMark].length * 0.5f);
        })
        .Repeat();
    }
}
