using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public GameObject playerMoney;
	private Text moneyText;

	private int money;
	private float reputation;
	private float influence;

	// Use this for initialization
	void Start () {

	moneyText = playerMoney.GetComponent<Text>();
	money = 1000;
	reputation = 0.0f;
	influence = 0.0f;
	moneyText.text = ""+money;
	
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
