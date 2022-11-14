using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExp : MonoBehaviour
{
    public int exp;
    public int level;
    public int nextLevel;

    public Text levelUI;
    public Text nextLevelUI;

    public static PlayerExp instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerExp dans la scène");
            return;
        }

        instance = this;
    }

    public void Start()
    {
        levelUI.text = "Level : " + level.ToString();
        nextLevelUI.text = "Next level in " + (nextLevel-exp) + " exp";
    }

    public void GainExp(int _ExpToGain)
    {
        exp += _ExpToGain;
        if (exp >= nextLevel)
        {
            level++;
            exp -= nextLevel;
            levelUI.text = "Level : " + level.ToString();
        }
        nextLevelUI.text = "Next level in " + (nextLevel - exp) + " exp";
    }
}
