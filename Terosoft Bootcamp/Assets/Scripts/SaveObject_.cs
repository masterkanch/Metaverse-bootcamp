using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObject_ : MonoBehaviour
{
    
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
