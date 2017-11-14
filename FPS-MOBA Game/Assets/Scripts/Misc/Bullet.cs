using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col) {
		var hit = col.gameObject;
		var health = hit.GetComponent<Health>();
		if (health != null)
		{
			health.Damage(10);
		}

		Destroy(gameObject);
	}
}
