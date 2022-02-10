using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //Important pour toutes les IAs !

public class FollowPlayer : MonoBehaviour
{
    public GameObject Follow; //L'objet a suivre
    private NavMeshAgent Scorpion; //NavMeshAgent qui suit


    private void Start()
    {
        Scorpion = GetComponent<NavMeshAgent>(); //Prend le component "NavMeshAgent" de son objet (objet où est le script) et le sauvegarde dans "Blob"
        Follow = GameObject.Find("Player"); //trouve un Gameobject de nom "MobFollowThis" et le sauvegarde dans "Follow"
    }


    private void Update()
    {
        Scorpion.SetDestination(Follow.transform.position); //Blob va à la position de l'objet a suivre
    }
}
