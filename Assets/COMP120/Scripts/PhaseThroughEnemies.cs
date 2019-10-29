using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseThroughEnemies : PowerUpClass
{
    public override void PowerUp(GameObject[] enemyList)
	{
		foreach (GameObject enemy in enemyList)
        {
			enemy.GetComponent<EnemyController>().PhaseTouch();
		}
	}
}
