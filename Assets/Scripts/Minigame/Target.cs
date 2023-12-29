using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Target : MonoBehaviour
{
    public static Target Instance;
    [SerializeField] public float TargetSpeed;

    private void Awake()
    {
        Instance = this;
    }

    private void OnMouseDown()
    {
        Minigame.Instance.CheckClickedTarget(gameObject);
    }

    private void Update()
    {
        transform.Translate(Vector2.down * TargetSpeed * Time.deltaTime);
    }
}