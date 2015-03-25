using UnityEngine;
using System.Collections;

public class Boar_Move_Chase: MonoBehaviour {

	public float speed;
	private bool isFacingRight;

	private Transform player;

	void OnEnable()
	{
		//init values
		speed = 0.0f;
	}

	void OnDisable()
	{
		player = null;

		isFacingRight = false;
		speed = 0.0f;
	}

	public void Update()
	{
		moveHorizontally ();
	}

	void moveHorizontally()
	{
		//move to player's x position
		if(player != null)
		{
			//player is to the left of us, send velocity to the left
			if(player.position.x <= transform.position.x)
			{
				rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
				speed -= 0.3f;	//accelerate to the left
			}

			//player is to the right of us, send velocity to the right
			else if(player.position.x >= transform.position.x)
			{
				rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
				speed += 0.3f;	//accelerate to the right
			}
		}

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
	
	public void setPlayer(Transform playerTransform) { player = playerTransform; }

	public bool getFacingRight() { return isFacingRight; }
	public void setFacingRight(bool right) { isFacingRight = right; }
}
