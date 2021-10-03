using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sound
{
    none,
    menu,
    game,
    tiro,
    pertodeinimigo,
    pulo
}

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSourceMusic = default;
    [SerializeField] private AudioSource audioSourceEffects = default;
    [SerializeField] private AudioClip[] music = default;
    [SerializeField] private AudioClip[] effects = default;

    public static SoundController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        
    }

    public void SoundEffectsController(Sound sound)
    {
        //if (sound == Sound.menu) SomMusic(music[0]); //Colocar o som aui qunado fizer o menu

        if (sound == Sound.game) SomMusic(music[0]);
        else if (sound == Sound.pertodeinimigo) SomMusic(music[1]);
        else if (sound == Sound.tiro) SomEffect(effects[0]);
        else if (sound == Sound.pulo) SomEffect(effects[1]);
    }

    public bool MusicPlaying()
    {
        return audioSourceMusic.isPlaying;
    }

    public void StopSound()
    {
        audioSourceMusic.Stop();
    }

    void SomMusic(AudioClip audioClip)
    {
        audioSourceMusic.clip = audioClip;
        audioSourceMusic.Play();
    }

    void SomEffect(AudioClip audioClip)
    {
        audioSourceEffects.clip = audioClip;
        audioSourceEffects.Play();
    }
}
