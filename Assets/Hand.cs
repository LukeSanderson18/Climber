using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    public Sprite open;
    public Sprite closed;

    private SpriteRenderer spr;
	
	void Start () {
        spr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
