﻿using UnityEngine;

public class Player_Movement : MonoBehaviour {

    public Rigidbody rigid_body;
    public float forward_force = 2000f;
    public float side_force = 500f;

    float ground_level = .99f;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        rigid_body.AddForce(0, 0, forward_force * Time.deltaTime);

        if ( Input.GetKey("d") )
        {
            rigid_body.AddForce(side_force * Time.deltaTime, 0 , 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rigid_body.AddForce(-side_force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if(rigid_body.position.y < ground_level)
        {
            FindObjectOfType<Game_Manager>().EndGame();
        }
    }
}