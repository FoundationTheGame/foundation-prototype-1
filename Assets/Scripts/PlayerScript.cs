using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerScript : MonoBehaviour {

	public GameObject play2;
	public GameObject play3;
	public GameObject play4;

	public GameObject playerMoney;
	public GameObject playerDate;
	private Text moneyText;
	private Text dateText;
	private float timer = 5.0f;
	private int increment = 0;

	private int money;
	private float reputation;
	private float influence;
	private DateTime date;


	// Use this for initialization
	void Start () {

	moneyText = playerMoney.GetComponent<Text>();
	dateText = playerDate.GetComponent<Text>();
	moneyText = playerMoney.GetComponent<Text>();

	money = 1000;
	reputation = 0.0f;
	influence = 0.0f;
	
	moneyText.text = ""+money;

	date = new DateTime(1213,1,1);
	dateText.text = date.ToString("d MMM yyyy");
	
	
	}
	
	// Update is called once per frame
	void Update () {
		
		timer -= Time.deltaTime;
		if (timer <= 0.0f){
		dateText = playerDate.GetComponent<Text>();
		date = date.AddDays(1);
		dateText.text = date.ToString("d MMM yyyy");
		updateTimespeed(0);
		}


	}

	public void updateTimespeed (int inc) {
			
		if (inc + increment >= 0 && inc + increment <= 3)
			increment += inc;

		Debug.Log(increment);
		switch (increment){
			case 0:
				timer = 5.0f;
				timer -= Time.deltaTime;
				play2.SetActive(false);
				play3.SetActive(false);
				play4.SetActive(false);
				break;
			case 1:
				timer = 4.0f;
				timer -= Time.deltaTime;
				play2.SetActive(true);
				play3.SetActive(false);
				play4.SetActive(false);
				break;
			case 2:
				timer = 2.0f;
				timer -= Time.deltaTime;
				play2.SetActive(true);
				play3.SetActive(true);
				play4.SetActive(false);
				break;
			case 3:
				timer = 1.0f;
				timer -= Time.deltaTime;
				play2.SetActive(true);
				play3.SetActive(true);
				play4.SetActive(true);
				break;
			default:
				break;
			
		}

		
	}
}
