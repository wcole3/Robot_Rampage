using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //make sure music isn't destroy
        DontDestroyOnLoad(gameObject);
	}
	
	
}
