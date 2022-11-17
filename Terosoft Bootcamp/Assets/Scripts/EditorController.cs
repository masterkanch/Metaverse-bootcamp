using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorController : MonoBehaviour
{
    public Camera camera;
    public GameObject SelectObj;
    
    Vector3 Hitpoint;
    Vector3 MousePoint;

    void Update(){
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit)) {

           if(hit.collider.tag == "ground"){
                MousePoint = hit.point;
           }

           Debug.DrawLine(camera.transform.position,hit.point,Color.red);
           Debug.Log("Hit"+hit.point);

           if(hit.collider.GetComponent<PlayerController>() != null){
                Debug.Log("Name " + hit.collider.GetComponent<PlayerController>().Name);
           }

           if(Input.GetMouseButtonDown(0)){
                if(SelectObj != null){
                    SelectObj.GetComponent<Collider>().enabled = true;
                }
                SelectObj = hit.collider.gameObject;
           }
        }

        if(Input.GetMouseButtonDown(1)){
            if(SelectObj != null){
                SelectObj.GetComponent<Collider>().enabled = true;
                SelectObj = null;
            }
        }

        if(SelectObj != null){
            Hitpoint = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, camera.nearClipPlane));
            Debug.Log("HitPoint" + Hitpoint);

            if(SelectObj.tag == "movable"){
                SelectObj.GetComponent<Collider>().enabled = false;
            }
            

            if(SelectObj.tag == "movable"){
                SelectObj.transform.position = MousePoint;
            }

            if(Input.mouseScrollDelta.y > 0)
            {
                SelectObj.transform.eulerAngles = new Vector3(0,SelectObj.transform.eulerAngles.y + 45f,0);
            }
            if (Input.mouseScrollDelta.y < 0)
            {
                SelectObj.transform.eulerAngles = new Vector3(0, SelectObj.transform.eulerAngles.y - 45f, 0);
            }


            /*
            if(SelectObj.name == "Player"){
                SelectObj.transform.position = Hitpoint;
            }
            */
        }

    }
}
