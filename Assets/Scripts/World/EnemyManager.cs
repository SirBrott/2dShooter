using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyManager : MonoBehaviour
{

	// global public EnemyManager;

	public GameObject[] enemyShipGO;
	public int enemyPoolSize = 10;
	public GameObject bullet;
	public int numBullets = 10;

	//public Collider2D spawnArea;
	public bool spawnShip = false;
	public float spawnDelay;
	float nextSpawn = 0f;
	
	Vector3[] screenCords;	
	CamBounds camBounds;
	Vector3 relativePos;
	float angle;
	
	/*
		set up wave manager, new wave every # of spawns, pause for 5 secs, have timer
	*/

	void Start ()
	{
		camBounds = GetComponent<CamBounds> ();
		
		screenCords = new Vector3[16];
		SetScreenCords ();
		
		for (int i = 0; i < enemyShipGO.Length; i++) {
			ObjectPool.instance.AddToPool (enemyShipGO [i], enemyPoolSize);
		}

		ObjectPool.instance.AddToPool (bullet, numBullets);
		
	}
	
	void Update ()
	{	
		
		if (spawnShip && Time.time > nextSpawn) {
			
			SpawnEdge ();
			
			
			
			nextSpawn = Time.time + spawnDelay;
		}
	}


	void SpawnEnemy (int shipGO, Vector3 pos, float rot)
	{

		GameObject go = ObjectPool.instance.GetPool (enemyShipGO [shipGO]);

		if (go != null) {
			go.transform.position = pos;
			go.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, rot));
			go.SetActive (true);
		}

	}

	void SpawnEdge ()
	{

		// 12 13 14 15
		// 8  9  10 11
		// 4  5  6  7
		// 0  1  2  3

		// spawn enemy on a top postions
		// pick posiont 0, 1, 2, 3
		
		int [] temp = new int[] { 4, 8, 7, 11, 12, 13, 14, 15};

		int tempGO = Random.Range (0, enemyShipGO.Length);

		int tempPos = temp [Random.Range (0, temp.Length)];

		//int tempPos = 13;

		int tempDest = SetDestination (tempPos);

		//int tempDest = 1;


		//angle = Vector3.Angle(screenCords[tempPos], screenCords[tempDest]);

		relativePos = screenCords [tempDest] - screenCords [tempPos]; 
		angle = Mathf.Atan2 (relativePos.x, relativePos.y) * Mathf.Rad2Deg;

		// instatiat random enemy
		SpawnEnemy (tempGO, screenCords [tempPos], -angle);


	}
	
	void SpawnGround ()
	{
		// spawn background elemnets including turrests, trucks, and solders
	}


	int SetDestination (int value)
	{
		// set the destination based on sorce

		int output;
		int [] list;

		// 12 13 14 15
		// 8  9  10 11
		// 4  5  6  7
		// 0  1  2  3
	
		// set the list of good end pont for a starting point
		switch (value) {
		case 4:
			list = new int[] { 1, 2, 3, 5, 6, 7, 9, 10, 11, 13, 14, 15 };
			break;

		case 7:
			list = new int[] { 0, 1, 2, 4, 5, 6, 8, 9, 10, 12, 13, 14 };
			break;

		case 8:
			list = new int[] { 1, 2, 3, 5, 6, 7, 9, 10, 11, 13, 14, 15 };
			break;

		case 11:
			list = new int[] { 0, 1, 2, 4, 5, 6, 8, 9, 10, 12, 13, 14 };
			break;

		case 12:
			list = new int[] { 5, 6, 7, 9, 10, 11, 13, 14 };
			break;

		case 13:
		case 14:
			list = new int[] { 0, 1, 2, 3, 4, 5, 6,7, 8, 9, 10, 11};
			break;

		case 15:
			list = new int[]{ 0, 1, 2, 4, 5, 6, 8, 9, 10};
			break;

		default:
			return 0;
		}
			
		// pick a random output
		output = list [Random.Range (0, list.Length)];

		// return output
		return output;


	}

	void SetScreenCords ()
	{
		float [] screenNum;
		int x = 0;
		int y = 0;
		float depth = 100f;
		screenNum = new float[4];

		screenNum [0] = 0f;
		screenNum [1] = 0.333f;
		screenNum [2] = 0.666f;
		screenNum [3] = 1f;

		// 12 13 14 15
		// 8  9  10 11
		// 4  5  6  7
		// 0  1  2  3

		for (int i = 0; i < 16; i++) {

			Vector3 temp = camBounds.ScreenPoint (screenNum [x], screenNum [y], depth);

			screenCords [i] = new Vector3 (temp.x, temp.y, temp.z);

			x++;

			if (x == 4) {
				x = 0;
				y++;
			}
		}
	}
}
