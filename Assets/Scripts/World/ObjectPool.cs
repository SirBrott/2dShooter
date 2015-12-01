using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
	
	/// <summary>
	/// Gobal instance refrance.
	/// </summary>
	public static ObjectPool instance;

	/// <summary>
	/// The parent the Game Object is set under in the Inspector.
	/// </summary>
	public Transform parent;
	
	List<GameObject> pooledObjects;	

	// make a seprate pool for each type of object, can resue the aquasition and setup code

	void Awake ()
	{
		// set global refrace to this
		pooledObjects = new List<GameObject> ();
		instance = this;
				
	}

	/// <summary>
	/// Adds a Game Object to pool.
	/// </summary>
	/// <param name="toPool">Game Object to add to Pool.</param>
	/// <param name="numPool">Number of Game Objects to add.</param>
	public void AddToPool (GameObject toPool, int numPool = 1)
	{
		Debug.Log ("toPool= " + toPool.name + " numPool " + numPool);
			
		for (int i = 0; i < numPool; i ++) {
			GameObject go = Instantiate (toPool);
			go.transform.SetParent (parent);
			go.SetActive (false);
			pooledObjects.Add (go);	
			
		}
		
	}

	/// <summary>
	/// Gets a deactivated Game Object from the pool.
	/// </summary>
	/// <returns>Deactivated Game Object if avalable otherwise returns NULL </returns>
	/// <param name="objToRef">Object For reference.</param>
	public GameObject GetPool (GameObject objToRef)
	{
		//print ("get pool");
		// interate over list, 
		// find object.name that maches, 
		// if object not active return object
		// else return null
		
		foreach (GameObject obj in pooledObjects) {
			
			//	print ("is " + obj.name + " == " + objToRef.name + "(Clone)");
			
			if (obj.name == objToRef.name + "(Clone)") {
				if (!obj.activeSelf) {
					return obj;
				}
			}
		}
		
		//print ("return null");
		return null;
	}
	
}