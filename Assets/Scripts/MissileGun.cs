using Unity.Netcode;
using UnityEngine;

public class MissileGun : NetworkBehaviour
{
    public int playerNumber = 1;
    public GameObject missilePrefab;
    public Transform fireTransform;
    public float fireForce = 2000;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;
        if (Input.GetButtonDown("Fire" + playerNumber))
        {
            GameObject missile = Instantiate(missilePrefab, fireTransform.position, transform.rotation);
            NetworkObject networkObject = missile.GetComponent<NetworkObject>();
            networkObject.Spawn();
            Rigidbody missileBody = missile.GetComponent<Rigidbody>();
            missileBody.AddForce(transform.forward * fireForce);
        }
    }
}
