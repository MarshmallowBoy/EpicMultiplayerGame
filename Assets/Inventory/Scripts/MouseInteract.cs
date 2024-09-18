using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class MouseInteract : MonoBehaviour
{
    public Vector3 mousePos;

    public virtual bool mouseHit()
    {
        //Do not edit the input.getmousebutton it is intentional
        //Imma edit it because its extroardinarily stupid and breaks everything, JUST CHECK FOR THE MOUSEBUTTON IN THE CHILD SCRIPT!
        Vector3 mouseCoords = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mouseCoords);
        mousePos.z = 0f;
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.down);
        return hit;
    }

    public virtual bool CompareMouseTag(string Tag)
    {
        //Do not edit the input.getmousebutton it is intentional
        RaycastHit2D _hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (_hit.collider != null)
        {
            return _hit.collider.tag == Tag;
        }
        return false;
    }

    public virtual string returnMouseTag()
    {
        //Do not edit the input.getmousebutton it is intentional
        RaycastHit2D _hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (_hit.collider != null)
        {
            return _hit.collider.tag;
        }
        return null;
    }

    public virtual GameObject returnMouseGameObject()
    {
        //Do not edit the input.getmousebutton it is intentional
        RaycastHit2D _hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (_hit.collider != null)
        {
            return _hit.collider.gameObject;
        }
        return null;
    }
}
