using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Linq;
using UnityEngine;

public class Item
{
    public string name;
    public float damage;
    public float time;
    public float slowSpeed;
    public float size;
    public float def;
    public float atk;
    public float timeAffect;
}
public class ItemController : MonoBehaviour
{
    public string nameItem;
    public int leverItem;
    protected ItemVO itemData;
    public Item item;

    public float damage;
    public float time;
    public float slowSpeed;
    public float size;
    public float def;
    public float atk;
    public float timeAffect;
    private CapsuleCollider2D capsuleCollider;
    void Start()
    {
        itemData = new ItemVO(nameItem);
        item = itemData.GetEntityInfo(leverItem);
        name = item.name;
        damage = item.damage;
        time = item.time;
        slowSpeed = item.slowSpeed;
        size = item.size;
        def = item.def;
        atk = item.atk;
        timeAffect = item.timeAffect;
        transform.localScale = new Vector3(item.size, item.size, item.size);
        capsuleCollider = transform.GetComponent<CapsuleCollider2D>();
        capsuleCollider.enabled = false;
        if (nameItem == "Item5" || nameItem == "Item6")
        {
            GameManager.decreaseDEF = def;
            GameManager.increaseATK = atk;
            if (nameItem == "Item5")
            {
                GameManager.OnItemDef = true;
            }
            else
            {
                GameManager.OnItemAtk = true;
            }
        }
    }
    private void Update()
    {
        if (nameItem == "Item2" || nameItem == "Item5" || nameItem == "Item6")
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                if (nameItem == "Item5")
                {
                    GameManager.decreaseDEF = 1;
                    GameManager.OnItemDef = false;
                }
                else if (nameItem == "Item6")
                {
                    GameManager.increaseATK = 1;
                    GameManager.OnItemAtk = false;
                }
                Destroy(gameObject);
            }
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}