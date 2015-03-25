using UnityEngine;
using System.Collections;

public class Boar_StateMachine : MonoBehaviour {

	private Stats_Enemy stats;

	public Boar_Move_Chase moveChase;
	public Boar_Move_Idle moveIdle;

	public CircleCollider2D aggroThreshold;
	public BoxCollider2D borderCollider;
	public Rigidbody2D rb2d;

	void Awake()
	{
		//stop rigidbody from rotating
		rb2d.fixedAngle = true;

		//initialize the movement scripts to inactive
		moveChase.enabled = false;
		moveIdle.enabled = false;

		//set first script (idle)
		moveIdle.enabled = true;

		//init stats sheet for boar, give stats sheet to receiver
		stats = new Stats_Enemy(7);
		//GetComponent<Receiver_Damage>().setStatsEnemy (stats);
	}

	//enter aggro threshold
	void OnTriggerEnter2D(Collider2D other)
	{
		//if other is player, aggro
		if(other.gameObject.tag == "Player")
		{
			//extract facing data to pass to chase script
			bool right = moveIdle.getFacingRight();

			moveIdle.enabled = false;
			moveChase.enabled = true;

			moveChase.setPlayer (other.transform);
			moveChase.setFacingRight(right);	//sync chase facing w/ last idle facing
		}
	}

	//exit aggro threshold
	void OnTriggerExit2D(Collider2D other)
	{
		//if other is player, stop aggro
		if(other.gameObject.tag == "Player")
		{
			//extract facing data to pass to idle script
			bool right = moveChase.getFacingRight();

			moveChase.enabled = false;
			moveIdle.enabled = true; 

			moveIdle.setFacingRight(right);		//sync idle facing w/ last chase facing
		}
	}
}
