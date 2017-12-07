using UnityEngine;

[System.Serializable]
public class PlayerWeapon {

	public GameObject Bullet;
    // Default weapon model/name, doesn't really matters much tho, but still!
    public string gunName = "GUN";

    // Default weapon damage
    public float damage = 15f;
    // Default weapon range
    public float range = 150f;

}
