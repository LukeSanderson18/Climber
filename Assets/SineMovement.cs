using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMovement : MonoBehaviour {

    public float speed = 1;
    public float distance = 1;
    float startY;

    private void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        Vector3 mov = new Vector3(transform.position.x, startY + Mathf.Sin(speed * Time.time) * distance, transform.position.z);
        transform.position = mov;
    }
}
