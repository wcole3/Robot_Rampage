﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour {
    //Constants used for robot rampage
    //Scenes
    public const string SceneBattle = "Battle";
    public const string SceneMenu = "MainMenu";

    //Gun Types
    public const string Pistol = "Pistol";
    public const string AssaultRifle = "AssaultRifle";
    public const string Shotgun = "Shotgun";

    //Robot types
    public const string RedRobot = "RedRobot";
    public const string BlueRobot = "BlueRobot";
    public const string YellowRobot = "YellowRobot";

    //Pickup types
    public const int PickUpPistolAmmo = 1;
    public const int PickUPAssaultRifleAmmo = 2;
    public const int PickUpShotgunAmmo = 3;
    public const int PickUpHealth = 4;
    public const int PickUpArmor = 5;

    //Misc
    public const string Game = "Game";
    public const float CameraDefaultZoom = 60f;

    //bundle the pickup types
    public static readonly int[] AllPickUpTypes = new int[5]
    {
        PickUpPistolAmmo,
        PickUPAssaultRifleAmmo,
        PickUpShotgunAmmo,
        PickUpHealth,
        PickUpArmor
    };
	
}
