using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float jumpDist = 0.32f;

    private bool jumping = false;
    private Vector3 startingPos;

	// Use this for initialization
	void Start () {
        //Debug.Log(Screen.width);
        //Debug.Log(Screen.height);

        startingPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        // Movement logic.
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        if(!jumping)
        {
            //  The wizard didn't move.
            if (horizontalMovement != 0)
            {
                transform.position = new Vector2(
                    transform.position.x + (horizontalMovement > 0 ? jumpDist : -jumpDist),
                    transform.position.y);
                jumping = true;
            }
            if(verticalMovement != 0)
            {
                transform.position = new Vector2(
                    transform.position.x,
                    transform.position.y + (verticalMovement > 0 ? jumpDist : -jumpDist)
                    );
                jumping = true;
            }
        }
        else    
        {
            // The wizard did move.
            if (horizontalMovement == 0 && verticalMovement == 00)
            {
                jumping = false;
            }
        }


        // Keep wizard inside the window.
        //Debug.Log(-(Screen.height) / 100 / 2);
        if(transform.position.y < -((float)Screen.height) / 100 / 2)
        {
            // Checking for the lower bound in the Y axis.
            transform.position = new Vector3(transform.position.x, transform.position.y + jumpDist);
        }

        if (transform.position.y > ((float)Screen.height) / 100 / 2)
        {
            // Checking for the upper bound in the Y axis.
            transform.position = startingPos;
        }


        if (transform.position.x < -((float)Screen.width) / 100 / 2)
        {
            // Checking for the left bound in the X axis.
            transform.position = new Vector3(transform.position.x + jumpDist, transform.position.y);
        }

        if (transform.position.x > ((float)Screen.width) / 100 / 2)
        {
            // Checking for the right bound in the X axis.
            transform.position = new Vector3(transform.position.x - jumpDist, transform.position.y);
        }
    }
}
