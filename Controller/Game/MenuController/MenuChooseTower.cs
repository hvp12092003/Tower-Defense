using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuChooseTower : MonoBehaviour
{
    [SerializeField] GameObject menuChooseSupportTower;

    public void ChooseSupportTower()
    {
        menuChooseSupportTower.SetActive(true);
    }
}
