using UnityEngine;
using System.Collections;


public class Sound : MonoBehaviour
{
    public AudioClip[] bg;
    public AudioClip sfxCheckpoint;
    public AudioClip[] sfxStep;
    public AudioClip sfxJump;
    public AudioClip sfxClaw;
    public AudioClip sfxHurt;
    public AudioClip sfxDarkAmbience;
    public AudioClip sfxBreath;
    public AudioClip sfxGod;

    public AudioSource audioBg;
    public AudioSource audioSounds;

    private static Sound instance;
    public static Sound g
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<Sound>();
            return instance;
        }
    }


    void Start()
    {
        AudioSource[] audios = GetComponents<AudioSource>();
        audioBg = audios[0];
        audioSounds = audios[1];


        // Play the soundtrack sounds one after the other
        int bgMark = 0;
        this.tt("PlayTheBGSound").ttAdd((ttHandler t) =>
        {
            audioBg.PlayOneShot(bg[bgMark]);
            bgMark = (bgMark + 1) % bg.Length;

            t.WaitFor(bg[bgMark].length);
        })
        .ttRepeat();
    }


    public void PlayCheckpoint()
    {
        audioSounds.PlayOneShot(sfxCheckpoint, 0.50f);
    }


    public void PlayStep()
    {
        int who = Random.Range(0, sfxStep.Length);
        audioSounds.PlayOneShot(sfxStep[who], 0.10f);
    }


    public void PlayJump()
    {
        if (sfxJump)
            audioSounds.PlayOneShot(sfxJump, 0.70f);
    }


    public void PlayClaw()
    {
        audioSounds.PlayOneShot(sfxClaw, 0.3f);
    }


    public void PlayHurt()
    {
        audioSounds.PlayOneShot(sfxHurt);
    }


    public void PlayDarkAmbience()
    {
        audioSounds.PlayOneShot(sfxDarkAmbience);
    }


    public void PlayBreath()
    {
        audioSounds.PlayOneShot(sfxBreath);
    }


    public void PlayGod()
    {
        audioSounds.PlayOneShot(sfxGod);
    }
}
