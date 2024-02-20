using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTowerController : TowerController
{
    TowerVO mgVO;
    // Start is called before the first frame update
    void Start()
    {
        KindOfTower = 2;

        mgVO = new TowerVO("MagicTower");
        towerInfor = mgVO.GetEntityInfo(level);
        targetingRange = towerInfor.targetingRange;
        damage = towerInfor.damage;
        bulletPerSecond = towerInfor.bulletPerSecond;

        switch (transform.parent.name)
        {
            case "MagicTowerLv1(Clone)" or "MagicTowerLv2(Clone)" or "MagicTowerLv3(Clone)":
                lvUpdate = GameManager.lvCurrentMagic1Tower;
                break;
            case "MagicTowerLv4(Clone)" or "MagicTowerLv5(Clone)" or "MagicTowerLv6(Clone)":
                lvUpdate = GameManager.lvCurrentMagic2Tower;
                break;
            case "MagicTowerLv7(Clone)" or "MagicTowerLv8(Clone)" or "MagicTowerLv9(Clone)":
                lvUpdate = GameManager.lvCurrentMagic3Tower;
                break;
            case "MagicTowerLv10(Clone)" or "MagicTowerLv11(Clone)" or "MagicTowerLv12(Clone)":
                lvUpdate = GameManager.lvCurrentMagic4Tower;
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
    }

    void FixedUpdate()
    {
        TowerActive();
    }
}
