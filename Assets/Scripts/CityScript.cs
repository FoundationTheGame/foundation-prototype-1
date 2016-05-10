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

    private Text countyNameText;
	private Text cityNameText;
	private Text warehouseMaterialText;
	

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
			warehouseMaterialText.text = "Fish: ";

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
