using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseRayon : MonoBehaviour
{
    public Transform RayonLaser;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(RayonLaser, gameObject.transform.position, Quaternion.identity, transform.parent);
            //Instantiate(RayonLaser, transform.parent);
        }
    }
}
