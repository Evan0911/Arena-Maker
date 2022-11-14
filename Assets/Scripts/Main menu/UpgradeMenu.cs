using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    private string saveSeparator = "%VALUE%"; //Faire une vérification que ce terme n'est pas utilisé si l'on sauvegarde une string
    string[] content;
    public Text expText;
    int[] carac;
    public Text resultText;

    void Start()
    {
        string saveString = File.ReadAllText(Application.dataPath + "/data.txt"); //pour lire
        content = saveString.Split(new[] { saveSeparator }, System.StringSplitOptions.None); //pour redécouper les données sauvegardés
        expText.text = content[1] + " exp";
        carac = new int[]
        {
            int.Parse(content[1]),
            int.Parse(content[2]),
            int.Parse(content[3]),
            int.Parse(content[4])
        };
    }

    public void Upgrade(int _Index)
    {
        if (carac[0] >= 10)
        {
            carac[_Index] += 10;
            carac[0] -= 10;
            Save();
            resultText.text = "L'Upgrade à bien été enregistré";
        }
    }

    void Save()
    {
        int i = 1;
        foreach(int uneCarac in carac)
        {
            content[i] = uneCarac.ToString();
            i++;
        }
        string saveString = string.Join(saveSeparator, content);
        File.WriteAllText(Application.dataPath + "/data.txt", saveString);
    }
}
