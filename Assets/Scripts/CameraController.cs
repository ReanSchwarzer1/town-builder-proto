using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 mouseOriginPoint;
    private Vector3 offset;
    private bool dragging;
   //change size to zoom in/out
   //clamp values to min and max
   //mouse wheel scrolling

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * (10f * Camera.main.orthographicSize * .1f), 2.5f, 20f);
        if (Input.GetMouseButton(2))
        {
            offset = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
            if (!dragging)
            {
                dragging = true;
                mouseOriginPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }         
        }
        else
        {
            dragging = false;
        }
        if (dragging)
        {
            transform.position = mouseOriginPoint - offset;
        }
    }
}
