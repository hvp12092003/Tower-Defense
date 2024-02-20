using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UpdateHeart : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtHeart;

    // Start is called before the first frame update
    void Start()
    {
        txtHeart.text = GameManager.heart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        txtHeart.text = GameManager.heart.ToString();
    }
}
