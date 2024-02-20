using UnityEngine;

public class MenuChooseLv : MonoBehaviour
{
    [SerializeField] GameObject MenuMain;
    [SerializeField] GameObject MenuChooseLvMap;
    [SerializeField] GameObject MenuShop;
    [SerializeField] GameObject MenuUpdate;

    // Audio
    protected AudioController audioController;
    private void Awake()
    {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
    }
    public void OpenShop()
    {
        audioController.PlaySFX(audioController.audioGoto);
        MoveMenu.Instance.OffMenuChooseLvMap();
        MoveMenu.Instance.OnShop();
    }
    public void OpenUpdate()
    {
        audioController.PlaySFX(audioController.audioGoto);
        MoveMenu.Instance.OnMenuUpdate();
        MoveMenu.Instance.OffMenuChooseLvMap();
    }
    public void Exit()
    {
        audioController.PlaySFX(audioController.audioGoto);
        MoveMenu.Instance.OffMenuChooseLvMap();
        MoveMenu.Instance.OnMenuMain();
    }
}
