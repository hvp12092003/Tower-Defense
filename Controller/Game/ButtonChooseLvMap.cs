using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonChooseLvMap : MonoBehaviour
{
    [SerializeField] private GameObject zeroStar;
    [SerializeField] private GameObject oneStar;
    [SerializeField] private GameObject twoStar;
    [SerializeField] private GameObject threeStar;

    [SerializeField] public int level;
    [SerializeField] private int amountStart;
    MoveDoor moveDoor;
    void Start()
    {
        moveDoor = GameObject.FindGameObjectWithTag("Door").GetComponent<MoveDoor>();
        amountStart = GameManager.mapResult.dataArray[level];
        switch (amountStart)
        {
            case 0:
                zeroStar.SetActive(true);
                break;
            case 1:
                oneStar.SetActive(true);
                break;
            case 2:
                twoStar.SetActive(true);
                break;
            case 3:
                threeStar.SetActive(true);
                break;
        }
    }
    public void LoadMap()
    {
        GameManager.levelMap = level;
        GAMEMANAGER.Instance.SaveDataModel();
        moveDoor.CloseTheDoor(level + 1);
    }


}
