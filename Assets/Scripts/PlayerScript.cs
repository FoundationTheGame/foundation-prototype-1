	using UnityEngine;
	using UnityEngine.UI;
	using System.Collections;
	using System;
	using PixelCrushers.DialogueSystem;

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
	private int daysPassed = 0;

	public float money;
	public float reputation;
	public float influence;
	public DateTime date;


	// Use this for initialization
	void Start () {

	moneyText = playerMoney.GetComponent<Text>();
	dateText = playerDate.GetComponent<Text>();
	moneyText = playerMoney.GetComponent<Text>();

	money = DialogueLua.GetVariable("Money").AsFloat;
	reputation = DialogueLua.GetVariable("Reputation").AsFloat;
	influence = DialogueLua.GetVariable("Influence").AsFloat;
	
	moneyText.text = ""+money;

	date = new DateTime(1213,1,1);
	dateText.text = date.ToString("d MMM yyyy");
	
	
	}
	
	// Update is called once per frame
	void Update () {
		
		moneyText = playerMoney.GetComponent<Text>();
		dateText = playerDate.GetComponent<Text>();
		moneyText = playerMoney.GetComponent<Text>();

		money = DialogueLua.GetVariable("Money").AsFloat;
		reputation = DialogueLua.GetVariable("Reputation").AsFloat;
		influence = DialogueLua.GetVariable("Influence").AsFloat;
	
		moneyText.text = ""+money;

		timer -= Time.deltaTime;
		if (timer <= 0.0f){
		dateText = playerDate.GetComponent<Text>();
		date = date.AddDays(1);
		dateText.text = date.ToString("d MMM yyyy");
		updateTimespeed(0);
		daysPassed++;
		if (daysPassed == 7){
		weeklyUpdate();
		daysPassed = 0;
		}
		}


	}

	public void weeklyUpdate(){

		updateCounties();
		updateDeals();

	}

	public void updateTimespeed (int inc) {
			
		if (inc + increment >= 0 && inc + increment <= 3)
			increment += inc;

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

	void updateCounties(){
		
			int wood = DialogueLua.GetLocationField("Ambersmith","Wood").AsInt;
			int ironOre = DialogueLua.GetLocationField("Angus","IronOre").AsInt;
			int cereal = DialogueLua.GetLocationField("Guthrie","Cereal").AsInt;

			int woodWeek = DialogueLua.GetLocationField("Ambersmith","WeeklyProduction").AsInt;
			int ironOreWeek = DialogueLua.GetLocationField("Angus","WeeklyProduction").AsInt;
			int cerealWeek = DialogueLua.GetLocationField("Guthrie","WeeklyProduction").AsInt;

			DialogueLua.SetLocationField("Dundee", "Wood", DialogueLua.GetLocationField("Dundee","Wood").AsInt + wood);
			DialogueLua.SetLocationField("Dundee", "IronOre", DialogueLua.GetLocationField("Dundee","IronOre").AsInt + ironOre);
			DialogueLua.SetLocationField("Dundee", "Cereal", DialogueLua.GetLocationField("Dundee","Cereal").AsInt + cereal);

			DialogueLua.SetLocationField("Ambersmith","Wood",woodWeek);
			DialogueLua.SetLocationField("Angus","IronOre",ironOreWeek);
			DialogueLua.SetLocationField("Guthrie","Wood",cerealWeek);
		}

	void updateDeals(){
		
		bool AmbersmithHasDeal = DialogueLua.GetLocationField("Ambersmith","HasDeal").AsBool;
		bool AngusHasDeal = DialogueLua.GetLocationField("Angus","HasDeal").AsBool;
		bool GuthrieHasDeal = DialogueLua.GetLocationField("Guthrie","HasDeal").AsBool;

		float AmbersmithDealPrice = DialogueLua.GetLocationField("Ambersmith","DealPrice").AsFloat;
		float AngusDealPrice = DialogueLua.GetLocationField("Angus","DealPrice").AsFloat;
		float GuthrieDealPrice = DialogueLua.GetLocationField("Guthrie","DealPrice").AsFloat;

		int AmbersmithDealQuantity = DialogueLua.GetLocationField("Ambersmith","DealQuantity").AsInt;
		int AngusDealQuantity = DialogueLua.GetLocationField("Angus","DealQuantity").AsInt;
		int GuthrieDealQuantity = DialogueLua.GetLocationField("Gjuthrie","DealQuantity").AsInt;

		int AmbersmithDealWeeks = DialogueLua.GetLocationField("Ambersmith","DealWeeksLeft").AsInt;
		int AngusDealWeeks = DialogueLua.GetLocationField("Angus","DealWeeksLeft").AsInt;
		int GuthrieDealWeeks = DialogueLua.GetLocationField("Guthrie","DealWeeksLeft").AsInt;

		if(AmbersmithHasDeal && AmbersmithDealWeeks > 0){
			if(AmbersmithDealPrice > money){
				print("Not enough money to deal");
			}
			else if ((warehouseTotal()+AmbersmithDealQuantity > DialogueLua.GetLocationField("DundeeWarehouse","WarehouseLevel").AsInt*1000)){
			print("Not enough space in warehouse");
				}
			else {
			money = money - AmbersmithDealPrice;
			DialogueLua.SetLocationField("DundeeWarehouse","Wood",DialogueLua.GetLocationField("DundeeWarehouse", "Wood").AsInt + AmbersmithDealQuantity);
			DialogueLua.SetLocationField("Ambersmith","DealWeeksLeft",DialogueLua.GetLocationField("Ambersmith","DealWeeksLeft").AsInt - 1);
			}
		}

		if(AngusHasDeal && AngusDealWeeks > 0){
			if(AngusDealPrice > money){
				print("Not enough money to deal");
			}
			else if ((warehouseTotal()+AngusDealQuantity > DialogueLua.GetLocationField("DundeeWarehouse","WarehouseLevel").AsInt*1000)){
			print("Not enough space in warehouse");
				}
			else {
			money = money - AngusDealPrice;
			DialogueLua.SetLocationField("DundeeWarehouse","IronOre",DialogueLua.GetLocationField("DundeeWarehouse", "IronOre").AsInt + AngusDealQuantity);
			DialogueLua.SetLocationField("Angus","DealWeeksLeft",DialogueLua.GetLocationField("Angus","DealWeeksLeft").AsInt - 1);
			}
		}

		if(GuthrieHasDeal && GuthrieDealWeeks > 0){
			if(GuthrieDealPrice > money){
				print("Not enough money to deal");
			}
			else if ((warehouseTotal()+GuthrieDealQuantity > DialogueLua.GetLocationField("DundeeWarehouse","WarehouseLevel").AsInt*1000)){
			print("Not enough space in warehouse");
				}
			else {
			money = money - GuthrieDealPrice;
			DialogueLua.SetLocationField("DundeeWarehouse","Cereal",DialogueLua.GetLocationField("DundeeWarehouse", "Cereal").AsInt + GuthrieDealQuantity);
			DialogueLua.SetLocationField("Guthrie","DealWeeksLeft",DialogueLua.GetLocationField("Guthrie","DealWeeksLeft").AsInt - 1);
			}
		}



		}

		int warehouseTotal(){
	
		return (DialogueLua.GetLocationField("DundeeWarehouse", "Fish").AsInt+
			DialogueLua.GetLocationField("DundeeWarehouse", "Meat").AsInt+
			DialogueLua.GetLocationField("DundeeWarehouse", "Cereal").AsInt+
			DialogueLua.GetLocationField("DundeeWarehouse", "IronOre").AsInt+
			DialogueLua.GetLocationField("DundeeWarehouse", "GoldOre").AsInt+
			DialogueLua.GetLocationField("DundeeWarehouse", "Wood").AsInt+
			DialogueLua.GetLocationField("DundeeWarehouse", "Wool").AsInt+
			DialogueLua.GetLocationField("DundeeWarehouse", "Bread").AsInt+
			DialogueLua.GetLocationField("DundeeWarehouse", "Ale").AsInt+
			DialogueLua.GetLocationField("DundeeWarehouse", "Tools").AsInt+
			DialogueLua.GetLocationField("DundeeWarehouse", "Weapons").AsInt+
			DialogueLua.GetLocationField("DundeeWarehouse", "Jewelry").AsInt+
			DialogueLua.GetLocationField("DundeeWarehouse", "Furniture").AsInt+
			DialogueLua.GetLocationField("DundeeWarehouse", "Clothes").AsInt);

	}
		
		}
