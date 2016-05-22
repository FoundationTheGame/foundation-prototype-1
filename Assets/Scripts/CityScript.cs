using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class CityScript : MonoBehaviour
{

    public GameObject countyName;
    public GameObject cityName;
    public GameObject option1;
    public GameObject option2;
    public GameObject option3;
    public GameObject option4;
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

    private Text countyNameText;
    private Text cityNameText;
    private Text warehouseMaterialText;
	private Text marketStoredText;


    public int units = 0;
    public int type;
    public double unit_price; 

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

		marketStoredText = warehouseFish.GetComponent<Text>();
        marketStoredText.text = "Fish: " + DialogueLua.GetLocationField("DundeeWarehouse", "Fish").AsInt;
        marketStoredText = warehouseMeat.GetComponent<Text>();
        marketStoredText.text = "Meat: " + DialogueLua.GetLocationField("DundeeWarehouse", "Meat").AsInt;
        marketStoredText = warehouseCereals.GetComponent<Text>();
        marketStoredText.text = "Cereals: " + DialogueLua.GetLocationField("DundeeWarehouse", "Cereals").AsInt;
        marketStoredText = warehouseIronOre.GetComponent<Text>();
        marketStoredText.text = "Iron Ore: " + DialogueLua.GetLocationField("DundeeWarehouse", "IronOre").AsInt;
        marketStoredText = warehouseGoldOre.GetComponent<Text>();
        marketStoredText.text = "Gold Ore: " + DialogueLua.GetLocationField("DundeeWarehouse", "GoldOre").AsInt;
        marketStoredText = warehouseWood.GetComponent<Text>();
        marketStoredText.text = "Wood: " + DialogueLua.GetLocationField("DundeeWarehouse", "Wood").AsInt;
        marketStoredText = warehouseWool.GetComponent<Text>();
        marketStoredText.text = "Wool: " + DialogueLua.GetLocationField("DundeeWarehouse", "Wool").AsInt;
        marketStoredText = warehouseBread.GetComponent<Text>();
        marketStoredText.text = "Bread: " + DialogueLua.GetLocationField("DundeeWarehouse", "Bread").AsInt;
        marketStoredText = warehouseAle.GetComponent<Text>();
        marketStoredText.text = "Ale: " + DialogueLua.GetLocationField("DundeeWarehouse", "Ale").AsInt;
        marketStoredText = warehouseTools.GetComponent<Text>();
        marketStoredText.text = "Tools: " + DialogueLua.GetLocationField("DundeeWarehouse", "Tools").AsInt;
        marketStoredText = warehouseWeapons.GetComponent<Text>();
        marketStoredText.text = "Weapons: " + DialogueLua.GetLocationField("DundeeWarehouse", "Weapons").AsInt;
        marketStoredText = warehouseJewelry.GetComponent<Text>();
        marketStoredText.text = "Jewelry: " + DialogueLua.GetLocationField("DundeeWarehouse", "Jewelry").AsInt;
        marketStoredText = warehouseFurniture.GetComponent<Text>();
        marketStoredText.text = "Furniture: " + DialogueLua.GetLocationField("DundeeWarehouse", "Furniture").AsInt;
        marketStoredText = warehouseClothes.GetComponent<Text>();
        marketStoredText.text = "Clothes: " + DialogueLua.GetLocationField("DundeeWarehouse", "Clothes").AsInt;

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

            warehouseMaterialText = warehouseFish.GetComponent<Text>();
            warehouseMaterialText.text = "Fish: " + DialogueLua.GetLocationField("DundeeWarehouse", "Fish").AsInt;
            warehouseMaterialText = warehouseMeat.GetComponent<Text>();
            warehouseMaterialText.text = "Meat: " + DialogueLua.GetLocationField("DundeeWarehouse", "Meat").AsInt;
            warehouseMaterialText = warehouseCereals.GetComponent<Text>();
            warehouseMaterialText.text = "Cereals: " + DialogueLua.GetLocationField("DundeeWarehouse", "Cereals").AsInt;
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
            warehouseMaterialText.text = "Level: " + DialogueLua.GetLocationField("DundeeWarehouse", "WarehouseLevel").AsInt + " (Max Capacity " + (DialogueLua.GetLocationField("DundeeWarehouse", "Level").AsInt+1)*100 + " units)";

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
}