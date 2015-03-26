using UnityEngine;
using System.Collections;

public class Stats_Player {

	private int currentHealth;
	private int maxHealth;
	private const int minHealth = 0;

	public delegate void DeathEvent();
	public static event DeathEvent onDeath;
	
	public Stats_Player(int max)
	{
		currentHealth = max;
		maxHealth = max;
	}
	
	~Stats_Player()
	{
		//
	}
	
	public void changeHealth(int adjustment)
	{
		currentHealth += adjustment;
		if(currentHealth <= minHealth)
		{
			currentHealth = minHealth;
			onDeath();
		}
	}
	
	public int getMaxHealth(){ return maxHealth; }
	public int getCurHealth(){ return currentHealth; }
}
