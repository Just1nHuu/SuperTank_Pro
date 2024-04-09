using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Components;
using UnityEngine;

public class MissileGun : NetworkBehaviour {

    public int playerNumber = 1;

    public GameObject missilePrefab;

    public Transform fireTransform;

    public float fireForce = 2000;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire" + playerNumber))
        {
            GameObject missile = Instantiate(missilePrefab, fireTransform.position, transform.rotation);

            NetworkObject networkObject = missile.GetComponent<NetworkObject>();
            networkObject.Spawn();

            Rigidbody missileBody = missile.GetComponent<Rigidbody>();
            if (missileBody != null)
            {
                missileBody.GetComponent(transform.forward * fireForce);

            }

        }
	}
}
