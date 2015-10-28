using UnityEngine;
using System.Collections;

public class ObjectMove : MonoBehaviour {


	public float speed = 1;

	// move an object forword at a set speed
	void Update () {
		transform.Translate (Vector2.up * speed * Time.deltaTime);
	}




}
