using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerScript : MonoBehaviour {

	public Transform pivot;
	public Transform aim;
	public GameObject projectilPrefab;
	public float speed = 10f;

	NavMeshAgent agent;
	RaycastHit hit;
	Ray ray;
	Vector3 pointHit;

	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		pivot = GameObject.Find ("Pivot").transform;
		aim = GameObject.Find ("Aim").transform;
	}

	void Update () {
		Move ();
	}

	void Move () {
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast(ray, out hit)) {
			pointHit = new Vector3 (hit.point.x, transform.position.y, hit.point.z);
		}
		Vector3 p = new Vector3 (pointHit.x, pivot.transform.position.y, pointHit.z);
		pivot.transform.LookAt (p);

		if (Input.GetMouseButtonDown(0) && hit.collider.tag == "Scenario") {
			agent.destination = pointHit;
		}

		if (Input.GetMouseButtonDown(0) && hit.collider.tag == "Enemy") {
			GameObject projectil = Instantiate (projectilPrefab, aim.transform.position, pivot.transform.rotation);
			projectil.GetComponent<Transform> ().LookAt (aim.transform.position);
			projectil.GetComponent<Rigidbody> ().AddRelativeForce (Vector3.forward * speed);
			Destroy (projectil, 2f);
		}
	}
}
