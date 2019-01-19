using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    public bool touching;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8) //if touching wall
        {
            touching = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8) //if touching wall
        {
            touching = false;
        }
    }
    
}
