using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    private float Imobile = 0.001f;
    public GameObject DeathParticles;
    GameObject PO;
    private float ScaleX;
    private float ScaleY;
    private float ScaleZ;
    public float timer;

    public float Active;
    private void Start()
    {
        ScaleX = this.gameObject.transform.localScale.x;
        ScaleY = this.gameObject.transform.localScale.y;
        ScaleZ = this.gameObject.transform.localScale.z;

        timer = 0;
    }


    // Update is called once per frame
    void Update()
    {

        Active = Active + Time.deltaTime;
    
        
        
        if (this.gameObject.GetComponent<Rigidbody>().velocity.magnitude < Imobile && Active > 0.1)
        {
            timer = timer + Time.deltaTime;
        }

        if (timer >= 0.5 && timer <0.51)
        {
            PO = GameObject.Instantiate(DeathParticles);
            PO.transform.position = transform.position + new Vector3(ScaleX, -ScaleY / 1.5f, ScaleZ);
        }

        if (timer >= 2)
        {
            Destroy(this.gameObject);
        }
    }
}