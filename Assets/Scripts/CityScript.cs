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
    public GameObject option5;
    public GameObject option6;
    public GameObject DundeeFocus;
    public GameObject AmbersmithFocus;
    public GameObject AngusFocus;
    public GameObject GuthrieFocus;
    public GameObject focused;
    public GameObject marketPanel;
    public GameObject marketbuyPanel;
    public GameObject marketsellPanel;
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

    //Market buy Materials 
    public GameObject marketBFish;
    public GameObject marketBMeat;
    public GameObject marketBCereals;
    public GameObject marketBIronOre;
    public GameObject marketBGoldOre;
    public GameObject marketBWood;
    public GameObject marketBWool;
    public GameObject marketBBread;
    public GameObject marketBAle;
    public GameObject marketBTools;
    public GameObject marketBWeapons;
    public GameObject marketBJewelry;
    public GameObject marketBFurniture;
    public GameObject marketBClothes;

    public GameObject marketBQuantity;
    public GameObject marketBPlus;
    public GameObject marketBMinus;
    public GameObject marketBComfirm;
    public GameObject marketBCancel;
    public GameObject marketBTotal;

    public GameObject imputBFish;
    public GameObject imputBMeat;
    public GameObject imputBCereals;
    public GameObject imputBIronOre;
    public GameObject imputBGoldOre;
    public GameObject imputBWood;
    public GameObject imputBWool;
    public GameObject imputBBread;
    public GameObject imputBAle;
    public GameObject imputBTools;
    public GameObject imputBWeapons;
    public GameObject imputBJewelry;
    public GameObject imputBFurniture;
    public GameObject imputBClothes;

    //Market Sell Materials 
    public GameObject marketSFish;
    public GameObject marketSMeat;
    public GameObject marketSCereals;
    public GameObject marketSIronOre;
    public GameObject marketSGoldOre;
    public GameObject marketSWood;
    public GameObject marketSWool;
    public GameObject marketSBread;
    public GameObject marketSAle;
    public GameObject marketSTools;
    public GameObject marketSWeapons;
    public GameObject marketSJewelry;
    public GameObject marketSFurniture;
    public GameObject marketSClothes;

    private Text countyNameText;
    private Text cityNameText;
    private Text warehouseMaterialText;
    private Text marketMaterialText;


    public int units = 0;
    public int type;
    public double unit_price; 

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
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

        //Market

        option2.GetComponentInChildren<Text>().text = "Go to Market";
        
        option2.GetComponent<Button>().onClick.AddListener(() =>
        { 
        marketPanel.SetActive(true);
        marketPanel.GetComponentInChildren<Text>().text = "Marketplace";
        DisableButtons();
        option5.GetComponentInChildren<Text>().text = "Buy";
        option6.GetComponentInChildren<Text>().text = "sell";

            option5.GetComponent<Button>().onClick.AddListener(() =>
            {
                buypanel();


          });
            option6.GetComponent<Button>().onClick.AddListener(() =>
            {
                sellpanel();
            }); 

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
            warehouseMaterialText.text = "Level: " + DialogueLua.GetLocationField("DundeeWarehouse", "WarehouseLevel").AsInt + " (Max Capacity " + ((DialogueLua.GetLocationField("DundeeWarehouse", "Level").AsInt) * 100) + " units)";

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

    void buypanel()
    {
            //Market.Teste(marketPanel);
            marketPanel.SetActive(false);
            marketsellPanel.SetActive(false);
          /* marketBQuantity.SetActive(false);
            marketBPlus.SetActive(false);
            marketBMinus.SetActive(false);
            marketBComfirm.SetActive(false);
            marketBCancel.SetActive(false);
            marketBTotal.SetActive(false);*/
            marketbuyPanel.SetActive(true);
            marketPanel.GetComponentInChildren<Text>().text = "Marketplace";
            DisableButtons();

            marketMaterialText = marketBFish.GetComponent<Text>();
            marketMaterialText.text = "Fish              " +
            DialogueLua.GetLocationField("Dundee", "Fish").AsInt + "            " +
            ((DialogueLua.GetLocationField("Dundee", "FishPrice").AsFloat) * 1.1) + "                    " +
            DialogueLua.GetLocationField("DundeeWarehouse", "Fish").AsInt;
            //  ((DialogueLua.GetLocationField("Dundee", "FishPrice").AsFloat) * 0.9);

            marketMaterialText = marketBMeat.GetComponent<Text>();
            marketMaterialText.text = "Meat            " +
            DialogueLua.GetLocationField("Dundee", "Meat").AsInt + "              " +
            ((DialogueLua.GetLocationField("Dundee", "MeatPrice").AsFloat) * 1.1) + "                  " +
            DialogueLua.GetLocationField("DundeeWarehouse", "Meat").AsInt;
            // ((DialogueLua.GetLocationField("Dundee", "MeatPrice").AsFloat) * 0.9);

            marketMaterialText = marketBCereals.GetComponent<Text>();
            marketMaterialText.text = "Cereals      " +
            DialogueLua.GetLocationField("Dundee", "Cereal").AsInt + "              " +
            ((DialogueLua.GetLocationField("Dundee", "CerealsPrice").AsFloat) * 1.1) + "                    " +
            DialogueLua.GetLocationField("DundeeWarehouse", "Cereals").AsInt;
            //((DialogueLua.GetLocationField("Dundee", "CerealsPrice").AsFloat) * 0.9);

            marketMaterialText = marketBIronOre.GetComponent<Text>();
            marketMaterialText.text = "Iron ore         " +
            DialogueLua.GetLocationField("Dundee", "IronOre").AsInt + "              " +
            ((DialogueLua.GetLocationField("Dundee", "IronOrePrice").AsFloat) * 1.1) + "                 " +
            DialogueLua.GetLocationField("DundeeWarehouse", "IronOre").AsInt;
            // ((DialogueLua.GetLocationField("Dundee", "IronOrePrice").AsFloat) * 0.9);

            marketMaterialText = marketBGoldOre.GetComponent<Text>();
            marketMaterialText.text = "Gold ore       " +
            DialogueLua.GetLocationField("Dundee", "GoldOre").AsInt + "            " +
            ((DialogueLua.GetLocationField("Dundee", "GoldOrePrice").AsFloat) * 1.1) + "                  " +
            DialogueLua.GetLocationField("DundeeWarehouse", "GoldOre").AsInt;
            //((DialogueLua.GetLocationField("Dundee", "GoldOrePrice").AsFloat) * 0.9);

            marketMaterialText = marketBWood.GetComponent<Text>();
            marketMaterialText.text = "Wood        " +
            DialogueLua.GetLocationField("Dundee", "Wood").AsInt + "             " +
            ((DialogueLua.GetLocationField("Dundee", "WoodPrice").AsFloat) * 1.1) + "                  " +
            DialogueLua.GetLocationField("DundeeWarehouse", "Wood").AsInt;
            //((DialogueLua.GetLocationField("Dundee", "WoodPrice").AsFloat) * 0.9);

            marketMaterialText = marketBWool.GetComponent<Text>();
            marketMaterialText.text = "Wool           " +
            DialogueLua.GetLocationField("Dundee", "Wool").AsInt + "            " +
            ((DialogueLua.GetLocationField("Dundee", "WoolPrice").AsFloat) * 1.1) + "                    " +
            DialogueLua.GetLocationField("DundeeWarehouse", "Wool").AsInt;
            //((DialogueLua.GetLocationField("Dundee", "WoolPrice").AsFloat) * 0.9);

            marketMaterialText = marketBClothes.GetComponent<Text>();
            marketMaterialText.text = "Clothes       " +
            DialogueLua.GetLocationField("Dundee", "Clothes").AsInt + "            " +
            ((DialogueLua.GetLocationField("Dundee", "ClothesPrice").AsFloat) * 1.1) + "                 " +
            DialogueLua.GetLocationField("DundeeWarehouse", "Clothes").AsInt;
            //((DialogueLua.GetLocationField("Dundee", "ClothesPrice").AsFloat) * 0.9);

            marketMaterialText = marketBFurniture.GetComponent<Text>();
            marketMaterialText.text = "Furniture    " +
            DialogueLua.GetLocationField("Dundee", "Furniture").AsInt + "            " +
            ((DialogueLua.GetLocationField("Dundee", "FurniturePrice").AsFloat) * 1.1) + "                 " +
            DialogueLua.GetLocationField("DundeeWarehouse", "Furniture").AsInt;
            //((DialogueLua.GetLocationField("Dundee", "FurniturePrice").AsFloat) * 0.9);

            marketMaterialText = marketBJewelry.GetComponent<Text>();
            marketMaterialText.text = "Jewelry         " +
            DialogueLua.GetLocationField("Dundee", "Jewelry").AsInt + "            " +
            ((DialogueLua.GetLocationField("Dundee", "JewelryPrice").AsFloat) * 1.1) + "                    " +
            DialogueLua.GetLocationField("DundeeWarehouse", "Jewelry").AsInt;
            //((DialogueLua.GetLocationField("Dundee", "JewelryPrice").AsFloat) * 0.9);

            marketMaterialText = marketBWeapons.GetComponent<Text>();
            marketMaterialText.text = "Weapons     " +
            DialogueLua.GetLocationField("Dundee", "Weapons").AsInt + "           " +
            ((DialogueLua.GetLocationField("Dundee", "WeaponsPrice").AsFloat) * 1.1) + "                 " +
            DialogueLua.GetLocationField("DundeeWarehouse", "Weapons").AsInt;
            //((DialogueLua.GetLocationField("Dundee", "WeaponsPrice").AsFloat) * 0.9);


            marketMaterialText = marketBTools.GetComponent<Text>();
            marketMaterialText.text = "Tools            " +
            DialogueLua.GetLocationField("Dundee", "Tools").AsInt + "           " +
            ((DialogueLua.GetLocationField("Dundee", "ToolsPrice").AsFloat) * 1.1) + "                    " +
            DialogueLua.GetLocationField("DundeeWarehouse", "Tools").AsInt;
            //((DialogueLua.GetLocationField("Dundee", "ToolsPrice").AsFloat) * 0.9);

            marketMaterialText = marketBAle.GetComponent<Text>();
            marketMaterialText.text = "Ale               " +
            DialogueLua.GetLocationField("Dundee", "Ale").AsInt + "             " +
            ((DialogueLua.GetLocationField("Dundee", "AlePrice").AsFloat) * 1.1) + "                  " +
            DialogueLua.GetLocationField("DundeeWarehouse", "Ale").AsInt;
            //((DialogueLua.GetLocationField("Dundee", "AlePrice").AsFloat) * 0.9);

            marketMaterialText = marketBBread.GetComponent<Text>();
            marketMaterialText.text = "Bread           " +
            DialogueLua.GetLocationField("Dundee", "Bread").AsInt + "             " +
            ((DialogueLua.GetLocationField("Dundee", "BreadPrice").AsFloat) * 1.1) + "                  " +
            DialogueLua.GetLocationField("DundeeWarehouse", "Bread").AsInt + "                  ";
        //((DialogueLua.GetLocationField("Dundee", "BreadPrice").AsFloat) * 0.9);

        marketBPlus.GetComponent<Button>().onClick.AddListener(() =>
        {
            buyplus();
        });

        marketBMinus.GetComponent<Button>().onClick.AddListener(() =>
        {
            buyminus();
        });

        imputBFish.GetComponentInChildren<Text>().text = "Select";
        imputBFish.GetComponent<Button>().onClick.AddListener(() =>
        {
            selectbuy(1);
        });
        imputBMeat.GetComponentInChildren<Text>().text = "Select";
        imputBMeat.GetComponent<Button>().onClick.AddListener(() =>
        {
            selectbuy(2);
        });
        imputBCereals.GetComponent<Button>().onClick.AddListener(() =>
        {
            selectbuy(3);
        });
        imputBIronOre.GetComponent<Button>().onClick.AddListener(() =>
        {
            selectbuy(4);
        });
        imputBGoldOre.GetComponent<Button>().onClick.AddListener(() =>
        {
            selectbuy(5);
        });
        imputBWood.GetComponent<Button>().onClick.AddListener(() =>
        {
            selectbuy(6);
        });
        imputBWool.GetComponent<Button>().onClick.AddListener(() =>
        {
            selectbuy(7);
        });
        imputBClothes.GetComponent<Button>().onClick.AddListener(() =>
        {
            selectbuy(8);
        });
        imputBFurniture.GetComponent<Button>().onClick.AddListener(() =>
        {
            selectbuy(9);
        });
        imputBJewelry.GetComponent<Button>().onClick.AddListener(() =>
        {
            selectbuy(10);
        });
        imputBWeapons.GetComponent<Button>().onClick.AddListener(() =>
        {
            selectbuy(11);
        });
        imputBTools.GetComponent<Button>().onClick.AddListener(() =>
        {
            selectbuy(12);
        });
        imputBAle.GetComponent<Button>().onClick.AddListener(() =>
        {
            selectbuy(13);
        });
        imputBBread.GetComponent<Button>().onClick.AddListener(() =>
        {
            selectbuy(14);
        });
        
        option2.GetComponentInChildren<Text>().text = "Buy";
            option3.GetComponentInChildren<Text>().text = "Sell";
            option3.GetComponent<Button>().onClick.AddListener(() =>
            {
                sellpanel();
            });
            option4.GetComponentInChildren<Text>().text = "Leave Market";
            option4.GetComponent<Button>().onClick.AddListener(() => {
                marketbuyPanel.SetActive(false);
                OnMouseDown();
            });
            option2.SetActive(true);
            option3.SetActive(true);
            option4.SetActive(true);
    }

    void sellpanel()
    {
       
            //Market.Teste(marketPanel);
            marketPanel.SetActive(false);
            marketbuyPanel.SetActive(false);
            marketsellPanel.SetActive(true);
            marketPanel.GetComponentInChildren<Text>().text = "Marketplace";
            DisableButtons();

            marketMaterialText = marketSFish.GetComponent<Text>();
            marketMaterialText.text = "Fish              " +
            DialogueLua.GetLocationField("Dundee", "Fish").AsInt + "            " +
            ((DialogueLua.GetLocationField("Dundee", "FishPrice").AsFloat) * 0.9) + "                    " +
            DialogueLua.GetLocationField("DundeeWarehouse", "Fish").AsInt;
            //  ((DialogueLua.GetLocationField("Dundee", "FishPrice").AsFloat) * 0.9);

            marketMaterialText = marketSMeat.GetComponent<Text>();
            marketMaterialText.text = "Meat            " +
            DialogueLua.GetLocationField("Dundee", "Meat").AsInt + "              " +
            ((DialogueLua.GetLocationField("Dundee", "MeatPrice").AsFloat) * 0.9) + "                  " +
            DialogueLua.GetLocationField("DundeeWarehouse", "Meat").AsInt;
            // ((DialogueLua.GetLocationField("Dundee", "MeatPrice").AsFloat) * 0.9);

            marketMaterialText = marketSCereals.GetComponent<Text>();
            marketMaterialText.text = "Cereals      " +
            DialogueLua.GetLocationField("Dundee", "Cereal").AsInt + "              " +
            ((DialogueLua.GetLocationField("Dundee", "CerealsPrice").AsFloat) * 0.9) + "                    " +
            DialogueLua.GetLocationField("DundeeWarehouse", "Cereals").AsInt;
            //((DialogueLua.GetLocationField("Dundee", "CerealsPrice").AsFloat) * 0.9);

            marketMaterialText = marketSIronOre.GetComponent<Text>();
            marketMaterialText.text = "Iron ore         " +
            DialogueLua.GetLocationField("Dundee", "IronOre").AsInt + "              " +
            ((DialogueLua.GetLocationField("Dundee", "IronOrePrice").AsFloat) * 0.9) + "                 " +
            DialogueLua.GetLocationField("DundeeWarehouse", "IronOre").AsInt;
            // ((DialogueLua.GetLocationField("Dundee", "IronOrePrice").AsFloat) * 0.9);

            marketMaterialText = marketSGoldOre.GetComponent<Text>();
            marketMaterialText.text = "Gold ore       " +
            DialogueLua.GetLocationField("Dundee", "GoldOre").AsInt + "            " +
            ((DialogueLua.GetLocationField("Dundee", "GoldOrePrice").AsFloat) * 0.9) + "                  " +
            DialogueLua.GetLocationField("DundeeWarehouse", "GoldOre").AsInt;
            //((DialogueLua.GetLocationField("Dundee", "GoldOrePrice").AsFloat) * 0.9);

            marketMaterialText = marketSWood.GetComponent<Text>();
            marketMaterialText.text = "Wood        " +
            DialogueLua.GetLocationField("Dundee", "Wood").AsInt + "             " +
            ((DialogueLua.GetLocationField("Dundee", "WoodPrice").AsFloat) * 0.9) + "                  " +
            DialogueLua.GetLocationField("DundeeWarehouse", "Wood").AsInt;
            //((DialogueLua.GetLocationField("Dundee", "WoodPrice").AsFloat) * 0.9);

            marketMaterialText = marketSWool.GetComponent<Text>();
            marketMaterialText.text = "Wool           " +
            DialogueLua.GetLocationField("Dundee", "Wool").AsInt + "            " +
            ((DialogueLua.GetLocationField("Dundee", "WoolPrice").AsFloat) * 0.9) + "                    " +
            DialogueLua.GetLocationField("DundeeWarehouse", "Wool").AsInt;
            //((DialogueLua.GetLocationField("Dundee", "WoolPrice").AsFloat) * 0.9);

            marketMaterialText = marketSClothes.GetComponent<Text>();
            marketMaterialText.text = "Clothes       " +
            DialogueLua.GetLocationField("Dundee", "Clothes").AsInt + "            " +
            ((DialogueLua.GetLocationField("Dundee", "ClothesPrice").AsFloat) * 0.9) + "                 " +
            DialogueLua.GetLocationField("DundeeWarehouse", "Clothes").AsInt;
            //((DialogueLua.GetLocationField("Dundee", "ClothesPrice").AsFloat) * 0.9);

            marketMaterialText = marketSFurniture.GetComponent<Text>();
            marketMaterialText.text = "Furniture    " +
            DialogueLua.GetLocationField("Dundee", "Furniture").AsInt + "            " +
            ((DialogueLua.GetLocationField("Dundee", "FurniturePrice").AsFloat) * 0.9) + "                 " +
            DialogueLua.GetLocationField("DundeeWarehouse", "Furniture").AsInt;
            //((DialogueLua.GetLocationField("Dundee", "FurniturePrice").AsFloat) * 0.9);

            marketMaterialText = marketSJewelry.GetComponent<Text>();
            marketMaterialText.text = "Jewelry         " +
            DialogueLua.GetLocationField("Dundee", "Jewelry").AsInt + "            " +
            ((DialogueLua.GetLocationField("Dundee", "JewelryPrice").AsFloat) * 0.9) + "                    " +
            DialogueLua.GetLocationField("DundeeWarehouse", "Jewelry").AsInt;
            //((DialogueLua.GetLocationField("Dundee", "JewelryPrice").AsFloat) * 0.9);

            marketMaterialText = marketSWeapons.GetComponent<Text>();
            marketMaterialText.text = "Weapons     " +
            DialogueLua.GetLocationField("Dundee", "Weapons").AsInt + "           " +
            ((DialogueLua.GetLocationField("Dundee", "WeaponsPrice").AsFloat) * 0.9) + "                 " +
            DialogueLua.GetLocationField("DundeeWarehouse", "Weapons").AsInt;
            //((DialogueLua.GetLocationField("Dundee", "WeaponsPrice").AsFloat) * 0.9);


            marketMaterialText = marketSTools.GetComponent<Text>();
            marketMaterialText.text = "Tools            " +
            DialogueLua.GetLocationField("Dundee", "Tools").AsInt + "           " +
            ((DialogueLua.GetLocationField("Dundee", "ToolsPrice").AsFloat) * 0.9) + "                    " +
            DialogueLua.GetLocationField("DundeeWarehouse", "Tools").AsInt;
            //((DialogueLua.GetLocationField("Dundee", "ToolsPrice").AsFloat) * 0.9);

            marketMaterialText = marketSAle.GetComponent<Text>();
            marketMaterialText.text = "Ale               " +
            DialogueLua.GetLocationField("Dundee", "Ale").AsInt + "             " +
            ((DialogueLua.GetLocationField("Dundee", "AlePrice").AsFloat) * 0.9) + "                  " +
            DialogueLua.GetLocationField("DundeeWarehouse", "Ale").AsInt;
            //((DialogueLua.GetLocationField("Dundee", "AlePrice").AsFloat) * 0.9);

            marketMaterialText = marketSBread.GetComponent<Text>();
            marketMaterialText.text = "Bread           " +
            DialogueLua.GetLocationField("Dundee", "Bread").AsInt + "             " +
            ((DialogueLua.GetLocationField("Dundee", "BreadPrice").AsFloat) * 0.9) + "                  " +
            DialogueLua.GetLocationField("DundeeWarehouse", "Bread").AsInt + "                  ";
        //((DialogueLua.GetLocationField("Dundee", "BreadPrice").AsFloat) * 0.9)
       

        option2.GetComponentInChildren<Text>().text = "Buy";
            option2.GetComponent<Button>().onClick.AddListener(() =>
            {
            buypanel();
            });
            option3.GetComponentInChildren<Text>().text = "Sell";
            option4.GetComponentInChildren<Text>().text = "Leave Market";
            option4.GetComponent<Button>().onClick.AddListener(() => {
                marketsellPanel.SetActive(false);
                OnMouseDown();
            });
            
            option2.SetActive(true);
            option3.SetActive(true);
            option4.SetActive(true);
    }

    void buyplus()
    {
        units = units + 1;
        marketBQuantity.GetComponentInChildren<Text>().text = "" + units;
        marketBTotal.GetComponentInChildren<Text>().text = "Total Price : " + (units * unit_price);
    }

    void buyminus()
    {
        if (units > 0)
        {
            units = units - 1;
            marketBQuantity.GetComponentInChildren<Text>().text = "" + units;
            marketBTotal.GetComponentInChildren<Text>().text = "Total Price : " + (units * unit_price);
        }
    }

    void buycancel()
    {

        marketBQuantity.SetActive(false);
        marketBPlus.SetActive(false);
        marketBMinus.SetActive(false);
        marketBComfirm.SetActive(false);
        marketBCancel.SetActive(false);
        marketBTotal.SetActive(false);
        units = 0;
        type = 0;
    }


    void selectbuy (int t)
    {

        if (t == 1)
        {
            type = 1;
            unit_price = (DialogueLua.GetLocationField("Dundee", "FishPrice").AsFloat) * 1.1;
        }

        if (t == 2)
        {
            type = 2;
            unit_price = (DialogueLua.GetLocationField("Dundee", "MeatPrice").AsFloat) * 1.1;
        }
        if (t == 3)
        {
            type = 3;
            unit_price = (DialogueLua.GetLocationField("Dundee", "CerealsPrice").AsFloat) * 1.1;
        }

        if (t == 4)
        {
            type = 4;
            unit_price = (DialogueLua.GetLocationField("Dundee", "IronOre").AsFloat) * 1.1;
        }

        if (t == 5)
        {
            type = 5;
            unit_price = (DialogueLua.GetLocationField("Dundee", "GoldOrePrice").AsFloat) * 1.1;
        }
        if (t == 6)
        {
            type = 6;
            unit_price = (DialogueLua.GetLocationField("Dundee", "WoodPrice").AsFloat) * 1.1;
        }

        if (t == 7)
        {
            type = 7;
            unit_price = (DialogueLua.GetLocationField("Dundee", "WoolPrice").AsFloat) * 1.1;
        }

        if (t == 8)
        {
            type = 8;
            unit_price = (DialogueLua.GetLocationField("Dundee", "ClothesPrice").AsFloat) * 1.1;
        }

        if (t == 9)
        {
            type = 9;
            unit_price = (DialogueLua.GetLocationField("Dundee", "FurniturePrice").AsFloat) * 1.1;
        }

        if (t == 10)
        {
            type = 10;
            unit_price = (DialogueLua.GetLocationField("Dundee", "JewelryPrice").AsFloat) * 1.1;
        }

        if (t == 11)
        {
            type = 11;
            unit_price = (DialogueLua.GetLocationField("Dundee", "WeaponsPrice").AsFloat) * 1.1;
        }

        if (t == 12)
        {
            type = 12;
            unit_price = (DialogueLua.GetLocationField("Dundee", "ToolsPrice").AsFloat) * 1.1;
        }
        if (t == 13)
        {
            type = 13;
            unit_price = (DialogueLua.GetLocationField("Dundee", "AlePrice").AsFloat) * 1.1;
        }

        if (t == 14)
        {
            type = 14;
            unit_price = (DialogueLua.GetLocationField("Dundee", "BreadPrice").AsFloat) * 1.1;
        }

        marketBQuantity.SetActive(true);
        marketBQuantity.GetComponentInChildren<Text>().text = "" + units;
        marketBPlus.SetActive(true);
        marketBMinus.SetActive(true);
        marketBComfirm.SetActive(true);
        marketBCancel.SetActive(true);
        marketBCancel.GetComponent<Button>().onClick.AddListener(() =>
        {
            buycancel();
        });

        marketBTotal.SetActive(true);
        marketBTotal.GetComponentInChildren<Text>().text = "Total Price : " + (units * unit_price);

    }

}
