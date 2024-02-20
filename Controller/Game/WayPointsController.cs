using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase;
using LTAUnityBase.Base.DesignPattern;

public class WayPointsController : MonoBehaviour
{
    [SerializeField]
    public static Transform[] points;

    private void Awake()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
