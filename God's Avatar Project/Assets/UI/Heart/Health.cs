using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private int health; // Les points de vie actuel du Joueur
    [SerializeField] private int numOfhearts; // Nombre de coeurs total du joueur

    public Image[] hearts; // Toutes les coeurs
    [SerializeField] private Sprite heartFull; // Sprite du coeur plein
    [SerializeField] private Sprite heartEmpty; // Sprite du coeur vide

    // Update is called once per frame
    void Update()
    {

        if (health > numOfhearts)
        {
            health = numOfhearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {

            if(i < health)
            {
                hearts[i].sprite = heartFull;
            } else {
                hearts[i].sprite = heartEmpty;
            }

            if(i < numOfhearts)
            {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }

        }

    }
}
