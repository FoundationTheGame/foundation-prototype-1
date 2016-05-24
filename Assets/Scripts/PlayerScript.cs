	using UnityEngine;
	using UnityEngine.UI;
	using System.Collections;
	using System;
	using PixelCrushers.DialogueSystem;

	public class PlayerScript : MonoBehaviour {

	public GameObject play2;
	public GameObject play3;
	public GameObject play4;

	public GameObject weeklyReport;
	public GameObject AmbersmithReport;
	public GameObject AngusReport;
	public GameObject GuthrieReport;
	public GameObject Income;
	public GameObject Expenses;
	public GameObject quitReport;

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
		updateMarket();
		displayWeeklyPanel();

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
			DialogueLua.SetVariable("Money",DialogueLua.GetVariable("Money").AsFloat - AmbersmithDealPrice);
			DialogueLua.SetLocationField("DundeeWarehouse","Wood",DialogueLua.GetLocationField("DundeeWarehouse", "Wood").AsInt + AmbersmithDealQuantity);
			DialogueLua.SetLocationField("Ambersmith","DealWeeksLeft",DialogueLua.GetLocationField("Ambersmith","DealWeeksLeft").AsInt - 1);
			if(DialogueLua.GetLocationField("Ambersmith","DealWeeksLeft").AsInt == 0)
			DialogueLua.SetLocationField("Ambersmith","HasDeal",false);
			DialogueLua.SetVariable("Expenses",DialogueLua.GetVariable("Expenses").AsFloat+AmbersmithDealPrice);
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
			DialogueLua.SetVariable("Money",DialogueLua.GetVariable("Money").AsFloat - AngusDealPrice);
			DialogueLua.SetLocationField("DundeeWarehouse","IronOre",DialogueLua.GetLocationField("DundeeWarehouse", "IronOre").AsInt + AngusDealQuantity);
			DialogueLua.SetLocationField("Angus","DealWeeksLeft",DialogueLua.GetLocationField("Angus","DealWeeksLeft").AsInt - 1);
			if(DialogueLua.GetLocationField("Angus","DealWeeksLeft").AsInt == 0)
			DialogueLua.SetLocationField("Angus","HasDeal",false);
			DialogueLua.SetVariable("Expenses",DialogueLua.GetVariable("Expenses").AsFloat+AngusDealPrice);
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
			DialogueLua.SetVariable("Money",DialogueLua.GetVariable("Money").AsFloat - GuthrieDealPrice);
			DialogueLua.SetLocationField("DundeeWarehouse","Cereal",DialogueLua.GetLocationField("DundeeWarehouse", "Cereal").AsInt + GuthrieDealQuantity);
			DialogueLua.SetLocationField("Guthrie","DealWeeksLeft",DialogueLua.GetLocationField("Guthrie","DealWeeksLeft").AsInt - 1);
			if(DialogueLua.GetLocationField("Guthrie","DealWeeksLeft").AsInt == 0)
			DialogueLua.SetLocationField("Guthrie","HasDeal",false);
			DialogueLua.SetVariable("Expenses",DialogueLua.GetVariable("Expenses").AsFloat+GuthrieDealPrice);
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

	void updateMarket(){
	
	System.Random rnd = new System.Random();
	float randomValue = rnd.Next(0, 11);
	float randomFactor = randomValue/10;
	float signal = (rnd.Next()%2);
	if(signal == 0)
	DialogueLua.SetLocationField("Dundee", "Fish", Math.Max(DialogueLua.GetLocationField("Dundee", "Fish").AsInt - (10*randomFactor) , 0));
	else DialogueLua.SetLocationField("Dundee", "Fish", DialogueLua.GetLocationField("Dundee", "Fish").AsInt + (10*randomFactor));

	randomValue = rnd.Next(0, 11);
	randomFactor = randomValue/10;
	signal = (rnd.Next()%2);
	if(signal == 0)

	DialogueLua.SetLocationField("Dundee", "Meat", Math.Max(DialogueLua.GetLocationField("Dundee", "Meat").AsInt - (20*randomFactor), 0));
	else DialogueLua.SetLocationField("Dundee", "Meat", DialogueLua.GetLocationField("Dundee", "Meat").AsInt + (20*randomFactor));
	
	randomValue = rnd.Next(0, 11);
	randomFactor = randomValue/10;
	DialogueLua.SetLocationField("Dundee", "Cereal", Math.Max(DialogueLua.GetLocationField("Dundee", "Cereal").AsInt - (200*randomFactor), 0));
	
	randomValue = rnd.Next(0, 11);
	randomFactor = randomValue/10;
	DialogueLua.SetLocationField("Dundee", "IronOre", Math.Max(DialogueLua.GetLocationField("Dundee", "IronOre").AsInt - (150*randomFactor), 0));
	
	randomValue = rnd.Next(0, 11);
	randomFactor = randomValue/10;
	signal = (rnd.Next()%2);
	if(signal == 0)
	DialogueLua.SetLocationField("Dundee", "GoldOre", Math.Max(DialogueLua.GetLocationField("Dundee", "GoldOre").AsInt - (10*randomFactor), 0));
	else DialogueLua.SetLocationField("Dundee", "GoldOre", DialogueLua.GetLocationField("Dundee", "GoldOre").AsInt + (10*randomFactor));
	
	randomValue = rnd.Next(0, 11);
	randomFactor = randomValue/10;
	DialogueLua.SetLocationField("Dundee", "Wood", Math.Max(DialogueLua.GetLocationField("Dundee", "Wood").AsInt - (250*randomFactor), 0));

	randomValue = rnd.Next(0, 11);
	randomFactor = randomValue/10;
	signal = (rnd.Next()%2);
	if(signal == 0)
	DialogueLua.SetLocationField("Dundee", "Wool", Math.Max(DialogueLua.GetLocationField("Dundee", "Wool").AsInt - (10*randomFactor), 0));
	else DialogueLua.SetLocationField("Dundee", "Wool", DialogueLua.GetLocationField("Dundee", "Wool").AsInt + (10*randomFactor));

	randomValue = rnd.Next(0, 11);
	randomFactor = randomValue/10;
	signal = (rnd.Next()%2);
	if(signal == 0)
	DialogueLua.SetLocationField("Dundee", "Bread", Math.Max(DialogueLua.GetLocationField("Dundee", "Bread").AsInt - (50*randomFactor), 0));
	else DialogueLua.SetLocationField("Dundee", "Bread", DialogueLua.GetLocationField("Dundee", "Bread").AsInt + (50*randomFactor));

	randomValue = rnd.Next(0, 11);
	randomFactor = randomValue/10;
	signal = (rnd.Next()%2);
	if(signal == 0)
	DialogueLua.SetLocationField("Dundee", "Ale", Math.Max(DialogueLua.GetLocationField("Dundee", "Ale").AsInt - (40*randomFactor), 0));
	else DialogueLua.SetLocationField("Dundee", "Ale", DialogueLua.GetLocationField("Dundee", "Ale").AsInt + (40*randomFactor));

	randomValue = rnd.Next(0, 11);
	randomFactor = randomValue/10;
	signal = (rnd.Next()%2);
	if(signal == 0)
	DialogueLua.SetLocationField("Dundee", "Tools", Math.Max(DialogueLua.GetLocationField("Dundee", "Tools").AsInt - (25*randomFactor), 0));
	else DialogueLua.SetLocationField("Dundee", "Tools", DialogueLua.GetLocationField("Dundee", "Tools").AsInt + (25*randomFactor));

	randomValue = rnd.Next(0, 11);
	randomFactor = randomValue/10;
	signal = (rnd.Next()%2);
	if(signal == 0)
	DialogueLua.SetLocationField("Dundee", "Weapons", Math.Max(DialogueLua.GetLocationField("Dundee", "Weapons").AsInt - (18*randomFactor), 0));
	else DialogueLua.SetLocationField("Dundee", "Weapons", DialogueLua.GetLocationField("Dundee", "Weapons").AsInt + (18*randomFactor));

	randomValue = rnd.Next(0, 11);
	randomFactor = randomValue/10;
	signal = (rnd.Next()%2);
	if(signal == 0)
	DialogueLua.SetLocationField("Dundee", "Jewelry", Math.Max(DialogueLua.GetLocationField("Dundee", "Jewelry").AsInt - (5*randomFactor), 0));
	else DialogueLua.SetLocationField("Dundee", "Jewelry", DialogueLua.GetLocationField("Dundee", "Jewelry").AsInt + (5*randomFactor));

	randomValue = rnd.Next(0, 11);
	randomFactor = randomValue/10;
	signal = (rnd.Next()%2);
	if(signal == 0)
	DialogueLua.SetLocationField("Dundee", "Furniture", Math.Max(DialogueLua.GetLocationField("Dundee", "Furniture").AsInt - (33*randomFactor), 0));
	else DialogueLua.SetLocationField("Dundee", "Furniture", DialogueLua.GetLocationField("Dundee", "Furniture").AsInt + (33*randomFactor));
	
	randomValue = rnd.Next(0, 11);
	randomFactor = randomValue/10;
	signal = (rnd.Next()%2);
	if(signal == 0)
	DialogueLua.SetLocationField("Dundee", "Clothes", Math.Max(DialogueLua.GetLocationField("Dundee", "Clothes").AsInt - (10*randomFactor), 0));
	else DialogueLua.SetLocationField("Dundee", "Clothes", DialogueLua.GetLocationField("Dundee", "Clothes").AsInt + (10*randomFactor));
	
	}

	void displayWeeklyPanel(){
		float timer2 = timer;
		timer = 1000000f;
		weeklyReport.SetActive(true);
		if(DialogueLua.GetLocationField("Ambersmith","HasDeal").AsBool)
		AmbersmithReport.GetComponent<Text>().text = "Ambersmith is producing "+ DialogueLua.GetLocationField("Ambersmith","DealQuantity").AsString +" wood for "+ DialogueLua.GetLocationField("Ambersmith","DealWeeksLeft").AsString + " more weeks. (Price: "+ DialogueLua.GetLocationField("Ambersmith","DealPrice").AsString + ").";
		if(DialogueLua.GetLocationField("Guthrie","HasDeal").AsBool)
		GuthrieReport.GetComponent<Text>().text = "Guthrie is producing "+ DialogueLua.GetLocationField("Guthrie","DealQuantity").AsString +" cereals for "+ DialogueLua.GetLocationField("Guthrie","DealWeeksLeft").AsString + " more weeks. (Price: "+ DialogueLua.GetLocationField("Guthrie","DealPrice").AsString + ").";
		if(DialogueLua.GetLocationField("Angus","HasDeal").AsBool)
		AngusReport.GetComponent<Text>().text = "Angus is producing "+ DialogueLua.GetLocationField("Angus","DealQuantity").AsString +" iron ore for "+ DialogueLua.GetLocationField("Angus","DealWeeksLeft").AsString + " more weeks. (Price: "+ DialogueLua.GetLocationField("Angus","DealPrice").AsString + ").";
		
		Income.GetComponent<Text>().text = "Income :"+ DialogueLua.GetVariable("Income").AsString;
		Expenses.GetComponent<Text>().text = "Expenses :"+ DialogueLua.GetVariable("Expenses").AsString;
		
		quitReport.GetComponent<Button>().onClick.AddListener(() =>
		{
			 DialogueLua.SetVariable("Income",0);
			 DialogueLua.SetVariable("Expenses",0);
			weeklyReport.SetActive(false);
			timer = timer2;
		});

	}
		
}
