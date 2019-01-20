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

    private Hand handL;
    private Hand handR;
    private SpriteRenderer handLSpr;
    private SpriteRenderer handRSpr;

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

    public float jumpSpeed = 5f;
    public float midAirSpeed = 5f;

    private GameObject lGO;
    private GameObject rGO;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        armLSprite = armL.GetComponent<SpriteRenderer>();
        armRSprite = armR.GetComponent<SpriteRenderer>();

        handL = armL.transform.GetChild(0).GetComponent<Hand>();
        handR = armR.transform.GetChild(0).GetComponent<Hand>();

        handLSpr = handL.GetComponent<SpriteRenderer>();
        handRSpr = handR.GetComponent<SpriteRenderer>();

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

        //Setting alpha like a lazy boi
        Color tmp = armLSprite.color;
        tmp.a = 0.2f;
        armLSprite.color = tmp;

        tmp = armRSprite.color;
        tmp.a = 0.2f;
        armRSprite.color = tmp;

        //Input
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

        //move in air

        if (lC && !lHold)
        {
            rb.AddForce(Vector2.left * midAirSpeed);
        }

        if (rC && !rHold)
        {
            rb.AddForce(Vector2.right * midAirSpeed);
        }

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
        if (lRel)
        {
            if(lHold && armLArm.touching)
            {
                rb.gravityScale = 1;
                rb.velocity = transform.up * jumpSpeed;
            }

            lHold = false;
        }
        if (rRel)
        {
            if (rHold && armRArm.touching)
            {
                rb.gravityScale = 1;
                rb.velocity = transform.up * jumpSpeed;
            }
            rHold = false;
        }

        if (lHold && rHold)
        {
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
            handLSpr.sprite = handL.closed;
            handRSpr.sprite = handR.closed;
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

            handLSpr.sprite = handL.closed;
            lGO = armLArm.otherObj;
        }
        else
        {
            handLSpr.sprite = handL.open;
            lGO = null;
        }

        if (rHold)
        {
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;

            rGO = armRArm.otherObj;

            Vector3 pos = armR.transform.position;
            Vector3 otherPos = rGO.transform.position;
            transform.Rotate(Vector3.back, 3, Space.Self);
            pos -= armR.transform.position;
            transform.position += pos;

            handRSpr.sprite = handR.closed;
            
        }
        else
        {
            handRSpr.sprite = handR.open;
            rGO = null;
        }

        //Add jump force when releasing

        /*if (((rRel && armRArm.touching) || (lRel && armLArm.touching)) && (!lC && !rC))
        {
            rb.gravityScale = 1;
            rb.velocity = transform.up * jumpSpeed;
        }
        */

    }
}
