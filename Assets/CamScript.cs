using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour {

    public Transform player;
    public float offset = 4f;
    public float speed = 5;
    float topY;

    private void Update()
    {
        if(player.transform.position.y + offset > topY)
        {
            topY = player.transform.position.y + offset;
        }

        
                
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(0, topY, -10), speed * Time.deltaTime);
    }
}
