using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Educat : MonoBehaviour
{
    public GameObject[] Step_1 = new GameObject[2];
    public GameObject[] Step_2 = new GameObject[2];
    public GameObject hand1;
    public GameObject hand2;
    // Update is called once per frame
    private void Start()
    {
        if (!PlayerPrefs.HasKey("Education")) { PlayerPrefs.SetInt("Education", 0); }
        if (PlayerPrefs.GetInt("Education") == 1) { gameObject.SetActive(false); }
    }
    void FixedUpdate()
    {
        if (Step_1[0].name != "Dot" && Step_1[1].name != "Dot") { hand1.SetActive(false);hand2.SetActive(true); }
        if (Step_2[0].name != "Dot" && Step_2[1].name != "Dot") { hand2.SetActive(false); PlayerPrefs.SetInt("Education", 1); gameObject.SetActive(false); }
    }
}
