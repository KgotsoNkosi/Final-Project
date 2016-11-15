﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class Checkpoint : MonoBehaviour {

	public SpawnpointScript spawnPoint;

	public void OnTriggerEnter(Collider col)
	{
		
		GameManager.managerController.counter++;
		spawnPoint = col.gameObject.GetComponentInChildren<SpawnpointScript> ();
		if (col.tag == "Vehicel") {
			spawnPoint.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
			spawnPoint.rotation = new Quaternion (transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
		} 
	}

}
