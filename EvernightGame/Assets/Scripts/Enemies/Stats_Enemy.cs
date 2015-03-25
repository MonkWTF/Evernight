using UnityEngine;
using System.Collections;

public class Stats_Enemy {

	private int currentHealth;
	private int maxHealth;

	public Stats_Enemy(int max)
	{
		currentHealth = max;
		maxHealth = max;
	}

	~Stats_Enemy()
	{
		//
	}

	public void changeHealth(int adjustment)
	{
		currentHealth += adjustment;
	}

	public int getMaxHealth(){ return maxHealth; }
	public int getCurHealth(){ return currentHealth; }
}
