using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class BoxInforTowerController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Name;
    [SerializeField] TextMeshProUGUI Range;
    [SerializeField] TextMeshProUGUI Atk;
    [SerializeField] TextMeshProUGUI RateOfFire;
    [SerializeField] TextMeshProUGUI KindOfDamage;

    public void DisplayInforTower(string name, string range, string atk, string rateofFire, string kindOfDame)
    {
        MoveIUInGame.Instance.OnBoxInfor();
        Name.text = name;
        Range.text = "RangeTarget: " + range + "m";
        Atk.text = "Damage: " + atk;
        RateOfFire.text = "RateOfFire: " + rateofFire + "/s";
        KindOfDamage.text = "KindOfDamage:" + kindOfDame;
    }
    public void DisplayInforSupportTower(int kindOfTowerSP, string name, string range, string atk, string rateofFire, string kindOfDame)
    {
        MoveIUInGame.Instance.OnBoxInfor();
        Name.text = name;
        Range.text = "RangeEffect: " + range + "m";
        RateOfFire.text = "RateOfFire: " + 0 + "/s";
        KindOfDamage.text = "kindOfDamage:" + kindOfDame;
        switch (kindOfTowerSP)
        {
            case 1:
                Atk.text = "Effect:increased attack of the pillars.";
                break;
            case 2:
                Atk.text = "Effect:increase the area of attack of the towers";
                break;
            case 3:
                Atk.text = "Effect:increase the attack speed of the pillars.";
                break;
            case 4:
                Atk.text = "Effect:Move nearby enemies to 1 location in the past.";
                RateOfFire.text = "RateOfFire: " + rateofFire + "/s";
                break;
        }
    }
}
