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
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 210, 820), 191, Mathf.Clamp(transform.position.z, 170, 600));
    }
}