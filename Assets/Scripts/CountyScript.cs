using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class CountyScript : MonoBehaviour {

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

    private Text countyNameText;
    private Text cityNameText;


    // Use this for initialization
    void Start() {
        Lua.RegisterFunction(this.gameObject.name + "CountyConversationCleanUp", this, typeof(CountyScript).GetMethod("OnMouseDown"));
    }

    // Update is called once per frame
    void Update() {

    }


    public void OnMouseDown() {
        DisableButtons();
        unFocus();

        countyNameText = countyName.GetComponent<Text>();
        cityNameText = cityName.GetComponent<Text>();

        countyNameText.text = "County of " + this.gameObject.name;
        cityNameText.text = "City of " + transform.parent.name;

        option1.GetComponentInChildren<Text>().text = "Talk to Master";
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

    }

    void DisableButtons() {
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