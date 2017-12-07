using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

	//Movement speed
	[SerializeField]
	private float speed = 10f;

	//Mouse sensitivity
	[SerializeField]
	private float lookSensitivity = 2f;

	//The power of the jump
	[SerializeField]
	private float jumpPower;

	//The distance the ground is within for the player to be classed as grounded
	private float GroundDistance = 1.1f;

    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

    void Update()
    {
        //Movement
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 movHorizontal = transform.right * xMov;
        Vector3 movVertical = transform.forward * zMov;

        Vector3 velocity = (movHorizontal + movVertical).normalized * speed;

        //Applying the movement, to the PlayerMotor script
        motor.Move(velocity);

        //Rotation
        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0f, yRot, 0f) * lookSensitivity;

        //Applying the rotation, to the PlayerMotor script
        motor.Rotate(rotation);

        //Camera rotation
        float xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 cameraRotation = new Vector3(xRot, 0f, 0f) * lookSensitivity;

        //Applying the camera rotation, to the PlayerMotor script
        motor.CameraRotate(cameraRotation);

		if (Input.GetKeyDown(KeyCode.Space)) {
			if (Physics.Raycast(transform.position, Vector3.down, GroundDistance)) {
				motor.Jump(jumpPower);
			}
		}
    }

}
