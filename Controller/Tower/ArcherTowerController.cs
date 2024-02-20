using Unity.Burst.CompilerServices;
using UnityEngine;

public class ArcherController : TowerController
{
    TowerVO achertowerVO;
    public int x;
    public float statusAnimator = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();

        achertowerVO = new TowerVO("Archertower");
        towerInfor = achertowerVO.GetEntityInfo(level);
        targetingRange = towerInfor.targetingRange;
        bulletPerSecond = towerInfor.bulletPerSecond;
        switch (transform.parent.name)
        {
            case "ArcherTowerLv1(Clone)" or "ArcherTowerLv2(Clone)" or "ArcherTowerLv3(Clone)":
                lvUpdate = GameManager.lvCurrentArcher1Tower;
                break;
            case "ArcherTowerLv4(Clone)" or "ArcherTowerLv5(Clone)" or "ArcherTowerLv6(Clone)":
                lvUpdate = GameManager.lvCurrentArcher2Tower;
                break;
            case "ArcherTowerLv7(Clone)" or "ArcherTowerLv8(Clone)" or "ArcherTowerLv9(Clone)":
                lvUpdate = GameManager.lvCurrentArcher3Tower;
                break;
            case "ArcherTowerLv10(Clone)" or "ArcherTowerLv11(Clone)" or "ArcherTowerLv12(Clone)":
                lvUpdate = GameManager.lvCurrentArcher4Tower;
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
        KindOfTower = 1;
    }
    private void FixedUpdate()
    {
        TowerActive();
        AnimationArcher();
    }
    void AnimationArcher()
    {
        if (aniTower)
        {
            if (positionEnemy.x >= 0 && positionEnemy.y > 0)
            {
                statusAnimator = 2;
                transform.localScale = new Vector3(1, 1, 0);
            }
            else if (positionEnemy.x >= 0 && positionEnemy.y < 0)
            {
                statusAnimator = 1;
                transform.localScale = new Vector3(1, 1, 0);
            }
            else if (positionEnemy.x <= 0 && positionEnemy.y < 0)
            {
                statusAnimator = 1;
                transform.localScale = new Vector3(-1, 1, 0);
            }
            else if (positionEnemy.x <= 0 && positionEnemy.y > 0)
            {
                statusAnimator = 2;
                transform.localScale = new Vector3(-1, 1, 0);
            }
            aniTower = false;
        }
        else
        {
            if (statusAnimator == 2)
            {
                statusAnimator = 1.5f;
            }
            else if (statusAnimator == 1)
            {
                statusAnimator = 0.5f;
            }
        }
        animator.SetFloat("Status", statusAnimator);
    }
}
