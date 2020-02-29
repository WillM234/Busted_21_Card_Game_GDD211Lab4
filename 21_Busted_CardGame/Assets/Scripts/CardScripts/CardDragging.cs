using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDragging : MonoBehaviour
{
    public bool UseP_Displacement = true;

    private bool dragging = false;//lets me know if the player is currently dragging this gameObject

    private Vector3 P_Displacement;//distance from the center of this gameObject to the point where the player clicks to start dragging

    private float zDisplacement;//distance from camera to mouse on the Z-axis

    private void OnMouseDown()
    {
        dragging = true;
        zDisplacement = -Camera.main.transform.position.z + transform.position.z;
        if (UseP_Displacement)
            P_Displacement = -transform.position + MouseInWorldCoords();
        else
            P_Displacement = Vector3.zero;
    }
    // Update is called once per frame
    void Update()
    {
        if(dragging)
        {
            Vector3 mousePos = MouseInWorldCoords();
            transform.position = new Vector3(mousePos.x - P_Displacement.x, mousePos.y - P_Displacement.y, transform.position.z);
        }
    }
    private void OnMouseUp()
    {
    if(dragging)
        {
            dragging = false;
        }
    }

    private Vector3 MouseInWorldCoords()
    {
        var screenMousePos = Input.mousePosition;
        screenMousePos.z = zDisplacement;
        return Camera.main.ScreenToWorldPoint(screenMousePos);
    }
}
