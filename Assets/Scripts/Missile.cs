using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {
    //Controller for the robot missle
    public float speed = 30f;
    public int damage = 10;

	// Use this for initialization
	void Start () {
        //start a coroutine to kill the missle
        StartCoroutine("DeathTimer");
	}
	
	// Update is called once per frame
	void Update () {
        //set the missle position
        transform.Translate((Vector3.forward * speed) * Time.deltaTime);
	}

    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
    //when missile hits the player do damage
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<Player>() != null)
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
        }
    }
}
