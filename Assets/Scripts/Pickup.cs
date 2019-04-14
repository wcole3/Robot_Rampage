using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
    //methods for the pickup items
    public int type;//the type of pickup
    public AudioClip pickupSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && other.gameObject.GetComponent<Player>() != null)
        {
            other.gameObject.GetComponent<Player>().PickupItem(type);
            GetComponentInParent<PickupSpawn>().PickupPickedUp();//tell the spawn to spawn another in 10 seconds
            other.GetComponent<AudioSource>().PlayOneShot(pickupSound);
            Destroy(gameObject);
        }
    }
}
