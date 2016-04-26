
// Sound library, belongs to Game.

// Andrés Villalobos ^ andresalvivar@gmail.com ^ twitter.com/matnesis
// 2015/10/19 04:48 PM


using UnityEngine;
using matnesis.TeaTime;

public class Sounds : MonoBehaviour
{
    [Header("Background")]
    public AudioClip[] bgLoop;
    public AudioClip[] bgRandom;

    [Header("Bullets")]
    public AudioClip bulletShoot;
    public AudioClip bulletExplosion;

    [Header("Teleport")]
    public AudioClip teleportIn;
    public AudioClip teleportDuring;
    public AudioClip teleportOut;


    [Header("Audio sources")]
    public AudioSource background;
    public AudioSource[] sounds = new AudioSource[3];

    private int soundsIndex = 0;


    void Start()
    {
        // Audio sources are connected
        AudioSource[] audios = GetComponents<AudioSource>();

        background = audios[0];

        sounds[0] = audios[1];
        sounds[1] = audios[2];
        sounds[2] = audios[3];


        // @
        // Bg sounds to loop
        {
            int bgMark = 0;
            this.tt("bgLoop").If(() => bgLoop.Length > 0).Add((ttHandler t) =>
            {
                // Wait for the sound to almost over
                background.PlayOneShot(bgLoop[bgMark]);
                t.WaitFor(bgLoop[bgMark].length * 0.8f);

                // Next
                bgMark = ++bgMark % bgLoop.Length;
            })
            .Repeat();
        }


        // @
        // Random bg sounds
        {
            this.tt("bgRandom")
            .Add(() => Random.Range(180f, 240f))
            .If(() => bgRandom.Length > 0).Add((ttHandler t) =>
            {
                // Play a random bg sound
                int randomBg = Random.Range(0, bgRandom.Length);
                background.PlayOneShot(bgRandom[randomBg]);

                // Waits the sound duration plus a random between 3m and 4m
                t.WaitFor(bgRandom[randomBg].length);
            })
           .Repeat();
        }
    }


    public AudioSource PlaySound(AudioClip clip, float volume = 1, float pitch = 1)
    {
        if (clip == null) return null;

        AudioSource current = sounds[soundsIndex];
        current.pitch = pitch;
        current.PlayOneShot(clip, volume);

        // Next audio source
        soundsIndex = ++soundsIndex % sounds.Length;


        return current;
    }
}
