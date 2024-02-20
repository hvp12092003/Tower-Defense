using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanelController : MonoBehaviour
{
    [SerializeField] GameObject PausePanel;

    [SerializeField] GameObject OnSound;
    [SerializeField] GameObject OffSound;

    [SerializeField] GameObject OnMusic;
    [SerializeField] GameObject OffMusic;

    [SerializeField] GameObject OnShaking;
    [SerializeField] GameObject OffShaking;

    public RectTransform rec;

    public bool onPause = false;
    public int count = 0;

    // Audio
    protected AudioController audioController;
    MoveDoor moveDoor;

    private void Awake()
    {
        moveDoor = GameObject.FindGameObjectWithTag("Door").GetComponent<MoveDoor>();
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
    }
    private void Start()
    {

        if (!GameManager.music)
        {
            OnMusic.SetActive(false);
            OffMusic.SetActive(true);
        }
        if (!GameManager.SFX)
        {
            OnSound.SetActive(false);
            OffSound.SetActive(true);
        }
    }
    public void OnPausePanel()
    {
        MoveIUInGame.Instance.OnPausePanel();
    }
    public void ExitPause()
    {
        MoveIUInGame.Instance.OffPausePanel();
    }

    public void ButtonRestart()
    {
        audioController.PlaySFX(audioController.audioClick);
        Time.timeScale = 1;
        GAMEMANAGER.Instance.SaveDataModel();
        moveDoor.CloseTheDoor(GameManager.levelMap + 1);
    }

    public void ButtonBackManiMenu()
    {
        audioController.PlaySFX(audioController.audioClick);
        Time.timeScale = 1;
        Time.timeScale = 1;
        GAMEMANAGER.Instance.SaveDataModel();
        moveDoor.CloseTheDoor(0);
    }

    public void ButtonMusic()
    {
        if (GameManager.music)
        {
            GameManager.music = false;
            audioController.PlaySFX(audioController.audioClick);
            OnMusic.SetActive(false);
            OffMusic.SetActive(true);
        }
        else
        {
            GameManager.music = true;
            audioController.PlaySFX(audioController.audioClick);
            OnMusic.SetActive(true);
            OffMusic.SetActive(false);
        }
    }
    public void ButtonSound()
    {
        if (GameManager.SFX)
        {
            GameManager.SFX = false;
            audioController.PlaySFX(audioController.audioClick);
            OnSound.SetActive(false);
            OffSound.SetActive(true);
        }
        else
        {
            GameManager.SFX = true;
            audioController.PlaySFX(audioController.audioClick);
            OffSound.SetActive(false);
            OnSound.SetActive(true);
        }
    }
    public void ButtonShaking()
    {
        if (GameManager.shaking)
        {
            GameManager.shaking = false;
            audioController.PlaySFX(audioController.audioClick);
            OnShaking.SetActive(false);
            OffShaking.SetActive(true);
        }
        else
        {
            GameManager.shaking = true;
            audioController.PlaySFX(audioController.audioClick);
            OffShaking.SetActive(false);
            OnShaking.SetActive(true);
        }
    }
}
