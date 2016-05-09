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
	
		cityNameText.text = "City of " + this.gameObject.name;
		countyNameText.text = " ";

        option1.GetComponentInChildren<Text>().text = "Talk to Lord";
        option1.GetComponent<Button>().onClick.AddListener(() => { DialogueManager.StartConversation(this.gameObject.name); });
        option1.SetActive(true);

        option2.GetComponentInChildren<Text>().text = "Go to Market";
        option2.GetComponent<Button>().onClick.AddListener(() => 
        {   Market.Teste(marketPanel);
            option1.SetActive(false);
            option2.SetActive(false);
            option3.SetActive(false);
            option4.SetActive(false);
        });
        option2.SetActive(true);

        option3.GetComponentInChildren<Text>().text = "Go to Warehouse";
        option3.SetActive(true);

    }
}
