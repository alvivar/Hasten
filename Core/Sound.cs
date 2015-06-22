using UnityEngine;
using System.Collections;


public class Sound : MonoBehaviour
{
    public AudioClip sfxCheckpoint;
    public AudioClip[] sfxStep;
    public AudioClip sfxJump;
    public AudioClip sfxClaw;
    public AudioClip sfxHurt;
    public AudioClip sfxDarkAmbience;
    public AudioClip sfxBreath;
    public AudioClip sfxGod;

    private AudioSource audio2;

    private static Sound instance;
    public static Sound Get
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
        audio2 = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (!cEternalLoop) StartCoroutine(EternalLoop());
    }


    bool cEternalLoop = false;
    IEnumerator EternalLoop()
    {
        cEternalLoop = true;

        audio2.PlayOneShot(audio2.clip);
        yield return new WaitForSeconds(audio2.clip.length / 2);

        cEternalLoop = false;
    }


    public void PlayCheckpoint()
    {
        audio2.PlayOneShot(sfxCheckpoint, 0.50f);
    }


    public void PlayStep()
    {
        int who = Random.Range(0, sfxStep.Length);
        audio2.PlayOneShot(sfxStep[who], 0.10f);
    }


    public void PlayJump()
    {
        if (sfxJump)
            audio2.PlayOneShot(sfxJump, 0.70f);
    }


    public void PlayClaw()
    {
        audio2.PlayOneShot(sfxClaw, 0.3f);
    }


    public void PlayHurt()
    {
        audio2.PlayOneShot(sfxHurt);
    }


    public void PlayDarkAmbience()
    {
        audio2.PlayOneShot(sfxDarkAmbience);
    }


    public void PlayBreath()
    {
        audio2.PlayOneShot(sfxBreath);
    }


    public void PlayGod()
    {
        audio2.PlayOneShot(sfxGod);
    }
}
