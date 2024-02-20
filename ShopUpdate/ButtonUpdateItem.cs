using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonUpdateItem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI numstar;

    public enum Options
    {
        Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item8
    }
    public Options selectedKindOfITem;
    // Audio
    protected AudioController audioController;
    private void Awake()
    {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
    }

    public void UpdateLvItem()
    {
        switch (selectedKindOfITem)
        {
            case Options.Item1:
                if (GameManager.amountStar > 0 && GameManager.lvCurrentItem1 < 5)
                {
                    audioController.PlaySFX(audioController.audioButJe);
                    GameManager.lvCurrentItem1++;
                    GameManager.amountStar--;
                    numstar.text = GameManager.lvCurrentItem1.ToString();
                }
                break;
            case Options.Item2:
                if (GameManager.amountStar > 0 && GameManager.lvCurrentItem2 < 5)
                {
                    audioController.PlaySFX(audioController.audioButJe);
                    GameManager.lvCurrentItem2++;
                    GameManager.amountStar--;
                    numstar.text = GameManager.lvCurrentItem2.ToString();
                }
                break;
            case Options.Item3:
                if (GameManager.amountStar > 0 && GameManager.lvCurrentItem3 < 5)
                {
                    audioController.PlaySFX(audioController.audioButJe);
                    GameManager.lvCurrentItem3++;
                    GameManager.amountStar--;
                    numstar.text = GameManager.lvCurrentItem3.ToString();
                }
                break;
            case Options.Item4:
                if (GameManager.amountStar > 0 && GameManager.lvCurrentItem4 < 5)
                {
                    audioController.PlaySFX(audioController.audioButJe);
                    GameManager.lvCurrentItem4++;
                    GameManager.amountStar--;
                    numstar.text = GameManager.lvCurrentItem4.ToString();
                }
                break;
            case Options.Item5:
                if (GameManager.amountStar > 0 && GameManager.lvCurrentItem5 < 5)
                {
                    audioController.PlaySFX(audioController.audioButJe);
                    GameManager.lvCurrentItem5++;
                    GameManager.amountStar--;
                    numstar.text = GameManager.lvCurrentItem5.ToString();
                }
                break;
            case Options.Item6:
                if (GameManager.amountStar > 0 && GameManager.lvCurrentItem6 < 5)
                {
                    audioController.PlaySFX(audioController.audioButJe);
                    GameManager.lvCurrentItem6++;
                    GameManager.amountStar--;
                    numstar.text = GameManager.lvCurrentItem6.ToString();
                }
                break;
            case Options.Item7:
                if (GameManager.amountStar > 0 && GameManager.lvCurrentItem7 < 5)
                {
                    audioController.PlaySFX(audioController.audioButJe);
                    GameManager.lvCurrentItem7++;
                    GameManager.amountStar--;
                    numstar.text = GameManager.lvCurrentItem7.ToString();
                }
                break;
            case Options.Item8:
                if (GameManager.amountStar > 0 && GameManager.lvCurrentItem8 < 5)
                {
                    audioController.PlaySFX(audioController.audioButJe);
                    GameManager.lvCurrentItem8++;
                    GameManager.amountStar--;
                    numstar.text = GameManager.lvCurrentItem8.ToString();
                }
                break;
        }
    }
    public void FixedUpdate()
    {
        switch (selectedKindOfITem)
        {
            case Options.Item1:
                numstar.text = GameManager.lvCurrentItem1.ToString();
                break;
            case Options.Item2:
                numstar.text = GameManager.lvCurrentItem2.ToString();
                break;
            case Options.Item3:
                numstar.text = GameManager.lvCurrentItem3.ToString();
                break;
            case Options.Item4:
                numstar.text = GameManager.lvCurrentItem4.ToString();
                break;
            case Options.Item5:
                numstar.text = GameManager.lvCurrentItem5.ToString();
                break;
            case Options.Item6:
                numstar.text = GameManager.lvCurrentItem6.ToString();
                break;
            case Options.Item7:
                numstar.text = GameManager.lvCurrentItem7.ToString();
                break;
            case Options.Item8:
                numstar.text = GameManager.lvCurrentItem8.ToString();
                break;
        }
    }
}
