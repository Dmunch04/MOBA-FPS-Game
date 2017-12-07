using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour {

    private const string PLAYER_TAG = "Player";

    public PlayerWeapon weapon;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;

	[SerializeField]
	private Transform bulletSpawn;

	void Start()
    {
		if(bulletSpawn == null) {
			Debug.LogError("PlayerShoot: No place to spawn bullets");
		}
        if (cam == null)
        {
            Debug.LogError("PlayerShoot: No camera!!");
            this.enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // Shoot
            Shoot();
        }
    }

    [Client]
    void Shoot()
    {
		Instantiate(weapon.Bullet, bulletSpawn.position,bulletSpawn.rotation);
    }

    [Command]
    void CmdPlayerShot (string ID)
    {
        Debug.Log(ID + " has been shot!");
    }

}
