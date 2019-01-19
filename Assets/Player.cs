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

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        armLSprite = armL.GetComponent<SpriteRenderer>();
        armRSprite = armR.GetComponent<SpriteRenderer>();

        armLArm = armL.GetComponent<Arm>();
        armRArm = armR.GetComponent<Arm>();

        rb.gravityScale = 0;

        armLSprite.color = Color.white;
        armRSprite.color = Color.white;

        
    }

    private void Update()
    {
        

        armLSprite.color = armLArm.touching ? Color.green : Color.red; 
    }
}
