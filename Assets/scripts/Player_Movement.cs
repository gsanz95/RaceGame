using UnityEngine;

public class Player_Movement : MonoBehaviour {

    // Movement with forces
    public Rigidbody player_rigid_body;
    public float forward_force = 1000f;
    public float side_force = 50f;
    public float jump_force = 2000f;
    public float fall_gravity = 2000f;
    float ground_barrier = .5f;
    float ground_level = 1f;

    // Movement with velocity
    public float speed_modifier = 100f;
    public float side_speed_modifier = 15f;
    float horizontal_speed = 0f;
    float forward_speed = 0f;
    float vertical_speed = 0f;
    public bool isTouchingGround = true;
    public float max_intended_height = 1.8f;
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

        if(isTouchingGround) {
            DoJump();
        }

        Fall();

        SidewaysMovement();
        UpdatePosition();

        //Debug.Log(player_rigid_body.velocity);
        CheckIfBelowGround();
    }

    void ForwardMovement() {
        //player_rigid_body.AddForce(0, 0, forward_force * Time.deltaTime);
        forward_speed += side_speed_modifier;
        forward_speed *= Time.deltaTime;
    }

    void SidewaysMovement() {
        /*if ( Input.GetKey("d") )
        {
            player_rigid_body.AddForce(side_force * Time.deltaTime, 0 , 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            player_rigid_body.AddForce(-side_force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }*/
        
        horizontal_speed = Input.GetAxis("Horizontal") * speed_modifier;
        horizontal_speed *= Time.deltaTime;
    }

    void UpdatePosition() {
        movement = new Vector3(horizontal_speed, vertical_speed, forward_speed);
        player_updated_position = player_rigid_body.transform.position + movement;

        player_rigid_body.MovePosition(player_updated_position);
    }

    void CheckIfBelowGround() {
        if(player_rigid_body.position.y < ground_barrier) {
            FindObjectOfType<Game_Manager>().EndGame();
        }
    }

    void DoJump() {
        if(Input.GetKey("space")) {
                player_rigid_body.AddForce(0, jump_force * Time.deltaTime, 0);

            }
    }

    void Fall() {
        if(player_rigid_body.transform.position.y > max_intended_height && (player_rigid_body.position.y > ground_level)) {
            player_rigid_body.AddForce(0, -(fall_gravity * Time.deltaTime), 0);
        }
    }
}
