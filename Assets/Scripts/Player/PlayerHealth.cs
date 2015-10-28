using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public float health = 1;
	public GameObject Exploed;
	bool dead = false;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		// this is like the worst way of doing it but it works
		// TODO set up script for dealing with the player and attach
		// it to the world manaager
		if (health <=0 && !dead){
			Death();
			dead = true;
		}

		 
	}

	void OnDisable () {
		Invoke("RestartLevel", 2);
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Enemy"){
			TakeDamage(1);
		}
	}

	public void TakeDamage (float h){
		health -= h;
	}
	
	public void Death (){
		gameObject.SetActive(false);
		//Instantiate(Exploed, transform.position,transform.rotation);
	}

	void RestartLevel() {
		Application.LoadLevel(Application.loadedLevel);
	}
}
