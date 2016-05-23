using UnityEngine;
using System.Collections;

public class CameraPanController : MonoBehaviour
{
    int theScreenWidth;
    int theScreenHeight;
    public int Boundary = 30;
    public int speed = 5;
    bool e = true;

    void Start()
    {
        theScreenWidth = Screen.width;
        theScreenHeight = Screen.height;
    }

    void Update()
    {
        theScreenWidth = Screen.width;
        theScreenHeight = Screen.height;
        float xAxisValue = Input.GetAxis("Horizontal");
        float zAxisValue = Input.GetAxis("Vertical");
        if (e){
            transform.Translate(new Vector3(xAxisValue * speed, 0.0f, zAxisValue * speed));
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, 200, 850), 100, Mathf.Clamp(transform.position.z, 150, 800));

            /*
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
            */
        }
    }

    public void EnablePan()
    {
        e = true;
    }

    public void DisablePan()
    {
        e = false;
    }
}