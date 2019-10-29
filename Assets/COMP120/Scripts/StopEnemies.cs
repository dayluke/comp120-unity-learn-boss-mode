using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopEnemies : MonoBehaviour
{
    private void OnTriggerEnter(Collider coll)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyController>().Freeze();
        }

        Destroy(gameObject);
    }
}
