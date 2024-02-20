using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyController : MonoBehaviour
{
    public CapsuleCollider2D capsuleCollider2D;
    public GameObject obj;

    private void Start()
    {
        capsuleCollider2D = transform.parent.GetComponent<CapsuleCollider2D>();
    }
    public void OnBox()
    {
        capsuleCollider2D.enabled = true;
    }
    public void Destroy()
    {
        Destroy(obj.gameObject);
    }
}
