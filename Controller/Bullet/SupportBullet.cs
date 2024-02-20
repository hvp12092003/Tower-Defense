using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportBullet : BulletController
{
    // Update is called once per frame
    void FixedUpdate()
    {
        count++;
        if (count == 1) transform.position = new Vector3(target.position.x, target.position.y);
        if (count >= 5) Destroy(gameObject);
    }
}
