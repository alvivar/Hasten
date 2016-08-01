
// Sound library, belongs to Game.

// @matnesis
// 2015/10/19 04:48 PM


using UnityEngine;
using matnesis.TeaTime;

[Reactive]
public class Sounds : MonoBehaviour
{
    public BoolReactiveProp enableBgLoop = new BoolReactiveProp(true);
    public BoolReactiveProp enableBgRandom = new BoolReactiveProp(true);

    [Header("Background")]
    public AudioClip[] bgLoop;
    public AudioClip[] bgRandom;

    [Header("Ambient")]
    public AudioClip ambientDarkSurprise;
    public AudioClip ambientDarkStorm;

    [Header("Bullets")]
    public AudioClip bulletShoot;
    public AudioClip bulletExplosion;

    [Header("Teleport")]
    public AudioClip teleportIn;
    public AudioClip teleportDuring;
    public AudioClip teleportOut;


    [Header("Audio sources")]
    public AudioSource[] background = new AudioSource[2];
    public AudioSource[] sounds = new AudioSource[3];

    private int soundsIndex = 0;
    private int bgIndex = 0;


    void Start()
    {
        // Audio sources
        AudioSource[] audios = GetComponents<AudioSource>();
        background[0] = audios[0];
        background[1] = audios[1];
        sounds[0] = audios[2];
        sounds[1] = audios[3];
        sounds[2] = audios[4];


        // @
        // Bg sounds to loop
        {
            int bgMark = 0;
            this.tt("@bgLoop").Pause()
            .If(() => bgLoop.Length > 0).Add((ttHandler t) =>
            {
                // Wait for the sound to almost over
                background[0].PlayOneShot(bgLoop[bgMark]);
                t.Wait(bgLoop[bgMark].length * 0.8f);

                // Next
                bgMark = ++bgMark % bgLoop.Length;
            })
            .Repeat();


            // + Reactive
            enableBgLoop.Suscribe(x =>
            {
                if (x) this.tt("@bgLoop").Play();
                else this.tt("@bgLoop").Stop();
            });
        }


        // @
        // Random bg sounds
        {
            this.tt("@bgRandom").Pause()
            .Add(() => Random.Range(180f, 240f))
            .If(() => bgRandom.Length > 0).Add((ttHandler t) =>
            {
                // Play a random bg sound
                int randomBg = Random.Range(0, bgRandom.Length);
                background[0].PlayOneShot(bgRandom[randomBg]);

                // Waits the sound duration plus a random between 3m and 4m
                t.Wait(bgRandom[randomBg].length);
            })
           .Repeat();


            // + Reactive
            enableBgRandom.Suscribe(x =>
            {
                if (x) this.tt("@bgRandom").Play();
                else this.tt("@bgRandom").Stop();
            });
        }
    }


    public AudioSource PlaySound(AudioClip clip, float volume = 1, float pitch = 1)
    {
        if (clip == null) return null;

        AudioSource current = sounds[soundsIndex];
        current.pitch = pitch;

        if (this.tt("@psLimit").Count < 2)
        {
            this.tt("@psLimit")
            .Add((ttHandler t) => current.PlayOneShot(clip, volume))
            .Add(0.10f).Consume();
        }

        // Next
        soundsIndex = ++soundsIndex % sounds.Length;

        return current;
    }


    public AudioSource PlayBgSound(AudioClip clip, float volume = 1, float pitch = 1)
    {
        if (clip == null) return null;

        AudioSource current = background[1]; // The second will be used in this kind of play
        current.pitch = pitch;
        current.PlayOneShot(clip, volume);

        return current;
    }
}
