using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    public bool touching;
    private float timer;
    private bool testTouch;
    //public Transform otherObj;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8) //if touching wall
        {
            touching = true;
            testTouch = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8) //if touching wall
        {
            timer = 0.01f;
            testTouch = false;
        }
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0;
            if(!testTouch)
            touching = false;
        }
    }
}
