using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{

	public enum FireMode
	{
		Single,
		Burst,
		Auto,
		Charge,
	}

	public FireMode fireMode = FireMode.Auto;
	public GameObject shot01;
	public int shotNum;
	public Transform shotPoint01;
	public float fireDelay = 1f;
	public string fireButton = "Fire1";
	public int burstNumber = 3;

	ObjectPool projectile;

	float timer;

	// shot controler
	bool canShoot = true;
	float burstCount = 0;
	
	// Use this for initialization
	void Start ()
	{

		ObjectPool.instance.AddToPool (shot01, shotNum);
	
	}
	
	// Update is called once per frame
	void Update ()
	{

		timer += Time.deltaTime;

		if (Input.GetButton (fireButton) && fireDelay < timer) {
			Fire ();
		}
			
	}
	void Fire () // move this to a gun controler
	{
		//Instantiate (shot01, shotPoint01.position, shotPoint01.rotation);
		GameObject go = ObjectPool.instance.GetPool (shot01);
		if (go != null) {
			go.transform.position = shotPoint01.position;
			go.transform.rotation = shotPoint01.rotation;
			go.SetActive (true);
		}
			
		timer = 0;
	}

}
