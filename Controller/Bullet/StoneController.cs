using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class StoneController : BulletController
{
    [SerializeField] private Animator Animator;
    [SerializeField] private CircleCollider2D circle;

    [Header("Attributes")]
    public float radius;
    float status = 0;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        circle = GetComponent<CircleCollider2D>();
        circle.enabled = false;
    }
    private void FixedUpdate()
    {
        Move();
        if (distance <= 0.1f) circle.enabled = true;
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D boxOther)
    {
        if (boxOther.gameObject.tag == ("Enemy"))
        {

            circle.radius = radius;
            status = 1;
            Animator.SetFloat("Status", status);
        }
    }
}
