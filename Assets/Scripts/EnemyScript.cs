using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour {

	public GameObject seekAndDestroy;
	public float vMin, vMax;
	public int vidaMin, vidaMax;
	int vida;

	NavMeshAgent agent;

	void Start () {
		seekAndDestroy = GameObject.Find ("Player");
		agent = GetComponent<NavMeshAgent> ();
		agent.speed = Random.Range (vMin, vMax);
		vida = Random.Range (vidaMin, vidaMax);
	}

	void Update () {
		agent.destination = seekAndDestroy.transform.position;

	}

	void OnCollisionEnter (Collision c) {
		if (c.gameObject.tag == "Projectil") {
			Destroy (c.gameObject);
			vida--;
			if (vida >= 0) {
				Destroy (gameObject);
			}
		}
	}
}
