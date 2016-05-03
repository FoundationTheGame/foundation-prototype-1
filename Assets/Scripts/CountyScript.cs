using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountyScript : MonoBehaviour {

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

		countyNameText.text = "County of " + this.gameObject.name;
		cityNameText.text = "City of " + transform.parent.name;
		
		

}

}