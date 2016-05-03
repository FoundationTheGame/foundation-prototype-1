using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CityScript : MonoBehaviour {

	
	public GameObject countyName;
	public GameObject cityName;

	private Text countyNameText;
	private Text cityNameText;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){

		countyNameText = countyName.GetComponent<Text>();
		cityNameText = cityName.GetComponent<Text>();
	
			cityNameText.text = "City of " + this.gameObject.name;
			countyNameText.text = " ";
			
		
		
	

	}
}
