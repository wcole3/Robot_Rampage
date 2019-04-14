using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    //methods for the player character

    public int health;
    public int armor;
    public GameUI gameUI;
    public Game game;
    public AudioClip playerDead;
    public AudioClip playerHurt;

    private GunEquipper gunEquipper;
    private Ammo ammo;
    private AudioSource source;
	// Use this for initialization
	void Start () {
        gunEquipper = GetComponent<GunEquipper>();
        ammo = GetComponent<Ammo>();
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

	}
    //take damage
    public void TakeDamage(int amount)
    {
        //dampen damage by armor
        int healthdamage = amount;
        if (!source.isPlaying)
        {
            source.PlayOneShot(playerHurt);//play hurt sound effect
        }

        if(armor > 0)
        {
            //if player still has armor then dampen it
            int armorAbsorbed = (armor * 2) - healthdamage;
            if(armorAbsorbed > 0)
            {
                armor = armorAbsorbed / 2;
                gameUI.SetArmorText(armor);
                return;
            }
            else
            {
                armor = 0;
                gameUI.SetArmorText(armor);
            }
        }
        else
        {
            health -= healthdamage;
            if(health <= 0)
            {
                gameUI.SetHealthText(0);
                source.PlayOneShot(playerDead);
                game.GameOver();
            }
            else
            {
                gameUI.SetHealthText(health);
            }
        }
    }

    //handle pickups
    private void PickupHealth()
    {
        health += 50;
        if(health > 200)
        {
            health = 200;
        }
        gameUI.SetPickUpText("Health pickup up + 50 Health");
        gameUI.SetHealthText(health);
    }

    private void PickupArmor()
    {
        armor += 15;
        if(armor > 100)
        {
            armor = 100;
        }
        gameUI.SetPickUpText("Armor picked up + 15 armor");
        gameUI.SetArmorText(armor);
    }

    private void PickupPistolAmmo()
    {
        ammo.AddAmmo(Constants.Pistol, 20);
        gameUI.SetPickUpText("Pistol ammo picked up + 20 ammo");
        if(gunEquipper.GetActiveWeapon().tag == Constants.Pistol)
        {
            gameUI.SetAmmoText(ammo.GetAmmo(Constants.Pistol));
        }
    }

    private void PickupAssaultAmmo()
    {
        ammo.AddAmmo(Constants.AssaultRifle, 50);
        gameUI.SetPickUpText("Assualt rifle ammo picked up + 50 ammo");
        if (gunEquipper.GetActiveWeapon().tag == Constants.AssaultRifle)
        {
            gameUI.SetAmmoText(ammo.GetAmmo(Constants.AssaultRifle));
        }
    }

    private void PickupShotgunAmmo()
    {
        ammo.AddAmmo(Constants.Shotgun, 10);
        gameUI.SetPickUpText("Shotgun ammo picked up + 10 ammo");
        if (gunEquipper.GetActiveWeapon().tag == Constants.Shotgun)
        {
            gameUI.SetAmmoText(ammo.GetAmmo(Constants.Shotgun));
        }
    }

    //now the switch for pickups
    public void PickupItem(int pickupType)
    {
        switch (pickupType){
            case Constants.PickUpHealth:
                PickupHealth();
                break;
            case Constants.PickUpArmor:
                PickupArmor();
                break;
            case Constants.PickUpPistolAmmo:
                PickupPistolAmmo();
                break;
            case Constants.PickUPAssaultRifleAmmo:
                PickupAssaultAmmo();
                break;
            case Constants.PickUpShotgunAmmo:
                PickupShotgunAmmo();
                break;
            default:
                Debug.Log("Could not parse pickup type: " + pickupType);
                break;
        }
            

    }
}
