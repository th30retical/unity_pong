using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//max height: 2.3f
	//min height: -2.3f

	private const float Zero = 0.0f;
	static private float MoveSpeed = 0.1f;
	public KeyCode up;
	public KeyCode down;
	static private bool moved = false;

	//Updates at a fixed interval every update
	void FixedUpdate() {
		if (Ball.getPScore() == 10 || Ball.getCScore() == 10){
		
		} else {
			if (Input.GetKey (up) && !Input.GetKey(down)) {
			//if (Ball.getYComponent() > transform.position.y) {
				//move paddle up at a certain speed in accordance to the fps
				if (transform.position.y > 2.3f){
					MoveSpeed = Zero;
					transform.Translate(new Vector2(Zero,Zero));
				} else {
					MoveSpeed = 0.1f;
					transform.Translate(new Vector2(Zero,MoveSpeed));
					moved = true;
				}
			}
			//else if (Ball.getYComponent() < transform.position.y) {
			else if (Input.GetKey (down) && !Input.GetKey (up)) {
				//move paddle down at a certain speed in accordance to the fps
				if (transform.position.y < -2.3f){
					MoveSpeed = Zero;
					transform.Translate (new Vector2(Zero,Zero));
				} else {
					MoveSpeed = -0.1f;
					transform.Translate (new Vector2(Zero,MoveSpeed));
					moved = true;
				}
			}
		//print (transform.position.y);
		}
	}
	
	public static bool getMoved(){
		return moved;
	}
	
	public static void setMoved(bool x){
		moved = x;
	}
	
	public static float getSpeed() {
		return MoveSpeed;
	}
}