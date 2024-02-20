using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkullController : MonoBehaviour
{
    int count = 0;

    [SerializeField] public Image imageSkull;

    [SerializeField] GameObject IconSkull;

    // bool startedGame = false;
    bool TurnOnSkull = false;

    public void OnIconSkull()
    {
        IconSkull.SetActive(true);
        TurnOnSkull = true;
    }
    public void OffIconSkull()
    {
        GameManager.startCreatEnemies = true;

        TurnOnSkull = false;
        IconSkull.SetActive(false);
        //reset image 100%
        imageSkull.fillAmount = 1;
    }


    private void FixedUpdate()
    {
        if (GameManager.createIconSkull)
        {
            GameManager.createIconSkull = false;
            OnIconSkull();
        }

        if (TurnOnSkull)
        {
            ActiveTime();
        }

        //move iconSkull
        count++;
        if (count < 10)
        {
            transform.position += new Vector3(0, 1, 0) * 0.006f;
        }
        else if (count > 10)
        {
            transform.position += new Vector3(0, -1, 0) * 0.006f;
            if (count >= 19) count = 0;
        }

    }
    float countTepm = 1;
    void ActiveTime()
    {
        countTepm -= Time.deltaTime;
        if (countTepm < 0)
        {
            countTepm = 1;
            imageSkull.fillAmount -= 0.05f;
            if (imageSkull.fillAmount <= 0) OffIconSkull();
        }
    }
}
