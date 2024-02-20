using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject MenuRegistration;
    [SerializeField] GameObject MenuSetting;
    [SerializeField] GameObject MenuChooseLever;
    [SerializeField] GameObject Main;
    // Audio
    protected AudioController audioController;
    private void Awake()
    {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
    }
   
    public void OnMenuRegistration()
    {
        audioController.PlaySFX(audioController.audioGoto);
        MoveMenu.Instance.OffMenuMain();
        MoveMenu.Instance.OnMenuRegister();
    }
    public void OnMenuSetting()
    {
        audioController.PlaySFX(audioController.audioGoto);
        MoveMenu.Instance.OffMenuMain();
        MoveMenu.Instance.OnMenuSetting();
    }
    public void Play()
    {
        audioController.PlaySFX(audioController.audioGoto);
        MoveMenu.Instance.OffMenuMain();
        MoveMenu.Instance.OnMenuChooseLvMap();
    }

    public void OffMenuRegistration()
    {
        audioController.PlaySFX(audioController.audioGoto);
        MoveMenu.Instance.OffMenuRegister();
        MoveMenu.Instance.OnMenuMain();
    }
    public string urlToOpen = "https://www.facebook.com/phuc.hoangvan.3139";
    public void ButtonFB()
    {
        audioController.PlaySFX(audioController.audioClick);
        Application.OpenURL(urlToOpen);
    }
}
