using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float health = 1;
	public GameObject Exploed;
	float timeLife;
	bool bounds = false;
	float curentHelth;

	// Use this for initialization
	void OnEnable () {
		curentHelth = health;
	}
	
	// Update is called once per frame
	void Update () {
		if (curentHelth <= 0)
			 Death ();

	}

	void OnTriggerEnter2D (Collider2D other){

		if (other.gameObject.tag == "Bullet"){
			//TakeDamage(1);
			Remove();
		}
		if (other.gameObject.tag == "Kill"){
			Remove();
		}


	}

	public void TakeDamage (float h)
	{
		curentHelth -= h;
	}

	public void Remove (){

		//curentHelth = health;
		gameObject.SetActive(false);
	}

	public void Death ()
	{
		// activate exposion effect
	
		Remove();
	}
}
