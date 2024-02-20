using LTAUnityBase.Base.DesignPattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TakeData : MonoBehaviour
{
    public Tower[] TakePriceSupportTower(Tower[] PriceSupportTower)
    {
        TowerVO towerVO;
        towerVO = new TowerVO("SupportTower");
        int count = towerVO.ArrayCount;
        PriceSupportTower = new Tower[count];
        for (int i = 0; i < count; ++i)
        {
            PriceSupportTower[i] = towerVO.GetEntityInfo(i);
        }
        return PriceSupportTower;
    }
    public Tower[] TakePriceStoneTower(Tower[] PriceStoneTower)
    {
        TowerVO towerVO;
        towerVO = new TowerVO("StoneTower");
        int count = towerVO.ArrayCount;
        PriceStoneTower = new Tower[count];
        for (int i = 0; i < count; ++i)
        {
            PriceStoneTower[i] = towerVO.GetEntityInfo(i);
        }
        return PriceStoneTower;
    }
    public Tower[] TakePriceArcherTower(Tower[] PriceArcherTower)
    {
        TowerVO towerVO;
        towerVO = new TowerVO("ArcherTower");
        int count = towerVO.ArrayCount;
        PriceArcherTower = new Tower[count];
        for (int i = 0; i < count; ++i)
        {
            PriceArcherTower[i] = towerVO.GetEntityInfo(i);
        }
        return PriceArcherTower;
    }
    public Tower[] TakePriceMagicTower(Tower[] PriceMagicTower)
    {
        TowerVO towerVO;
        towerVO = new TowerVO("MagicTower");
        int count = towerVO.ArrayCount;
        PriceMagicTower = new Tower[count];
        for (int i = 0; i < count; ++i)
        {
            PriceMagicTower[i] = towerVO.GetEntityInfo(i);
        }
        return PriceMagicTower;
    }
    public void SaveMapResult(MapResult mapResult)
    {
        MapResult data = new MapResult();

        data.dataArray = mapResult.dataArray;

        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(Application.streamingAssetsPath + "/MapResult.json", jsonData);

    }
}
public class TkDt : SingletonMonoBehaviour<TakeData> { }

