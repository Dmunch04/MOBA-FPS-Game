using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public int visible = 0;
	public float sensitivity = 100.0f;
	public float clampAngle = 80.0f;
	private float rotationX = 0.0f;
	private float rotationY = 0.0f;

	// Use this for initialization
	void Start ()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		Vector3 rot = transform.localRotation.eulerAngles;
		rotationX = rot.x;
		rotationY = rot.y;
	}

	// Update is called once per frame
	void Update ()
	{
		float mouseX = Input.GetAxis ("Mouse X");
		float mouseY = -Input.GetAxis ("Mouse Y");

		rotationY += mouseX * sensitivity * Time.deltaTime;
		rotationX += mouseY * sensitivity * Time.deltaTime;
		rotationX = Mathf.Clamp(rotationX, -clampAngle, clampAngle);
		Quaternion localRotation = Quaternion.Euler(rotationX, rotationY, 0.0f);
		transform.rotation = localRotation;
	}
}
