using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MiniBossController : EntityController
{
    public BossVO bossVO;
    public int numBoss;
    int count = 0;
    bool check = true;
    // Start is called before the first frame update
    void Start()
    {
        bossVO = new BossVO();
        speed = bossVO.GetEntityInfo(numBoss).speed * 1.5f;
        hp = bossVO.GetEntityInfo(numBoss).hp / 2;
        atk = bossVO.GetEntityInfo(numBoss).atk / 2;
        defPhysic = bossVO.GetEntityInfo(numBoss).defPhysic / 2;
        defMagic = bossVO.GetEntityInfo(numBoss).defMagic / 2;
        je = bossVO.GetEntityInfo(numBoss).je;
        maxhp = hp;

        rb = GetComponent<Rigidbody>();

        animator = this.transform.GetComponent<Animator>();
        status = 0;

        targetPoint = WayPointsController.points[0];
    }

    public void SetTargGet(int numPoint)
    {
        WayPointIndex = numPoint - 1;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        count++;
        if (count < 10)
        {
            status = 0;
        }
        else
        {
            status = 1;
            if (hp > 0)
            {
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
                if (check)
                {
                    GetNextWayPoint();
                    check = false;
                }
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
            else if (hp < 0)
            {
                GameManager.endGame = true;
                Die();
            }
        }
        DisplayValue();
        animator.SetFloat("Status", status);
    }

    public void DisplayValue()
    {
        barHp.localScale = new Vector3((float)(hp / maxhp) * 0.25f, barHp.localScale.y, barHp.localScale.z);
    }

}
