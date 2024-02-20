using LTAUnityBase.Base.DesignPattern;
using TMPro;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject FailedPanel;
    [SerializeField] GameObject WinedPanel;
    [SerializeField] TextMeshProUGUI txtJe;
    [SerializeField] TextMeshProUGUI txtJE;
    [SerializeField] TextMeshProUGUI txtHeart;


    MapVO mapVO;


    // affect to Enemy
    public static float increaseATK = 1;
    public static float decreaseDEF = 1;
    public static bool OnItemDef = false;
    public static bool OnItemAtk = false;
    public static float timeDef;
    public static float timeAtk;

    public static Tower[] InforArcherTower;
    public static Tower[] InforMagicTower;
    public static Tower[] InforStoneTower;
    public static Tower[] InforSupportTower;

    // item
    public static bool offChooseOneItem = true;
    public Transform[] Item1;
    public Transform[] Item2;
    public Transform[] Item3;
    public Transform[] Item4;
    public Transform[] Item5;
    public Transform[] Item6;
    public Transform[] Item7;
    public Transform[] Item8;

    // data save
    public static SaveDataModel data;

    public static int lvCurrentItem1;
    public static int lvCurrentItem2;
    public static int lvCurrentItem3;
    public static int lvCurrentItem4;
    public static int lvCurrentItem5;
    public static int lvCurrentItem6;
    public static int lvCurrentItem7;
    public static int lvCurrentItem8;

    public static int amoutItem1;
    public static int amoutItem2;
    public static int amoutItem3;
    public static int amoutItem4;
    public static int amoutItem5;
    public static int amoutItem6;
    public static int amoutItem7;
    public static int amoutItem8;

    public static int lvCurrentArcher1Tower;
    public static int lvCurrentArcher2Tower;
    public static int lvCurrentArcher3Tower;
    public static int lvCurrentArcher4Tower;
    public static int lvCurrentMagic1Tower;
    public static int lvCurrentMagic2Tower;
    public static int lvCurrentMagic3Tower;
    public static int lvCurrentMagic4Tower;
    public static int lvCurrentStone1Tower;
    public static int lvCurrentStone2Tower;
    public static int lvCurrentStone3Tower;
    public static int lvCurrentStone4Tower;
    public static int lvCurrentSupportSpeedTower;
    public static int lvCurrentSupportDamgeTower;
    public static int lvCurrentSupportRangeTower;
    public static int lvCurrentSupportMoveTower;

    public static bool music;
    public static bool SFX;
    public static bool shaking;

    public static int JEMain;
    public static int JEMainUpdate;

    public static float je;
    public static float jeUpdate;

    public static float heart;

    public static int levelMap;

    // infor star map
    [SerializeField] private static int[] star;
    public static int amountStar;

    bool creatFailedPanel = true;

    public static bool onDot = false;

    //dataMap 
    public static float boss;
    public static float waveEnemy;
    public static float timeWave;
    public static float timeCreatEnemy;


    // infor to class creat
    public static bool startCreatEnemies = false;

    // infor to class icon
    public static bool createIconSkull = false;

    public static MapResult mapResult;

    public static bool endGame = false;

    public bool Playing;
    // Start is called before the first frame update
    void Awake()
    {

        Time.timeScale = 1;

        LoadDataModel();
        LoadMapResult();
        mapResult.dataArray = star;

        if (Playing)
        {
            DataMap dataMap;
            mapVO = new MapVO();
            dataMap = mapVO.GetEntityInfo(levelMap);
            heart = dataMap.heartInMap;
            jeUpdate = dataMap.jeInMap;
            je = jeUpdate;
            boss = dataMap.Boss;
            waveEnemy = dataMap.waveEnemy;
            timeWave = dataMap.timeWave;
            timeCreatEnemy = dataMap.timeCreatEnemy;

            InforSupportTower = TkDt.Instance.TakePriceSupportTower(InforSupportTower);
            InforStoneTower = TkDt.Instance.TakePriceStoneTower(InforStoneTower);
            InforArcherTower = TkDt.Instance.TakePriceArcherTower(InforArcherTower);
            InforMagicTower = TkDt.Instance.TakePriceMagicTower(InforMagicTower);

            txtHeart.text = heart.ToString();
        }
        else
        {
            txtJE.text = JEMain.ToString();
            LoadDataModel();
            JEMainUpdate = JEMain;

            star = new int[40];
        }

    }
    public int TakenMapLv()
    {
        return levelMap;
    }
    void Update()
    {
        if (Playing)
        {
            txtHeart.text = heart.ToString();
            if (je < jeUpdate)
            {
                je++;
                txtJe.text = je.ToString();
            }
            else if (je > jeUpdate)
            {
                je--;
                txtJe.text = je.ToString();
            }
            else
            {
                txtJe.text = je.ToString();
            }
            if (heart <= 0)
            {
                if (creatFailedPanel)
                {
                    FailedPanel.SetActive(true);
                    Time.timeScale = 0;
                }
            }
            // Win Game
            if (endGame)
            {
                endGame = false;
                MoveIUInGame.Instance.OnPanelWin();
                SetResultEndGame();
            }
        }
        else
        {
            if (JEMain > JEMainUpdate)
            {
                JEMain--;
                txtJE.text = JEMain.ToString();
            }
            else if (JEMain < JEMainUpdate)
            {
                JEMain++;
                txtJE.text = JEMain.ToString();
            }
            else
            {
                txtJE.text = JEMain.ToString();
            }
        }
    }

    public void SetResultEndGame()
    {
        if (heart >= 15)
        {
            Result(3);
        }
        else if (heart == 10 && heart <= 14)
        {
            Result(2);
        }
        else if (heart < 10)
        {
            Result(1);
        }
    }
    public void Result(int star)
    {
        mapResult.dataArray[levelMap] = star;
        TkDt.Instance.SaveMapResult(mapResult);
    }
    public void LoadDataModel()
    {
        data = new SaveDataModel();
        data = JsonUtility.FromJson<SaveDataModel>(File.ReadAllText(Application.streamingAssetsPath + "/DataUser.json"));

        levelMap = data.levelMap;

        amoutItem1 = data.amoutItem1;
        amoutItem2 = data.amoutItem2;
        amoutItem3 = data.amoutItem3;
        amoutItem4 = data.amoutItem4;
        amoutItem5 = data.amoutItem5;
        amoutItem6 = data.amoutItem6;
        amoutItem7 = data.amoutItem7;
        amoutItem8 = data.amoutItem8;

        JEMain = data.JEMain;

        lvCurrentItem1 = data.lvCurrentItem1;
        lvCurrentItem2 = data.lvCurrentItem2;
        lvCurrentItem3 = data.lvCurrentItem3;
        lvCurrentItem4 = data.lvCurrentItem4;
        lvCurrentItem5 = data.lvCurrentItem5;
        lvCurrentItem6 = data.lvCurrentItem6;
        lvCurrentItem7 = data.lvCurrentItem7;
        lvCurrentItem8 = data.lvCurrentItem8;

        lvCurrentArcher1Tower = data.lvCurrentArcher1Tower;
        lvCurrentArcher2Tower = data.lvCurrentArcher2Tower;
        lvCurrentArcher3Tower = data.lvCurrentArcher3Tower;
        lvCurrentArcher4Tower = data.lvCurrentArcher4Tower;
        lvCurrentMagic1Tower = data.lvCurrentMagic1Tower;
        lvCurrentMagic2Tower = data.lvCurrentMagic2Tower;
        lvCurrentMagic3Tower = data.lvCurrentMagic3Tower;
        lvCurrentMagic4Tower = data.lvCurrentMagic4Tower;
        lvCurrentStone1Tower = data.lvCurrentStone1Tower;
        lvCurrentStone2Tower = data.lvCurrentStone2Tower;
        lvCurrentStone3Tower = data.lvCurrentStone3Tower;
        lvCurrentStone4Tower = data.lvCurrentStone4Tower;
        lvCurrentSupportSpeedTower = data.lvCurrentSupportSpeedTower;
        lvCurrentSupportDamgeTower = data.lvCurrentSupportDamgeTower;
        lvCurrentSupportRangeTower = data.lvCurrentSupportRangeTower;
        lvCurrentSupportMoveTower = data.lvCurrentSupportMoveTower;


        music = data.music;
        SFX = data.SFX;
        shaking = data.shaking;
    }
    // save data user
    public void SaveDataModel()
    {
        data.levelMap = levelMap;
        data.amoutItem1 = amoutItem1;
        data.amoutItem2 = amoutItem2;
        data.amoutItem3 = amoutItem3;
        data.amoutItem4 = amoutItem4;
        data.amoutItem5 = amoutItem5;
        data.amoutItem6 = amoutItem6;
        data.amoutItem7 = amoutItem7;
        data.amoutItem8 = amoutItem8;

        data.JEMain = JEMain;

        data.lvCurrentItem1 = lvCurrentItem1;
        data.lvCurrentItem2 = lvCurrentItem2;
        data.lvCurrentItem3 = lvCurrentItem3;
        data.lvCurrentItem4 = lvCurrentItem4;
        data.lvCurrentItem5 = lvCurrentItem5;
        data.lvCurrentItem6 = lvCurrentItem6;
        data.lvCurrentItem7 = lvCurrentItem7;
        data.lvCurrentItem8 = lvCurrentItem8;

        data.lvCurrentArcher1Tower = lvCurrentArcher1Tower;
        data.lvCurrentArcher2Tower = lvCurrentArcher2Tower;
        data.lvCurrentArcher3Tower = lvCurrentArcher3Tower;
        data.lvCurrentArcher4Tower = lvCurrentArcher4Tower;
        data.lvCurrentMagic1Tower = lvCurrentMagic1Tower;
        data.lvCurrentMagic2Tower = lvCurrentMagic2Tower;
        data.lvCurrentMagic3Tower = lvCurrentMagic3Tower;
        data.lvCurrentMagic4Tower = lvCurrentMagic4Tower;
        data.lvCurrentStone1Tower = lvCurrentStone1Tower;
        data.lvCurrentStone2Tower = lvCurrentStone2Tower;
        data.lvCurrentStone3Tower = lvCurrentStone3Tower;
        data.lvCurrentStone4Tower = lvCurrentStone4Tower;
        data.lvCurrentSupportSpeedTower = lvCurrentSupportSpeedTower;
        data.lvCurrentSupportDamgeTower = lvCurrentSupportDamgeTower;
        data.lvCurrentSupportRangeTower = lvCurrentSupportRangeTower;
        data.lvCurrentSupportMoveTower = lvCurrentSupportMoveTower;


        data.music = music;
        data.SFX = SFX;
        data.shaking = shaking;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.streamingAssetsPath + "/DataUser.json", json);
    }
    //load data map played
    public void LoadMapResult()
    {
        mapResult = new MapResult();
        string filePath = Path.Combine(Application.streamingAssetsPath + "/MapResult.json");

        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            MapResult loadedData = JsonUtility.FromJson<MapResult>(jsonData);

            if (loadedData != null)
            {
                star = loadedData.dataArray;
                // use array loaded at here
                foreach (int num in star)
                {
                    amountStar += num;
                }
            }
        }
        else
        {
            Debug.Log("File does not exist!");
        }
    }

}
public class GAMEMANAGER : SingletonMonoBehaviour<GameManager> { }