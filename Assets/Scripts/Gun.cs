using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    //script to handle firing logic
    public float fireRate;
    //sound clips
    public Ammo ammo;
    public AudioClip liveFire;
    public AudioClip dryFire;
    //stuff for zooming
    public float zoomFactor;
    //weapon damage variables
    public int range;
    public int damage;

    protected float lastFireTime;//last time the gun was fired

    //fov zoom
    private float zoomFOV;
    private float zoomSpeed = 6;

	// Use this for initialization
	public void Start () {
        //setup zoom
        zoomFOV = (Constants.CameraDefaultZoom / zoomFactor);

        //make sure the user can fire at game start
        lastFireTime = Time.time - 10;


	}

    // we are going to override this for each gun
    protected virtual void Update()
    {
        //check for zooming
        if (Input.GetMouseButton(1))
        {
            //use right click for zoom
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, zoomFOV, zoomSpeed * Time.deltaTime);
        }
        else
        {
            Camera.main.fieldOfView = Constants.CameraDefaultZoom;
        }
	}

    //method to fire gun
    protected void Fire()
    {
        //check if gun has ammo
        if (ammo.HasAmmo(tag))
        {
            GetComponent<AudioSource>().PlayOneShot(liveFire);
            ammo.ConsumeAmmo(tag);
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(dryFire);
        }

        //play gun firing animation
        GetComponentInChildren<Animator>().Play("Fire");
        //chcek if the shot hit
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, range))
        {
            ProcessHit(hit.collider.gameObject);
        }
        //Debug.DrawRay(transform.parent.position, ray.direction * range, Color.green, 2.0f);
    }

    //method to raycast a hit
    private void ProcessHit(GameObject hitObject)
    {
        //check which object has been hit
        if(hitObject.gameObject.GetComponent<Player>() != null)
        {
            hitObject.gameObject.GetComponent<Player>().TakeDamage(damage);
        }
        else if(hitObject.gameObject.GetComponent<Robot>() != null)
        {
            hitObject.gameObject.GetComponent<Robot>().TakeDamage(damage);

        }
    }
}
