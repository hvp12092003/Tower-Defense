using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public BoxCollider2D box;

    [Header("Attributes")]
    public float bulletSpeed = 0.02f;
    protected int count = 0;
    int countMove = 0;
    protected Transform target;
    protected Vector2 direction;
    public float damage;
    public float distance;

    // lay target
    public void SetTargGet(Transform _target)
    {
        target = _target;
    }
    public void TakeInforTowerArrcher(float damageTower)
    {
        damage = damageTower;
    }
    public void Move()
    {
        count++;
        if (!target) transform.position += transform.up * bulletSpeed;
        else
        {
            distance = Vector2.Distance(transform.position, target.position);
            direction = (target.position - transform.position);
            transform.up = direction;
            transform.position += new Vector3(direction.x, direction.y) * bulletSpeed;
            countMove++;
            if (countMove < 3)
            {
                transform.position += new Vector3(0, 2f) * bulletSpeed;
            }
        }
        if (count > 100)
        {
            Destroy(this.gameObject);
        }
    }
}
