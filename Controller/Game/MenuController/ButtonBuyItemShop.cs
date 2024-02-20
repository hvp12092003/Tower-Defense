using UnityEngine;
using TMPro;

public class ButtonBuyItemShop : MonoBehaviour
{
    [SerializeField] public Sprite[] num;
    [SerializeField] public SpriteRenderer rend;
    [SerializeField] TextMeshProUGUI InforItem;
    public string infor;
    public int item;

    // Audio
    protected AudioController audioController;
    private void Awake()
    {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        switch (item)
        {
            case 1:
                RenNum(GameManager.amoutItem1);
                break;
            case 2:
                RenNum(GameManager.amoutItem2);
                break;
            case 3:
                RenNum(GameManager.amoutItem3);
                break;
            case 4:
                RenNum(GameManager.amoutItem4);
                break;
            case 5:
                RenNum(GameManager.amoutItem5);
                break;
            case 6:
                RenNum(GameManager.amoutItem6);
                break;
            case 7:
                RenNum(GameManager.amoutItem7);
                break;
            case 8:
                RenNum(GameManager.amoutItem8);
                break;
        }
    }
    public void DisplayInforItem()
    {
        audioController.PlaySFX(audioController.audioClick);
        InforItem.text = infor;
    }
    public void BuyItem()
    {
        audioController.PlaySFX(audioController.audioClick);
        switch (item)
        {
            case 1:
                if (GameManager.JEMain >= 10 && GameManager.amoutItem1 < 9)
                {
                    GameManager.JEMainUpdate -= 10;
                    Debug.Log("Je" + GameManager.JEMainUpdate);
                    GameManager.amoutItem1++;
                    RenNum(GameManager.amoutItem1);
                }
                break;
            case 2:
                if (GameManager.JEMain >= 10 && GameManager.amoutItem2 < 9)
                {
                    GameManager.JEMainUpdate -= 10;
                    Debug.Log("Je" + GameManager.JEMainUpdate);
                    GameManager.amoutItem2++;
                    RenNum(GameManager.amoutItem2);
                }
                break;
            case 3:
                if (GameManager.JEMain >= 10 && GameManager.amoutItem3 < 9)
                {
                    GameManager.JEMainUpdate -= 10;
                    Debug.Log("Je" + GameManager.JEMainUpdate);
                    GameManager.amoutItem3++;
                    RenNum(GameManager.amoutItem3);
                }
                break;
            case 4:
                if (GameManager.JEMain >= 10 && GameManager.amoutItem4 < 9)
                {
                    GameManager.JEMainUpdate -= 10;
                    Debug.Log("Je" + GameManager.JEMainUpdate);
                    GameManager.amoutItem4++;
                    RenNum(GameManager.amoutItem4);
                }
                break;
            case 5:
                if (GameManager.JEMain >= 10 && GameManager.amoutItem5 < 9)
                {
                    GameManager.JEMainUpdate -= 10;
                    Debug.Log("Je" + GameManager.JEMainUpdate);
                    GameManager.amoutItem5++;
                    RenNum(GameManager.amoutItem5);
                }
                break;
            case 6:
                if (GameManager.JEMain >= 10 && GameManager.amoutItem6 < 9)
                {
                    GameManager.JEMainUpdate -= 10;
                    Debug.Log("Je" + GameManager.JEMainUpdate);
                    GameManager.amoutItem6++;
                    RenNum(GameManager.amoutItem6);
                }
                break;
            case 7:
                if (GameManager.JEMain >= 10 && GameManager.amoutItem7 < 9)
                {
                    GameManager.JEMainUpdate -= 10;
                    Debug.Log("Je" + GameManager.JEMainUpdate);
                    GameManager.amoutItem7++;
                    RenNum(GameManager.amoutItem7);
                }
                break;
            case 8:
                if (GameManager.JEMain  >= 10 && GameManager.amoutItem8 < 9)
                {
                    GameManager.JEMainUpdate -= 10;
                    Debug.Log("Je" + GameManager.JEMainUpdate);
                    GameManager.amoutItem8++;
                    RenNum(GameManager.amoutItem8);
                }
                break;
        }

    }

    // rend image amount item
    public void RenNum(int amount)
    {
        switch (item)
        {
            case 1:
                rend.sprite = num[GameManager.amoutItem1];
                break;
            case 2:
                rend.sprite = num[GameManager.amoutItem2];
                break;
            case 3:
                rend.sprite = num[GameManager.amoutItem3];
                break;
            case 4:
                rend.sprite = num[GameManager.amoutItem4];
                break;
            case 5:
                rend.sprite = num[GameManager.amoutItem5];
                break;
            case 6:
                rend.sprite = num[GameManager.amoutItem6];
                break;
            case 7:
                rend.sprite = num[GameManager.amoutItem7];
                break;
            case 8:
                rend.sprite = num[GameManager.amoutItem8];
                break;
        }
    }
}
