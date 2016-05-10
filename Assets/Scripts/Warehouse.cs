using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Warehouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void Teste(GameObject warehousePanel) {
        warehousePanel.SetActive(true);
        warehousePanel.GetComponentInChildren<Text>().text = "Warehouse";
    }
}
