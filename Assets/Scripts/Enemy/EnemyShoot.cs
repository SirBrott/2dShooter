using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour
{

	public GameObject bullet;
	public int numBullets = 10;
	public GameObject target;
	public float shotIntervul = 1f;
	public bool isShootPlayer = false;
	public float angle = 180f;
	Vector3 relative;
	float timer;
	Transform myTransform;

	void Start ()
	{
		myTransform = transform;
		target = GameObject.Find ("Player"); 
		ObjectPool.instance.AddToPool (bullet, numBullets);
	}

	void OnEnable ()
	{
		timer = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;

		if (isShootPlayer) {
			relative = transform.InverseTransformPoint (target.transform.position);
			angle = Mathf.Atan2 (relative.x, relative.y) * Mathf.Rad2Deg;

		}

		// every N seconds fire a shot
		if (timer > shotIntervul) {
			Fire (-angle);
			timer = 0f;
		}
	}

	void Fire (float rot) // move this to a gun controler
	{
		
		GameObject go = ObjectPool.instance.GetPool (bullet);
		if (go != null) {
			go.transform.position = myTransform.position;
			go.transform.rotation = myTransform.rotation * Quaternion.Euler (new Vector3 (0, 0, rot));
			go.SetActive (true);
		}

	}
}
