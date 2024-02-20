using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailedPanelController : MonoBehaviour
{
    [SerializeField] private GameObject FailedPanel;
    MoveDoor moveDoor;
    void Start()
    {
        moveDoor = GameObject.FindGameObjectWithTag("Door").GetComponent<MoveDoor>();
    }
    public void ButtonReStart()
    {
        Time.timeScale = 1;
        GAMEMANAGER.Instance.SaveDataModel();
        moveDoor.CloseTheDoor(GameManager.levelMap + 1);
    }

    public void ButtonExitToMenu()
    {
        Time.timeScale = 1;
        GAMEMANAGER.Instance.SaveDataModel();
        moveDoor.CloseTheDoor(0);
    }
}
