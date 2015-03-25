using UnityEngine;
using System.Collections;

public class Receiver_Damage : MonoBehaviour {

	private Stats_Enemy enemyStats;
	private Stats_Player playerStats;

	void Awake()
	{
		//init stats objects to null
		//	-- state machine of parent game object passes an instance to this
		enemyStats = null;
		playerStats = null;
	}

	public bool receiveDamage(int incomingDmg, string senderTag)
	{
		//check this object's tag
		switch(gameObject.tag)
		{

		//player is receiving potential damage
		case "Player":

			//check sender object's tag to see if it can damage this entity
			switch(senderTag)
			{
			//sender can damage this entity
			case "Enemy":
			case "Boar":
			case "Gremlin":
			case "Deerman":
			//TODO -- add hazards
				return sendDmgToPlayer(incomingDmg);

			//sender can't damage this entity (not in list above)
			default:
				return false;
			}

		//enemy (of any type) is receiving potential damage
		case "Enemy":
		case "Boar":
		case "Gremlin":
		case "Deerman":

			//check sender object's tag to see if it can damage this entity
			switch(senderTag)
			{
				//sender can damage this entity
			case "Light":
			//TODO -- add hazards
				return sendDmgToEnemy (incomingDmg);

				//sender can't damage this entity (not in list above)
			default:
				return false;
			}

		//not a valid damage receiving target
		default:
			return false;
		}
	}

	private bool sendDmgToPlayer(int incomingDmg)
	{
		//if player stats are not null, send damage
		if(playerStats != null)
		{
			print(playerStats.changeHealth (incomingDmg)); //JUSTIN -- added print
			return true;
		}

		return false;
	}

	private bool sendDmgToEnemy(int incomingDmg)
	{
		//if enemy stats are not null, send damage
		if(enemyStats != null)
		{
			enemyStats.changeHealth (incomingDmg);
			return true;
		}

		return false;
	}

	public void setStatsEnemy(Stats_Enemy stats){ enemyStats = stats; }
	public void setStatsPlayer(Stats_Player stats){ playerStats = stats; }
}
