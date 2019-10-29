using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullEnemies : PowerUpClass
{
	private int counter = 0;
	
	public override void PowerUp(GameObject[] enemyList)
	{		
		foreach (GameObject enemy in enemyList)
        {
			if (counter % 5 == 0)
			{
				Destroy(enemy);
			}
			counter++;
		}
		
		if (enemyList.Length <= 1)
		{
			PlayerWins();
		}			
	}
}
