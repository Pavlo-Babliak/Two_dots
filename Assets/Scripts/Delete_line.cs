using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete_line : MonoBehaviour
{
    public void Delete() { Destroy(gameObject); }
    public void Destroy_trigger() { gameObject.GetComponent<EdgeCollider2D>().enabled = false; }
}
