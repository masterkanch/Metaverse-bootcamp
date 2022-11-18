using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float bufferY1;
    public float bufferY2;
    public float bufferX1;
    public float bufferX2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bufferY1 = Input.mousePosition.x - bufferY2;
        bufferX1 = Input.mousePosition.y - bufferX2;
        if (Input.GetMouseButton(2)||Input.GetKey(KeyCode.LeftControl))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x + (bufferX1 * 0.1f), transform.eulerAngles.y+(bufferY1*0.1f),transform.eulerAngles.z);
        }
        bufferY2 = Input.mousePosition.x;
        bufferX2 = Input.mousePosition.y;
    }
}
