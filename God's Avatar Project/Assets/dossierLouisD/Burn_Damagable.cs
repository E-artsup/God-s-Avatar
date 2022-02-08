using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn_Damagable : MonoBehaviour
{
    //Zones Des Variables
    public GameObject Laser_ref;
    public GameObject ArmePlayer_ref;
    public float HP;
    public float DamageParAttaque;

    Collider Laser;
    Collider ArmePlayer;

    public bool Momie_Burn;
    MeshRenderer Body;
    public Material DamageMaterial;

    private void OnEnable()
    {
        Laser = Laser_ref.GetComponent<Collider>();
        ArmePlayer = ArmePlayer_ref.GetComponent<Collider>();
        Body = gameObject.GetComponentInChildren<MeshRenderer>();
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject == Laser_ref)
        {
            Momie_Burn = true;
        }
        if (col.gameObject == ArmePlayer_ref & Momie_Burn == true)
        {
            HP = HP - DamageParAttaque;
            Material StockageTemporaire = Body.material;
            for (float i = 0; i <= 100;) 
            {
                i = i + Time.deltaTime;
                Body.material = DamageMaterial;
            }
            Body.material = StockageTemporaire;
            if (HP <= 0)
                Die();
            if (gameObject.name == "Momie_Boss")
            {
                if (HP <= 50)
                    DamageParAttaque = 15;
            }
        }

    }
    //Fonction de la mort de la Momie
    private void Die()
    {
        Destroy(gameObject);
    }
}
