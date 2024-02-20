using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTowerV2Controller : TowerController
{

    [SerializeField] public Transform crossbowL;
    [SerializeField] public Transform crossbowR;
    [SerializeField] public GameObject BulletDemo;

    TowerVO archertowerVO;
    public float test;
    public int aniBool = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();

        archertowerVO = new TowerVO("ArcherTower");
        towerInfor = archertowerVO.GetEntityInfo(level);
        targetingRange = towerInfor.targetingRange;
        damage = towerInfor.damage;
        bulletPerSecond = towerInfor.bulletPerSecond;
        KindOfTower = 1;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        TowerActive();
        if (aniTower)
        {
            AnimationArcherV2();
        }

    }
    public void AnimationArcherV2()
    {
        aniBool++;
        if (aniBool <= 16)
        {
            crossbowR.Rotate(0, 0, -5, 0);
            crossbowL.Rotate(0, 0, 5, 0);
            BulletDemo.transform.position += new Vector3(0, 0.004f);
        }
        else if (aniBool > 16)
        {
            aniBool = 0;
            BulletDemo.transform.position -= new Vector3(0, 0.064f);
            crossbowR.rotation = new Quaternion(0, 0, 0, 0);
            crossbowL.rotation = new Quaternion(0, 0, 0, 0);
            aniTower = false;
        }
    }
}
