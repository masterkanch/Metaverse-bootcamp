using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorController : MonoBehaviour
{
    public Camera camera;
    public GameObject SelectObj;
    
    Vector3 Hitpoint;

    void Update(){
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)) {
           Debug.DrawLine(camera.transform.position,hit.point,Color.red);
           Debug.Log("Hit"+hit.point);
           if(hit.collider.GetComponent<PlayerController>() != null){
                Debug.Log("Name " + hit.collider.GetComponent<PlayerController>().Name);
           }

           if(Input.GetMouseButtonDown(0)){
            SelectObj = hit.collider.gameObject;
           }
           
        }
        if(SelectObj != null){
            Hitpoint = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, camera.nearClipPlane));
            Debug.Log("HitPoint" + Hitpoint);
            if(SelectObj.name == "Player"){
                SelectObj.transform.position = Hitpoint;
            }
        }

    }
}
