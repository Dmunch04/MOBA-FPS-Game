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

		Vector3 rotation = new Vector3 (gameObject.transform.eulerAngles.x, camera.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
		gameObject.transform.eulerAngles = rotation;

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
