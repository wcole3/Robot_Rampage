using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSpawn : MonoBehaviour {
    //control the robot spawning
    [SerializeField]
    GameObject[] robots;

    private int timesSpawned;
    private int healthBonus = 0;//increase the health of the robots on each spawn

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //spawn robots
    public void SpawnRobot()
    {
        ++timesSpawned;
        //increment the health bonus
        healthBonus += 1;
        GameObject robot = (GameObject)Instantiate(robots[Random.Range(0, robots.Length)],
            transform.position, transform.rotation, null);
        robot.GetComponent<Robot>().health += healthBonus;
    }
}
