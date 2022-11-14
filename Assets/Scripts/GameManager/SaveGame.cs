using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveGame : MonoBehaviour
{
    private string saveSeparator = "%VALUE%"; //Faire une vérification que ce terme n'est pas utilisé si l'on sauvegarde une string
    string[] content;

    public static SaveGame instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de SaveGame dans la scène");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        string saveString = File.ReadAllText(Application.dataPath + "/data.txt"); //pour lire
        content = saveString.Split(new[] { saveSeparator }, System.StringSplitOptions.None); //pour redécouper les données sauvegardés
        PlayerAttacks.instance.damage = int.Parse(content[3]);
        PlayerHealth.instance.maxHealth = int.Parse(content[2]);
        PlayerMovement.instance.speed = int.Parse(content[4]);
        PlayerExp.instance.exp = int.Parse(content[1]);
    }

    public void SaveOnGameOver(int _Exp, int _Wave)
    {
        content[0] = _Wave.ToString();
        content[1] = _Exp.ToString();
        string saveString = string.Join(saveSeparator, content);
        File.WriteAllText(Application.dataPath + "/data.txt", saveString);
        Debug.Log("Sauvegarde effectué");
    }
}
