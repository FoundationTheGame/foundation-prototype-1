using UnityEngine;
using System.Collections;

public class CameraPanController : MonoBehaviour
{
    int theScreenWidth;
    int theScreenHeight;
    public int Boundary = 50;
    public int speed = 5;
    void Start()
    {
        theScreenWidth = Screen.width;
        theScreenHeight = Screen.height;
    }

    void Update()
    {
        float xAxisValue = Input.GetAxis("Horizontal");
        float zAxisValue = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(xAxisValue * speed, 0.0f, zAxisValue * speed));
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 200, 850), 100, Mathf.Clamp(transform.position.z, 150, 800));


        if (Input.mousePosition.x > theScreenWidth - Boundary)
        {
            //transform.position.x += speed * Time.deltaTime; // move on +X axis
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime * 20, transform.position.y, transform.position.z);
        }
        if (Input.mousePosition.x < 0 + Boundary)
        {
            //transform.position.x -= speed * Time.deltaTime; // move on -X axis
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime * 20, transform.position.y, transform.position.z);
        }
        if (Input.mousePosition.y > theScreenHeight - Boundary)
        {
            //transform.position.z += speed * Time.deltaTime; // move on +Z axis
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime * 20);
        }
        if (Input.mousePosition.y < 0 + Boundary)
        {
            //transform.position.z -= speed * Time.deltaTime; // move on -Z axis
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime * 20);
        }
    }

    void OnGUI()
    {
        /*GUI.Box(Rect((Screen.width / 2) - 140, 5, 280, 25), "Mouse Position = " + Input.mousePosition);
        GUI.Box(Rect((Screen.width / 2) - 70, Screen.height - 30, 140, 25), "Mouse X = " + Input.mousePosition.x);
        GUI.Box(Rect(5, (Screen.height / 2) - 12, 140, 25), "Mouse Y = " + Input.mousePosition.y);
        */
    }
}