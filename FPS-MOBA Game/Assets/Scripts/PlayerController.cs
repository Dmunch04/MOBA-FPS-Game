using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public GameObject camera;
	public float speed = 4.0f;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		float yRotation = camera.transform.eulerAngles.y;
		transform.eulerAngles = new Vector3 (transform.eulerAngles.x, yRotation, transform.eulerAngles.z);

		if (Input.GetKey ("w")) {
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}
		if (Input.GetKey ("s")) {
			transform.Translate (-Vector3.forward * speed * Time.deltaTime);
		}
		if (Input.GetKey ("a")) {
			transform.Translate (Vector3.left * speed * Time.deltaTime);
		}
		if (Input.GetKey ("d")) {
			transform.Translate (Vector3.right * speed * Time.deltaTime);
		}
	}
}
