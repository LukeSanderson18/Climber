using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMovement : MonoBehaviour {

    public float speed = 1;
    public float distance = 1;

    public bool horizontal;
    float startY;
    float startX;
    Vector3 mov;

    private void Start()
    {
        startY = transform.position.y;
        startX = transform.position.x;
    }

    void Update()
    {
        if (horizontal)
        {
            mov = new Vector3(startX + Mathf.Sin(speed * Time.time) * distance, transform.position.y, transform.position.z);
        }
        else
        {
            mov = new Vector3(transform.position.x, startY + Mathf.Sin(speed * Time.time) * distance, transform.position.z);
        }
        transform.position = mov;
    }
}
