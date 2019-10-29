using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PowerUpController : MonoBehaviour
{
	public GameObject cullPrefab, phasePrefab, freezePrefab;
	public GameObject youWinText;
	
	private void Start()
	{
		StartCoroutine(SpawnPowerUp(cullPrefab, 0));
		StartCoroutine(SpawnPowerUp(phasePrefab, 0));
		StartCoroutine(SpawnPowerUp(freezePrefab, 0));
	}
	
    public IEnumerator SpawnPowerUp(GameObject prefab, float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		Instantiate(prefab, GetRandomPoint(new Vector3(0,0,0) ,12.5f), Quaternion.identity);
	}
	
	public void RespawnPowerUp(GameObject powerUp)
	{
		if(powerUp.name.Contains("CullEnemiesPowerUp"))
		{
			Respawn(powerUp, cullPrefab);
			return;
		}
		
		if(powerUp.name.Contains("PhaseTouchPowerUp"))
		{
			Respawn(powerUp, phasePrefab);
			return;
		}
		
		if(powerUp.name.Contains("StopEnemiesPowerUp"))
		{
			Respawn(powerUp, freezePrefab);
			return;
		}
		
		Debug.Log(powerUp.name);
	}
	
	private void Respawn(GameObject obj, GameObject prefab)
	{
		Debug.Log(obj.name + " picked up. Respawning power up...");
		StartCoroutine(SpawnPowerUp(prefab, Random.Range(5,10)));
	}
	 
	public static Vector3 GetRandomPoint(Vector3 center, float maxDistance) {
        // Get Random Point inside Sphere which position is center, radius is maxDistance
        Vector3 randomPos = Random.insideUnitSphere * maxDistance + center;

        NavMeshHit hit; // NavMesh Sampling Info Container

        // from randomPos find a nearest point on NavMesh surface in range of maxDistance
        NavMesh.SamplePosition(randomPos, out hit, maxDistance, NavMesh.AllAreas);

        return hit.position;
	}
	
	public void PlayerWin()
	{
		youWinText.GetComponent<Text>().text = "YOU WIN!";
		youWinText.transform.GetChild(0).GetComponent<Text>().text = "YOU WIN!";
		youWinText.SetActive(true);
		Time.timeScale = 0;
	}
}
