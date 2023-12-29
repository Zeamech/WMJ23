using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnMouseDown()
    {
        Minigame.Instance.CheckClickedTarget(gameObject);
    }
}