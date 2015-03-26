using UnityEngine;
using System.Collections;

public class characterController : MonoBehaviour {

	public float moveSpeed;
	private float moveVelocity;
	public float jumpHeight;
	//private Transform lightPosition;
	//public float lightMovement;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask environment;
	private bool isFacingRight;
	private bool grounded;
	//GameObject lantern; 

	//JUSTIN
	public Rigidbody2D rb2d;
	
	private Stats_Player stats;
	private Vector3 checkPoint = Vector3.zero;
	//JUSTIN

	//JUSTIN
	void handleOnDeath()
	{
		Stats_Player.onDeath -= handleOnDeath;
		respawn();
	}
	
	void respawn()
	{
		Stats_Player.onDeath += handleOnDeath;
		stats.changeHealth(stats.getMaxHealth());
		transform.position = checkPoint;
	}
	//JUSTIN

	// Use this for initialization
	void Awake(){
		isFacingRight = true; 
		//lantern = GameObject.FindGameObjectWithTag ("Lantern");
		//lightPosition = lantern.GetComponent<Transform> ();
		//lightMovement = lantern.transform.position.x;
		//lightPosition = lightMovement.position.x;

		//JUSTIN
		//constrain rotation
		rb2d.fixedAngle = true;

		//init stats
		stats = new Stats_Player(10);
		GetComponent<Receiver_Damage>().setStatsPlayer (stats);
		
		//set initial spawn
		checkPoint = transform.position;

		//subscribe to death event
		Stats_Player.onDeath += handleOnDeath;
		//JUSTIN
	}
	
	void Start () {
		
	}
	
	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, environment);
		// Update is called once per frame
	}
	
	void Update () {
		//moveVelocity = 0f;
		
		if (rigidbody2D.velocity.x > 0.0f && isFacingRight) {
			flip ();
		}
		else if(rigidbody2D.velocity.x > 0.0f &&!isFacingRight){
			flip();
		}
		
		if(Input.GetKeyDown (KeyCode.Space) && grounded){
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpHeight);
		}
		
		if(Input.GetKey (KeyCode.D)){
			//lightMovement *= 1f;
			moveVelocity =  moveSpeed;
			//rigidbody2D.velocity = new Vector2(moveSpeed, rigidbody2D.velocity.y);
		}
		
		if(Input.GetKey (KeyCode.A)){
			//lightMovement *= -1f;
			moveVelocity = -moveSpeed;
			//rigidbody2D.velocity = new Vector2(-moveSpeed, rigidbody2D.velocity.y);
		}
		rigidbody2D.velocity = new Vector2 (moveVelocity, rigidbody2D.velocity.y);
	}
	
	private void flip(){
		isFacingRight = !isFacingRight;
		
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}