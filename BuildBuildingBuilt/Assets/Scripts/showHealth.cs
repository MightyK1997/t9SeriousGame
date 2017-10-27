using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showHealth : MonoBehaviour {

    public Text healthText;
    //healthCalc health;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        healthText.text = (healthCalc.houseHealth).ToString();
	}
}
