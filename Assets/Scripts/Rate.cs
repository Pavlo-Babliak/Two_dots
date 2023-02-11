using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Rate : MonoBehaviour
{
    public int i;
    public GameObject[] Im = new GameObject[5];
    public GameObject Rate_BOX;
    public void OpenMarket()
    {
        PlayerPrefs.SetInt("Rate", 1);
        Application.OpenURL("market://details?id=" + Application.identifier);
        Rate_BOX.active = false;
    }
    void FixedUpdate()
    {
        if (i == 0)
        {
            Im[0].GetComponent<Image>().color = new Color32(85, 85, 85, 255);
            Im[1].GetComponent<Image>().color = new Color32(85, 85, 85, 255);
            Im[2].GetComponent<Image>().color = new Color32(85, 85, 85, 255);
            Im[3].GetComponent<Image>().color = new Color32(85, 85, 85, 255);
            Im[4].GetComponent<Image>().color = new Color32(85, 85, 85, 255);
        }
        if (i == 1)
        {
            Im[0].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            Im[1].GetComponent<Image>().color = new Color32(85, 85, 85, 255);
            Im[2].GetComponent<Image>().color = new Color32(85, 85, 85, 255);
            Im[3].GetComponent<Image>().color = new Color32(85, 85, 85, 255);
            Im[4].GetComponent<Image>().color = new Color32(85, 85, 85, 255);
        }
        if (i == 2)
        {
            Im[0].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            Im[1].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            Im[2].GetComponent<Image>().color = new Color32(85, 85, 85, 255);
            Im[3].GetComponent<Image>().color = new Color32(85, 85, 85, 255);
            Im[4].GetComponent<Image>().color = new Color32(85, 85, 85, 255);
        }
        if (i == 3)
        {
            Im[0].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            Im[1].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            Im[2].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            Im[3].GetComponent<Image>().color = new Color32(85, 85, 85, 255);
            Im[4].GetComponent<Image>().color = new Color32(85, 85, 85, 255);
        }
        if (i == 4)
        {
            Im[0].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            Im[1].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            Im[2].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            Im[3].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            Im[4].GetComponent<Image>().color = new Color32(85, 85, 85, 255);
        }
        if (i == 5)
        {
            Im[0].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            Im[1].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            Im[2].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            Im[3].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            Im[4].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }
    public void B1() { i = 1; }
    public void B2() { i = 2; }
    public void B3() { i = 3; }
    public void B4() { i = 4; }
    public void B5() { i = 5; }
    public void Open_Rate_BOX() { Rate_BOX.active = true; }
    public void Exit_Rate_BOX() { Rate_BOX.active = false; }

}
