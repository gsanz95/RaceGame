using UnityEngine;

public class Player_Collision : MonoBehaviour {
	public Player_Movement movement;

	void OnCollisionEnter(Collision collisionInfo) {
		if(collisionInfo.collider.tag == "Obstacle") {
			movement.enabled = false;
			FindObjectOfType<Game_Manager>().EndGame();
		}
	}
}
	