using UnityEngine.UI;
using UnityEngine;

public class Score_Updater : MonoBehaviour {

	public Transform player_transform;
	public Text score_text;

	//Updated once per frame
	void Update() {
		score_text.text = player_transform.position.z.ToString("0");
	}
}
