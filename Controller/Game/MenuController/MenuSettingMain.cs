using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuSettingMain : MonoBehaviour
{
    [SerializeField] GameObject MenuSetting;
    [SerializeField] GameObject MainMenu;

    [SerializeField] GameObject ButtonOnMusic;
    [SerializeField] GameObject ButtonOffMusic;

    [SerializeField] GameObject ButtonOnSound;
    [SerializeField] GameObject ButtonOffSound;

    [SerializeField] GameObject ButtonOnVibration;
    [SerializeField] GameObject ButtonOffVibration;

    [SerializeField] GameObject ButtonOnNotification;
    [SerializeField] GameObject ButtonOffNotification;

    [SerializeField] GameObject ButtonPlusGraphics;
    [SerializeField] GameObject ButtonMinusGraphics;

    public Image bar;

    // Audio
    protected AudioController audioController;
    private void Awake()
    {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
    }
    private void Start()
    {
        bar = bar.GetComponent<Image>();
        if (!GameManager.music)
        {
            ButtonOnMusic.SetActive(false);
            ButtonOffMusic.SetActive(true);
        }
        if (!GameManager.SFX)
        {
            ButtonOnSound.SetActive(false);
            ButtonOffSound.SetActive(true);
        }
    }
    public void Exit()
    {
        audioController.PlaySFX(audioController.audioGoto);
        MoveMenu.Instance.OffMenuSettingr();
        MoveMenu.Instance.OnMenuMain();
    }
    bool music = true;
    public void OnOffMusic()
    {
        if (music)
        {
            GameManager.music = false;
            ButtonOnMusic.SetActive(false);
            ButtonOffMusic.SetActive(true);
            music = false;
        }
        else
        {
            audioController.PlaySFX(audioController.audioClick);
            GameManager.music = true;
            ButtonOnMusic.SetActive(true);
            ButtonOffMusic.SetActive(false);
            music = true;
        }
    }

    bool sound = true;
    public void OnOffSound()
    {
        if (sound)
        {
            GameManager.SFX = false;
            ButtonOnSound.SetActive(false);
            ButtonOffSound.SetActive(true);
            sound = false;
        }
        else
        {
            audioController.PlaySFX(audioController.audioClick);
            GameManager.SFX = true;
            ButtonOnSound.SetActive(true);
            ButtonOffSound.SetActive(false);
            sound = true;
        }
    }

    bool vibration = true;
    public void OnOffVibration()
    {
        if (vibration)
        {
            audioController.PlaySFX(audioController.audioClick);
            ButtonOnVibration.SetActive(false);
            ButtonOffVibration.SetActive(true);
            vibration = false;
        }
        else
        {
            audioController.PlaySFX(audioController.audioClick);
            ButtonOnVibration.SetActive(true);
            ButtonOffVibration.SetActive(false);
            vibration = true;
        }
    }

    bool notification = true;
    public void OnOffnotification()
    {
        if (notification)
        {
            audioController.PlaySFX(audioController.audioClick);
            ButtonOnNotification.SetActive(false);
            ButtonOffNotification.SetActive(true);
            notification = false;
        }
        else
        {
            audioController.PlaySFX(audioController.audioClick);
            ButtonOnNotification.SetActive(true);
            ButtonOffNotification.SetActive(false);
            notification = true;
        }
    }

    float graphics = 1f;
    public void PlusGraphics()
    {
        audioController.PlaySFX(audioController.audioClick);
        if (graphics < 1) graphics += 0.2f;
        bar.fillAmount = graphics;
    }

    public void MinusGraphics()
    {
        audioController.PlaySFX(audioController.audioClick);
        if (graphics > 0) graphics -= 0.2f;
        bar.fillAmount = graphics;
    }
}
