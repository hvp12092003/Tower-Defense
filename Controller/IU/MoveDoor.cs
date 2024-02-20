using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class MoveDoor : MonoBehaviour
{
    public Transform doorLeft;
    public Transform doorRight;
    bool loadScene = false;
    int numScene;
    float count = 1f;

    // Audio
    protected AudioController audioController;
    private void Awake()
    {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
    }
    void Start()
    {
        audioController.PlaySFX(audioController.audioDoor);
        doorRight.transform.DOMove(new Vector3(-17, 0, 0), 1f);
        doorLeft.transform.DOMove(new Vector3(17, 0, 0), 1f);
    }
            bool setaudio = true;
    private void Update()
    {
        if (loadScene)
        {
            if (setaudio) { setaudio = false; audioController.PlaySFX(audioController.audioDoor); }
            doorRight.transform.DOMove(new Vector3(-6.5f, 0, 0), 0.2f);
            doorLeft.transform.DOMove(new Vector3(6.5f, 0, 0), 0.2f);
            count -= Time.deltaTime;
            if (count <= 0)
            {
                SceneManager.LoadScene(numScene);
            }
        }
    }
    public void CloseTheDoor(int scene)
    {
        loadScene = true;
        numScene = scene;
    }
}
