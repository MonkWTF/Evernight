using UnityEngine;
using System.Collections;

public class Sender_Damage_Trigger : MonoBehaviour {

	//first instance of collision detected
	void OnTriggerEnter2D(Collider2D other)
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
		//1pt damage sender
		case "Light_Lantern":
			dmg = -1;
			break;

		//instant kill
		case "Light_Brazier":
			dmg = int.MinValue;
			break;
			
		//this isn't a valid damage sender
		default:
			return;
		}
		
		//send damage to the colliding entity
		receiver.receiveDamage (dmg, gameObject.tag);
	}
	
	//contact is maintained
	void OnTriggerStay2D(Collider2D other)
	{
		OnTriggerEnter2D (other);
	}
}
