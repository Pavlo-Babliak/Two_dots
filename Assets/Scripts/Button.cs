using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
public class Button : MonoBehaviour
{
    int i;

    bool return_ads;
    bool Next_ads;
    bool Exit_main_ads;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Curent_lvl")) { PlayerPrefs.SetInt("Curent_lvl", 1); }
        if (Application.loadedLevel != 0) { i = GameObject.Find("Help").transform.childCount; }
        IronSource.Agent.init("16aef9ed5");

    }
    private void Start()
    {
        Vibration.Init();
        if (Application.loadedLevel >= 16) 
        {
            IronSource.Agent.loadInterstitial();
            IronSourceEvents.onInterstitialAdClosedEvent += InterstitialAdClosedEvent;
            IronSourceEvents.onInterstitialAdOpenedEvent += InterstitialAdOpenedEvent;
        }
    }

    void InterstitialAdClosedEvent()
    {
        IronSource.Agent.loadInterstitial();
        GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = true;
        if (Next_ads == true)
        {
            SceneManager.LoadScene(Convert.ToInt32(Application.loadedLevel) + 1);
            Next_ads = false;
        }
        if (Exit_main_ads == true)
        {      
            SceneManager.LoadScene(0);
            Exit_main_ads = false;
        }
        if (return_ads == true)
        {
            SceneManager.LoadScene(Application.loadedLevel);
            return_ads = false;
        }
    }

    public void InterstitialAdOpenedEvent()
    {
        GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = false;
    }

    public void Return() 
    {
        if (Application.loadedLevel >= 16)
        {
            if (Application.loadedLevel % 2 == 0)
            {
                if (IronSource.Agent.isInterstitialReady())
                {
                    return_ads = true;
                    IronSource.Agent.showInterstitial();
                }
                else
                {
                    Application.LoadLevel(Application.loadedLevel);
                }
            }
            else
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
        else
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
    public void Home() 
    {
        if (Application.loadedLevel >= 16)
        {
            if (Application.loadedLevel % 2 == 0)
            {
                if (IronSource.Agent.isInterstitialReady())
                {
                    Exit_main_ads = true;
                    IronSource.Agent.showInterstitial();
                }
                else
                {
                    Application.LoadLevel(0);
                }
            }
            else
            {
                Application.LoadLevel(0);
            }
        }
        else
        {
            Application.LoadLevel(0);
        }
    }
    public void Next() 
    {
        if (Application.loadedLevel >= 16)
        {
            if (Application.loadedLevel % 2 == 0)
            {
                if (IronSource.Agent.isInterstitialReady())
                {
                    Next_ads = true;
                    IronSource.Agent.showInterstitial();
                }
                else
                {
                    SceneManager.LoadScene(Convert.ToInt32(Application.loadedLevel) + 1);
                }
            }
            else
            {
                SceneManager.LoadScene(Convert.ToInt32(Application.loadedLevel) + 1);
            }
        }
        else
        {
            SceneManager.LoadScene(Convert.ToInt32(Application.loadedLevel) + 1);
        }
    }
    public void Exit_menu()
    {
        if (Application.loadedLevel >= 16)
        {
            if (Application.loadedLevel % 2 == 0)
            {
                if (IronSource.Agent.isInterstitialReady())
                {
                    Exit_main_ads = true;
                    IronSource.Agent.showInterstitial();
                }
                else
                {
                    Application.LoadLevel(0);
                }
            }
            else
            {
                Application.LoadLevel(0);
            }
        }
        else
        {
            Application.LoadLevel(0);
        }
    }

    public void Load_lvl()
    {
        if (PlayerPrefs.GetInt("Curent_lvl") < 101) { Application.LoadLevel(PlayerPrefs.GetInt("Curent_lvl")); }
        else { GameObject.Find("Win_game").transform.GetChild(0).gameObject.SetActive(true); }
    }

    public void Destroy_last_line()
    {
        if (PlayerPrefs.GetInt("Money") >= 15)
        {
            if (GameObject.Find("Line_" + Core.count_line))
            {
                GameObject.Find("Line_" + Core.count_line).GetComponent<Animator>().enabled = true;
                for (int k = 0; k < i; k++)
                {
                    if (GameObject.Find("Help").transform.GetChild(k).name == "Line_" + Core.count_line)
                    {
                        GameObject.Find("Help").transform.GetChild(k).name = "Line";
                    }
                }
                Core.count_line--;
                GameObject.Find("Main Camera").GetComponent<Core>().count_dot--;
                GameObject.Find("Count_Dots").GetComponent<TextMeshProUGUI>().text = System.Convert.ToString(GameObject.Find("Main Camera").GetComponent<Core>().count_dot + "/" + GameObject.Find("Count_Dots").GetComponent<Count_dots>().count_dots / 2);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 15);
                GameObject.Find("Money").GetComponent<Money>().SetMoney();
                
            }
        }
    }
    public void Help()
    {
        if (PlayerPrefs.GetInt("Money") >= 50)
        {
            int n = 0;
            if (GameObject.Find("Dot"))
            {
                while (GameObject.Find("Dot"))
                {
                    GameObject.Find("Dot").name = "Dot_" + n;
                    n++;
                }
            }

            for (int k = 0; k < i; k++)
            {
                if (GameObject.Find("Help").transform.GetChild(k).gameObject.activeSelf == false)
                {
                    Color32 col;
                    col = GameObject.Find("Help").transform.GetChild(k).GetComponent<LineRenderer>().startColor;
                    if (GameObject.Find("Help").transform.GetChild(k).name == "Line")
                    {
                        GameObject.Find("Help").transform.GetChild(k).GetComponent<LineRenderer>().startColor = new Color32(col.r, col.g, col.b, 100);
                        GameObject.Find("Help").transform.GetChild(k).GetComponent<LineRenderer>().endColor = new Color32(col.r, col.g, col.b, 100);
                        GameObject.Find("Help").transform.GetChild(k).gameObject.SetActive(true);
                        break;
                    }
                    if (k == i - 1)
                    {
                        GameObject.Find("Frame_help").SetActive(false);
                        break;
                    }

                }
            }
            for (int m = 0; m < n; m++)
            {
                GameObject.Find("Dot_" + m).name = "Dot";
            }
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 50);
            GameObject.Find("Money").GetComponent<Money>().SetMoney();
        }
    }
    public void Restart_game() { PlayerPrefs.DeleteAll(); GameObject.Find("Win_game").transform.GetChild(0).gameObject.SetActive(false); }
}
