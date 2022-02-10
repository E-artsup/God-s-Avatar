using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health; // Les points de vie actuel du Joueur
    [SerializeField] private int _numOfhearts; // Nombre de coeurs total du joueur

    public Image[] hearts; // Toutes les coeurs
    [SerializeField] private Sprite _heartFull; // Sprite du coeur plein
    [SerializeField] private Sprite _heartEmpty; // Sprite du coeur vide

    // Update is called once per frame
    void Update()
    {

        if (_health > _numOfhearts)
        {
            _health = _numOfhearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {

            if(i < _health)
            {
                hearts[i].sprite = _heartFull;
            } else {
                hearts[i].sprite = _heartEmpty;
            }

            if(i < _numOfhearts)
            {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }

        }

    }
}
