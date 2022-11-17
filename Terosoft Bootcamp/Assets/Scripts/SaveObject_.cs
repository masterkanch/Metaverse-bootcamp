using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObject_ : MonoBehaviour
{
    public int ObjNumber;
    public bool isLoad;

    void Start()
    {
        EditorController.Obj[EditorController.MaxObj] = gameObject;
        if (!isLoad)
        {
            EditorController.MaxObj++;
        }
        
    }

    public void save()
    {
        PlayerPrefs.SetFloat("",transform.position.x);
    }
    
    void Update()
    {
        
    }
}
