using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Food : MonoBehaviour
{
    Vector3 offset;

    private void OnMouseDown()
    {
        offset = transform.position-MouseWorldPosition();
        transform.GetComponent<Collider>().enabled = false;
        
    }

    private void OnMouseDrag()
    {
        transform.position = MouseWorldPosition()+offset;

    }

    private void OnMouseUp()
    {
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
        RaycastHit hitInfo;
        if (Physics.Raycast(rayOrigin,rayDirection, out hitInfo))
        {
            if (hitInfo.transform.tag == "DropArea")
            {
                transform.position = hitInfo.transform.position;
                //Destroy(transform.gameObject);
            }
        }
        else
        {
            transform.DOMove(new Vector3(0, 0, 0), 0.3f);
        }

        transform.GetComponent<Collider>().enabled=true;
    }
    Vector3 MouseWorldPosition()
    {
        var MouseScreenPos= Input.mousePosition;
        MouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(MouseScreenPos);
    }
}
