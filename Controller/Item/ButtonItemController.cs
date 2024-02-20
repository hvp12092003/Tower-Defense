using UnityEngine;

public class ButtonItemController : MonoBehaviour
{
    // button exit
    [SerializeField] GameObject Exit;
    [SerializeField] GameObject RangeUseItem;

    // sprites so 0-9
    public Sprite[] sprite;
    // lay componnet nun
    public SpriteRenderer rendNum;

    public string kindOfItem;

    public Transform DemoItem;
    Transform DemoItemCurrent;
    bool createdDemoItem = false;

    //Item56
    public Transform PositionItem56;

    // item
    // public Transform[] Item;
    // bien de set co dang choose item ko
    bool onChoose = false;
    //lay vi tri chuot
    public Vector2 mousePos;

    // lay vi tri item
    // public int numItem;
    bool checkData = true;
    public bool use = false;

    // Audio
    protected AudioController audioController;
    private void Awake()
    {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
    }
    public void OnChooseItem()
    {
        switch (kindOfItem)
        {
            case "Item1":
                if (GameManager.offChooseOneItem && GameManager.amoutItem1 > 0)
                {
                    Exit.SetActive(true);
                    RangeUseItem.SetActive(true);
                    onChoose = true;
                    createdDemoItem = true;
                    GameManager.offChooseOneItem = false;
                }
                break;
            case "Item2":
                if (GameManager.offChooseOneItem && GameManager.amoutItem2 > 0)
                {
                    Exit.SetActive(true);
                    RangeUseItem.SetActive(true);
                    onChoose = true;
                    createdDemoItem = true;
                    GameManager.offChooseOneItem = false;
                }
                break;
            case "Item3":
                if (GameManager.offChooseOneItem && GameManager.amoutItem3 > 0)
                {
                    Exit.SetActive(true);
                    RangeUseItem.SetActive(true);
                    onChoose = true;
                    createdDemoItem = true;
                    GameManager.offChooseOneItem = false;
                }
                break;
            case "Item4":
                if (GameManager.offChooseOneItem && GameManager.amoutItem4 > 0)
                {
                    Exit.SetActive(true);
                    RangeUseItem.SetActive(true);
                    onChoose = true;
                    createdDemoItem = true;
                    GameManager.offChooseOneItem = false;
                }
                break;
            case "Item7":
                if (GameManager.offChooseOneItem && GameManager.amoutItem7 > 0)
                {
                    Exit.SetActive(true);
                    RangeUseItem.SetActive(true);
                    onChoose = true;
                    createdDemoItem = true;
                    GameManager.offChooseOneItem = false;
                }
                break;
            case "Item8":
                if (GameManager.offChooseOneItem && GameManager.amoutItem8 > 0)
                {
                    Exit.SetActive(true);
                    RangeUseItem.SetActive(true);
                    onChoose = true;
                    createdDemoItem = true;
                    GameManager.offChooseOneItem = false;
                }
                break;
        }

    }
    public void OffChooseItem()
    {
      //  audioController.PlaySFX(audioController.audioClick);
        Destroy(DemoItemCurrent.gameObject);
        Exit.SetActive(false);
        RangeUseItem.SetActive(false);
        onChoose = false;
        GameManager.offChooseOneItem = true;
    }

    public void DisplayAmountItem()
    {
        switch (kindOfItem)
        {
            case "Item1":
                rendNum.sprite = sprite[GameManager.amoutItem1];
                break;
            case "Item2":
                rendNum.sprite = sprite[GameManager.amoutItem2];
                break;
            case "Item3":
                rendNum.sprite = sprite[GameManager.amoutItem3];
                break;
            case "Item4":
                rendNum.sprite = sprite[GameManager.amoutItem4];
                break;
            case "Item5":
                rendNum.sprite = sprite[GameManager.amoutItem5];
                break;
            case "Item6":
                rendNum.sprite = sprite[GameManager.amoutItem6];
                break;
            case "Item7":
                rendNum.sprite = sprite[GameManager.amoutItem7];
                break;
            case "Item8":
                rendNum.sprite = sprite[GameManager.amoutItem8];
                break;
        }
    }

    public void CreatItem()
    {
        use = true;
        switch (kindOfItem)
        {
            case "Item1":
                audioController.PlaySFX(audioController.audioItem1);
                Instantiate(GAMEMANAGER.Instance.Item1[GameManager.lvCurrentItem1-1], new Vector3(mousePos.x, mousePos.y), Quaternion.identity);
                OffChooseItem();
                GameManager.amoutItem1--;
                DisplayAmountItem();
                break;
            case "Item2":
                audioController.PlaySFX(audioController.audioItem2);
                Instantiate(GAMEMANAGER.Instance.Item2[GameManager.lvCurrentItem2-1], new Vector3(mousePos.x, mousePos.y), Quaternion.identity);
                OffChooseItem();
                GameManager.amoutItem2--;
                DisplayAmountItem();
                break;
            case "Item3":
                audioController.PlaySFX(audioController.audioItem3);
                Instantiate(GAMEMANAGER.Instance.Item3[GameManager.lvCurrentItem3 - 1], new Vector3(mousePos.x, mousePos.y), Quaternion.identity);
                OffChooseItem();
                GameManager.amoutItem3--;
                DisplayAmountItem();
                break;
            case "Item4":
                audioController.PlaySFX(audioController.audioItem4);
                Instantiate(GAMEMANAGER.Instance.Item4[GameManager.lvCurrentItem4 - 1], new Vector3(mousePos.x, mousePos.y), Quaternion.identity);
                OffChooseItem();
                GameManager.amoutItem4--;
                DisplayAmountItem();
                break;
            case "Item7":
                audioController.PlaySFX(audioController.audioItem7);
                Instantiate(GAMEMANAGER.Instance.Item7[GameManager.lvCurrentItem7 - 1], new Vector3(mousePos.x, mousePos.y), Quaternion.identity);
                OffChooseItem();
                GameManager.amoutItem7--;
                DisplayAmountItem();
                break;
            case "Item8":
                audioController.PlaySFX(audioController.audioItem8);
                Instantiate(GAMEMANAGER.Instance.Item8[GameManager.lvCurrentItem8 - 1], new Vector3(mousePos.x, mousePos.y), Quaternion.identity);
                OffChooseItem();
                GameManager.amoutItem8--;
                DisplayAmountItem();
                break;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        if (Exit != null)
        {
            Exit.SetActive(false);
        }
    }


    public void OnItem5()
    {
        if (GameManager.offChooseOneItem && !GameManager.OnItemDef && GameManager.amoutItem5 > 0)
        {
            audioController.PlaySFX(audioController.audioItem56);
            DemoItem = Instantiate(GAMEMANAGER.Instance.Item5[GameManager.lvCurrentItem5 - 1], PositionItem56);
            GameManager.amoutItem5--;
            DisplayAmountItem();
        }
    }
    public void OnItem6()
    {
        if (GameManager.offChooseOneItem && !GameManager.OnItemAtk && GameManager.amoutItem6 > 0)
        {
            audioController.PlaySFX(audioController.audioItem56);
            DemoItem = Instantiate(GAMEMANAGER.Instance.Item6[GameManager.lvCurrentItem6 - 1], PositionItem56);
            GameManager.amoutItem6--;
            DisplayAmountItem();
        }

    }

    // Update is called once per frame
    void Update()
    {
        //lay so luong
        if (checkData)
        {
            DisplayAmountItem();
            checkData = false;
        }

        // neu dang chon thi lay vi chi chuot
        if (onChoose)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (createdDemoItem)
            {
                createdDemoItem = false;
                DemoItemCurrent = Instantiate(DemoItem, new Vector3(mousePos.x, mousePos.y), Quaternion.identity);
            }
            DemoItemCurrent.position = new Vector3(mousePos.x, mousePos.y);
        }
    }
}
