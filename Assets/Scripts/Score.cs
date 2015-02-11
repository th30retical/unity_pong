using System.Collections;
using UnityEngine;

public class Score : MonoBehaviour {

	private static int p_score = 0;
	private static int c_score = 0;
	private static string o = "P: " +p_score+"   C: "+c_score;

	void FixedUpdate(){
		
		guiText.text = o;
		//now print score onto GUItext
		//Debug.Log(o);
	}	

	public static void updateScore() {
		p_score = Ball.getPScore();
		c_score = Ball.getCScore();
		
		o = "P: " +p_score+"   C: "+c_score;
		//fix spacing
	
	}
	
}
