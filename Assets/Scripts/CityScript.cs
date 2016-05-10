using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class CityScript : MonoBehaviour {

	public GameObject countyName;
	public GameObject cityName;
    public GameObject option1;
    public GameObject option2;
    public GameObject option3;
    public GameObject option4;
    public GameObject marketPanel;
	public GameObject warehousePanel;

	//Warehouse Materials
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

	//Market Materials
	public GameObject marketFish;
	public GameObject marketMeat;
	public GameObject marketCereals;
	public GameObject marketIronOre;
	public GameObject marketGoldOre;
	public GameObject marketWood;
	public GameObject marketWool;
	public GameObject marketBread;
	public GameObject marketAle;
	public GameObject marketTools;
	public GameObject marketWeapons;
	public GameObject marketJewelry;
	public GameObject marketFurniture;
	public GameObject marketClothes;

    private Text countyNameText;
	private Text cityNameText;
	private Text warehouseMaterialText;
	private Text marketMaterialText;
	

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
        DisableButtons();

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
        
		//Market

        option2.GetComponentInChildren<Text>().text = "Go to Market";
        option2.GetComponent<Button>().onClick.AddListener(() => 
        {
            //Market.Teste(marketPanel);
			marketPanel.SetActive(true);
			marketPanel.GetComponentInChildren<Text>().text = "Marketplace";
            DisableButtons();

			marketMaterialText = marketFish.GetComponent<Text>();
			marketMaterialText.text = "Fish"+ "  |  " + 
			DialogueLua.GetLocationField("Dundee", "Fish").AsInt + "  |  " + 
			((DialogueLua.GetLocationField("Dundee", "FishPrice").AsFloat)*1.1) + "  |  " + 
			DialogueLua.GetLocationField("DundeeWarehouse", "Fish").AsInt + "  |  " + 
			((DialogueLua.GetLocationField("Dundee", "FishPrice").AsFloat)*0.9);

			marketMaterialText = marketMeat.GetComponent<Text>();
			marketMaterialText.text = "Meat"+ "  |  " + 
			DialogueLua.GetLocationField("Dundee", "Meat").AsInt + "  |  " + 
			((DialogueLua.GetLocationField("Dundee", "MeatPrice").AsFloat)*1.1) + "  |  " + 
			DialogueLua.GetLocationField("DundeeWarehouse", "Meat").AsInt + "  |  " + 
			((DialogueLua.GetLocationField("Dundee", "MeatPrice").AsFloat)*0.9);

			marketMaterialText = marketCereals.GetComponent<Text>();
			marketMaterialText.text = "Cereal"+ "  |  " + 
			DialogueLua.GetLocationField("Dundee", "Cereal").AsInt + "  |  " + 
			((DialogueLua.GetLocationField("Dundee", "CerealPrice").AsFloat)*1.1) + "  |  " + 
			DialogueLua.GetLocationField("DundeeWarehouse", "Cereal").AsInt + "  |  " + 
			((DialogueLua.GetLocationField("Dundee", "CerealPrice").AsFloat)*0.9);

			marketMaterialText = marketIronOre.GetComponent<Text>();
			marketMaterialText.text = "Iron Ore"+ "  |  " + 
			DialogueLua.GetLocationField("Dundee", "IronOre").AsInt + "  |  " + 
			((DialogueLua.GetLocationField("Dundee", "IronOrePrice").AsFloat)*1.1) + "  |  " + 
			DialogueLua.GetLocationField("DundeeWarehouse", "IronOre").AsInt + "  |  " + 
			((DialogueLua.GetLocationField("Dundee", "IronOrePrice").AsFloat)*0.9);

			marketMaterialText = marketGoldOre.GetComponent<Text>();
			marketMaterialText.text = "Gold Ore"+ "  |  " + 
			DialogueLua.GetLocationField("Dundee", "GoldOre").AsInt + "  |  " + 
			((DialogueLua.GetLocationField("Dundee", "GoldOrePrice").AsFloat)*1.1) + "  |  " + 
			DialogueLua.GetLocationField("DundeeWarehouse", "GoldOre").AsInt + "  |  " + 
			((DialogueLua.GetLocationField("Dundee", "FishPrice").AsFloat)*0.9);

			marketMaterialText = marketWood.GetComponent<Text>();
			marketMaterialText.text = "Wood"+ "  |  " + 
			DialogueLua.GetLocationField("Dundee", "Wood").AsInt + "  |  " + 
			((DialogueLua.GetLocationField("Dundee", "WoodPrice").AsFloat)*1.1) + "  |  " + 
			DialogueLua.GetLocationField("DundeeWarehouse", "Wood").AsInt + "  |  " + 
			((DialogueLua.GetLocationField("Dundee", "WoodPrice").AsFloat)*0.9);

			marketMaterialText = marketWool.GetComponent<Text>();
			marketMaterialText.text = "Wool"+ "  |  " + 
			DialogueLua.GetLocationField("Dundee", "Wool").AsInt + "  |  " + 
			((DialogueLua.GetLocationField("Dundee", "WoolPrice").AsFloat)*1.1) + "  |  " + 
			DialogueLua.GetLocationField("DundeeWarehouse", "Wool").AsInt + "  |  " + 
			((DialogueLua.GetLocationField("Dundee", "WoolPrice").AsFloat)*0.9);

			marketMaterialText = marketClothes.GetComponent<Text>();
			marketMaterialText.text = "Clothes"+ "  |  " + 
			DialogueLua.GetLocationField("Dundee", "Clothes").AsInt + "  |  " + 
			((DialogueLua.GetLocationField("Dundee", "ClothesPrice").AsFloat)*1.1) + "  |  " + 
			DialogueLua.GetLocationField("DundeeWarehouse", "Clothes").AsInt + "  |  " + 
			((DialogueLua.GetLocationField("Dundee", "ClothesPrice").AsFloat)*0.9);

			marketMaterialText = marketFurniture.GetComponent<Text>();
			marketMaterialText.text = "Furniture"+ "  |  " + 
			DialogueLua.GetLocationField("Dundee", "Furniture").AsInt + "  |  " + 
			((DialogueLua.GetLocationField("Dundee", "FurniturePrice").AsFloat)*1.1) + "  |  " + 
			DialogueLua.GetLocationField("DundeeWarehouse", "Furniture").AsInt + "  |  " + 
			((DialogueLua.GetLocationField("Dundee", "FurniturePrice").AsFloat)*0.9);

			marketMaterialText = marketJewelry.GetComponent<Text>();
			marketMaterialText.text = "Jewelry"+ "  |  " + 
			DialogueLua.GetLocationField("Dundee", "Jewelry").AsInt + "  |  " + 
			((DialogueLua.GetLocationField("Dundee", "JewelryPrice").AsFloat)*1.1) + "  |  " + 
			DialogueLua.GetLocationField("DundeeWarehouse", "Jewelry").AsInt + "  |  " + 
			((DialogueLua.GetLocationField("Dundee", "JewelryPrice").AsFloat)*0.9);

			marketMaterialText = marketWeapons.GetComponent<Text>();
			marketMaterialText.text = "Weapons"+ "  |  " + 
			DialogueLua.GetLocationField("Dundee", "Weapons").AsInt + "  |  " + 
			((DialogueLua.GetLocationField("Dundee", "WeaponsPrice").AsFloat)*1.1) + "  |  " + 
			DialogueLua.GetLocationField("DundeeWarehouse", "Weapons").AsInt + "  |  " + 
			((DialogueLua.GetLocationField("Dundee", "WeaponsPrice").AsFloat)*0.9);

			marketMaterialText = marketTools.GetComponent<Text>();
			marketMaterialText.text = "Tools"+ "  |  " + 
			DialogueLua.GetLocationField("Dundee", "Tools").AsInt + "  |  " + 
			((DialogueLua.GetLocationField("Dundee", "ToolsPrice").AsFloat)*1.1) + "  |  " + 
			DialogueLua.GetLocationField("DundeeWarehouse", "Tools").AsInt + "  |  " + 
			((DialogueLua.GetLocationField("Dundee", "ToolsPrice").AsFloat)*0.9);

			marketMaterialText = marketAle.GetComponent<Text>();
			marketMaterialText.text = "Ale"+ "  |  " + 
			DialogueLua.GetLocationField("Dundee", "Ale").AsInt + "  |  " + 
			((DialogueLua.GetLocationField("Dundee", "AlePrice").AsFloat)*1.1) + "  |  " + 
			DialogueLua.GetLocationField("DundeeWarehouse", "Ale").AsInt + "  |  " + 
			((DialogueLua.GetLocationField("Dundee", "AlePrice").AsFloat)*0.9);

			marketMaterialText = marketBread.GetComponent<Text>();
			marketMaterialText.text = "Bread"+ "  |  " + 
			DialogueLua.GetLocationField("Dundee", "Bread").AsInt + "  |  " + 
			((DialogueLua.GetLocationField("Dundee", "BreadPrice").AsFloat)*1.1) + "  |  " + 
			DialogueLua.GetLocationField("DundeeWarehouse", "Bread").AsInt + "  |  " + 
			((DialogueLua.GetLocationField("Dundee", "BreadPrice").AsFloat)*0.9);

			option4.GetComponentInChildren<Text>().text = "Leave Market";
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

			warehouseMaterialText = warehouseFish.GetComponent<Text>();
			warehouseMaterialText.text = "Fish: "+ DialogueLua.GetLocationField("DundeeWarehouse", "Fish").AsInt;
			warehouseMaterialText = warehouseMeat.GetComponent<Text>();
			warehouseMaterialText.text = "Meat: "+ DialogueLua.GetLocationField("DundeeWarehouse", "Meat").AsInt;
			warehouseMaterialText = warehouseCereals.GetComponent<Text>();
			warehouseMaterialText.text = "Cereals: "+ DialogueLua.GetLocationField("DundeeWarehouse", "Cereals").AsInt;
			warehouseMaterialText = warehouseIronOre.GetComponent<Text>();
			warehouseMaterialText.text = "Iron Ore: "+ DialogueLua.GetLocationField("DundeeWarehouse", "IronOre").AsInt;
			warehouseMaterialText = warehouseGoldOre.GetComponent<Text>();
			warehouseMaterialText.text = "Gold Ore: "+ DialogueLua.GetLocationField("DundeeWarehouse", "GoldOre").AsInt;
			warehouseMaterialText = warehouseWood.GetComponent<Text>();
			warehouseMaterialText.text = "Wood: "+ DialogueLua.GetLocationField("DundeeWarehouse", "Wood").AsInt;
			warehouseMaterialText = warehouseWool.GetComponent<Text>();
			warehouseMaterialText.text = "Wool: "+ DialogueLua.GetLocationField("DundeeWarehouse", "Wool").AsInt;
			warehouseMaterialText = warehouseBread.GetComponent<Text>();
			warehouseMaterialText.text = "Bread: "+ DialogueLua.GetLocationField("DundeeWarehouse", "Bread").AsInt;
			warehouseMaterialText = warehouseAle.GetComponent<Text>();
			warehouseMaterialText.text = "Ale: "+ DialogueLua.GetLocationField("DundeeWarehouse", "Ale").AsInt;
			warehouseMaterialText = warehouseTools.GetComponent<Text>();
			warehouseMaterialText.text = "Tools: "+ DialogueLua.GetLocationField("DundeeWarehouse", "Tools").AsInt;
			warehouseMaterialText = warehouseWeapons.GetComponent<Text>();
			warehouseMaterialText.text = "Weapons: "+ DialogueLua.GetLocationField("DundeeWarehouse", "Weapons").AsInt;
			warehouseMaterialText = warehouseJewelry.GetComponent<Text>();
			warehouseMaterialText.text = "Jewelry: "+ DialogueLua.GetLocationField("DundeeWarehouse", "Jewelry").AsInt;
			warehouseMaterialText = warehouseFurniture.GetComponent<Text>();
			warehouseMaterialText.text = "Furniture: "+ DialogueLua.GetLocationField("DundeeWarehouse", "Furniture").AsInt;
			warehouseMaterialText = warehouseClothes.GetComponent<Text>();
			warehouseMaterialText.text = "Clothes: "+ DialogueLua.GetLocationField("DundeeWarehouse", "Clothes").AsInt;
			warehouseMaterialText = warehouseLevel.GetComponent<Text>();
			warehouseMaterialText.text = "Level: "+ DialogueLua.GetLocationField("DundeeWarehouse", "WarehouseLevel").AsInt +" (Max Capacity "+ ((DialogueLua.GetLocationField("DundeeWarehouse", "Level").AsInt)*100) +" units)";

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
}
