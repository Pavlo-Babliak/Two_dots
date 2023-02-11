using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    void Start()
    {
        if (!PlayerPrefs.HasKey("Money")) { PlayerPrefs.SetInt("Money", 0); }
        gameObject.GetComponent<TextMeshProUGUI>().text = System.Convert.ToString(PlayerPrefs.GetInt("Money"));
    }
    public void SetMoney()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = System.Convert.ToString(PlayerPrefs.GetInt("Money"));
    }
}
