using UnityEngine;
using System.Collections;

public class PlayerMovementHandler : MonoBehaviour {

	public float mSpeed;
	private bool mFacingLeft;
	private bool mFacingRight;

	public Rigidbody2D rb2d;

	private Stats_Player stats;	//JUSTIN

	// Use this for initialization
	void Start () {
		rb2d.fixedAngle = true;

		mSpeed = 3.0f;

		mFacingRight = true;
		mFacingLeft = !mFacingRight;

		stats = new Stats_Player(10); //JUSTIN
		GetComponent<Receiver_Damage>().setStatsPlayer (stats); //JUSTIN
	}
	
	// Update is called once per frame
	void Update () {
		checkForMovement();
	}

	void checkForMovement()
	{
		float hVal = Input.GetAxis("Horizontal");

		//left
		if(hVal < 0)
		{
			if(mFacingRight)
			{
				transform.Rotate(0, 180, 0);
				mFacingLeft = !mFacingLeft;
				mFacingRight = !mFacingRight;
			}
		}
		//right
		else if(hVal > 0)
		{
			if(mFacingLeft)
			{
				transform.Rotate(0, 180, 0);
				mFacingLeft = !mFacingLeft;
				mFacingRight = !mFacingRight;
			}
		}

		transform.position += new Vector3(hVal * mSpeed * Time.deltaTime, 0.0f, 0.0f);
	}

	public bool getFacingLeft()
	{
		return mFacingLeft;
	}

	public bool getFacingRight()
	{
		return mFacingRight;
	}
}
