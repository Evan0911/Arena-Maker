using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    private int actualWave = 1;
    private int enemyLeft = 10;

    public Text waveNumberText;
    public Text enemyLeftText;

    public static WaveManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de WaveManager dans la scène");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        waveNumberText.text = actualWave.ToString();
        enemyLeftText.text = enemyLeft.ToString();
    }

    public int GetWave()
    {
        return actualWave;
    }

    public void EnemyDeath()
    {
        enemyLeft--;
        if (enemyLeft == 0)
        {
            NextWave();
        }
        enemyLeftText.text = enemyLeft.ToString();
    }

    public void NextWave()
    {
        actualWave++;
        enemyLeft = 10;
        waveNumberText.text = actualWave.ToString();
    }
}
