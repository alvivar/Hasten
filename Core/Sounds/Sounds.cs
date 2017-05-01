
// Sound library, belongs to Game.

// @matnesis
// 2015/10/19 04:48 PM


using UnityEngine;
using matnesis.TeaTime;
using matnesis.Reactive;

public class SoundsStrings
{
    // Character
    public static string Checkpoint = "Checkpoint";
    public static string JumpStart = "Jump_Start";
    public static string Landing = "Landing";
    public static string Run = "Run";
    public static string SecondJump = "Second_Jump";
    public static string SlidingOnWall = "SlidingOnWall";
    public static string StopSlidingOnWall = "StopSlidingOnWall";
    public static string TeleportClose = "Teleport_Close";
    public static string TeleportLoop = "Teleport_Loop";
    public static string TeleportLoopStop = "Teleport_Loop_Stop";
    public static string TeleportOpen = "Teleport_Open";
    public static string Walk = "Walk";
    public static string WalkLand = "Walk_Land";
    public static string WeaponSwing = "WeaponSwing";

    // Enemies
    public static string BulletExplosion = "BulletExplosion";
    public static string EnemyDetectedPlay = "EnemyDetected_Play";
    public static string EnemyDetectedStop = "EnemyDetected_Stop";
    public static string Grumbling = "Grumbling";
    public static string RockSmash = "RockSmash";
    public static string ScreamingHive = "ScreamingHive";
    public static string ShootBullet = "ShootBullet";
    public static string WalkerWalkingPlay = "WalkerWalking_Play";
    public static string WalkerWalkingStop = "WalkerWalking_Stop";
}

[ReactiveInEditMode]
public class Sounds : MonoBehaviour
{
    public ReactiveBool enableBgLoop = new ReactiveBool(true);
    public ReactiveBool enableBgRandom = new ReactiveBool(true);

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
            enableBgLoop.Subscribe(x =>
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
            enableBgRandom.Subscribe(x =>
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

    public void VolumeFade(float fadeTo, float duration)
    {
        // #todo Optimize!
        this.tt().Loop(duration, (ttHandler t) => background[0].volume = Mathf.Lerp(1, fadeTo, t.t));
        this.tt().Loop(duration, (ttHandler t) => background[1].volume = Mathf.Lerp(1, fadeTo, t.t));
        this.tt().Loop(duration, (ttHandler t) => sounds[0].volume = Mathf.Lerp(1, fadeTo, t.t));
        this.tt().Loop(duration, (ttHandler t) => sounds[1].volume = Mathf.Lerp(1, fadeTo, t.t));
        this.tt().Loop(duration, (ttHandler t) => sounds[2].volume = Mathf.Lerp(1, fadeTo, t.t));
    }
}
