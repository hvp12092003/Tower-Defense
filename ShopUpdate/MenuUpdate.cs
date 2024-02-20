using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuUpdate : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI numstar;

    // Audio
    protected AudioController audioController;
    private void Awake()
    {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
    }
    public void ButtonDone()
    {
        audioController.PlaySFX(audioController.audioClick);
        GAMEMANAGER.Instance.SaveDataModel();
    }
    public void ButtonReset()
    {
        audioController.PlaySFX(audioController.audioClick);
        GameManager.lvCurrentItem1 = 1;
        GameManager.lvCurrentItem2 = 1;
        GameManager.lvCurrentItem3 = 1;
        GameManager.lvCurrentItem4 = 1;
        GameManager.lvCurrentItem5 = 1;
        GameManager.lvCurrentItem6 = 1;
        GameManager.lvCurrentItem7 = 1;
        GameManager.lvCurrentItem8 = 1;

        GameManager.lvCurrentArcher1Tower = 1;
        GameManager.lvCurrentArcher2Tower = 1;
        GameManager.lvCurrentArcher3Tower = 1;
        GameManager.lvCurrentArcher4Tower = 1;

        GameManager.lvCurrentMagic1Tower = 1;
        GameManager.lvCurrentMagic2Tower = 1;
        GameManager.lvCurrentMagic3Tower = 1;
        GameManager.lvCurrentMagic4Tower = 1;

        GameManager.lvCurrentStone1Tower = 1;
        GameManager.lvCurrentStone2Tower = 1;
        GameManager.lvCurrentStone3Tower = 1;
        GameManager.lvCurrentStone4Tower = 1;

        GameManager.lvCurrentSupportDamgeTower = 1;
        GameManager.lvCurrentSupportMoveTower = 1;
        GameManager.lvCurrentSupportRangeTower = 1;
        GameManager.lvCurrentSupportSpeedTower = 1;

        GameManager.amountStar = 0;

        GAMEMANAGER.Instance.LoadMapResult();
        GAMEMANAGER.Instance.SaveDataModel();
    }
    public void ButtonExit()
    {
        audioController.PlaySFX(audioController.audioGoto);
        MoveMenu.Instance.OffMenuUpdate();
        MoveMenu.Instance.OnMenuChooseLvMap();
    }
    // Update is called once per frame
    void Update()
    {
        numstar.text = GameManager.amountStar.ToString();
    }
}
