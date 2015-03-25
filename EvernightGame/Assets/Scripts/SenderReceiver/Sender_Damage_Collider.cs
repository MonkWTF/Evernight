using UnityEngine;
using System.Collections;

public class Sender_Damage_Collider : MonoBehaviour {

	//first instance of collision detected
	void OnCollisionEnter2D(Collision2D other)
	{
		//get handle on collider's damage receiver
		Receiver_Damage receiver;
		receiver = other.gameObject.GetComponent<Receiver_Damage>();
		if(receiver == null)
		{
			return;
		}

		//set damage amount based on tag of this object
		//
		//					-- IMPORTANT --
		//	dmg should be set as a negative number so that it will
		//	deduct from the receiver's health instead of add to it
		//
		int dmg = 0;
		switch(gameObject.tag)
		{

		//boar is sending damage
		case "Boar":
			dmg = -1;
			break;

		//TODO -- add more cases

		//this isn't a valid damage sender, send 0 damage
		default:
			dmg = 0;
			break;
		}

		//send damage to the colliding entity
		receiver.receiveDamage (dmg, gameObject.tag);
	}

	//contact is maintained
	void OnCollisionStay2D(Collision2D other)
	{
		//
	}
	       
	void OnCollisionExit2D(Collision2D other)
	{
		//
	}
}
