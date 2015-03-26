using UnityEngine;
using System.Collections;

public class Brazier_DetectPlayer : MonoBehaviour {

	//detect player's presence
	void OnCollisionTrigger2D(Collider2D other)
	{
		//is other object the player?
		if(other.gameObject.tag == "Player")
		{

		}
	}
}
