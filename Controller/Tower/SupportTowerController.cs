using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportTowerController : TowerController
{
    SupportTowerVO supVO;
    public CircleCollider2D circle;
    [Header("Damage:0-2 || Speed:3-5  || Range:6-8 || Move:9-11")]
    public string nameTower;
    public float increaseSpeedShot;
    public float increaseTargetingRange;
    public float increaseDamage;
    // Start is called before the first frame update
    void Start()
    {
        KindOfTower = 4;

        supVO = new SupportTowerVO("SupportTower");
        towerSupportInfor = supVO.GetEntityInfo(level);

        targetingRange = towerSupportInfor.targetingRange;
        nameTower = towerSupportInfor.name;
        increaseSpeedShot = towerSupportInfor.increaseSpeedShot;
        increaseTargetingRange = towerSupportInfor.increaseTargetingRange;
        increaseDamage = towerSupportInfor.increaseDamage;
        bulletPerSecond = towerSupportInfor.bulletPerSecond;
        switch (transform.parent.name)
        {
            case "SupportDamageLv1(Clone)" or "SupportDamageLv2(Clone)" or "SupportDamageLv3(Clone)":
                lvUpdate = GameManager.lvCurrentSupportDamgeTower;
                break;
            case "SupportMoveLv1(Clone)" or "SupportMoveLv3(Clone)" or "SupportMoveLv3(Clone)":
                lvUpdate = GameManager.lvCurrentSupportMoveTower;
                break;
            case "SupportRangeLv1(Clone)" or "SupportRangeLv2(Clone)" or "SupportRangeLv3(Clone)":
                lvUpdate = GameManager.lvCurrentSupportRangeTower;
                break;
            case "SupportSpeedLv1(Clone)" or "SupportSpeedLv2(Clone)" or "SupportSpeedLv3(Clone)":
                lvUpdate = GameManager.lvCurrentSupportSpeedTower;
                break;
        }
        if (level <= 8)
        {
            switch (lvUpdate)
            {
                case 1:
                    targetingRange *= 1.1f;
                    increaseSpeedShot *= 1.1f;
                    increaseTargetingRange *= 1.1f;
                    break;
                case 2:
                    targetingRange *= 1.2f;
                    increaseSpeedShot *= 1.2f;
                    increaseTargetingRange *= 1.2f;
                    break;
                case 3:
                    targetingRange *= 1.3f;
                    increaseSpeedShot *= 1.3f;
                    increaseTargetingRange *= 1.3f;
                    break;
                case 4:
                    targetingRange *= 1.4f;
                    increaseSpeedShot *= 1.4f;
                    increaseTargetingRange *= 1.4f;
                    break;
                case 5:
                    targetingRange *= 1.5f;
                    increaseSpeedShot *= 1.5f;
                    increaseTargetingRange *= 1.5f;
                    break;
            }
            circle = this.GetComponent<CircleCollider2D>();
            circle.radius = targetingRange;
        }
        else
        {
            switch (lvUpdate)
            {
                case 1:
                    targetingRange *= 1.1f;
                    bulletPerSecond *= 1.1f;
                    break;
                case 2:
                    targetingRange *= 1.2f;
                    bulletPerSecond *= 1.2f;
                    break;
                case 3:
                    targetingRange *= 1.3f;
                    bulletPerSecond *= 1.3f;
                    break;
                case 4:
                    targetingRange *= 1.4f;
                    bulletPerSecond *= 1.4f;
                    break;
                case 5:
                    bulletPerSecond *= 1.5f;
                    targetingRange *= 1.5f;
                    break;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TowerActive();
    }
}
