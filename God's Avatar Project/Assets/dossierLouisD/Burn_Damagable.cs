using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Burn_Damagable : MonoBehaviour
{
    //Zones Des Variables
    public GameObject Laser_ref;
    public GameObject ArmePlayer_ref;
    public GameObject Artephact_ref;
    public float HP;
    public float DamageParAttaque;

    Collider Laser;
    Collider ArmePlayer;

    public bool Momie_Burn;
    MeshRenderer Body;
    public Material DamageMaterial;
    NavMeshAgent agent;
    public bool Momie_Boss;

    public Material BurnMomie;
    public Material BurnHat1;
    public Material BurnHat2;
    public Material[] MomieBoss;

    private void OnEnable()
    {
        Laser = Laser_ref.GetComponent<Collider>();
        ArmePlayer = ArmePlayer_ref.GetComponent<Collider>();
        Body = gameObject.GetComponentInChildren<MeshRenderer>();
        agent = gameObject.GetComponent<NavMeshAgent>();
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject == Laser_ref)
        {
            Momie_Burn = true;
            agent.speed = 2;
            SkinnedMeshRenderer skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
            skinnedMeshRenderer.material = BurnMomie;
            if (gameObject.name == "Momie_Boss")
            {
                MeshRenderer meshRenderer = GetComponentInChildren<MeshRenderer>();
                meshRenderer.material = BurnMomie;
                meshRenderer.materials = MomieBoss;
            }
        }
        if (col.gameObject == ArmePlayer_ref & Momie_Burn == true)
        {
            HP = HP - DamageParAttaque;
            if (HP <= 0)
                Die();
            if (gameObject.name == "Momie_Boss")
            {
                if (HP <= 50)
                {
                    Momie_Boss = true;
                }

            }
        }

    }
    //Fonction de la mort de la Momie
    private void Die()
    {
        Destroy(gameObject);
        if (gameObject.name == "Momie_Boss")
        {
            Instantiate(Artephact_ref);
        }
    }
}
