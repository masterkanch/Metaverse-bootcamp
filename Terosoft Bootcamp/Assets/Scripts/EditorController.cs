using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorController : MonoBehaviour
{
    public string Name;
    public GameObject[] PrefabObj;
    public static GameObject[] Obj;
    public static int MaxObj;
    public Camera camera;
    public GameObject SelectObj;
    
    Vector3 Hitpoint;
    Vector3 MousePoint;

    private void Start()
    {
        Obj = new GameObject[99];
    }

    public void Create(int num)
    {
        GameObject clone = Instantiate(PrefabObj[num]);
        clone.transform.position = Vector3.zero;
        clone.GetComponent<SaveObject_>().ObjNumber = num;
    }

    public void SaveMap()
    {
        PlayerPrefs.SetInt("MaxObj", MaxObj);
        for(int i = 0; i < MaxObj; i++)
        {
            PlayerPrefs.SetInt("ObjectNum"+i.ToString(), Obj[i].GetComponent<SaveObject_>().ObjNumber);

            PlayerPrefs.SetFloat("X" + i.ToString(), Obj[i].GetComponent<SaveObject_>().transform.position.x);
            PlayerPrefs.SetFloat("Y" + i.ToString(), Obj[i].GetComponent<SaveObject_>().transform.position.y);
            PlayerPrefs.SetFloat("Z" + i.ToString(), Obj[i].GetComponent<SaveObject_>().transform.position.z);

            PlayerPrefs.SetFloat ("RX" + i.ToString(), Obj[i].GetComponent<SaveObject_>().transform.eulerAngles.x);
            PlayerPrefs.SetFloat("RY" + i.ToString(), Obj[i].GetComponent<SaveObject_>().transform.eulerAngles.y);
            PlayerPrefs.SetFloat("RZ" + i.ToString(), Obj[i].GetComponent<SaveObject_>().transform.eulerAngles.z);

        }
        Debug.Log("Save Complete!");
    }

    public void LoadMap()
    {
        for (int i = 0; i < MaxObj; i++)
        {
            if (Obj[i] !=null)
            Destroy(Obj[i].gameObject);
        }

        MaxObj = PlayerPrefs.GetInt("MaxObj");

        for (int i = 0; i < MaxObj; i++)
        {
            int ObjNum = PlayerPrefs.GetInt("ObjectNum" + i.ToString());
            float X = PlayerPrefs.GetFloat("X" + i.ToString());
            float Y = PlayerPrefs.GetFloat("Y" + i.ToString());
            float Z = PlayerPrefs.GetFloat("Z" + i.ToString());

            float RX = PlayerPrefs.GetFloat("RX" + i.ToString());
            float RY = PlayerPrefs.GetFloat("RY" + i.ToString());
            float RZ = PlayerPrefs.GetFloat("RZ" + i.ToString());

            GameObject clone = Instantiate(PrefabObj[ObjNum]);
            Obj[i] = clone;
            clone.GetComponent<SaveObject_>().isLoad = true;
            clone.transform.position = new Vector3(X, Y, Z);
            clone.transform.eulerAngles = new Vector3(RX, RY, RZ);
            clone.GetComponent<SaveObject_>().ObjNumber = ObjNum;
         
            


        }
        Debug.Log("Load Complete!");
    }

 

    void Update(){
        for(int i = 0; i < MaxObj; i++)
        {
            Debug.Log(Obj[i].name);
        }
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
