using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour {
    //class to control robot behavior
    [SerializeField]
    private readonly string robotType;//red, blue, or yellow
    //need a color coding missile for each robot
    [SerializeField]
    GameObject missilePrefab;
    //add sounds
    [SerializeField]
    private AudioClip deathSound;
    [SerializeField]
    private AudioClip fireSound;
    [SerializeField]
    private AudioClip hurtSound;

    public int health;
    public int range;
    public float fireRate;
    //get the animator
    public Animator robot;

    public Transform missleFireSpot;//the transform where missles are fired from
    //get navmesh agent
    private NavMeshAgent agent;

    private Transform killTarget;//the target the robots want to kill
    private float timeLastFired;//times since last fire

    private bool isDead = false;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        killTarget = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        //make sure robot isn't dead
        if (isDead)
        {
            return;
        }
        //locked on target
        transform.LookAt(killTarget);
        //engage
        agent.SetDestination(killTarget.position);
        //check if in range
        if((Vector3.Distance(transform.position, killTarget.position) < range) && fireRate < (Time.time - timeLastFired))
        {
            timeLastFired = Time.time;
            Fire();

        }
	}

    //method to have the robots fire
    private void Fire()
    {
        //setup the missile
        GameObject missile = (GameObject)Instantiate(missilePrefab);
        missile.transform.position = missleFireSpot.transform.position;
        missile.transform.rotation = missleFireSpot.transform.rotation;
        robot.Play("Fire");
        GetComponent<AudioSource>().PlayOneShot(fireSound);
    }

    //method to have the robot take damage
    public void TakeDamage(int amount)
    {
        //check if robot is dead
        if (isDead)
        {
            return;
        }
        health -= amount;

        //check if robot is now dead
        if(health <= 0)
        {
            GetComponent<BoxCollider>().enabled = false;//disable collider so player cant mount it
            isDead = true;
            robot.Play("Die");
            //manually lower volume because this efect is way too loud
            GetComponent<AudioSource>().volume = 0.3f;
            GetComponent<AudioSource>().PlayOneShot(deathSound);
            GetComponent<AudioSource>().volume = 1.0f;
            //start destroy routine
            StartCoroutine("RobotDeath");
            //remove enemy from ui
            Game.RemoveEnemy();

        }
        else
        {
            killTarget.gameObject.GetComponent<AudioSource>().PlayOneShot(hurtSound);
        }
    }
    IEnumerator RobotDeath()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
