using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpClass : MonoBehaviour
{
	private PowerUpController powerUpController;
	
	private void Start()
	{
		powerUpController = GameObject.Find("PowerUpController").GetComponent<PowerUpController>();
	}
	
	private void OnTriggerEnter(Collider coll)
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		
		PowerUp(enemies);
		powerUpController.RespawnPowerUp(gameObject);
        Destroy(gameObject);
	}
	
    public virtual void PowerUp(GameObject[] enemyList)
	{
        // Do Power Up Action
	}
	
	public void PlayerWins()
	{
		powerUpController.PlayerWin();
	}
}
