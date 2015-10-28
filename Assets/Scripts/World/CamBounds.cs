using UnityEngine;
using System.Collections;

public class CamBounds : MonoBehaviour {

	public Transform boundsLeft, boundsRight, boundsTop, boundsBottom;
	public Transform killLeft, killRight, killTop, killBottom;

	public float padding = 2;
	public float killPosOffset = 5;
	public float killSizeOffset = 5;


	Camera cam;
	Vector3 rightTop;
	Vector3 leftBottom;

	Vector2 temp;
	Vector2 s;

	bool top, right, left, bottom;

	void Awake ()
	{
		cam = Camera.main.GetComponent<Camera>();
	}

	void Start()
	{
		ScreenToWorld ();
		ScreenBounds ();
	}

	public void ScreenToWorld ()
	{
		// calculate the world cords of the top bottem left right of the screen
		rightTop = cam.ViewportToWorldPoint (new Vector3 (1, 1, 0));
		leftBottom = cam.ViewportToWorldPoint (new Vector3 (0, 0, 0));
				                                               
	}

	public void ScreenBounds ()
	{
		// collider positions + padding
		boundsLeft.position = new Vector3 (leftBottom.x - padding, 0, 0);
		boundsRight.position = new Vector3 (rightTop.x + padding, 0, 0);
		boundsTop.position = new Vector3 (0, rightTop.y + padding, 0);
		boundsBottom.position = new Vector3 (0, leftBottom.y - padding, 0);

		killLeft.position = new Vector3 (leftBottom.x - killPosOffset, 0, 0);
		killRight.position = new Vector3 (rightTop.x + killPosOffset, 0, 0);
		killTop.position = new Vector3 (0, rightTop.y + killPosOffset, 0);
		killBottom.position = new Vector3 (0, leftBottom.y - killPosOffset, 0);



		// set the size of the bounds
		BoxCollider2D b;

		// left side bounds
		b = boundsLeft.GetComponent<BoxCollider2D> ();
		b.size = new Vector2 (1, rightTop.y - leftBottom.y);

		// right side bounds
		b = boundsRight.GetComponent<BoxCollider2D> ();
		b.size = new Vector2 (1, rightTop.y - leftBottom.y);

		// top side bounds
		b = boundsTop.GetComponent<BoxCollider2D> ();
		b.size = new Vector2 (rightTop.x - leftBottom.x, 1);

		// bottom side bounds
		b = boundsBottom.GetComponent<BoxCollider2D> ();
		b.size = new Vector2 (rightTop.x - leftBottom.x, 1);

		// set kill bounds 

		// left side bounds
		b = killLeft.GetComponent<BoxCollider2D> ();
		b.size = new Vector2 (1, rightTop.y - leftBottom.y + killSizeOffset);
		
		// right side bounds
		b = killRight.GetComponent<BoxCollider2D> ();
		b.size = new Vector2 (1, rightTop.y - leftBottom.y + killSizeOffset);
		
		// top side bounds
		b = killTop.GetComponent<BoxCollider2D> ();
		b.size = new Vector2 (rightTop.x - leftBottom.x + killSizeOffset, 1);
		
		// bottom side bounds
		b = killBottom.GetComponent<BoxCollider2D> ();
		b.size = new Vector2 (rightTop.x - leftBottom.x + killSizeOffset, 1);


	}

	public Vector3 RandomPointOnScreen (float limitMinX, float limitMaxX, float limitMinY, float limitMaxY) 
	{
		float randomX = Random.Range (limitMinX, limitMaxX);
		float randomY = Random.Range (limitMinY, limitMaxY);

		Vector3 spawnPoint = cam.ViewportToWorldPoint (new Vector3 (randomX, randomY, 10));

		return spawnPoint;

	}

	// get the world cords from a screen point
	public Vector3 ScreenPoint (float pointX, float pointY, float pointZ) {

		Vector3 screenPoint = cam.ViewportToWorldPoint (new Vector3 (pointX, pointY, pointZ));

		return screenPoint;
	}

}
