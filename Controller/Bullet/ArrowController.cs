using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class ArrowController : BulletController
{
    public void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        box = this.GetComponent<BoxCollider2D>();
        box.enabled = false;
    }
    private void FixedUpdate()
    {
        Move();
        if (distance <= 0.1f) box.enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D boxOther)
    {
        if (boxOther.gameObject.tag == ("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
