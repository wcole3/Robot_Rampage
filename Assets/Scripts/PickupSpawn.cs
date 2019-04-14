using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawn : MonoBehaviour {
    //spawn the pickups in set locations around the level
    [SerializeField]
    private GameObject[] pickups;

	// Use this for initialization
	void Start () {
        SpawnPickup();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //spawn the pickups
    public void SpawnPickup()
    {
        //get the gameobject
        GameObject pickup = (GameObject)Instantiate(pickups[Random.Range(0, pickups.Length)]);
        pickup.transform.position = transform.position;
        pickup.transform.parent = transform;

    }

    //respawn the pickup
    IEnumerator RespawnPickup()
    {
        yield return new WaitForSeconds(10);
        SpawnPickup();
    }

    public void PickupPickedUp()
    {
        StartCoroutine("RespawnPickup");
    }
}
