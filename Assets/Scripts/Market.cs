using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Market : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void Teste(GameObject marketPanel) {
        marketPanel.SetActive(true);
        marketPanel.GetComponentInChildren<Text>().text = "Marketplace";
    }
}
