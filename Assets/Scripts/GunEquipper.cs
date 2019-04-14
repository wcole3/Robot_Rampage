using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEquipper : MonoBehaviour {
    [SerializeField]
    GameUI gameUI;
    [SerializeField]
    Ammo ammo;
    //script to change weapon equipped
    public static string activeWeaponType;//reference to current's equipped weapon

    public GameObject Pistol;
    public GameObject AssaultRifle;
    public GameObject Shotgun;

    private GameObject activeGun;


	// Use this for initialization
	void Start () {
        //start the game with a pistol
        activeWeaponType = Constants.Pistol;
        activeGun = Pistol;

	}
	
	// Update is called once per frame
	void Update () {
        //get key presses to chang weapon
        if (Input.GetKey("1"))
        {
            SelectWeapon(Pistol);
            activeWeaponType = Constants.Pistol;
            gameUI.UpdateReticle();

        }else if (Input.GetKey("2"))
        {
            SelectWeapon(AssaultRifle);
            activeWeaponType = Constants.AssaultRifle;
            gameUI.UpdateReticle();

        }else if(Input.GetKey("3"))
        {
            SelectWeapon(Shotgun);
            activeWeaponType = Constants.Shotgun;
            gameUI.UpdateReticle();
        }

    }
    //getter method for active weapon
    public GameObject GetActiveWeapon()
    {
        return activeGun;
    }


    //load the correct weapon
    private void SelectWeapon(GameObject weapon)
    {
        //set all as inactive
        Pistol.SetActive(false);
        AssaultRifle.SetActive(false);
        Shotgun.SetActive(false);

        weapon.SetActive(true);
        activeGun = weapon;
        gameUI.SetAmmoText(ammo.GetAmmo(activeGun.tag));
    }
}
