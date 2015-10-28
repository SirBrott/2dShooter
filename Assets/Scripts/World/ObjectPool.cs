using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
	
	// refrace to this script
	public static ObjectPool instance;
	public Transform parent;
	
	List<GameObject> pooledObjects;	

	// make a seprate pool for each type of object, can resue the aquasition and setup code

	void Awake ()
	{
		// set global refrace to this
		pooledObjects = new List<GameObject> ();
		instance = this;
				
	}
	
	// let the managers deal with adding objects to the pool
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