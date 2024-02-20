using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataType : MonoBehaviour
{
}

[SerializeField]
public class DataMap
{
    public float heartInMap;
    public float jeInMap;
    public float waveEnemy;
    public float timeWave;
    public float timeCreatEnemy;
    public float Boss;
}
[System.Serializable]
public class MapResult
{
    public int[] dataArray;
}
public class TypeEnemy
{
    public float numTypeE;
}


[SerializeField]
public class Enemy
{
    public string name;
    public float speed;
    public float hp;
    public float atk;
    public float defPhysic;
    public float defMagic;
    public float je;
}


[SerializeField]
public class Tower
{
    public float targetingRange;
    public float bulletPerSecond;
    public float price;
    public float priceSell;
    public float damage;
}


[SerializeField]
public class SupportTower
{
    public string name;
    public float targetingRange;
    public float bulletPerSecond;
    public float price;
    public float priceSell;
    public float increaseSpeedShot;
    public float increaseTargetingRange;
    public float increaseDamage;
}



[SerializeField]
public class SaveDataModel
{
    public int levelMap;
    public int lvCurrentItem1;
    public int lvCurrentItem2;
    public int lvCurrentItem3;
    public int lvCurrentItem4;
    public int lvCurrentItem5;
    public int lvCurrentItem6;
    public int lvCurrentItem7;
    public int lvCurrentItem8;

    public int amoutItem1;
    public int amoutItem2;
    public int amoutItem3;
    public int amoutItem4;
    public int amoutItem5;
    public int amoutItem6;
    public int amoutItem7;
    public int amoutItem8;

    public int lvCurrentArcher1Tower;
    public int lvCurrentArcher2Tower;
    public int lvCurrentArcher3Tower;
    public int lvCurrentArcher4Tower;
    public int lvCurrentMagic1Tower;
    public int lvCurrentMagic2Tower;
    public int lvCurrentMagic3Tower;
    public int lvCurrentMagic4Tower;
    public int lvCurrentStone1Tower;
    public int lvCurrentStone2Tower;
    public int lvCurrentStone3Tower;
    public int lvCurrentStone4Tower;
    public int lvCurrentSupportMoveTower;
    public int lvCurrentSupportRangeTower;
    public int lvCurrentSupportDamgeTower;
    public int lvCurrentSupportSpeedTower;

    public bool music = true;
    public bool SFX = true;
    public bool shaking = true;

    public int JEMain;


}
