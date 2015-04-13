using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	[System.Serializable]
	public class PlayerStats
	{
		public int healt = 100;
	}
	public int fallDeath = -20;
	public PlayerStats playerStats = new PlayerStats ();

	void Update(){
		if (transform.position.y <= fallDeath)
		{
			DamagePlayer(10000);
		}
	}

	public void DamagePlayer (int damage)
	{
		playerStats.healt -= damage;
		if (playerStats.healt <= 0) 
		{
			GameMaster.KillPlayer(this);
		}
	}



}
