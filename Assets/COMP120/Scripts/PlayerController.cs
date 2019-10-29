using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
	public GameObject youLoseText;
	public Material redMaterial;
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(x, rb.velocity.y, y);

        rb.velocity = dir * speed;
    }
	
	public void Lose()
	{
		GetComponent<Renderer>().material = redMaterial;
		youLoseText.GetComponent<Text>().text = "YOU LOSE!";
		youLoseText.transform.GetChild(0).GetComponent<Text>().text = "YOU LOSE!";
		youLoseText.SetActive(true);
		Time.timeScale = 0;
	}
}
