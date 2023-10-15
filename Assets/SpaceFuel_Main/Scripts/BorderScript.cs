using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Boost" || col.gameObject.tag == "PowerUp")
        {
            Destroy(col.gameObject);
        }
    }
}
