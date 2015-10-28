using UnityEngine;
using System.Collections;

public class PlayerMovment : MonoBehaviour {
	// moves the player

	public float speed = 5f;
	public Animator anim;

	float h;
	float v;
	Vector2 movement;
	bool isWall = false;
	string colliderName = "none";
	
	void Update () {
		// collect inputs
		h = Input.GetAxisRaw ("Horizontal");
		v = Input.GetAxisRaw ("Vertical");
		anim.SetFloat("Direction", h);

		// figure boundoury collsions

		movement = new Vector2 (h, v);

		// left/right collsion
		if (colliderName == "BoundsLeft" && h < -0.1f || colliderName == "BoundsRight" && h > 0.1f) {
			movement = new Vector2 (0, v);
		}

		// top/bottom collison
		if (colliderName == "BoundsBottom" && v < -0.1f || colliderName == "BoundsTop" && v > 0.1f) {
			movement = new Vector2 (h, 0);
		}


		// TODO add momentem easying to the movement
		movement = movement * speed * Time.deltaTime;

		// apply forces
		transform.Translate(movement);

	}

	void OnTriggerEnter2D (Collider2D other) {
		// check if colliding with things
		colliderName = other.name;
	}

	void OnTriggerExit2D (Collider2D other) {
		colliderName = "none";
	}
}
