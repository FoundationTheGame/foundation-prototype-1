using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using PixelCrushers.DialogueSystem;
using System;

public class CityScript : MonoBehaviour
{

    public GameObject countyName;
    public GameObject cityName;
    public GameObject option1;
    public GameObject option2;
    public GameObject option3;
    public GameObject option4;
	public GameObject buyButton;
	public GameObject sellButton;
    public GameObject DundeeFocus;
    public GameObject AmbersmithFocus;
    public GameObject AngusFocus;
    public GameObject GuthrieFocus;
    public GameObject focused;
    public GameObject marketPanel;
    public GameObject warehousePanel;

    //Warehouse Goods
    public GameObject warehouseFish;
    public GameObject warehouseMeat;
    public GameObject warehouseCereals;
    public GameObject warehouseIronOre;
    public GameObject warehouseGoldOre;
    public GameObject warehouseWood;
    public GameObject warehouseWool;
    public GameObject warehouseBread;
    public GameObject warehouseAle;
    public GameObject warehouseTools;
    public GameObject warehouseWeapons;
    public GameObject warehouseJewelry;
    public GameObject warehouseFurniture;
    public GameObject warehouseClothes;
    public GameObject warehouseLevel;

	//Marketplace Goods
    public GameObject stockFish;
    public GameObject stockMeat;
    public GameObject stockCereals;
    public GameObject stockIronOre;
    public GameObject stockGoldOre;
    public GameObject stockWood;
    public GameObject stockWool;
    public GameObject stockBread;
    public GameObject stockTools;
    public GameObject stockWeapons;
    public GameObject stockJewelry;
    public GameObject stockFurniture;
    public GameObject stockClothes;
	public GameObject stockAle;

	public GameObject priceFish;
    public GameObject priceMeat;
    public GameObject priceCereals;
    public GameObject priceIronOre;
    public GameObject priceGoldOre;
    public GameObject priceWood;
    public GameObject priceWool;
    public GameObject priceBread;
    public GameObject priceTools;
    public GameObject priceWeapons;
    public GameObject priceJewelry;
    public GameObject priceFurniture;
    public GameObject priceClothes;
	public GameObject priceAle;

	public GameObject storedFish;
    public GameObject storedMeat;
    public GameObject storedCereals;
    public GameObject storedIronOre;
    public GameObject storedGoldOre;
    public GameObject storedWood;
    public GameObject storedWool;
    public GameObject storedBread;
    public GameObject storedTools;
    public GameObject storedWeapons;
    public GameObject storedJewelry;
    public GameObject storedFurniture;
    public GameObject storedClothes;
	public GameObject storedAle;

	public InputField inputFish;
    public InputField inputMeat;
    public InputField inputCereals;
    public InputField inputIronOre;
    public InputField inputGoldOre;
    public InputField inputWood;
    public InputField inputWool;
    public InputField inputBread;
    public InputField inputTools;
    public InputField inputWeapons;
    public InputField inputJewelry;
    public InputField inputFurniture;
    public InputField inputClothes;
	public InputField inputAle;

    private Text countyNameText;
    private Text cityNameText;
    private Text warehouseMaterialText;
	private Text marketStoredText;

    // Use this for initialization
    void Start()
    {
        Lua.RegisterFunction(this.gameObject.name + "CityConversationCleanUp", this, typeof(CityScript).GetMethod("OnMouseDown"));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        DisableButtons();
        unFocus();

        countyNameText = countyName.GetComponent<Text>();
        cityNameText = cityName.GetComponent<Text>();

        cityNameText.text = "City of " + this.gameObject.name;
        countyNameText.text = " ";



        //Lord

        option1.GetComponentInChildren<Text>().text = "Talk to Lord";
        option1.GetComponent<Button>().onClick.AddListener(() => {
            DialogueManager.StartConversation(this.gameObject.name);
            DisableButtons();

            option4.GetComponentInChildren<Text>().text = "Leave Conversation";
            option4.GetComponent<Button>().onClick.AddListener(() => {
                DialogueManager.StopConversation();
                OnMouseDown();
            });
            option4.SetActive(true);
        });
        option1.SetActive(true);
        focused.SetActive(true);



        //Marketplace

        option2.GetComponentInChildren<Text>().text = "Go to Market";
        option2.GetComponent<Button>().onClick.AddListener(() =>
        { 
        marketPanel.SetActive(true);
        marketPanel.GetComponentInChildren<Text>().text = "Market of "+ this.gameObject.name;
        DisableButtons();

		getMarketStored();
		getMarketPrices();
		getMarketStock();

		buyButton.GetComponent<Button>().onClick.AddListener(() =>
        {
		updateBuy();
		});

		sellButton.GetComponent<Button>().onClick.AddListener(() =>
        { 
		updateSell();
		});
		
		option4.GetComponentInChildren<Text>().text = "Leave Marketplace";
            option4.GetComponent<Button>().onClick.AddListener(() => {
                marketPanel.SetActive(false);
                OnMouseDown();
            });
            option4.SetActive(true);
        });
        option2.SetActive(true);
    




        //Warehouse
    
        option3.GetComponentInChildren<Text>().text = "Go to Warehouse";
        option3.GetComponent<Button>().onClick.AddListener(() =>
        {

            warehousePanel.SetActive(true);
            warehousePanel.GetComponentInChildren<Text>().text = "Warehouse";
            DisableButtons();

			getWarehouseGoods();

            option4.GetComponentInChildren<Text>().text = "Leave Warehouse";
            option4.GetComponent<Button>().onClick.AddListener(() => {
                warehousePanel.SetActive(false);
                OnMouseDown();
            });
            option4.SetActive(true);
        });
        option3.SetActive(true);
    }

    void DisableButtons()
    {
        option1.SetActive(false);
        option1.GetComponent<Button>().onClick.RemoveAllListeners();
        option2.SetActive(false);
        option2.GetComponent<Button>().onClick.RemoveAllListeners();
        option3.SetActive(false);
        option3.GetComponent<Button>().onClick.RemoveAllListeners();
        option4.SetActive(false);
        option4.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    void unFocus()
    {
        DundeeFocus.SetActive(false);
        AmbersmithFocus.SetActive(false);
        GuthrieFocus.SetActive(false);
        AngusFocus.SetActive(false);
    }

	void getMarketStored(){
		marketStoredText = storedFish.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("DundeeWarehouse", "Fish").AsInt;
        marketStoredText = storedMeat.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("DundeeWarehouse", "Meat").AsInt;
        marketStoredText = storedCereals.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("DundeeWarehouse", "Cereal").AsInt;
        marketStoredText = storedIronOre.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("DundeeWarehouse", "IronOre").AsInt;
        marketStoredText = storedGoldOre.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("DundeeWarehouse", "GoldOre").AsInt;
        marketStoredText = storedWood.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("DundeeWarehouse", "Wood").AsInt;
        marketStoredText = storedWool.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("DundeeWarehouse", "Wool").AsInt;
        marketStoredText = storedBread.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("DundeeWarehouse", "Bread").AsInt;
        marketStoredText = storedAle.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("DundeeWarehouse", "Ale").AsInt;
        marketStoredText = storedTools.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("DundeeWarehouse", "Tools").AsInt;
        marketStoredText = storedWeapons.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("DundeeWarehouse", "Weapons").AsInt;
        marketStoredText = storedJewelry.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("DundeeWarehouse", "Jewelry").AsInt;
        marketStoredText = storedFurniture.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("DundeeWarehouse", "Furniture").AsInt;
        marketStoredText = storedClothes.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("DundeeWarehouse", "Clothes").AsInt;
	}

	void getMarketPrices(){
		marketStoredText = priceFish.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("Dundee", "FishPrice").AsInt;
        marketStoredText = priceMeat.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("Dundee", "MeatPrice").AsInt;
        marketStoredText = priceCereals.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("Dundee", "CerealPrice").AsInt;
        marketStoredText = priceIronOre.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("Dundee", "IronOrePrice").AsInt;
        marketStoredText = priceGoldOre.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("Dundee", "GoldOrePrice").AsInt;
        marketStoredText = priceWood.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("Dundee", "WoodPrice").AsInt;
        marketStoredText = priceWool.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("Dundee", "WoolPrice").AsInt;
        marketStoredText = priceBread.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("Dundee", "BreadPrice").AsInt;
        marketStoredText = priceAle.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("Dundee", "AlePrice").AsInt;
        marketStoredText = priceTools.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("Dundee", "ToolsPrice").AsInt;
        marketStoredText = priceWeapons.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("Dundee", "WeaponsPrice").AsInt;
        marketStoredText = priceJewelry.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("Dundee", "JewelryPrice").AsInt;
        marketStoredText = priceFurniture.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("Dundee", "FurniturePrice").AsInt;
        marketStoredText = priceClothes.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("Dundee", "ClothesPrice").AsInt;
	}

	void getMarketStock(){
		marketStoredText = stockFish.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("Dundee", "Fish").AsInt;
        marketStoredText = stockMeat.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("Dundee", "Meat").AsInt;
        marketStoredText = stockCereals.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("Dundee", "Cereal").AsInt;
        marketStoredText = stockIronOre.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("Dundee", "IronOre").AsInt;
        marketStoredText = stockGoldOre.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("Dundee", "GoldOre").AsInt;
        marketStoredText = stockWood.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("Dundee", "Wood").AsInt;
        marketStoredText = stockWool.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("Dundee", "Wool").AsInt;
        marketStoredText = stockBread.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("Dundee", "Bread").AsInt;
        marketStoredText = stockAle.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("Dundee", "Ale").AsInt;
        marketStoredText = stockTools.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("Dundee", "Tools").AsInt;
        marketStoredText = stockWeapons.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("Dundee", "Weapons").AsInt;
        marketStoredText = stockJewelry.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("Dundee", "Jewelry").AsInt;
        marketStoredText = stockFurniture.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("Dundee", "Furniture").AsInt;
        marketStoredText = stockClothes.GetComponent<Text>();
        marketStoredText.text = ""+DialogueLua.GetLocationField("Dundee", "Clothes").AsInt;
	}

	void updateBuy(){
	
		int fish = Convert.ToInt32(inputFish.text);
		int meat = Convert.ToInt32(inputMeat.text);
		int cereals = Convert.ToInt32(inputCereals.text);
		int ironOre = Convert.ToInt32(inputIronOre.text);
		int goldOre = Convert.ToInt32(inputGoldOre.text);
		int wood = Convert.ToInt32(inputWood.text);
		int wool = Convert.ToInt32(inputWool.text);
		int bread = Convert.ToInt32(inputBread.text);
		int ale = Convert.ToInt32(inputAle.text);
		int tools = Convert.ToInt32(inputTools.text);
		int weapons = Convert.ToInt32(inputWeapons.text);
		int jewelry = Convert.ToInt32(inputJewelry.text);
		int furniture = Convert.ToInt32(inputFurniture.text);
		int clothes = Convert.ToInt32(inputClothes.text);

        int fishPrice = DialogueLua.GetLocationField("Dundee", "FishPrice").AsInt;
        int meatPrice = DialogueLua.GetLocationField("Dundee", "MeatPrice").AsInt;
        int cerealsPrice = DialogueLua.GetLocationField("Dundee", "CerealPrice").AsInt;
        int ironOrePrice = DialogueLua.GetLocationField("Dundee", "IronOrePrice").AsInt;
        int goldOrePrice = DialogueLua.GetLocationField("Dundee", "GoldOrePrice").AsInt;
        int woodPrice = DialogueLua.GetLocationField("Dundee", "WoodPrice").AsInt;
        int woolPrice = DialogueLua.GetLocationField("Dundee", "WoolPrice").AsInt;
        int breadPrice = DialogueLua.GetLocationField("Dundee", "BreadPrice").AsInt;
        int alePrice = DialogueLua.GetLocationField("Dundee", "AlePrice").AsInt;
        int toolsPrice = DialogueLua.GetLocationField("Dundee", "ToolsPrice").AsInt;
        int weaponsPrice = DialogueLua.GetLocationField("Dundee", "WeaponsPrice").AsInt;
        int jewelryPrice = DialogueLua.GetLocationField("Dundee", "JewelryPrice").AsInt;
        int furniturePrice = DialogueLua.GetLocationField("Dundee", "FurniturePrice").AsInt;
        int clothesPrice = DialogueLua.GetLocationField("Dundee", "ClothesPrice").AsInt;

		float playerMoney = DialogueLua.GetVariable("Money").AsInt;
		float totalPrice = fish*fishPrice + meat*meatPrice + cereals*cerealsPrice + ironOre*ironOrePrice + goldOre*goldOrePrice + wood*woodPrice + wool*woolPrice + bread*breadPrice + ale*alePrice + tools*toolsPrice + weapons*weaponsPrice + jewelry*jewelryPrice + furniture*furniturePrice + clothes*clothesPrice;
		int total = fish + meat + cereals + ironOre + goldOre + wood + wool + bread + ale + tools + weapons + jewelry + furniture + clothes;
		int warehousetotal = warehouseTotal();
		int warehousecapacity = warehouseCapacity();

		bool markethasgoods = true; 
		if(	((DialogueLua.GetLocationField("Dundee", "Fish").AsInt - fish)< 0) ||
			((DialogueLua.GetLocationField("Dundee", "Meat").AsInt - meat)< 0) ||
			((DialogueLua.GetLocationField("Dundee", "Cereal").AsInt - cereals)< 0) ||
			((DialogueLua.GetLocationField("Dundee", "IronOre").AsInt - ironOre)< 0) ||
			((DialogueLua.GetLocationField("Dundee", "GoldOre").AsInt - goldOre)< 0) ||
			((DialogueLua.GetLocationField("Dundee", "Wood").AsInt - wood)< 0) ||
			((DialogueLua.GetLocationField("Dundee", "Wool").AsInt - wool)< 0) ||
			((DialogueLua.GetLocationField("Dundee", "Bread").AsInt - bread)< 0) ||
			((DialogueLua.GetLocationField("Dundee", "Ale").AsInt - ale)< 0) ||
			((DialogueLua.GetLocationField("Dundee", "Tools").AsInt - tools)< 0) ||
			((DialogueLua.GetLocationField("Dundee", "Weapons").AsInt - weapons)< 0) ||
			((DialogueLua.GetLocationField("Dundee", "Jewelry").AsInt - jewelry)< 0) ||
			((DialogueLua.GetLocationField("Dundee", "Furniture").AsInt - furniture)< 0) ||
			((DialogueLua.GetLocationField("Dundee", "Clothes").AsInt - clothes)< 0))
			markethasgoods = false;

		//Purchase can be done
		if(totalPrice > playerMoney){
			print("Insufficient funds");
		}
		else if (warehousetotal+total > warehousecapacity){
			print("Warehouse full");
		}
		else if (!markethasgoods){
			print("Insufficient goods");
		} 
		else{
			DialogueLua.SetVariable("Money", playerMoney-totalPrice);
			DialogueLua.SetLocationField("Dundee", "Fish", ""+(DialogueLua.GetLocationField("Dundee", "Fish").AsInt - fish));
			DialogueLua.SetLocationField("Dundee", "Meat", ""+(DialogueLua.GetLocationField("Dundee", "Meat").AsInt - meat));
			DialogueLua.SetLocationField("Dundee", "Cereal", ""+(DialogueLua.GetLocationField("Dundee", "Cereal").AsInt - cereals));
			DialogueLua.SetLocationField("Dundee", "IronOre", ""+(DialogueLua.GetLocationField("Dundee", "IronOre").AsInt - ironOre));
			DialogueLua.SetLocationField("Dundee", "GoldOre", ""+(DialogueLua.GetLocationField("Dundee", "GoldOre").AsInt - goldOre));
			DialogueLua.SetLocationField("Dundee", "Wood", ""+(DialogueLua.GetLocationField("Dundee", "Wood").AsInt - wood));
			DialogueLua.SetLocationField("Dundee", "Wool", ""+(DialogueLua.GetLocationField("Dundee", "Wool").AsInt - wool));
			DialogueLua.SetLocationField("Dundee", "Bread", ""+(DialogueLua.GetLocationField("Dundee", "Bread").AsInt - bread));
			DialogueLua.SetLocationField("Dundee", "Ale", ""+(DialogueLua.GetLocationField("Dundee", "Ale").AsInt - ale));
			DialogueLua.SetLocationField("Dundee", "Tools", ""+(DialogueLua.GetLocationField("Dundee", "Tools").AsInt - tools));
			DialogueLua.SetLocationField("Dundee", "Weapons", ""+(DialogueLua.GetLocationField("Dundee", "Weapons").AsInt - weapons));
			DialogueLua.SetLocationField("Dundee", "Jewelry", ""+(DialogueLua.GetLocationField("Dundee", "Jewelry").AsInt - jewelry));
			DialogueLua.SetLocationField("Dundee", "Furniture", ""+(DialogueLua.GetLocationField("Dundee", "Furniture").AsInt - furniture));
			DialogueLua.SetLocationField("Dundee", "Clothes", ""+(DialogueLua.GetLocationField("Dundee", "Clothes").AsInt - clothes));

			DialogueLua.SetLocationField("DundeeWarehouse", "Fish", ""+(DialogueLua.GetLocationField("DundeeWarehouse", "Fish").AsInt + fish));
			DialogueLua.SetLocationField("DundeeWarehouse", "Meat", ""+(DialogueLua.GetLocationField("DundeeWarehouse", "Meat").AsInt + meat));
			DialogueLua.SetLocationField("DundeeWarehouse", "Cereal", ""+(DialogueLua.GetLocationField("DundeeWarehouse", "Cereal").AsInt + cereals));
			DialogueLua.SetLocationField("DundeeWarehouse", "IronOre", ""+(DialogueLua.GetLocationField("DundeeWarehouse", "IronOre").AsInt + ironOre));
			DialogueLua.SetLocationField("DundeeWarehouse", "GoldOre", ""+(DialogueLua.GetLocationField("DundeeWarehouse", "GoldOre").AsInt + goldOre));
			DialogueLua.SetLocationField("DundeeWarehouse", "Wood", ""+(DialogueLua.GetLocationField("DundeeWarehouse", "Wood").AsInt + wood));
			DialogueLua.SetLocationField("DundeeWarehouse", "Wool", ""+(DialogueLua.GetLocationField("DundeeWarehouse", "Wool").AsInt + wool));
			DialogueLua.SetLocationField("DundeeWarehouse", "Bread", ""+(DialogueLua.GetLocationField("DundeeWarehouse", "Bread").AsInt + bread));
			DialogueLua.SetLocationField("DundeeWarehouse", "Ale", ""+(DialogueLua.GetLocationField("DundeeWarehouse", "Ale").AsInt + ale));
			DialogueLua.SetLocationField("DundeeWarehouse", "Tools", ""+(DialogueLua.GetLocationField("DundeeWarehouse", "Tools").AsInt + tools));
			DialogueLua.SetLocationField("DundeeWarehouse", "Weapons", ""+(DialogueLua.GetLocationField("DundeeWarehouse", "Weapons").AsInt + weapons));
			DialogueLua.SetLocationField("DundeeWarehouse", "Jewelry", ""+(DialogueLua.GetLocationField("DundeeWarehouse", "Jewelry").AsInt + jewelry));
			DialogueLua.SetLocationField("DundeeWarehouse", "Furniture", ""+(DialogueLua.GetLocationField("DundeeWarehouse", "Furniture").AsInt + furniture));
			DialogueLua.SetLocationField("DundeeWarehouse", "Clothes", ""+(DialogueLua.GetLocationField("DundeeWarehouse", "Clothes").AsInt + clothes));

			getMarketStored();
			getMarketPrices();
			getMarketStock();
			resetInputFields();
			
		}
		
	}

	void updateSell(){
	
		int fish = Convert.ToInt32(inputFish.text);
		int meat = Convert.ToInt32(inputMeat.text);
		int cereals = Convert.ToInt32(inputCereals.text);
		int ironOre = Convert.ToInt32(inputIronOre.text);
		int goldOre = Convert.ToInt32(inputGoldOre.text);
		int wood = Convert.ToInt32(inputWood.text);
		int wool = Convert.ToInt32(inputWool.text);
		int bread = Convert.ToInt32(inputBread.text);
		int ale = Convert.ToInt32(inputAle.text);
		int tools = Convert.ToInt32(inputTools.text);
		int weapons = Convert.ToInt32(inputWeapons.text);
		int jewelry = Convert.ToInt32(inputJewelry.text);
		int furniture = Convert.ToInt32(inputFurniture.text);
		int clothes = Convert.ToInt32(inputClothes.text);

        int fishPrice = DialogueLua.GetLocationField("Dundee", "FishPrice").AsInt;
        int meatPrice = DialogueLua.GetLocationField("Dundee", "MeatPrice").AsInt;
        int cerealsPrice = DialogueLua.GetLocationField("Dundee", "CerealPrice").AsInt;
        int ironOrePrice = DialogueLua.GetLocationField("Dundee", "IronOrePrice").AsInt;
        int goldOrePrice = DialogueLua.GetLocationField("Dundee", "GoldOrePrice").AsInt;
        int woodPrice = DialogueLua.GetLocationField("Dundee", "WoodPrice").AsInt;
        int woolPrice = DialogueLua.GetLocationField("Dundee", "WoolPrice").AsInt;
        int breadPrice = DialogueLua.GetLocationField("Dundee", "BreadPrice").AsInt;
        int alePrice = DialogueLua.GetLocationField("Dundee", "AlePrice").AsInt;
        int toolsPrice = DialogueLua.GetLocationField("Dundee", "ToolsPrice").AsInt;
        int weaponsPrice = DialogueLua.GetLocationField("Dundee", "WeaponsPrice").AsInt;
        int jewelryPrice = DialogueLua.GetLocationField("Dundee", "JewelryPrice").AsInt;
        int furniturePrice = DialogueLua.GetLocationField("Dundee", "FurniturePrice").AsInt;
        int clothesPrice = DialogueLua.GetLocationField("Dundee", "ClothesPrice").AsInt;

		bool playerhasgoods = true; 
		if(	((DialogueLua.GetLocationField("DundeeWarehouse", "Fish").AsInt - fish)< 0) ||
			((DialogueLua.GetLocationField("DundeeWarehouse", "Meat").AsInt - meat)< 0) ||
			((DialogueLua.GetLocationField("DundeeWarehouse", "Cereal").AsInt - cereals)< 0) ||
			((DialogueLua.GetLocationField("DundeeWarehouse", "IronOre").AsInt - ironOre)< 0) ||
			((DialogueLua.GetLocationField("DundeeWarehouse", "GoldOre").AsInt - goldOre)< 0) ||
			((DialogueLua.GetLocationField("DundeeWarehouse", "Wood").AsInt - wood)< 0) ||
			((DialogueLua.GetLocationField("DundeeWarehouse", "Wool").AsInt - wool)< 0) ||
			((DialogueLua.GetLocationField("DundeeWarehouse", "Bread").AsInt - bread)< 0) ||
			((DialogueLua.GetLocationField("DundeeWarehouse", "Ale").AsInt - ale)< 0) ||
			((DialogueLua.GetLocationField("DundeeWarehouse", "Tools").AsInt - tools)< 0) ||
			((DialogueLua.GetLocationField("DundeeWarehouse", "Weapons").AsInt - weapons)< 0) ||
			((DialogueLua.GetLocationField("DundeeWarehouse", "Jewelry").AsInt - jewelry)< 0) ||
			((DialogueLua.GetLocationField("DundeeWarehouse", "Furniture").AsInt - furniture)< 0) ||
			((DialogueLua.GetLocationField("DundeeWarehouse", "Clothes").AsInt - clothes)< 0))
			playerhasgoods = false;

		if (!playerhasgoods){
			print("Insufficient goods in warehouse");
		} 
		else{
			float playerMoney = DialogueLua.GetVariable("Money").AsInt;
			float totalPrice = fish*fishPrice + meat*meatPrice + cereals*cerealsPrice + ironOre*ironOrePrice + goldOre*goldOrePrice + wood*woodPrice + wool*woolPrice + bread*breadPrice + ale*alePrice + tools*toolsPrice + weapons*weaponsPrice + jewelry*jewelryPrice + furniture*furniturePrice + clothes*clothesPrice;
			DialogueLua.SetVariable("Money", playerMoney+totalPrice);

			DialogueLua.SetLocationField("Dundee", "Fish", ""+(DialogueLua.GetLocationField("Dundee", "Fish").AsInt + fish));
			DialogueLua.SetLocationField("Dundee", "Meat", ""+(DialogueLua.GetLocationField("Dundee", "Meat").AsInt + meat));
			DialogueLua.SetLocationField("Dundee", "Cereal", ""+(DialogueLua.GetLocationField("Dundee", "Cereal").AsInt + cereals));
			DialogueLua.SetLocationField("Dundee", "IronOre", ""+(DialogueLua.GetLocationField("Dundee", "IronOre").AsInt + ironOre));
			DialogueLua.SetLocationField("Dundee", "GoldOre", ""+(DialogueLua.GetLocationField("Dundee", "GoldOre").AsInt + goldOre));
			DialogueLua.SetLocationField("Dundee", "Wood", ""+(DialogueLua.GetLocationField("Dundee", "Wood").AsInt + wood));
			DialogueLua.SetLocationField("Dundee", "Wool", ""+(DialogueLua.GetLocationField("Dundee", "Wool").AsInt + wool));
			DialogueLua.SetLocationField("Dundee", "Bread", ""+(DialogueLua.GetLocationField("Dundee", "Bread").AsInt + bread));
			DialogueLua.SetLocationField("Dundee", "Ale", ""+(DialogueLua.GetLocationField("Dundee", "Ale").AsInt + ale));
			DialogueLua.SetLocationField("Dundee", "Tools", ""+(DialogueLua.GetLocationField("Dundee", "Tools").AsInt + tools));
			DialogueLua.SetLocationField("Dundee", "Weapons", ""+(DialogueLua.GetLocationField("Dundee", "Weapons").AsInt + weapons));
			DialogueLua.SetLocationField("Dundee", "Jewelry", ""+(DialogueLua.GetLocationField("Dundee", "Jewelry").AsInt + jewelry));
			DialogueLua.SetLocationField("Dundee", "Furniture", ""+(DialogueLua.GetLocationField("Dundee", "Furniture").AsInt + furniture));
			DialogueLua.SetLocationField("Dundee", "Clothes", ""+(DialogueLua.GetLocationField("Dundee", "Clothes").AsInt + clothes));

			DialogueLua.SetLocationField("DundeeWarehouse", "Fish", ""+(DialogueLua.GetLocationField("DundeeWarehouse", "Fish").AsInt - fish));
			DialogueLua.SetLocationField("DundeeWarehouse", "Meat", ""+(DialogueLua.GetLocationField("DundeeWarehouse", "Meat").AsInt - meat));
			DialogueLua.SetLocationField("DundeeWarehouse", "Cereal", ""+(DialogueLua.GetLocationField("DundeeWarehouse", "Cereal").AsInt - cereals));
			DialogueLua.SetLocationField("DundeeWarehouse", "IronOre", ""+(DialogueLua.GetLocationField("DundeeWarehouse", "IronOre").AsInt - ironOre));
			DialogueLua.SetLocationField("DundeeWarehouse", "GoldOre", ""+(DialogueLua.GetLocationField("DundeeWarehouse", "GoldOre").AsInt - goldOre));
			DialogueLua.SetLocationField("DundeeWarehouse", "Wood", ""+(DialogueLua.GetLocationField("DundeeWarehouse", "Wood").AsInt - wood));
			DialogueLua.SetLocationField("DundeeWarehouse", "Wool", ""+(DialogueLua.GetLocationField("DundeeWarehouse", "Wool").AsInt - wool));
			DialogueLua.SetLocationField("DundeeWarehouse", "Bread", ""+(DialogueLua.GetLocationField("DundeeWarehouse", "Bread").AsInt - bread));
			DialogueLua.SetLocationField("DundeeWarehouse", "Ale", ""+(DialogueLua.GetLocationField("DundeeWarehouse", "Ale").AsInt - ale));
			DialogueLua.SetLocationField("DundeeWarehouse", "Tools", ""+(DialogueLua.GetLocationField("DundeeWarehouse", "Tools").AsInt - tools));
			DialogueLua.SetLocationField("DundeeWarehouse", "Weapons", ""+(DialogueLua.GetLocationField("DundeeWarehouse", "Weapons").AsInt - weapons));
			DialogueLua.SetLocationField("DundeeWarehouse", "Jewelry", ""+(DialogueLua.GetLocationField("DundeeWarehouse", "Jewelry").AsInt - jewelry));
			DialogueLua.SetLocationField("DundeeWarehouse", "Furniture", ""+(DialogueLua.GetLocationField("DundeeWarehouse", "Furniture").AsInt - furniture));
			DialogueLua.SetLocationField("DundeeWarehouse", "Clothes", ""+(DialogueLua.GetLocationField("DundeeWarehouse", "Clothes").AsInt - clothes));

			getMarketStored();
			getMarketPrices();
			getMarketStock();
			resetInputFields();
			
		}
		
	}

	int warehouseCapacity(){
	return (DialogueLua.GetLocationField("DundeeWarehouse", "Level").AsInt+1)*100;
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

	void resetInputFields(){
		inputFish.text = ""+0;
			inputMeat.text = ""+0;
			inputCereals.text = ""+0;
			inputIronOre.text = ""+0;
			inputGoldOre.text = ""+0;
			inputWood.text = ""+0;
			inputWool.text = ""+0;
			inputBread.text = ""+0;
			inputAle.text = ""+0;
			inputTools.text = ""+0;
			inputWeapons.text = ""+0;
			inputJewelry.text = ""+0;
			inputFurniture.text = ""+0;
			inputClothes.text = ""+0;
	}

	void getWarehouseGoods(){
            warehouseMaterialText = warehouseFish.GetComponent<Text>();
            warehouseMaterialText.text = "Fish: " + DialogueLua.GetLocationField("DundeeWarehouse", "Fish").AsInt;
            warehouseMaterialText = warehouseMeat.GetComponent<Text>();
            warehouseMaterialText.text = "Meat: " + DialogueLua.GetLocationField("DundeeWarehouse", "Meat").AsInt;
            warehouseMaterialText = warehouseCereals.GetComponent<Text>();
            warehouseMaterialText.text = "Cereals: " + DialogueLua.GetLocationField("DundeeWarehouse", "Cereal").AsInt;
            warehouseMaterialText = warehouseIronOre.GetComponent<Text>();
            warehouseMaterialText.text = "Iron Ore: " + DialogueLua.GetLocationField("DundeeWarehouse", "IronOre").AsInt;
            warehouseMaterialText = warehouseGoldOre.GetComponent<Text>();
            warehouseMaterialText.text = "Gold Ore: " + DialogueLua.GetLocationField("DundeeWarehouse", "GoldOre").AsInt;
            warehouseMaterialText = warehouseWood.GetComponent<Text>();
            warehouseMaterialText.text = "Wood: " + DialogueLua.GetLocationField("DundeeWarehouse", "Wood").AsInt;
            warehouseMaterialText = warehouseWool.GetComponent<Text>();
            warehouseMaterialText.text = "Wool: " + DialogueLua.GetLocationField("DundeeWarehouse", "Wool").AsInt;
            warehouseMaterialText = warehouseBread.GetComponent<Text>();
            warehouseMaterialText.text = "Bread: " + DialogueLua.GetLocationField("DundeeWarehouse", "Bread").AsInt;
            warehouseMaterialText = warehouseAle.GetComponent<Text>();
            warehouseMaterialText.text = "Ale: " + DialogueLua.GetLocationField("DundeeWarehouse", "Ale").AsInt;
            warehouseMaterialText = warehouseTools.GetComponent<Text>();
            warehouseMaterialText.text = "Tools: " + DialogueLua.GetLocationField("DundeeWarehouse", "Tools").AsInt;
            warehouseMaterialText = warehouseWeapons.GetComponent<Text>();
            warehouseMaterialText.text = "Weapons: " + DialogueLua.GetLocationField("DundeeWarehouse", "Weapons").AsInt;
            warehouseMaterialText = warehouseJewelry.GetComponent<Text>();
            warehouseMaterialText.text = "Jewelry: " + DialogueLua.GetLocationField("DundeeWarehouse", "Jewelry").AsInt;
            warehouseMaterialText = warehouseFurniture.GetComponent<Text>();
            warehouseMaterialText.text = "Furniture: " + DialogueLua.GetLocationField("DundeeWarehouse", "Furniture").AsInt;
            warehouseMaterialText = warehouseClothes.GetComponent<Text>();
            warehouseMaterialText.text = "Clothes: " + DialogueLua.GetLocationField("DundeeWarehouse", "Clothes").AsInt;
           
		    warehouseMaterialText = warehouseLevel.GetComponent<Text>();
            warehouseMaterialText.text = "Level: " + DialogueLua.GetLocationField("DundeeWarehouse", "WarehouseLevel").AsInt + " (Max Capacity " +  warehouseCapacity() + " units)";

	
	}
}