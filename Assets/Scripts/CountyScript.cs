﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class CountyScript : MonoBehaviour {

	public GameObject countyName;
	public GameObject cityName;
    public GameObject option1;
    public GameObject option2;
    public GameObject option3;
    public GameObject option4;

    private Text countyNameText;
	private Text cityNameText;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	void OnMouseDown(){
        option1.SetActive(false);
        option2.SetActive(false);
        option3.SetActive(false);
        option4.SetActive(false);

        countyNameText = countyName.GetComponent<Text>();
		cityNameText = cityName.GetComponent<Text>();

		countyNameText.text = "County of " + this.gameObject.name;
		cityNameText.text = "City of " + transform.parent.name;

        option1.GetComponentInChildren<Text>().text = "Talk to Master";
        option1.GetComponent<Button>().onClick.AddListener(() => { DialogueManager.StartConversation(this.gameObject.name); });
        option1.SetActive(true);
    }

}