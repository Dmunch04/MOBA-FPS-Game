using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

	public Rigidbody bullet;
	public Transform barrelEnd;
	public float speed = 4.0f;
	public Camera camera;

	void Awake()
	{
		camera.enabled = false;
	}

	// Use this for initialization
	void Start () {



	}

	// Update is called once per frame
	void Update () {

		if (!isLocalPlayer) {
			return;
		}

		float yRotation = camera.transform.eulerAngles.y;
		transform.eulerAngles = new Vector3( transform.eulerAngles.x, yRotation, transform.eulerAngles.z );

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

		if (Input.GetButtonDown("Fire1")) {
			Rigidbody clone;
			clone = Instantiate(bullet, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
			clone.AddForce(barrelEnd.forward * 5000);
		}
	}

	public override void OnStartLocalPlayer() {
		camera.enabled = true;
		GetComponent<MeshRenderer>().material.color = Color.blue;
	}
}
