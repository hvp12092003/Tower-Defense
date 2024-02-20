using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuShop : MonoBehaviour
{
    [SerializeField] GameObject MenuChooseLvMap;
    [SerializeField] GameObject MenuShopThis;

    // Audio
    protected AudioController audioController;
    private void Awake()
    {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
    }
    public void ButtonExit()
    {
        audioController.PlaySFX(audioController.audioGoto);
        MoveMenu.Instance.OffShop();
        MoveMenu.Instance.OnMenuChooseLvMap();
    }
    public void ButtonBuy1()
    {
        audioController.PlaySFX(audioController.audioButJe);
        GameManager.JEMainUpdate += 40;
    }
    public void ButtonBuy2()
    {
        audioController.PlaySFX(audioController.audioButJe);
        GameManager.JEMainUpdate += 100;
    }
    public void ButtonBuy3()
    {
        audioController.PlaySFX(audioController.audioButJe);
        GameManager.JEMainUpdate += 200;
    }
}
