using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        float xAxisValue = Input.GetAxis("Horizontal");
        float zAxisValue = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(xAxisValue * 3, 0.0f, zAxisValue * 3));
        
    }
}