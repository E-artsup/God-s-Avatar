using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public bool RAY;
    public bool ANKH;

    public GameObject ReviveParticles;
    GameObject PO;

    public float Wait;
    public float Delay;

    public float cubeSize;
    public int cubesNumber;
    public float cubesX;
    public float cubesY;
    public float cubesZ;
    public float Maxcubes;
    
    float cubesPivotDistance;
    Vector3 cubesPivot;

    public float explosionForce = 50f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;

    public float Multiplicator = 3;
    public GameObject IntPiece;
    // Use this for initialization
    void Start()
    {
        cubesX = this.gameObject.transform.localScale.x * Multiplicator;
        cubesY = this.gameObject.transform.localScale.y * Multiplicator;
        cubesZ = this.gameObject.transform.localScale.z * Multiplicator;
        


        cubeSize = (cubesX * cubesY * cubesZ) / (15 * Maxcubes);

        cubesNumber = (int)cubesX * (int)cubesZ / 2;
        //calculate pivot distance
        cubesPivotDistance = cubeSize * cubesNumber / 5;
        //use this value to create pivot vector)
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);

    }

    // Update is called once per frame
    void Update()
    {
        if (ANKH == false)
        {
            gameObject.GetComponent<Outline>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<Outline>().enabled = true;
        }

        Wait = Wait + Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "RayonLaser(Clone)" && gameObject.GetComponent<MeshRenderer>().enabled == true && RAY == true)
        {
            explode();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "ControlSphere" && gameObject.GetComponent<MeshRenderer>().enabled == true && Input.GetKeyDown(KeyCode.R) && ANKH == true && Wait >= Delay)
        {
            Wait = 0;
            explode();
        }

        if (other.gameObject.name == "ControlSphere" && gameObject.GetComponent<MeshRenderer>().enabled == false && Input.GetKeyDown(KeyCode.R) && ANKH == true && Wait >= Delay )
        {
            Wait = 0;
            PO = GameObject.Instantiate(ReviveParticles);
            PO.transform.position = transform.position + new Vector3(0, -this.gameObject.transform.localScale.y/2, 0);
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
    }

    public void explode()
    {
        //make object disappear
        //gameObject.SetActive(false);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().isTrigger = true;

        //loop 3 times to create 5x5x5 pieces in x,y,z coordinates
        for (int x = 0; x < cubesX * Maxcubes; x++)
        {
            for (int y = 0; y < cubesY * Maxcubes; y++)
            {
                for (int z = 0; z < cubesZ * Maxcubes; z++)
                {
                    createPiece(x, y, z);
                }
            }
        }


        //get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        //add explosion force to all colliders in that overlap sphere
        foreach (Collider hit in colliders)
        {
            //get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //add explosion force to this body with given parameters
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }

    }

    void createPiece(int x, int y, int z)
    {

        //create piece
        GameObject piece;
        piece = GameObject.Instantiate(IntPiece);  //.CreatePrimitive(PrimitiveType.Cube);

        //set piece position and scale
        piece.transform.position = transform.position + new Vector3((cubesX / Maxcubes) * x/3.25f,
                                                                    (cubesY / Maxcubes) * y/3.25f, 
                                                                    (cubesZ / Maxcubes) * z/3.25f) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize * (Multiplicator / cubesX) *(8/cubesNumber),
                                                 cubeSize * (Multiplicator / cubesY) *(8/cubesNumber),
                                                 cubeSize * (Multiplicator / cubesZ) *(8/cubesNumber));

        //add rigidbody and set mass
        //piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
    }

}