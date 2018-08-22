using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 2f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);

        //Debug.Log(Screen.width / 100f / 2f + 1f);

        // Checks to see if enemy has left the right hand side of the game.
        if (transform.position.x > (Screen.width / 100f) / 2f + 1f)
        {
            transform.position = new Vector3(-transform.position.x + 1f, transform.position.y, transform.position.z);
        }  
        // Checks to see if the enemy has left the left hand side of the game.
        else if(transform.position.x < (-Screen.width / 100f) / 2f - 1f)
        {
            transform.position = new Vector3(-transform.position.x - 1f, transform.position.y, transform.position.z);
        }
	}
}
