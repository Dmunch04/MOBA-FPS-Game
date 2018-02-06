using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	Rigidbody rb;
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		rb.AddRelativeForce(new Vector3(0, 0, 1000));
	}


	private void OnCollisionEnter (Collision collision)
	{
		print("Damage, if it had been added.");
		Destroy(gameObject);
	}
}
