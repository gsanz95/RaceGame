using UnityEngine;

public class Player_Collision : MonoBehaviour {
	public Player_Movement movement;

	void OnCollisionEnter(Collision collisionInfo) {
		//Debug.Log("Collision with " + collisionInfo.collider.tag);
		if(collisionInfo.collider.tag == "Obstacle") {
			movement.enabled = false;
			FindObjectOfType<Game_Manager>().EndGame();
		}
		if(collisionInfo.collider.tag == "Ground") {
			movement.isTouchingGround = true;
		}
	}

	void OnCollisionExit(Collision collisionInfo)
	{
			movement.isTouchingGround = false;
	}
}
	