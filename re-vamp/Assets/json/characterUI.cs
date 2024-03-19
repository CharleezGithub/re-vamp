using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;
using UnityEngine.TextCore.Text;

[Serializable]
public class characterUI : MonoBehaviour
{
    public static Character player;
    public TextMeshProUGUI name;
    public TextMeshProUGUI bio;
    public Image img;
    public index list;
    public int i = 0;


    void Start()
    {
        string path = "Assets/Json/index.json";
        StreamReader r = new StreamReader(path);
        string temp = r.ReadToEnd();
        r.Close();
        list = JsonUtility.FromJson<index>(temp);
    }
    // Start is called before the first frame update
    void Update()
    {
        string path = "Assets/Json/" + list.files[i] + ".json";
        StreamReader sr = new StreamReader(path);
        string temp = sr.ReadToEnd();
        player = JsonUtility.FromJson<Character>(temp);

        name.text = player.name;
        bio.text = player.bio;
        img.sprite = (Sprite)Resources.Load(list.files[i], typeof(Sprite));
    }

    public void NextChar()
    {
        if (i < list.files.Length - 1)
            i++;
        else
            i = 0;
    }
    public void PrevChar()
    {
        if (i > 0)
            i--;
        else
            i = 3;
    }

}
