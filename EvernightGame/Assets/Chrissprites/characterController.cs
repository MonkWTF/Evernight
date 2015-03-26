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
	
	
	
	// Use this for initialization
	void Awake(){
		isFacingRight = true; 
		//lantern = GameObject.FindGameObjectWithTag ("Lantern");
		//lightPosition = lantern.GetComponent<Transform> ();
		//lightMovement = lantern.transform.position.x;
		//lightPosition = lightMovement.position.x;
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