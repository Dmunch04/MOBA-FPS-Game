using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour {

	public Rigidbody bullet;
	public Transform barrelEnd;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame

	void Update() {
		if (Input.GetButtonDown("Fire1")) {
			Rigidbody clone;
			clone = Instantiate(bullet, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
			clone.AddForce(barrelEnd.forward * 5000);
		}
	}
}
