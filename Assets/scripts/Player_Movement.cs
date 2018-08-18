using UnityEngine;

public class Player_Movement : MonoBehaviour {

    // Movement with forces
    public Rigidbody player_rigid_body;
    public float forward_force = 2000f;
    public float side_force = 500f;
    public float jump_force = 3000f;
    public float fall_gravity = 500f;
    float ground_level = .5f;

    // Movement with velocity
    public float speed_modifier = 100f;
    public float side_speed_modifier = 15f;
    float horizontal_speed = 0f;
    float forward_speed = 0f;
    float vertical_speed = 0f;
    public bool isTouchingGround = true;
    Vector3 movement;
    Vector3 player_updated_position;

	// Use this for initialization
	void Start ()
    {
	}

	
	// Update is called once per frame
	void FixedUpdate ()
    {
        ForwardMovement();

        //player_rigid_body.AddForce(0, 0, forward_force * Time.deltaTime);

        if(isTouchingGround) {
            /*if ( Input.GetKey("d") )
            {
                player_rigid_body.AddForce(side_force * Time.deltaTime, 0 , 0, ForceMode.VelocityChange);
            }

            if (Input.GetKey("a"))
            {
                player_rigid_body.AddForce(-side_force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }

            if(Input.GetKey("space")) {
                player_rigid_body.AddForce(0, jump_force * Time.deltaTime, 0);
            }*/

            if(Input.GetKey("space")) {
                player_rigid_body.AddForce(0, jump_force * Time.deltaTime, 0);

            }
        }

        if(player_rigid_body.transform.position.y > 1.8 && (player_rigid_body.position.y > 1)) {
            player_rigid_body.AddForce(0, -(fall_gravity * Time.deltaTime), 0);
        }

        SidewaysMovement();
        UpdatePosition();

        Debug.Log(player_rigid_body.transform.position);
        Debug.Log(player_rigid_body.velocity);

        if(player_rigid_body.position.y < ground_level) {
            FindObjectOfType<Game_Manager>().EndGame();
        }
    }

    void ForwardMovement() {
        forward_speed += side_speed_modifier;
        forward_speed *= Time.deltaTime;
    }

    void SidewaysMovement() {
        horizontal_speed = Input.GetAxis("Horizontal") * speed_modifier;
        horizontal_speed *= Time.deltaTime;
    }

    void UpdatePosition() {
        movement = new Vector3(horizontal_speed, vertical_speed, forward_speed);
        player_updated_position = player_rigid_body.transform.position + movement;

        player_rigid_body.MovePosition(player_updated_position);
    }
}
