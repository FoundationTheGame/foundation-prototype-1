using UnityEngine;
using System.Collections;

public class CameraPanController : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        float xAxisValue = Input.GetAxis("Horizontal");
        float zAxisValue = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(xAxisValue * 5, 0.0f, zAxisValue * 5));
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 200, 900), 250, Mathf.Clamp(transform.position.z, -50 , 600));
    }
}