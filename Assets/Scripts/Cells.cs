using UnityEngine;

public class Cells : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "line")
        {
            gameObject.name = "Cell_blocked";
            if (gameObject.transform.childCount == 1) { gameObject.transform.GetChild(0).name = "Dot_blocked"; }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "line")
        {
            gameObject.name = "Cell";
            if (gameObject.transform.childCount == 1) { gameObject.transform.GetChild(0).name = "Dot"; }
        }
    }
}
