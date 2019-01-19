using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject armL;
    public GameObject armR;

    private SpriteRenderer armLSprite;
    private SpriteRenderer armRSprite;

    private Arm armLArm;
    private Arm armRArm;

    bool lC;                //held
    bool rC;

    bool lRel;              //released
    bool rRel;

    public float jumpSpeed = 5;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        armLSprite = armL.GetComponent<SpriteRenderer>();
        armRSprite = armR.GetComponent<SpriteRenderer>();

        armLArm = armL.GetComponent<Arm>();
        armRArm = armR.GetComponent<Arm>();

        rb.gravityScale = 0;

        armLSprite.color = Color.blue;
        armRSprite.color = Color.white;

    }

    private void Update()
    {
        armLSprite.color = armLArm.touching ? Color.green : Color.red;
        armRSprite.color = armRArm.touching ? Color.green : Color.red;

        lC = Input.GetMouseButton(0);
        rC = Input.GetMouseButton(1);

        lRel = Input.GetMouseButtonUp(0);
        rRel = Input.GetMouseButtonUp(1);

        //if either button pressed when you can attach, turn off gravity

        //Both
        if (lC && rC)
        {
            if (armLArm.touching && armRArm.touching)
            {
                return;
            }
        }
        //Left Arm
        if (armLArm.touching)
        {
            if (lC)
            {
                rb.gravityScale = 0;
                rb.velocity = Vector2.zero;
                Vector3 pos = armL.transform.position;
                transform.Rotate(Vector3.back, -3, Space.Self);
                pos -= armL.transform.position;
                transform.position += pos;
            }
        }

        //Right Arm
        if (armRArm.touching)
        {
            if (rC)
            {
                rb.gravityScale = 0;
                rb.velocity = Vector2.zero;
                Vector3 pos = armR.transform.position;
                transform.Rotate(Vector3.back, 3, Space.Self);
                pos -= armR.transform.position;
                transform.position += pos;
            }
        }


        if ((rRel || lRel) && (!lC && !rC))
        {
            rb.gravityScale = 1;
            rb.AddForce(transform.up * jumpSpeed);
        }
    }
}
