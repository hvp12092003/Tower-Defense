using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WinPanelController : MonoBehaviour
{
    [SerializeField] GameObject OneStar;
    [SerializeField] GameObject TwoStar;
    [SerializeField] GameObject ThreeStar;

    // Start is called before the first frame update
    void Update()
    {
        if (GameManager.heart >= 15)
        {
            ThreeStar.SetActive(true);
        }
        else if (GameManager.heart == 10 && GameManager.heart <= 14)
        {
            TwoStar.SetActive(true);
        }
        else if (GameManager.heart < 10)
        {
            OneStar.SetActive(true);
        }
    }
}
