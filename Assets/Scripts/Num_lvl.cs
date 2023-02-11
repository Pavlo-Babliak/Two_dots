using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Num_lvl : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text =System.Convert.ToString(Application.loadedLevel);
    }
}
