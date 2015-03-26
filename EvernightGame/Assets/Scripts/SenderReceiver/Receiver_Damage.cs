using UnityEngine;
using System.Collections;

public class Receiver_Damage : MonoBehaviour {

	private Stats_Enemy enemyStats;
	private Stats_Player playerStats;

	public float timeSinceLastDamage;
	public float minTimeSinceLastDamage;

	void Awake()
	{
		minTimeSinceLastDamage = 1.5f;
		timeSinceLastDamage = minTimeSinceLastDamage;
	}

	void OnDisable()
	{
		enemyStats = null;
		playerStats = null;
	}

	void Update()
	{
		timeSinceLastDamage += Time.deltaTime;
	}

	public bool receiveDamage(int incomingDmg, string senderTag)
	{
		if(timeSinceLastDamage >= minTimeSinceLastDamage)
		{
			//check this object's tag
			switch(gameObject.tag)
			{
	
			//player is receiving damage
			case "Player":

				if(checkDmgPlayer(incomingDmg, senderTag))
				{
					return true;
				}
				return false;

			//enemy (of any type) is receiving damage
			case "Enemy_Boar":
			case "Enemy_Gremlin":
			case "Enemy_Deerman":

				if(checkDmgEnemy (incomingDmg, senderTag))
				{
					return true;
				}
				return false;

			//not a valid damage receiving target
			default:
				return false;
			}
		}

		return false;
	}

	private bool checkDmgPlayer(int incomingDmg, string senderTag)
	{
		//check sender object's tag to see if it can damage this entity
		switch(senderTag)
		{
		//sender can damage this entity
		case "Enemy_Boar":
		case "Enemy_Gremlin":
		case "Enemy_Deerman":
		//TODO -- expand list

			if(receiveDmgPlayer(incomingDmg))
			{
				timeSinceLastDamage = 0.0f;
				return true;
			}
			return false;
			
		//sender can't damage this entity (not in list above)
		default:
			return false;
		}
	}

	private bool receiveDmgPlayer(int incomingDmg)
	{
		//if player stats are not null, send damage
		if(playerStats != null)
		{
			playerStats.changeHealth (incomingDmg);
			return true;
		}

		return false;
	}

	private bool checkDmgEnemy(int incomingDmg, string senderTag)
	{
		//check sender object's tag to see if it can damage this entity
		switch(senderTag)
		{
		//sender can damage this entity
		case "Light_Lantern":
		case "Light_Brazier":
		//TODO -- expand list

			if(receiveDmgEnemy(incomingDmg))
			{
				timeSinceLastDamage = 0.0f;
				return true;
			}
			return false;
			
		//sender can't damage this entity (not in list above)
		default:
			return false;
		}
	}

	private bool receiveDmgEnemy(int incomingDmg)
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
