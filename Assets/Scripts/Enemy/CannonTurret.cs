using UnityEngine;
using System.Collections;

public class CannonTurret : MonoBehaviour {

	public GameObject target;
	public Animator anim;
	Vector3 relative;
	public float angle;

	// Use this for initialization
	void Start () {
		target = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {

		// find the angle between the player and the turret 0 to 180 on the right 0 to -180 on the left
		// dont know how this works but it dose
		relative = transform.InverseTransformPoint(target.transform.position);
		angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
		// change animation frame to point at player

		anim.SetFloat("angle", angle);


	}
}
