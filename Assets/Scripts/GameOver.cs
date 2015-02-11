using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	void FixedUpdate() {
		if (Ball.getCScore() == 10){
			guiText.text = "GAME OVER";
		} else if (Ball.getPScore() == 10){
			guiText.text = "YOU WIN";
		}
	}
}
