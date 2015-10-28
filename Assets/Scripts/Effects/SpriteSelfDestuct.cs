using UnityEngine;
using System.Collections;

public class SpriteSelfDestuct : MonoBehaviour {

	float timeDeath;
	float despawnTime = 3;

	void Update () {
	//self destruct
	//	if (Time.time >= timeDeath)	
	//		SelfDistroy();
	
	}

	void OnEnable () {
		timeDeath = despawnTime + Time.time;
	}

	void OnDisable () {

	}

	void OnTriggerEnter2D (Collider2D other)
	{
		SelfDistroy();


	}

	public void SelfDistroy() {
		gameObject.SetActive(false);
	}

}
