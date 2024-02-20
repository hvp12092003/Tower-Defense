using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateJeInGame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtJe;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if (GameManager.je < jeUpdate)
        {
            je++;
            txtJe.text = je.ToString();
        }
        else if (je > jeUpdate)
        {
            je--;
            txtJe.text = je.ToString();
        }
        else
        {
            txtJe.text = je.ToString();
        }*/
    }
}
