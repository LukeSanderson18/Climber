using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject armL;
    public GameObject armR;

    private SpriteRenderer armLSprite;
    private SpriteRenderer armRSprite;

    private SpriteRenderer handL;
    private SpriteRenderer handR;

    private Arm armLArm;
    private Arm armRArm;

    bool lC;                //held
    bool rC;

    bool lRel;              //released
    bool rRel;

    bool lPre;              //pressed
    bool rPre;

    bool lHold;
    bool rHold;

    public float jumpSpeed = 5;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        armLSprite = armL.GetComponent<SpriteRenderer>();
        armRSprite = armR.GetComponent<SpriteRenderer>();

        handL = armL.transform.GetChild(0).GetComponent<SpriteRenderer>();
        handR = armR.transform.GetChild(0).GetComponent<SpriteRenderer>();

        armLArm = armL.GetComponent<Arm>();
        armRArm = armR.GetComponent<Arm>();

        rb.gravityScale = 0;

        armLSprite.color = Color.blue;
        armRSprite.color = Color.white;

    }

    private void Update()
    {
        //Inputs and the like.

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        if (lHold) armLSprite.color = Color.cyan;
        else { armLSprite.color = armLArm.touching ? Color.green : Color.red; }

        if (rHold) armRSprite.color = Color.cyan;
        else { armRSprite.color = armRArm.touching ? Color.green : Color.red; }

        lC = Input.GetMouseButton(0);
        rC = Input.GetMouseButton(1);

        lRel = Input.GetMouseButtonUp(0);
        rRel = Input.GetMouseButtonUp(1);

        lPre = Input.GetMouseButtonDown(0);
        rPre = Input.GetMouseButtonDown(1);


        //**********
        //  if either button pressed when you can attach, turn off gravity!!
        //**********

        //Player logic

        //Left Arm
        if (armLArm.touching)
        {
            if (lPre)
            {
                lHold = true;
            }
        }
        else
        {
            lHold = false;
            rb.gravityScale = 1;
        }

        //Right Arm
        if (armRArm.touching)
        {
            if (rPre)
            {
                rHold = true;
            }
        }
        else
        {
            rHold = false;
            rb.gravityScale = 1;
        }

        //if release button, l/rHold becomes false.
        if (lRel) lHold = false;
        if (rRel) rHold = false;

        if (lHold && rHold)
        {
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
            return;
        }

        //If successfully holding...
        if (lHold)
        {
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
            Vector3 pos = armL.transform.position;
            transform.Rotate(Vector3.back, -3, Space.Self);
            pos -= armL.transform.position;
            transform.position += pos;
        }
        if (rHold)
        {
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
            Vector3 pos = armR.transform.position;
            transform.Rotate(Vector3.back, 3, Space.Self);
            pos -= armR.transform.position;
            transform.position += pos;
        }

        //Add jump force when releasing
        if (((rRel && armRArm.touching) || (lRel && armLArm.touching)) && (!lC && !rC))
        {
            rb.gravityScale = 1;
            rb.velocity = transform.up * jumpSpeed;
            //rb.AddForce(transform.up * jumpSpeed,ForceMode2D.Impulse);
        }
    }
}
