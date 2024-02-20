using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmountItemController : MonoBehaviour
{
    public Sprite[] sprite;
    public SpriteRenderer rendNum;
    public int numItem;

    // Start is called before the first frame update
    void Start()
    {
        rendNum = this.GetComponent<SpriteRenderer>();
    }

    
}
