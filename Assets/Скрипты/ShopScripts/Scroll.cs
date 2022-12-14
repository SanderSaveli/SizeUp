using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public GameObject figures;
    private Vector3 offset, screenpoint;
    public float lowerlimit;
    private float lockedXPos;
    private void Update()
    {
        if (figures.transform.position.y > lowerlimit)
        {
            figures.transform.position = Vector3.MoveTowards(figures.transform.position, new Vector3(figures.transform.position.x, -8f, figures.transform.position.z), Time.deltaTime * 10f);
        }
        else if (figures.transform.position.y < -10f)
        {
            figures.transform.position = Vector3.MoveTowards(figures.transform.position, new Vector3(figures.transform.position.x, 0f, figures.transform.position.z), Time.deltaTime * 10f);
        }
   

    }
    private void OnMouseDown()
    {
        lockedXPos = screenpoint.y;
        offset = figures.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        Cursor.visible = false;
    }
    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenpoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        curPosition.x = lockedXPos;
        figures.transform.position = curPosition;
    }
    private void OnMouseUp()
    {
        Cursor.visible = true;
    }

}
