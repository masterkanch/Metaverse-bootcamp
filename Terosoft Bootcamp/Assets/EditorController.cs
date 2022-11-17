using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorController : MonoBehaviour
{
    public Camera camera;

    void Update(){
        
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit)) {
           Debug.DrawLine(camera.transform.position,hit.point,Color.red);
           Debug.Log("Hit"+hit.point);
           if(hit.collider.GetComponent<PlayerController>() != null){
                Debug.Log("Name " + hit.collider.GetComponent<PlayerController>().Name);
           }
           
        }

    }
}
