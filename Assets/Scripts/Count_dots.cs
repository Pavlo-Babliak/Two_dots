using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Count_dots : MonoBehaviour
{
    public int count_dots;
   public void Count()
    {
        int i = 0;
        if (GameObject.Find("Dot")) 
        {
            while (GameObject.Find("Dot")) 
            {
                GameObject.Find("Dot").name = "Dot_" + i;
                i++;
            }
        }
        count_dots=i;
        gameObject.GetComponent<TextMeshProUGUI>().text = "0/" + i/2; 
        for(int k=0; k < i; k++) 
        {
            GameObject.Find("Dot_" + k).name = "Dot";
        }
    }
}
