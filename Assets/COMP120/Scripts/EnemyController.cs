using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;
    public bool touchedPlayer = false;
    public bool canEnemyTouch = true;
	public Material redMaterial;
    private bool freeze = false;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (!touchedPlayer && !freeze)
        {
            agent.SetDestination(target.transform.position);
        } else
        {
            agent.ResetPath();
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Player") && canEnemyTouch)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<EnemyController>().touchedPlayer = true;
            }

            touchedPlayer = true;
            Debug.Log("Enemy wins!");
			coll.gameObject.GetComponent<PlayerController>().Lose();
        }
    }

    public void Freeze()
    {
        StartCoroutine(FreezeEnemies());
    }

    private IEnumerator FreezeEnemies()
    {
        freeze = true;
        yield return new WaitForSeconds(5);
        freeze = false;
    }

    public void PhaseTouch()
    {
        StartCoroutine(PhaseWait());

    }

    private IEnumerator PhaseWait()
    {
        canEnemyTouch = false;
        yield return new WaitForSeconds(5);
        canEnemyTouch = true;
    }
}