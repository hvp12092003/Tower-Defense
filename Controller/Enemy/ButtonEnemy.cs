using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonEnemy : MonoBehaviour
{
    EnemeiesController enemyScrip;
    BoxInforEnemyController boxInfor;
    private void Start()
    {
        enemyScrip = this.transform.parent.GetComponent<EnemeiesController>();
        boxInfor = GameObject.FindGameObjectWithTag("BoxInforEnemy").GetComponent<BoxInforEnemyController>();
    }
    public void ShowInfor()
    {
        Debug.Log(123);
        boxInfor.DisplayInforTower(enemyScrip.Name, enemyScrip.hp.ToString(), enemyScrip.speed.ToString(), enemyScrip.defPhysic.ToString(), enemyScrip.defMagic.ToString());
    }
}
