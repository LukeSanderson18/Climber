using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pTest : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed = 10;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed);
    }
}
