using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayonLaser : MonoBehaviour
{
    public Vector3 FrontScale;
    private float XScale;
    private float YScale;
    private float ZScale;
    public bool explode;
    // Start is called before the first frame update
    void Start()
    {
        XScale = 0.5f;
        YScale = 0.5f;
        ZScale = this.gameObject.transform.localScale.z;
        this.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        FrontScale = new Vector3(0, 0, 0.2f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.gameObject.transform.localScale.z < 15)
        {
            this.gameObject.transform.localScale += FrontScale * 2;
            this.gameObject.transform.localPosition += FrontScale;
        }
        else
        {
            this.gameObject.transform.localScale -= new Vector3(XScale * 0.1f, YScale * 0.1f);
        }

        if (this.gameObject.transform.localScale.x < 0.1)
        {
            Destroy(this.gameObject);
        }
    }
}
