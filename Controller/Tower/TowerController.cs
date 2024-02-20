using UnityEditor;
using UnityEngine;


public class TowerController : MonoBehaviour
{

    [Header("References")]
    [SerializeField] public Transform Bullet;
    [SerializeField] public Transform PointShot;
    [SerializeField] public LayerMask enemyMask;

    [Header("Attribute")]
    [SerializeField] public float targetingRange;
    [SerializeField] public float damage;
    [SerializeField] public float bulletPerSecond;
    //  [SerializeField] protected float bulletPerSecond;

    protected Tower towerInfor;
    protected SupportTower towerSupportInfor;
    protected bool aniTower = false;

    protected int lvUpdate;
    public int level;
    protected float price;
    protected float priceCell;
    protected float countShot = 0;

    private bool OnAffectSupDamage = false;
    private bool OnAffectSupSpeed = false;
    private bool OnAffectSupRange = false;

    protected Transform target;
    protected Animator animator;
    protected Vector3 positionEnemy;

    protected int KindOfTower;// Archer:1||Magic:2||Stone:3||Support:4

    // test raycast 

    // Audio
    protected AudioController audioController;
    private void Awake()
    {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
    }
    public void TowerActive()
    {
        if (target != null)
        {

            positionEnemy = target.position - transform.position;
        }
        if (target == null)
        {
            FindTarget();
            return;
        }

        if (!CheckTargetIsinRange())
        {
            target = null;
        }
        else
        {
            countShot += Time.deltaTime;
            if (countShot >= 1f / bulletPerSecond)
            {
                countShot = 0f;
                aniTower = true;
                Shoot();
            }
        }
    }
    public void ShootStone()
    {

    }
    // ban
    public void Shoot()
    {
        Transform bulletObj = Instantiate(Bullet, PointShot.transform.position, Quaternion.identity);
        switch (KindOfTower)
        {
            case 1:
                audioController.PlaySFX(audioController.audioArcherShot);
                ArrowController arrowbulletScript = bulletObj.GetComponent<ArrowController>();
                arrowbulletScript.SetTargGet(target);
                arrowbulletScript.TakeInforTowerArrcher(towerInfor.damage);
                countShot = 0;
                break;
            case 2:
                audioController.PlaySFX(audioController.audioMagicShot);
                MagicController magicbulletScipt = bulletObj.GetComponent<MagicController>();
                magicbulletScipt.SetTargGet(target);
                magicbulletScipt.TakeInforTowerArrcher(towerInfor.damage);
                countShot = 0;
                break;
            case 3:
                audioController.PlaySFX(audioController.audioStoneShot);
                StoneController stonebulletScript = bulletObj.GetComponent<StoneController>();
                stonebulletScript.SetTargGet(target);
                stonebulletScript.TakeInforTowerArrcher(towerInfor.damage);
                countShot = 0;
                break;
            case 4:
                audioController.PlaySFX(audioController.audioMoveShot);
                SupportBullet supportbulletScript = bulletObj.GetComponent<SupportBullet>();
                supportbulletScript.SetTargGet(target);
                countShot = 0;
                break;
        }

    }

    // check khoang cach
    public bool CheckTargetIsinRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

    // ve raycat roi bat doi tuong co trong raycat 
    public void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.parent.position, targetingRange, (Vector2)transform.parent.position, 0f, enemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }
    /*// cho vao thi se hien vong raycat
    public void OnDrawGizmosSelected()
    {
        UnityEditor.Handles.color = Color.black;
        UnityEditor.Handles.DrawWireDisc(transform.parent.position, transform.parent.forward, targetingRange);

    }*/

    private void OnTriggerStay2D(Collider2D boxOther)
    {
        if (KindOfTower != 4)
        {
            if (boxOther.gameObject.tag == "SupportTower")
            {
                SupportTowerController supportScrip = boxOther.gameObject.GetComponent<SupportTowerController>();
                switch (supportScrip.nameTower)
                {
                    case "damage":
                        if (!OnAffectSupDamage)
                        {
                            OnAffectSupDamage = true;
                            towerInfor.damage = towerInfor.damage * supportScrip.increaseDamage;
                        }
                        break;
                    case "speed":
                        if (!OnAffectSupSpeed)
                        {
                            OnAffectSupSpeed = true;
                            bulletPerSecond = bulletPerSecond * supportScrip.increaseSpeedShot;
                        }
                        break;
                    case "range":
                        if (!OnAffectSupRange)
                        {
                            OnAffectSupRange = true;
                            targetingRange = targetingRange * supportScrip.increaseTargetingRange;
                        }
                        break;

                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D boxOther)
    {
        if (KindOfTower != 4)
        {
            if (boxOther.gameObject.tag == "SupportTower")
            {
                SupportTowerController supportScrip = boxOther.gameObject.GetComponent<SupportTowerController>();

                switch (supportScrip.nameTower)
                {
                    case "damage":
                        OnAffectSupDamage = false;
                        towerInfor.damage = towerInfor.damage / supportScrip.increaseDamage;
                        break;
                    case "speed":
                        OnAffectSupSpeed = false;
                        bulletPerSecond = bulletPerSecond / supportScrip.increaseSpeedShot;
                        break;
                    case "range":
                        OnAffectSupRange = false;
                        targetingRange = targetingRange / supportScrip.increaseTargetingRange;
                        break;

                }
            }
        }
    }
}
