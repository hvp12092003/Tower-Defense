using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EntityController : MonoBehaviour
{
    public GameObject obj;
    protected Transform targetPoint;
    public Transform barHp;
    protected Rigidbody rb;
    protected Animator animator;


    public string Name;
    public float speed;
    public float hp;
    protected float atk;
    protected float maxhp;
    public float defPhysic;
    public float defMagic;
    public int status;
    protected float je;

    protected bool Onfreeze = false;

    protected float timeOnItem7;
    protected bool OnRain = false;
    protected float OnDamageItem7;
    protected float countRain = 1;

    protected bool takeJe = false;

    protected Vector3 direction;
    protected int WayPointIndex = 0;


    protected void Die()
    {
        if (!takeJe)
        {
            hp = 0;
            GameManager.jeUpdate += je;
            takeJe = true;
        }
        Destroy(obj.gameObject);
    }

    public void TakeDamePhysic(float dame)
    {
        hp -= ((dame * GameManager.increaseATK) - (defPhysic * GameManager.decreaseDEF));
    }
    public void TakeDameMagic(float dame)
    {
        hp -= ((dame * GameManager.increaseATK) - (defMagic * GameManager.decreaseDEF));
    }

    public void Move()
    {
        status = 1;
        if (!Onfreeze)
        {
            status = 2;
            if (OnRain)
            {
                timeOnItem7 -= Time.deltaTime;
                countRain -= Time.deltaTime;
                if (countRain <= 0)
                {
                    TakeDameMagic(OnDamageItem7);
                    countRain = 1;
                }
                if (timeOnItem7 <= 0)
                {
                    OnRain = false;
                }
                direction = targetPoint.position - obj.transform.position;
                obj.transform.Translate(direction.normalized * (speed / 2) * Time.deltaTime, Space.World);
            }
            else
            {
                direction = targetPoint.position - obj.transform.position;
                obj.transform.Translate(direction.normalized * (speed) * Time.deltaTime, Space.World);
            }
        }
    }
    public void GetNextWayPoint()
    {
        WayPointIndex++;
        targetPoint = WayPointsController.points[WayPointIndex];
    }
    void OnTriggerEnter2D(Collider2D boxOther)
    {
        switch (boxOther.gameObject.tag)
        {
            case "Arrow":
                ArrowController arrow = boxOther.gameObject.GetComponent<ArrowController>();
                TakeDamePhysic(arrow.damage);
                break;
            case "Magic":
                MagicController magic = boxOther.gameObject.GetComponent<MagicController>();
                TakeDamePhysic(magic.damage);
                break;
            case "Stone":
                StoneController stone = boxOther.gameObject.GetComponent<StoneController>();
                TakeDamePhysic(stone.damage);
                break;
            case "Move":

                WayPointIndex = 0;
                GetNextWayPoint();
                obj.transform.position = targetPoint.transform.position;

                break;
            case "Item":
                ItemController itemScrip = boxOther.GetComponent<ItemController>();
                switch (itemScrip.nameItem)
                {
                    case "Item1":
                        TakeDameMagic(itemScrip.damage);
                        break;
                    case "Item2":
                        status = 1;
                        Onfreeze = true;
                        break;
                    case "Item3":
                        TakeDameMagic(itemScrip.damage);
                        break;
                    case "Item4":
                        WayPointIndex = 0;
                        GetNextWayPoint();
                        obj.transform.position = targetPoint.transform.position;
                        break;
                    case "Item7":
                        OnRain = true;
                        speed *= itemScrip.slowSpeed;
                        timeOnItem7 = itemScrip.timeAffect;
                        OnDamageItem7 = itemScrip.damage;
                        break;
                    case "Item8":
                        TakeDamePhysic(itemScrip.damage);
                        break;
                }
                break;
        }
    }
    void OnTriggerStay2D(Collider2D boxOther)
    {
        if (boxOther.gameObject.tag == ("Item"))
        {
            ItemController itemScrip = boxOther.gameObject.GetComponent<ItemController>();
            if (itemScrip.nameItem == "Item2")
            {
                status = 1;
            }
        }

    }
    void OnTriggerExit2D(Collider2D boxOther)
    {
        if (boxOther.gameObject.tag == ("Item"))
        {
            ItemController itemScrip = boxOther.gameObject.GetComponent<ItemController>();
            if (itemScrip.nameItem == "Item2")
            {
                Onfreeze = false;
                status = 2;
            }
        }
    }

}
