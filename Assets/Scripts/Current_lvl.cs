using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Current_lvl : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = System.Convert.ToString(PlayerPrefs.GetInt("Curent_lvl"));
    }
}
