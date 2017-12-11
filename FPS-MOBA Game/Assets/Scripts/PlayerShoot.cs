using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

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
        Ray r = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));

        r.origin = bulletSpawn.position;

        RaycastHit rhit;

        Debug.DrawRay(r.origin, r.direction * 100, Color.red, 1f);

        if (Physics.Raycast(r.origin, r.direction, out rhit, Mathf.Infinity, mask))
        {
            if (rhit.collider.tag == PLAYER_TAG)
            {
                CmdPlayerShot(rhit.collider.name);
            }
        }
            
    }

    [Command]
    void CmdPlayerShot (string ID)
    {
        Debug.Log(ID + " has been shot!");
    }

}
