using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
public class EnemeiesController : EntityController
{
    public EnemyVO enemyVO;
    public int numEnemy;
    // Start is called before the first frame update
    void Start()
    {
        enemyVO = new EnemyVO();
        targetPoint = WayPointsController.points[0];
        speed = enemyVO.GetEntityInfo(numEnemy).speed;
        hp = enemyVO.GetEntityInfo(numEnemy).hp;
        atk = enemyVO.GetEntityInfo(numEnemy).atk;
        defPhysic = enemyVO.GetEntityInfo(numEnemy).defPhysic;
        defMagic = enemyVO.GetEntityInfo(numEnemy).defMagic;
        je = enemyVO.GetEntityInfo(numEnemy).je;
        Name = enemyVO.GetEntityInfo(numEnemy).name;
        maxhp = hp;

        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        animator.SetFloat("Status", status);
        if (hp > 0)
        {

            direction = targetPoint.position - transform.position;
            //quay dau
            if (direction.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            Move();
            if (Vector3.Distance(transform.position, targetPoint.position) <= 0.2f)
            {
                if (WayPointIndex >= WayPointsController.points.Length - 1)
                {
                    Destroy(this.gameObject);
                    GameManager.heart -= 1;
                }
                else
                {
                    GetNextWayPoint();
                }
            }
            DisplayValue();
        }
        else
        {
            Die();
        }

    }
    public void DisplayValue()
    {
        barHp.localScale = new Vector3((float)(hp / maxhp) * 0.13f, barHp.localScale.y, barHp.localScale.z);
    }
}
