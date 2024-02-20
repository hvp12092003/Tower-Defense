using TMPro;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEditor;

public class DotController : MonoBehaviour
{
    [SerializeField] GameObject BoxInfor;
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject menuChooseTower;
    [SerializeField] GameObject menuUpOrSellTower;
    [SerializeField] GameObject menuChooseSupportTower;
    [SerializeField] GameObject BottonUpTower;
    [SerializeField] TextMeshProUGUI TextPriceToUp;
    [SerializeField] TextMeshProUGUI TextPriceToSell;

    public Transform[] ArcherTower;
    public Transform[] SupportTower;
    public Transform[] MagicTower;
    public Transform[] StoneTower;

    public Transform[] DemoArcherTower;
    public Transform[] DemoMagicTower;
    public Transform[] DemoStoneTower;
    public Transform[] DemoSupportTower;

    public GameObject rangeTartget;
    Transform currenTower;
    Transform currenDemoTower;

    public float scale = 1.3f;
    public float timeForMenuDot = 0.3f;
    float originScaleForRange = 222f;

    public int lvTower = 0;

    //archer:1  magic:2   Stone:3   support:4
    public int kindTower = 0;

    //damage:1  range:2  speed:3  move:4
    public int kindOfSupportTower = 0;

    //click
    public bool onArcher = false;
    public bool onMagic = false;
    public bool onStone = false;
    public bool onSPDamage = false;
    public bool onSPRange = false;
    public bool onSPSpeed = false;
    public bool onSPMove = false;

    public bool OnDemoTower = false;

    // box infor
    protected BoxInforTowerController box;
    // Audio
    protected AudioController audioController;
    private void Start()
    {
        Menu.SetActive(true);
        rangeTartget.SetActive(true);

        box = GameObject.FindGameObjectWithTag("BoxInfor").GetComponent<BoxInforTowerController>();
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
        menuChooseTower.transform.DOScale(Vector3.zero, 0);
        menuChooseSupportTower.transform.DOScale(Vector3.zero, 0);
        rangeTartget.transform.DOScale(Vector3.zero, 0);
        menuUpOrSellTower.transform.DOScale(Vector3.zero, 0);
    }
    public void OnBoxInfor()
    {
        switch (kindTower)
        {
            case 1:
                box.DisplayInforTower(ArcherTower[lvTower].name, (GameManager.InforArcherTower[lvTower].targetingRange * 10f).ToString(), GameManager.InforArcherTower[lvTower].damage.ToString(), GameManager.InforArcherTower[lvTower].bulletPerSecond.ToString(), "Physic");
                rangeTartget.transform.DOScale(new Vector3(originScaleForRange * GameManager.InforArcherTower[lvTower].targetingRange, originScaleForRange * GameManager.InforArcherTower[lvTower].targetingRange), 0);
                break;
            case 2:
                box.DisplayInforTower(MagicTower[lvTower].name, (GameManager.InforMagicTower[lvTower].targetingRange * 10f).ToString(), GameManager.InforMagicTower[lvTower].damage.ToString(), GameManager.InforMagicTower[lvTower].bulletPerSecond.ToString(), "Magic");
                rangeTartget.transform.DOScale(new Vector3(originScaleForRange * GameManager.InforMagicTower[lvTower].targetingRange, originScaleForRange * GameManager.InforMagicTower[lvTower].targetingRange), 0);
                break;
            case 3:
                box.DisplayInforTower(StoneTower[lvTower].name, (GameManager.InforStoneTower[lvTower].targetingRange * 10f).ToString(), GameManager.InforStoneTower[lvTower].damage.ToString(), GameManager.InforStoneTower[lvTower].bulletPerSecond.ToString(), "Physic");
                rangeTartget.transform.DOScale(new Vector3(originScaleForRange * GameManager.InforArcherTower[lvTower].targetingRange, originScaleForRange * GameManager.InforArcherTower[lvTower].targetingRange), 0);
                break;
            case 4:
                switch (kindOfSupportTower)
                {
                    case 1:
                        box.DisplayInforSupportTower(kindOfSupportTower, SupportTower[lvTower].name, (GameManager.InforSupportTower[lvTower].targetingRange * 10f).ToString(), GameManager.InforSupportTower[lvTower].damage.ToString(), GameManager.InforSupportTower[lvTower].bulletPerSecond.ToString(), "Magic");
                        rangeTartget.transform.DOScale(new Vector3(originScaleForRange * GameManager.InforSupportTower[lvTower].targetingRange, originScaleForRange * GameManager.InforSupportTower[lvTower].targetingRange), 0);
                        break;
                    case 2:
                        rangeTartget.transform.DOScale(new Vector3(originScaleForRange * GameManager.InforSupportTower[lvTower + 3].targetingRange, originScaleForRange * GameManager.InforSupportTower[lvTower + 3].targetingRange), 0);
                        box.DisplayInforSupportTower(kindOfSupportTower, SupportTower[lvTower + 3].name, (GameManager.InforSupportTower[lvTower].targetingRange * 10f).ToString(), GameManager.InforSupportTower[lvTower + 3].damage.ToString(), GameManager.InforSupportTower[lvTower + 3].bulletPerSecond.ToString(), "Magic");
                        break;
                    case 3:
                        rangeTartget.transform.DOScale(new Vector3(originScaleForRange * GameManager.InforSupportTower[lvTower + 6].targetingRange, originScaleForRange * GameManager.InforSupportTower[lvTower + 6].targetingRange), 0);
                        box.DisplayInforSupportTower(kindOfSupportTower, SupportTower[lvTower + 6].name, (GameManager.InforSupportTower[lvTower + 6].targetingRange * 10f).ToString(), GameManager.InforSupportTower[lvTower + 6].damage.ToString(), GameManager.InforSupportTower[lvTower + 6].bulletPerSecond.ToString(), "Magic");
                        break;
                    case 4:
                        rangeTartget.transform.DOScale(new Vector3(originScaleForRange * GameManager.InforSupportTower[lvTower + 9].targetingRange, originScaleForRange * GameManager.InforSupportTower[lvTower + 9].targetingRange), 0);
                        box.DisplayInforSupportTower(kindOfSupportTower, SupportTower[lvTower + 9].name, (GameManager.InforSupportTower[lvTower + 9].targetingRange * 10f).ToString(), GameManager.InforSupportTower[lvTower + 9].damage.ToString(), GameManager.InforSupportTower[lvTower + 9].bulletPerSecond.ToString(), "Magic");
                        break;
                }
                break;
        }
    }
    public void OnBoxInforUD()
    {
        switch (kindTower)
        {
            case 1:
                rangeTartget.transform.DOScale(new Vector3(originScaleForRange * GameManager.InforArcherTower[lvTower - 1].targetingRange, originScaleForRange * GameManager.InforArcherTower[lvTower - 1].targetingRange), 0);
                box.DisplayInforTower(ArcherTower[lvTower - 1].name, (GameManager.InforArcherTower[lvTower - 1].targetingRange * 10f).ToString(), GameManager.InforArcherTower[lvTower - 1].damage.ToString(), GameManager.InforArcherTower[lvTower - 1].bulletPerSecond.ToString(), "Physic");
                break;
            case 2:
                rangeTartget.transform.DOScale(new Vector3(originScaleForRange * GameManager.InforMagicTower[lvTower - 1].targetingRange, originScaleForRange * GameManager.InforMagicTower[lvTower - 1].targetingRange), 0);
                box.DisplayInforTower(MagicTower[lvTower - 1].name, (GameManager.InforMagicTower[lvTower - 1].targetingRange * 10f).ToString(), GameManager.InforMagicTower[lvTower - 1].damage.ToString(), GameManager.InforMagicTower[lvTower - 1].bulletPerSecond.ToString(), "Magic");
                break;
            case 3:
                rangeTartget.transform.DOScale(new Vector3(originScaleForRange * GameManager.InforArcherTower[lvTower - 1].targetingRange, originScaleForRange * GameManager.InforArcherTower[lvTower - 1].targetingRange), 0);
                box.DisplayInforTower(StoneTower[lvTower - 1].name, (GameManager.InforStoneTower[lvTower - 1].targetingRange * 10f).ToString(), GameManager.InforStoneTower[lvTower - 1].damage.ToString(), GameManager.InforStoneTower[lvTower - 1].bulletPerSecond.ToString(), "Physic");
                break;
            case 4:
                switch (kindOfSupportTower)
                {
                    case 1:
                        rangeTartget.transform.DOScale(new Vector3(originScaleForRange * GameManager.InforSupportTower[lvTower - 1].targetingRange, originScaleForRange * GameManager.InforSupportTower[lvTower - 1].targetingRange), 0);
                        box.DisplayInforSupportTower(kindOfSupportTower, SupportTower[lvTower - 1].name, (GameManager.InforSupportTower[lvTower - 1].targetingRange * 10f).ToString(), GameManager.InforSupportTower[lvTower - 1].damage.ToString(), GameManager.InforSupportTower[lvTower - 1].bulletPerSecond.ToString(), "Magic");
                        break;
                    case 2:
                        rangeTartget.transform.DOScale(new Vector3(originScaleForRange * GameManager.InforSupportTower[lvTower - 1 + 3].targetingRange, originScaleForRange * GameManager.InforSupportTower[lvTower - 1 + 3].targetingRange), 0);
                        box.DisplayInforSupportTower(kindOfSupportTower, SupportTower[lvTower - 1 + 3].name, (GameManager.InforSupportTower[lvTower - 1].targetingRange * 10f).ToString(), GameManager.InforSupportTower[lvTower - 1 + 3].damage.ToString(), GameManager.InforSupportTower[lvTower - 1 + 3].bulletPerSecond.ToString(), "Magic");
                        break;
                    case 3:
                        rangeTartget.transform.DOScale(new Vector3(originScaleForRange * GameManager.InforSupportTower[lvTower - 1 + 6].targetingRange, originScaleForRange * GameManager.InforSupportTower[lvTower - 1 + 6].targetingRange), 0);
                        box.DisplayInforSupportTower(kindOfSupportTower, SupportTower[lvTower - 1 + 6].name, (GameManager.InforSupportTower[lvTower - 1 + 6].targetingRange * 10f).ToString(), GameManager.InforSupportTower[lvTower - 1 + 6].damage.ToString(), GameManager.InforSupportTower[lvTower - 1 + 6].bulletPerSecond.ToString(), "Magic");
                        break;
                    case 4:
                        rangeTartget.transform.DOScale(new Vector3(originScaleForRange * GameManager.InforSupportTower[lvTower - 1 + 9].targetingRange, originScaleForRange * GameManager.InforSupportTower[lvTower - 1 + 9].targetingRange), 0);
                        box.DisplayInforSupportTower(kindOfSupportTower, SupportTower[lvTower - 1 + 9].name, (GameManager.InforSupportTower[lvTower - 1 + 9].targetingRange * 10f).ToString(), GameManager.InforSupportTower[lvTower - 1 + 9].damage.ToString(), GameManager.InforSupportTower[lvTower - 1 + 9].bulletPerSecond.ToString(), "Magic");
                        break;
                }
                break;
        }
    }
    public void OffBoxInfor()
    {
        MoveIUInGame.Instance.OffBoxInfor();
    }
    // on menu Dot
    public void OnMenu()
    {
        if (!GameManager.onDot)
        {
            GameManager.onDot = true;
            if (currenTower == null)
            {
                audioController.PlaySFX(audioController.audioClick);
                menuChooseTower.transform.DOScale(new Vector3(scale, scale, scale), timeForMenuDot);
            }
            else
            {
                OnBoxInforUD();
                menuUpOrSellTower.transform.DOScale(new Vector3(scale, scale, scale), timeForMenuDot);
                // neu la tru sp
                if (kindTower == 4)
                {
                    // neu lv tru sp =3 thi ko hien thi button Update nx
                    if (lvTower == 3)
                    {
                        BottonUpTower.SetActive(false);
                    }
                }
                else
                {
                    if (lvTower == 12)
                    {
                        BottonUpTower.SetActive(false);
                    }
                }
                PriceToSell();
                PriceToUpdate();
            }
        }
    }

    public void ResetOn()
    {
        onArcher = false;
        onMagic = false;
        onStone = false;
        onSPDamage = false;
        onSPRange = false;
        onSPSpeed = false;
        onSPMove = false;

    }
    // off menu Dot
    public void OffMenuDot()
    {
        OffBoxInfor();
        ResetOn();
        GameManager.onDot = false;
        audioController.PlaySFX(audioController.audioClick);
        menuChooseTower.transform.DOScale(Vector3.zero, 0.3f);
        rangeTartget.transform.DOScale(Vector3.zero, 0.3f);
        if (currenDemoTower != null)
        {
            Destroy(currenDemoTower.gameObject);
        }
    }
    public void OffMenuSupport()
    {
        OffBoxInfor();
        ResetOn();
        GameManager.onDot = false;
        menuChooseSupportTower.transform.DOScale(Vector3.zero, 0.3f);
        rangeTartget.transform.DOScale(Vector3.zero, 0.3f);
        if (currenDemoTower != null)
        {
            Destroy(currenDemoTower.gameObject);
        }
    }
    public void OffMenuUpOrSell()
    {
        OffBoxInfor();
        GameManager.onDot = false;
        accepUp = false;
        menuUpOrSellTower.transform.DOScale(Vector3.zero, 0.3f);
        rangeTartget.transform.DOScale(Vector3.zero, 0.3f);
        if (currenDemoTower != null)
        {
            Destroy(currenDemoTower.gameObject);
        }
    }
    // Choose archer
    public void ChooseArcherTower()
    {
        audioController.PlaySFX(audioController.audioClick);
        kindTower = 1;
        if (onArcher)
        {
            CreatTower();
        }
        else
        {
            onArcher = true;
            CreateDemoTower();
        }

    }

    // Choose magic
    public void ChooseMagicTower()
    {
        audioController.PlaySFX(audioController.audioClick);
        kindTower = 2;
        if (onMagic)
        {
            CreatTower();
        }
        else
        {
            onMagic = true;
            CreateDemoTower();
        }
    }
    // Choose stone
    public void ChooseStoneTower()
    {
        audioController.PlaySFX(audioController.audioClick);
        kindTower = 3;
        if (onStone)
        {
            CreatTower();
        }
        else
        {
            onStone = true;
            CreateDemoTower();
        }
    }
    // Choose support
    public void ChooseSupportTower()
    {
        audioController.PlaySFX(audioController.audioClick);
        kindTower = 4;
        menuChooseSupportTower.transform.DOScale(new Vector3(scale, scale), timeForMenuDot);
        OffMenuDot();
        if (currenDemoTower != null)
        {
            Destroy(currenDemoTower.gameObject);
        }
    }

    // create Demo tower
    public void CreateDemoTower()
    {
        if (currenDemoTower != null)
        {
            Destroy(currenDemoTower.gameObject);
        }
        OnBoxInfor();
        //created dome tower
        switch (kindTower)
        {
            case 1:
                currenDemoTower = Instantiate(DemoArcherTower[lvTower], transform.position, Quaternion.identity);
                break;
            case 2:
                currenDemoTower = Instantiate(DemoMagicTower[lvTower], transform.position, Quaternion.identity);
                break;
            case 3:
                currenDemoTower = Instantiate(DemoStoneTower[lvTower], transform.position, Quaternion.identity);
                break;
            case 4:
                switch (kindOfSupportTower)
                {
                    case 1:
                        currenDemoTower = Instantiate(DemoSupportTower[lvTower], transform.position, Quaternion.identity);
                        break;
                    case 2:
                        currenDemoTower = Instantiate(DemoSupportTower[lvTower + 3], transform.position, Quaternion.identity);
                        break;
                    case 3:
                        currenDemoTower = Instantiate(DemoSupportTower[lvTower + 6], transform.position, Quaternion.identity);
                        break;
                    case 4:
                        currenDemoTower = Instantiate(DemoSupportTower[lvTower + 9], transform.position, Quaternion.identity);
                        break;
                }
                break;
        }

    }

    // choose SupportTower
    public void ChooseSupportDameTower()
    {
        kindOfSupportTower = 1;
        if (onSPDamage)
        {
            CreatTower();
        }
        else
        {
            onSPDamage = true;
            CreateDemoTower();
        }
    }
    public void ChooseSupportRangeTower()
    {
        kindOfSupportTower = 2;
        if (onSPRange)
        {
            CreatTower();
        }
        else
        {
            onSPRange = true;
            CreateDemoTower();
        }
    }
    public void ChooseSupportSpeedTower()
    {
        kindOfSupportTower = 3;
        if (onSPSpeed)
        {
            CreatTower();
        }
        else
        {
            onSPSpeed = true;
            CreateDemoTower();
        }
    }
    public void ChooseSupportMoveTower()
    {
        kindOfSupportTower = 4;
        if (onSPMove)
        {
            CreatTower();
        }
        else
        {
            onSPMove = true;
            CreateDemoTower();
        }
    }


    private void PriceToUpdate()
    {
        if (kindTower == 4 && lvTower < 3 || kindTower != 4 && lvTower < 12)
        {
            switch (kindTower)
            {
                case 1:
                    TextPriceToUp.text = GameManager.InforArcherTower[lvTower].price.ToString();
                    break;
                case 2:
                    TextPriceToUp.text = GameManager.InforMagicTower[lvTower].price.ToString();
                    break;
                case 3:
                    TextPriceToUp.text = GameManager.InforStoneTower[lvTower].price.ToString();
                    break;
                case 4:
                    TextPriceToUp.text = GameManager.InforSupportTower[lvTower].price.ToString();
                    break;
            }
        }
    }
    private void PriceToSell()
    {
        switch (kindTower)
        {
            case 1:
                TextPriceToSell.text = GameManager.InforArcherTower[lvTower - 1].priceSell.ToString();
                break;
            case 2:
                TextPriceToSell.text = GameManager.InforMagicTower[lvTower - 1].priceSell.ToString();
                break;
            case 3:
                TextPriceToSell.text = GameManager.InforStoneTower[lvTower - 1].priceSell.ToString();
                break;
            case 4:
                TextPriceToSell.text = GameManager.InforSupportTower[lvTower - 1].priceSell.ToString();
                break;
        }
    }
    public void CreatTower()
    {
        ResetOn();
        switch (kindTower)
        {
            case 1:
                if (GameManager.jeUpdate >= GameManager.InforArcherTower[lvTower].price)
                {
                    DestroyTower();
                    currenTower = Instantiate(ArcherTower[lvTower], transform.position, Quaternion.identity);
                    GameManager.jeUpdate -= GameManager.InforArcherTower[lvTower].price;
                    lvTower++;
                }
                break;
            case 2:
                if (GameManager.jeUpdate >= GameManager.InforMagicTower[lvTower].price)
                {
                    DestroyTower();
                    currenTower = Instantiate(MagicTower[lvTower], transform.position, Quaternion.identity);
                    GameManager.jeUpdate -= GameManager.InforMagicTower[lvTower].price;
                    lvTower++;
                }
                break;
            case 3:
                if (GameManager.jeUpdate >= GameManager.InforStoneTower[lvTower].price)
                {
                    DestroyTower();
                    currenTower = Instantiate(StoneTower[lvTower], transform.position, Quaternion.identity);
                    GameManager.jeUpdate -= GameManager.InforStoneTower[lvTower].price;
                    lvTower++;
                }
                break;
            case 4:
                switch (kindOfSupportTower)
                {
                    case 1:
                        if (GameManager.jeUpdate >= GameManager.InforSupportTower[lvTower].price)
                        {
                            DestroyTower();
                            currenTower = Instantiate(SupportTower[lvTower], transform.position, Quaternion.identity);
                            GameManager.jeUpdate -= GameManager.InforSupportTower[lvTower].price;
                            lvTower++;
                        }
                        break;
                    case 2:
                        if (GameManager.jeUpdate >= GameManager.InforArcherTower[lvTower].price)
                        {
                            DestroyTower();
                            currenTower = Instantiate(SupportTower[lvTower + 3], transform.position, Quaternion.identity);
                            GameManager.jeUpdate -= GameManager.InforSupportTower[lvTower].price;
                            lvTower++;
                        }
                        break;
                    case 3:
                        if (GameManager.jeUpdate >= GameManager.InforArcherTower[lvTower].price)
                        {
                            DestroyTower();
                            currenTower = Instantiate(SupportTower[lvTower + 6], transform.position, Quaternion.identity);
                            GameManager.jeUpdate -= GameManager.InforSupportTower[lvTower].price;
                            lvTower++;
                        }
                        break;
                    case 4:
                        if (GameManager.jeUpdate >= GameManager.InforArcherTower[lvTower].price)
                        {
                            DestroyTower();
                            currenTower = Instantiate(SupportTower[lvTower + 9], transform.position, Quaternion.identity);
                            GameManager.jeUpdate -= GameManager.InforSupportTower[lvTower].price;
                            lvTower++;
                        }
                        break;
                }
                break;
        }
        OffMenuSupport();
        OffMenuUpOrSell();
        OffMenuDot();
    }
    public void DestroyTower()
    {
        if (currenTower != null) { Destroy(currenTower.gameObject); }
    }
    bool accepUp = false;
    public void LevelUpTower()
    {
        if (accepUp)
        {
            CreatTower();
            OffMenuDot();
        }
        else
        {
            accepUp = true;
            CreateDemoTower();
        }

    }
    public void SellTower()
    {
        audioController.PlaySFX(audioController.audioClick);
        switch (kindTower)
        {
            case 1:
                GameManager.jeUpdate += GameManager.InforArcherTower[lvTower - 1].priceSell;
                break;
            case 2:
                GameManager.jeUpdate += GameManager.InforMagicTower[lvTower - 1].priceSell;
                break;
            case 3:
                GameManager.jeUpdate += GameManager.InforStoneTower[lvTower - 1].priceSell;
                break;
            case 4:
                switch (kindOfSupportTower)
                {
                    case 1:
                        GameManager.jeUpdate += GameManager.InforSupportTower[lvTower - 1].priceSell;
                        break;
                    case 2:
                        GameManager.jeUpdate += GameManager.InforSupportTower[lvTower - 1].priceSell;
                        break;
                    case 3:
                        GameManager.jeUpdate += GameManager.InforSupportTower[lvTower - 1].priceSell;
                        break;
                    case 4:
                        GameManager.jeUpdate += GameManager.InforSupportTower[lvTower - 1].priceSell;
                        break;
                }
                break;
        }
        Destroy(currenTower.gameObject);
        currenTower = null;
        lvTower = 0;
        kindTower = 0;
        kindOfSupportTower = 0;
        BottonUpTower.SetActive(true);
        OffMenuUpOrSell();
    }

}
