using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace GodAvatar
{
    public class Combat : MonoBehaviour
    {

        public GameObject player;

        private PointDeVie pdv;

        public int hp = 10;
        public int damage = -5;
        public int poisonDamage = -5;
        public float poisonDelay = 1.0f;
        public float vitesseAttaque = 3.0f;

        private bool cb;

        private void Start()
        {
            cb = false;
            player = GameObject.Find("Player");
            pdv = player.GetComponent<PointDeVie>();

            hp = 10;
            damage = -5;
            poisonDamage = -5;
            poisonDelay = 1.0f;
            vitesseAttaque = 3.0f;
        }

        //Mort
        private void Update()
        {
            if (hp <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        //Attaque
        private void OnTriggerEnter(Collider other)
        {
            if (player != null && pdv != null)
            {
                Debug.Log("le player existe");
                if (other.gameObject == player)
                {
                    Debug.Log("le player est bien détecter");
                    cb = true;
                    StartCoroutine(AttaqueAuPoison());
                }
            }
        }

        //N'attaque plus
        private void OnTriggerExit(Collider other)
        {
            cb = false;
            Debug.Log("N'attaque plus");
        }

        //lance l'attaque
        IEnumerator AttaqueAuPoison()
        {
            while (cb)
            {
                Debug.Log("Attaque");
                pdv.Poisoned(damage, poisonDamage, poisonDelay);
                yield return new WaitForSeconds(vitesseAttaque);
            }
        }
    }
}

