using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossController : EntityController
{//miniBoss
    public Transform miniBoss;
    //layData
    public BossVO bossVO;
    //thu tu boss
    public int numBoss;
    //set da tao miniBoss chua
    bool createdMiniBoss = false;

    // Audio
    protected AudioController audioController;
    private void Awake()
    {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        bossVO = new BossVO();

        targetPoint = WayPointsController.points[0];
        // nhan data
        speed = bossVO.GetEntityInfo(numBoss).speed;
        hp = bossVO.GetEntityInfo(numBoss).hp;
        atk = bossVO.GetEntityInfo(numBoss).atk;
        defPhysic = bossVO.GetEntityInfo(numBoss).defPhysic;
        defMagic = bossVO.GetEntityInfo(numBoss).defMagic;
        je = bossVO.GetEntityInfo(numBoss).je;
        maxhp = hp;

        rb = GetComponent<Rigidbody>();
        animator = this.transform.GetComponent<Animator>();
        status = 3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animator.SetFloat("Status", status);

        if (hp > 0)
        {
            direction = targetPoint.position - obj.transform.position;
            //quay dau
            if (direction.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            // di chuyen theo points
            if (status != 0)
            {
                Move();
                if (Vector3.Distance(obj.transform.position, targetPoint.position) <= 0.2f)
                {
                    if (WayPointIndex >= WayPointsController.points.Length - 1)
                    {
                        Destroy(this.gameObject);
                        GameManager.heart -= 20;
                    }
                    else
                    {
                        GetNextWayPoint();
                    }
                }
            }
        }
        else
        {
            audioController.PlaySFX(audioController.audioBossDie);
            hp = 0;
            status = 0;
            if (miniBoss != null)
            {
                if (!createdMiniBoss)
                {
                    Transform miniBossObj = Instantiate(miniBoss, obj.transform.position, Quaternion.identity);
                    MiniBossController miniBossScript = miniBossObj.GetComponentInChildren<MiniBossController>();
                    miniBossScript.SetTargGet(WayPointIndex);
                    createdMiniBoss = true;
                }
            }
            else
            {
                GameManager.endGame = true;
            }
        }
        DisplayValue();
    }
    public void DisplayValue()
    {
        barHp.localScale = new Vector3((float)(hp / maxhp) * 0.25f, barHp.localScale.y, barHp.localScale.z);
    }
}
