using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroller : MonoBehaviour
{
    public float YMin;
    public float YMax;
    public float ScrollDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            float y = transform.position.y + Input.GetAxis("Mouse ScrollWheel") * ScrollDistance;
            if (y < YMin) y= YMin;
            else if(y > YMax) y= YMax;
            transform.position = new Vector3(transform.position.x, y, -10);
        }

    }
}
