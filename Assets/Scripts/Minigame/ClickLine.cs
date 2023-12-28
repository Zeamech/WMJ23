using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickLine : MonoBehaviour
{
    public bool ClickNow;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ClickNow = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ClickNow = false;
    }
}
