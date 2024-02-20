using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.PlayerLoop;

public class ButtonUpdateTower : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI numstar;
    public enum Options
    {
        Move, Speed, Range, Damge,
        Archer1, Archer2, Archer3, Archer4,
        Stone1, Stone2, Stone3, Stone4,
        Magic1, Magic2, Magic3, Magic4,
    }
    public Options selectedTower;

    // Audio
    protected AudioController audioController;
    private void Awake()
    {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
    }
   
    public void UpdateLvTower()
    {
        switch (selectedTower)
        {
            case Options.Move:
                if (GameManager.amountStar > 0 && GameManager.lvCurrentSupportMoveTower < 6)
                {
                    audioController.PlaySFX(audioController.audioButJe);
                    GameManager.lvCurrentSupportMoveTower++;
                    GameManager.amountStar--;
                }
                break;
            case Options.Speed:
                if (GameManager.amountStar > 0 && GameManager.lvCurrentSupportSpeedTower < 6)
                {
                    audioController.PlaySFX(audioController.audioButJe);
                    GameManager.lvCurrentSupportSpeedTower++;
                    GameManager.amountStar--;
                }
                break;
            case Options.Range:
                if (GameManager.amountStar > 0 && GameManager.lvCurrentSupportRangeTower < 6)
                {
                    audioController.PlaySFX(audioController.audioButJe);
                    GameManager.lvCurrentSupportRangeTower++;
                    GameManager.amountStar--;
                }
                break;
            case Options.Damge:
                if (GameManager.amountStar > 0 && GameManager.lvCurrentSupportDamgeTower <6)
                {
                    audioController.PlaySFX(audioController.audioButJe);
                    GameManager.lvCurrentSupportDamgeTower++;
                    GameManager.amountStar--;
                }
                break;
            case Options.Archer1:
                if (GameManager.amountStar > 0 && GameManager.lvCurrentArcher1Tower < 6)
                {
                    audioController.PlaySFX(audioController.audioButJe);
                    GameManager.lvCurrentArcher1Tower++;
                    GameManager.amountStar--;
                }
                break;
            case Options.Archer2:
                if (GameManager.amountStar > 0 && GameManager.lvCurrentArcher2Tower < 6)
                {
                    audioController.PlaySFX(audioController.audioButJe);
                    GameManager.lvCurrentArcher2Tower++;
                    GameManager.amountStar--;
                }
                break;
            case Options.Archer3:
                if (GameManager.amountStar > 0 && GameManager.lvCurrentArcher3Tower < 6)
                {
                    audioController.PlaySFX(audioController.audioButJe);
                    GameManager.lvCurrentArcher3Tower++;
                    GameManager.amountStar--;
                }
                break;
            case Options.Archer4:
                if (GameManager.amountStar > 0 && GameManager.lvCurrentArcher4Tower < 6)
                {
                    audioController.PlaySFX(audioController.audioButJe);
                    GameManager.lvCurrentArcher4Tower++;
                    GameManager.amountStar--;
                }
                break;
            case Options.Stone1:
                if (GameManager.amountStar > 0 && GameManager.lvCurrentStone1Tower < 6)
                {
                    audioController.PlaySFX(audioController.audioButJe);
                    GameManager.lvCurrentStone1Tower++;
                    GameManager.amountStar--;
                }
                break;
            case Options.Stone2:
                if (GameManager.amountStar > 0 && GameManager.lvCurrentStone2Tower < 6)
                {
                    audioController.PlaySFX(audioController.audioButJe);
                    GameManager.lvCurrentStone2Tower++;
                    GameManager.amountStar--;
                }
                break;
            case Options.Stone3:
                if (GameManager.amountStar > 0 && GameManager.lvCurrentMagic4Tower < 6)
                {
                    audioController.PlaySFX(audioController.audioButJe);
                    GameManager.lvCurrentStone3Tower++;
                    GameManager.amountStar--;
                }
                break;
            case Options.Stone4:
                if (GameManager.amountStar > 0 && GameManager.lvCurrentStone4Tower < 6)
                {
                    audioController.PlaySFX(audioController.audioButJe);
                    GameManager.lvCurrentStone4Tower++;
                    GameManager.amountStar--;
                }
                break;
            case Options.Magic1:
                if (GameManager.amountStar > 0 && GameManager.lvCurrentMagic1Tower < 6)
                {
                    audioController.PlaySFX(audioController.audioButJe);
                    GameManager.lvCurrentMagic1Tower++;
                    GameManager.amountStar--;
                }
                break;
            case Options.Magic2:
                if (GameManager.amountStar > 0 && GameManager.lvCurrentMagic2Tower <6)
                {
                    audioController.PlaySFX(audioController.audioButJe);
                    GameManager.lvCurrentMagic2Tower++;
                    GameManager.amountStar--;
                }
                break;
            case Options.Magic3:
                if (GameManager.amountStar > 0 && GameManager.lvCurrentMagic3Tower < 6)
                {
                    audioController.PlaySFX(audioController.audioButJe);
                    GameManager.lvCurrentMagic3Tower++;
                    GameManager.amountStar--;
                }
                break;
            case Options.Magic4:
                if (GameManager.amountStar > 0 && GameManager.lvCurrentMagic4Tower < 6)
                {
                    audioController.PlaySFX(audioController.audioButJe);
                    GameManager.lvCurrentMagic4Tower++;
                    GameManager.amountStar--;
                }
                break;
        }
    }
    public void FixedUpdate()
    {
        switch (selectedTower)
        {
            case Options.Move:
                numstar.text = GameManager.lvCurrentSupportMoveTower.ToString();
                break;
            case Options.Speed:
                numstar.text = GameManager.lvCurrentSupportSpeedTower.ToString();
                break;
            case Options.Range:
                numstar.text = GameManager.lvCurrentSupportRangeTower.ToString();
                break;
            case Options.Damge:
                numstar.text = GameManager.lvCurrentSupportDamgeTower.ToString();
                break;
            case Options.Archer1:
                numstar.text = GameManager.lvCurrentArcher1Tower.ToString();
                break;
            case Options.Archer2:
                numstar.text = GameManager.lvCurrentArcher2Tower.ToString();
                break;
            case Options.Archer3:
                numstar.text = GameManager.lvCurrentArcher3Tower.ToString();
                break;
            case Options.Archer4:
                numstar.text = GameManager.lvCurrentArcher4Tower.ToString();
                break;
            case Options.Stone1:
                numstar.text = GameManager.lvCurrentStone1Tower.ToString();
                break;
            case Options.Stone2:
                numstar.text = GameManager.lvCurrentStone2Tower.ToString();
                break;
            case Options.Stone3:
                numstar.text = GameManager.lvCurrentStone3Tower.ToString();
                break;
            case Options.Stone4:
                numstar.text = GameManager.lvCurrentStone4Tower.ToString();
                break;
            case Options.Magic1:
                numstar.text = GameManager.lvCurrentMagic1Tower.ToString();
                break;
            case Options.Magic2:
                numstar.text = GameManager.lvCurrentMagic2Tower.ToString();
                break;
            case Options.Magic3:
                numstar.text = GameManager.lvCurrentMagic3Tower.ToString();
                break;
            case Options.Magic4:
                numstar.text = GameManager.lvCurrentMagic4Tower.ToString();
                break;
        }
    }
}
