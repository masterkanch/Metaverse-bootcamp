using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObject_ : MonoBehaviour
{
    public int ObjNumber;
    void Start()
    {
        EditorController.Obj[EditorController.MaxObj] = gameObject;
        EditorController.MaxObj++;
    }

    public void save()
    {
        PlayerPrefs.SetFloat("",transform.position.x);
    }
    
    void Update()
    {
        
    }
}
