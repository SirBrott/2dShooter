using UnityEngine;
using System.Collections;

[RequireComponent(typeof (EnemyManager))]
public class EnemyMovement : MonoBehaviour {
	
	public float speed = 5f;
	public GameObject playerShip;
	public Vector3 targetPos;

	float movement;
	Transform myTransform;
	float posOffset = 0f;

	Vector3 relative;
	float angle;
	Quaternion targetRotation;


	void Awake () {
		myTransform = transform;
		playerShip = GameObject.FindWithTag("Player");
	
	}

	void Update () {


		//myTransform.position = Vector3.MoveTowards(myTransform.position, targetPos, Time.deltaTime * speed);
		myTransform.Translate(Vector3.up * speed * Time.deltaTime);
		//myTransform.LookAt(playerShip.transform.position);

				
	}

	public void SetTarget (Vector3 target) {
		targetPos = target;
	}

}
