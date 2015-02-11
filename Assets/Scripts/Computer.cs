using UnityEngine;
using System.Collections;

public class Computer : MonoBehaviour {
	
	//max height: 2.3f
	//min height: -2.3f
	private const float Zero = 0.0f;
	static private float MoveSpeed = 0.1f;

	void FixedUpdate(){
		//follow ball position to move but slightly slower.

		if (!Ball.getMoving()){
			//if the ball isn't moving, don't do anything
		}
		else if (Ball.getYComponent() > transform.position.y) {
			//move paddle up at a certain speed in accordance to the fps
			if (transform.position.y > 2.3f){
				MoveSpeed = Zero;
				transform.Translate(new Vector2(Zero,Zero));
			} else {
				MoveSpeed = 0.1f;
				transform.Translate(new Vector2(Zero,MoveSpeed));
				
			}
		} 
		else if (Ball.getYComponent() < transform.position.y) {
			//move paddle down at a certain speed in accordance to the fps
			if (transform.position.y < -2.3f){
				MoveSpeed = Zero;
				transform.Translate (new Vector2(Zero, Zero));
			} else {
				MoveSpeed = -0.1f;
				transform.Translate (new Vector2(Zero,MoveSpeed));
			}
		}
	}
	
	public static float getSpeed() {
		return MoveSpeed;
	}
}
