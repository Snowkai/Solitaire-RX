using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private bool dragging = false;
    private Vector3 offset;
    public bool isMouseDown = false;
    public bool isMouseUp = false;
    public Vector3 LastCardPosition;
    private GameObject MyLastDom;

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            // Move object, taking into account original offset.
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }

    private void OnMouseDown()
    {
        LastCardPosition = transform.position;
        MyLastDom = gameObject.GetComponent<Card>().MyLastDOM;
        // Record the difference between the objects centre, and the clicked point on the camera plane.
        if(transform.position.z > -1.5f) 
        {
            transform.position += new Vector3(0f, 0f, -1f);
        }
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
        isMouseDown = true;
        isMouseUp = false;
    }

    private void OnMouseUp()
    {
        // Stop dragging.
        dragging = false;
        isMouseDown = false;
        isMouseUp = true;
    }
}
