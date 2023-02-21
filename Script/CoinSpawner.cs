using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {

	float timer;
	public GameObject coinPrefab;

void Update () {

	timer += Time.deltaTime;

	if (timer >= 3f) {  //spawnea una moneda cada 3 segundos

		timer = 0;
		float x = Random.Range (-13f, 13f); //spawnea una moneda dentro de  x=-2f & y=-2f
		Vector3 position = new Vector3 (x, 0, 0);
		Quaternion rotation = new Quaternion (); //rotación vacía 
		Instantiate (coinPrefab, position, rotation);

		}
	}
}