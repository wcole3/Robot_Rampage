using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameUI : MonoBehaviour {
    //Control the game UI
    //the reticles
    [SerializeField]
    Sprite redReticle;
    [SerializeField]
    Sprite yellowReticle;
    [SerializeField]
    Sprite blueReticle;
    [SerializeField]
    Image reticle;
    [SerializeField]
    private Text ammoText;
    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Text armorText;
    [SerializeField]
    private Text nextWaveText;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text pickupText;
    [SerializeField]
    private Text enemiesLeftText;
    [SerializeField]
    private Text waveClearText;
    [SerializeField]
    private Text newWaveText;
    [SerializeField]
    private Player player;

    //need to be able to update reticle with gun changes
    public void UpdateReticle()
    {
        switch (GunEquipper.activeWeaponType)
        {
            case Constants.Pistol:
                reticle.sprite = redReticle;
                break;
            case Constants.AssaultRifle:
                reticle.sprite = blueReticle;
                break;
            case Constants.Shotgun:
                reticle.sprite = yellowReticle;
                break;
            default:
                return;
        }
    }

	// Use this for initialization
	void Start () {
        SetArmorText(player.armor);
        SetHealthText(player.health);
        SetAmmoText(20);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //method to set the texts
    public void SetArmorText(int armor)
    {
        armorText.text = "Armor: " + armor;
    }
    public void SetHealthText(int health)
    {
        healthText.text = "Health: " + health;
    }
    public void SetAmmoText(int ammo)
    {
        ammoText.text = "Ammo: " + ammo;
    }
    public void SetScore(int score)
    {
        scoreText.text = "" + score;
    }
    public void SetNextWaveText(int time)
    {
        nextWaveText.text = "Next Wave: " + time;
    }
    public void SetEnemyText(int left)
    {
        enemiesLeftText.text = "Enemies: " + left;
    }
    //method to activate hidden text
    public void ShowWaveClearText()
    {
        waveClearText.GetComponent<Text>().enabled = true;
        StartCoroutine("HideWaveClearText");//hide text after some time
    }
    IEnumerator HideWaveClearText()
    {
        yield return new WaitForSeconds(4);
        waveClearText.GetComponent<Text>().enabled = false;
    }

    public void SetPickUpText(string text)
    {
        pickupText.GetComponent<Text>().enabled = true;
        pickupText.text = text;
        StopCoroutine("HidePickupText");//restart coroutine so text isnt hidden
        StartCoroutine("HidePickupText");
    }
    IEnumerator HidePickupText()
    {
        yield return new WaitForSeconds(5);
        pickupText.GetComponent<Text>().enabled = false;
    }

    public void ShowNewWaveText()
    {
        newWaveText.GetComponent<Text>().enabled = true;
        StartCoroutine("HideNewWaveText");
    }
    IEnumerator HideNewWaveText()
    {
        yield return new WaitForSeconds(4);
        newWaveText.GetComponent<Text>().enabled = false;
    }

}
