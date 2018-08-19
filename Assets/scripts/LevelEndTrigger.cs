using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndTrigger : MonoBehaviour {
	public Game_Manager game_Manager;
	float restart_delay = 1f;

	void OnTriggerEnter(Collider colliderInfo) {
		if(colliderInfo.tag == "Player")
		{
			//Debug.Log("Game End!");
			game_Manager.endLevel();
			Invoke("LoadNextLevel", restart_delay);
		}
	}

	void LoadNextLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	
}
