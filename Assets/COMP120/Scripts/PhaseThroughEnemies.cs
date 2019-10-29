using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseThroughEnemies : MonoBehaviour
{
    private void OnTriggerEnter(Collider coll)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyController>().PhaseTouch();
        }

        Destroy(gameObject);
    }
}
