using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class CreatEnemiesController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI waveE;

    public EnemyInMapVO enemyInMapVO;

    public GameObject newEnemy;
    public GameObject EnemyInCanva;

    public GameObject[] enemies;
    public GameObject[] boss;
    public Transform pointCreate;


    public float waveEnemy;
    public float numBoss;
    public float timeWave;
    public float timeCreatEnemy;
    public float countTemp = 0;

    public float amuontEnemy;
    public float amuontEnemyInAWave;
    public int numEnemy = 0;

    public bool gameStartted = false;
    public bool createE = false;
    public bool EndGame = false;

    public float FixAmountEnemy;
    public float lvMap;

    // Audio
    protected AudioController audioController;
    private void Awake()
    {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
    }
    private void Start()
    {
       // Instantiate(newEnemy, EnemyInCanva.transform);
       // Instantiate(newEnemy, pointCreate.position, pointCreate.rotation);
        enemyInMapVO = new EnemyInMapVO(GameManager.levelMap);
        amuontEnemy = enemyInMapVO.ArrayCount;

        waveEnemy = GameManager.waveEnemy;
        timeWave = GameManager.timeWave;
        numBoss = GameManager.boss;
        timeCreatEnemy = GameManager.timeCreatEnemy;

        FixAmountEnemy = amuontEnemy / waveEnemy;
        amuontEnemyInAWave = FixAmountEnemy;
        UpdateWaveText();
    }
    // Update is called once per frame
    void Update()
    {
        if (!EndGame)
        {
            if (GameManager.startCreatEnemies)
            {
                GameManager.startCreatEnemies = false;

                gameStartted = true;
                createE = true;
            }

            // when created enemy done will count time to next wave
            if (gameStartted && !createE)
            {
                timeWave -= Time.deltaTime;
                if (timeWave <= 0)
                {
                    timeWave = GameManager.timeWave;
                    gameStartted = false;
                    GameManager.createIconSkull = true;
                }
            }
            // when user klick IconSkull or icon start
            if (createE)
            {
                // time crate a Enemy
                timeCreatEnemy -= Time.deltaTime;
                if (timeCreatEnemy <= 0)
                {
                    //reset time create Enemy
                    timeCreatEnemy = GameManager.timeCreatEnemy;

                    // create Enemy
                    Instantiate(enemies[(int)enemyInMapVO.GetEntityInfo(numEnemy).numTypeE], pointCreate.position, pointCreate.rotation);

                    // increase positon Enemy in map
                    numEnemy++;

                    // count enemy in a wave
                    amuontEnemyInAWave--;
                    // when wave end will turn on skull and stop create enemy
                    if (amuontEnemyInAWave <= 0)
                    {
                        // reset numEnemy in wave
                        amuontEnemyInAWave = FixAmountEnemy;
                        createE = false;
                        //count waves
                        waveEnemy--;
                        UpdateWaveText();
                        // when go to last wave will create a Boss of levelmap
                        if (waveEnemy <= 0)
                        {
                            audioController.PlaySFX(audioController.audioBoss);
                            Instantiate(boss[(int)numBoss], pointCreate.position, pointCreate.rotation);
                            EndGame = true;
                        }
                    }
                }
            }
        }
    }
    public void UpdateWaveText()
    {
        waveE.text = waveEnemy.ToString();
    }
}
