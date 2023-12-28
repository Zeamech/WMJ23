using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public bool Clicked;

    private void OnMouseDown()
    {
        Clicked = true;
    }

    private void OnMouseUp()
    {
        Clicked= false;
    }
}