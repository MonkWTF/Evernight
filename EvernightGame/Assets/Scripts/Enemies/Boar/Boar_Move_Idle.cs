using UnityEngine;
using System.Collections;

public class Boar_Move_Idle : MonoBehaviour {

	public float speed;

	private float distanceFromSpawn;
	public float maxDistFromSpawn = 5.0f;

	private bool isFacingRight;

	void OnEnable()
	{
		//init values
		speed = 0.0f;
		distanceFromSpawn = 0.0f;
	}

	void OnDisable()
	{
		isFacingRight = false;
		speed = 0.0f;
	}

	public void Update()
	{
		//set random chance to move
		if(Random.value > 0.99f ? true : false)
		{
			moveHorizontally ();
		}
	}

	private void moveHorizontally()
	{
		//value of -1 or 1 (moves left or right)
		int isLeftOrRight = (Random.value > 0.5f) ? -1 : 1;
		if(distanceFromSpawn > maxDistFromSpawn && isLeftOrRight == 1)
		{
			return;		//if we're right of right bounds and moving right, return
		}
		else if(distanceFromSpawn < -maxDistFromSpawn && isLeftOrRight == -1)
		{
			return;		//if we're left of left bounds and moving left, return
		}

		//update speed and distance from spawn
		speed = (Random.value + 0.75f) * isLeftOrRight;
		distanceFromSpawn += speed;

		//apply new velocity
		rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);

		//moving right but facing left
		if(rigidbody2D.velocity.x > 0.0f && !isFacingRight)
		{
			flip();
		}
		//moving left but facing right
		else if(rigidbody2D.velocity.x < 0.0f && isFacingRight)
		{
			flip ();
		}
	}
	
	private void flip()
	{
		isFacingRight = !isFacingRight;

		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale; 
	}

	public bool getFacingRight() { return isFacingRight; }
	public void setFacingRight(bool right) { isFacingRight = right; }
}
