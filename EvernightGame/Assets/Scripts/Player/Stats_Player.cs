using UnityEngine;
using System.Collections;

public class Stats_Player {

	private int currentHealth;
	private int maxHealth;
	
	public Stats_Player(int max)
	{
		currentHealth = max;
		maxHealth = max;
	}
	
	~Stats_Player()
	{
		//
	}
	
	public int changeHealth(int adjustment)
	{
		currentHealth += adjustment;
		return currentHealth; //JUSTIN
	}
	
	public int getMaxHealth(){ return maxHealth; }
	public int getCurHealth(){ return currentHealth; }
}
