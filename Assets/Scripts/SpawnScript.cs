using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

	public float tempoMin, tempoMax;
	float tempo;
	public GameObject enemyPrefab;

	void Start () {
		tempo = Random.Range (tempoMin, tempoMax);
		StartCoroutine ("Spawn", tempo);
	}

	void Update () {
		
	}

	IEnumerator Spawn (float t) {
		Instantiate (enemyPrefab, transform.position, transform.rotation);
		yield return new WaitForSeconds (t);
		tempo = Random.Range (tempoMin, tempoMax);
		StartCoroutine ("Spawn", tempo);
	}
}
