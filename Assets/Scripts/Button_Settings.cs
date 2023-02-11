using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Settings : MonoBehaviour
{
    public Sprite[] Sound = new Sprite[2];
    public Sprite[] Music = new Sprite[2];
    public Sprite[] Vibro = new Sprite[2];
    public GameObject[] S_M_V = new GameObject[3];
    public GameObject Exit_box;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Sound")) { PlayerPrefs.SetInt("Sound", 0); }
        if (!PlayerPrefs.HasKey("Music")) { PlayerPrefs.SetInt("Music", 0); }
        if (!PlayerPrefs.HasKey("Vibro")) { PlayerPrefs.SetInt("Vibro", 0); }

        if (PlayerPrefs.GetInt("Sound") == 0) { S_M_V[0].GetComponent<Image>().sprite = Sound[0];}
        else { S_M_V[0].GetComponent<Image>().sprite = Sound[1];  }
        if (PlayerPrefs.GetInt("Music") == 0) { S_M_V[1].GetComponent<Image>().sprite = Music[0];  }
        else { S_M_V[1].GetComponent<Image>().sprite = Music[1];  }
        if (PlayerPrefs.GetInt("Vibro") == 0) { S_M_V[2].GetComponent<Image>().sprite = Vibro[0];  }
        else { S_M_V[2].GetComponent<Image>().sprite = Vibro[1]; }
    }
    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Exit_box.SetActive(true);
            }
        }
    }
    public void Sound_1()
    {
        if (PlayerPrefs.GetInt("Sound") == 0) { S_M_V[0].GetComponent<Image>().sprite = Sound[1]; PlayerPrefs.SetInt("Sound", 1); }
        else { S_M_V[0].GetComponent<Image>().sprite = Sound[0]; PlayerPrefs.SetInt("Sound", 0); }
    }
    public void Music_1()
    {
        if (PlayerPrefs.GetInt("Music") == 0) { S_M_V[1].GetComponent<Image>().sprite = Music[1]; PlayerPrefs.SetInt("Music", 1); }
        else { S_M_V[1].GetComponent<Image>().sprite = Music[0]; PlayerPrefs.SetInt("Music", 0); }
    }
    public void Vibro_1()
    {
        if (PlayerPrefs.GetInt("Vibro") == 0) { S_M_V[2].GetComponent<Image>().sprite = Vibro[1]; PlayerPrefs.SetInt("Vibro", 1); }
        else { S_M_V[2].GetComponent<Image>().sprite = Vibro[0]; PlayerPrefs.SetInt("Vibro", 0); }
    }
    public void EXIT_game() { Application.Quit(); }
}
