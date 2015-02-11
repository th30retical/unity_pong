using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
	private const float ZERO = 0.0f;
	private const float ONE = 0.1f;
	private const float INC = 0.11f;
	
	//horizontal speed
	static private float x = ZERO;
	static private float y = ZERO;

	//score
	static private int p_score = 0;
	static private int c_score = 0;

	//ball position
	static private float y_pos;
	static private float x_pos;

	//if the ball is moving
	static private bool mov = false;
	
	//who won the point
	//false = player, true = computer
	private bool won = false;

	void FixedUpdate ()
	{
		//check if score is 10
		//end game if score is 10 DUH
		if (p_score == 10 || c_score == 10){
			x=0;
			y=0;
		}
		if (!mov && !won && Player.getMoved()) {
			setSpeed(ONE, ONE);
			mov = true;
		} else if (!mov && won && Player.getMoved()) {
			setSpeed (-ONE, ONE);
			mov = true;
		}
		
		//make sure ball stays inside walls
		if (y_pos > 2.6 || y_pos < -2.6) {
			y = -y;
		}
		
		//move the ball
		transform.Translate (new Vector2 (x, y));

		//update the y and x position
		y_pos = transform.position.y;
		x_pos = transform.position.x;
	
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		//check where on the paddle the ball hit
		string name = collision.collider.name;
		//Debug.Log(collision.contacts.GetValue);
		Debug.Log (Player.getSpeed());
		if (name == "P1_paddle") {
			if (y < 0 && Player.getSpeed() < 0) {
				setSpeed (-x, -INC);
			} else if (y < 0 && Player.getSpeed() > 0) {
				setSpeed (-x, -ONE);
			} else if (y > 0 && Player.getSpeed() < 0) {
				setSpeed (-x, ONE);
			} else if (y > 0 && Player.getSpeed () > 0) {
				setSpeed (-x, INC);
			} else if (y < 0 && Player.getSpeed () == 0) {
				setSpeed (-x, -ONE);
			} else if (y > 0 && Player.getSpeed () == 0) {
				setSpeed (-x, ONE);
			}
		} else if (name == "P2_paddle") {
			if (y < 0 && Computer.getSpeed() < 0) {
				setSpeed (-x, -INC);
			} else if (y < 0 && Computer.getSpeed() > 0) {
				setSpeed (-x, -ONE);
			} else if (y > 0 && Computer.getSpeed() < 0) {
				setSpeed (-x, ONE);
			} else if (y > 0 && Computer.getSpeed () > 0) {
				setSpeed (-x, INC);
			} else if (y < 0 && Computer.getSpeed () == 0) {
				setSpeed (-x, -ONE);
			} else if (y > 0 && Computer.getSpeed () == 0) {
				setSpeed (-x, ONE);
			}
		} 
		else if (name == "Left_bar") {
			setSpeed(ZERO, ZERO);
			mov = false;
			Player.setMoved(false);
			c_score += 1;
			Score.updateScore ();
			won = false;
			restart (won);
		} else if (name == "Right_bar") {
			setSpeed (ZERO, ZERO);
			mov = false;
			Player.setMoved(false);
			p_score += 1;
			Score.updateScore ();
			won = true;
			restart (won);
			}
	}

	public static bool getMoving ()
	{
		return mov;
	}
	
	public static float getYComponent ()
	{
		return y_pos;
	}

	public static float getXComponent ()
	{
		return x_pos;
	}

	public static int getPScore ()
	{
		return p_score;
	}

	public static int getCScore ()
	{
		return c_score;
	}

	public static void setSpeed(float a, float b) {
		x = a;
		y = b;
	}
	
	private void restart(bool w) {
		if (w) {
			//player won
			transform.position = new Vector2(2.5f,0);
			x_pos = 2.5f;
			y_pos = 0;
		} else {
			//player lost
			transform.position = new Vector2(-2.5f,0);
			x_pos = -2.5f;
			y_pos = 0;
		}
		//transform.position = new Vector2(0,0);
		//x_pos = 0;
		//y_pos = 0;
	}
}
