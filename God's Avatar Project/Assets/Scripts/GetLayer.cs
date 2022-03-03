using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLayer : MonoBehaviour
{
    public GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(go.layer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
