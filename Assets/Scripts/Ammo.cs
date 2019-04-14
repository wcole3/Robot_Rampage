using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {
    //class to handle the ammo
    [SerializeField]
    GameUI gameUI;

    //starting carrying capacity of different ammo types
    [SerializeField]
    private int pistolAmmo = 20;
    [SerializeField]
    private int assaultRifleAmmo = 50;
    [SerializeField]
    private int shotgunAmmo = 10;

    //Dictionary to hold this info
    public Dictionary<string, int> tagToAmmo;

	// Use this for initialization
	void Awake () {
        tagToAmmo = new Dictionary<string, int>
        {
            {Constants.Pistol, pistolAmmo},
            {Constants.AssaultRifle, assaultRifleAmmo},
            {Constants.Shotgun, shotgunAmmo}
        };
	}
	
    //method to add ammo to pool
    public void AddAmmo(string tag, int ammo)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("That type of ammo doesn't exist. Tag passed: " + tag);
        }

        tagToAmmo[tag] += ammo;
    }

    //check if a gun has ammo
    public bool HasAmmo(string tag)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("That type of ammo doesn't exist. Tag passed: " + tag);
        }

        return tagToAmmo[tag] > 0;
    }

    //get how much ammo a gun has
    public int GetAmmo(string tag)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("That type of ammo doesn't exist. Tag passed: " + tag);
        }

        return tagToAmmo[tag];
    }

    //method to comsume ammo
    public void ConsumeAmmo(string tag)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("That type of ammo doesn't exist. Tag passed: " + tag);
        }
        --tagToAmmo[tag];
        gameUI.SetAmmoText(tagToAmmo[tag]);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
