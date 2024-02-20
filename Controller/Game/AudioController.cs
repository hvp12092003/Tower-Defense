using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [Header("------------ Audio Source ------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------------ Audio Clip ------------")]
    public AudioClip audioBbackground;
    public AudioClip audioClick;
    public AudioClip audioWinGame;
    public AudioClip audioButJe;
    public AudioClip audioLoseGame;

    public AudioClip audioTakeDame;
    public AudioClip audioBossDie;
    public AudioClip audioBoss;

    public AudioClip audioArcherShot;
    public AudioClip audioStoneShot;
    public AudioClip audioMagicShot;
    public AudioClip audioMoveShot;

    public AudioClip audioItem1;
    public AudioClip audioItem2;
    public AudioClip audioItem3;
    public AudioClip audioItem4;
    public AudioClip audioItem56;
    public AudioClip audioItem7;
    public AudioClip audioItem8;
    public AudioClip audioDoor;
    public AudioClip audioBack;
    public AudioClip audioGoto;


    bool OnMusic = GameManager.music;
    private void Start()
    {
        musicSource.clip = audioBbackground;
    }
    private void Update()
    {
        if (GameManager.music && OnMusic)
        {
            OnMusic = false;
            musicSource.Play();
        }
        else if (!GameManager.music && !OnMusic)
        {
            OnMusic = true;
            musicSource.Stop();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (GameManager.SFX) SFXSource.PlayOneShot(clip);
    }

}
