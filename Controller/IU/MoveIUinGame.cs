using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using LTAUnityBase.Base.DesignPattern;

public class MoveIUinGame : MonoBehaviour
{
    public GameObject Index;
    public GameObject PausePanel;
    public GameObject ButtonItem;
    public GameObject WinPanel;
    public GameObject ButtonGame;
    public GameObject BoxInfor;
    public GameObject BoxInforEnemy;
    public GameObject ButtonOffBoxInforEnemy;
    float count;
    bool pause = false;
    // Audio
    protected AudioController audioController;
    public void Start()
    {

        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();

        Index.transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);
        ButtonGame.transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);
        ButtonItem.transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);
    }
    public void OnBoxInforEnemy()
    {
        ButtonOffBoxInforEnemy.SetActive(true);
        BoxInforEnemy.transform.DOLocalMove(new Vector3(0, 400, 0), 0.5f);
    }
    public void OffBoxInforEnemy()
    {
        BoxInforEnemy.transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);
        ButtonOffBoxInforEnemy.SetActive(false);
    }
    //box infor
    public void OnBoxInfor()
    {
        BoxInfor.transform.DOLocalMove(new Vector3(0, 400, 0), 0.5f);
    }
    public void OffBoxInfor()
    {
        BoxInfor.transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);
    }
    //pause
    public void OnPausePanel()
    {
        audioController.PlaySFX(audioController.audioGoto);
        PausePanel.transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);
        Index.transform.DOLocalMove(new Vector3(0, 400, 0), 0.5f);
        ButtonGame.transform.DOLocalMove(new Vector3(0, 400, 0), 0.5f);
        ButtonItem.transform.DOLocalMove(new Vector3(0, -400, 0), 0.5f);
        pause = true;

    }
    public void OffPausePanel()
    {
        audioController.PlaySFX(audioController.audioGoto);
        Time.timeScale = 1;
        PausePanel.transform.DOLocalMove(new Vector3(0, 1400, 0), 0.5f);
        Index.transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);
        ButtonGame.transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);
        ButtonItem.transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);
    }
    //panel Win game
    public void OnPanelWin()
    {
        WinPanel.transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);
        Index.transform.DOLocalMove(new Vector3(0, 400, 0), 0.5f);
        ButtonGame.transform.DOLocalMove(new Vector3(0, 400, 0), 0.5f);
        ButtonItem.transform.DOLocalMove(new Vector3(0, -400, 0), 0.5f);
    }
    public void Update()
    {
        if (pause)
        {
            count -= Time.deltaTime;
            if (count <= 0)
            {
                pause = false;
                Time.timeScale = 0;
            }
        }
        else
        {
            count = 0.5f;
        }
    }
}

public class MoveIUInGame : SingletonMonoBehaviour<MoveIUinGame> { }
