using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour {
	bool game_end = false;
	float restart_delay = 1f;

	public void EndGame() {
		if(game_end == false) {
			game_end = true;
			//Debug.Log("Game Over!");

			Invoke("Restart",restart_delay);
		}
	}

	void Restart () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
