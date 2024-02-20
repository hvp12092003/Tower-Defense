using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneTowerController : TowerController
{
    [SerializeField] public Transform launchers;

    TowerVO stVO;

    public int aniBool = 0;

    // Start is called before the first frame update
    void Start()
    {
        stVO = new TowerVO("StoneTower");
        towerInfor = stVO.GetEntityInfo(level);
        targetingRange = towerInfor.targetingRange;
        bulletPerSecond = towerInfor.bulletPerSecond;

        switch (transform.parent.name)
        {
            case "StoneTowerLv1(Clone)" or "StoneTowerLv2(Clone)" or "StoneTowerLv3(Clone)":
                lvUpdate = GameManager.lvCurrentStone1Tower;
                break;
            case "StoneTowerLv4(Clone)" or "StoneTowerLv5(Clone)" or "StoneTowerLv6(Clone)":
                lvUpdate = GameManager.lvCurrentStone2Tower;
                break;
            case "StoneTowerLv7(Clone)" or "StoneTowerLv8(Clone)" or "StoneTowerLv9(Clone)":
                lvUpdate = GameManager.lvCurrentStone3Tower;
                break;
            case "StoneTowerLv10(Clone)" or "StoneTowerLv11(Clone)" or "StoneTowerLv12(Clone)":
                lvUpdate = GameManager.lvCurrentStone4Tower;
                break;
        }
        switch (lvUpdate)
        {
            case 1:
                this.targetingRange *= 1.1f;
                bulletPerSecond *= 1.1f;
                towerInfor.damage *= 1.1f;
                break;
            case 2:
                this.targetingRange *= 1.2f;
                bulletPerSecond *= 1.2f;
                towerInfor.damage *= 1.2f;
                break;
            case 3:
                this.targetingRange *= 1.3f;
                bulletPerSecond *= 1.3f;
                towerInfor.damage *= 1.3f;
                break;
            case 4:
                this.targetingRange *= 1.4f;
                bulletPerSecond *= 1.4f;
                towerInfor.damage *= 1.4f;
                break;
            case 5:
                this.targetingRange *= 1.5f;
                bulletPerSecond *= 1.5f;
                towerInfor.damage *= 1.5f;
                break;
        }

        KindOfTower = 3;
    }

    // Update is called once per frame
    void Update()
    {
        TowerActive();
        if (aniTower)
        {
            AnimationStone();
        }
    }

    public void AnimationStone()
    {

        if (aniTower)
        {
            aniBool++;
            launchers.position += new Vector3(0, 0.01f);

            if (aniBool > 30)
            {
                launchers.position -= new Vector3(0, 0.31f);
                aniTower = false;
                aniBool = 0;
            }
        }
    }
}
