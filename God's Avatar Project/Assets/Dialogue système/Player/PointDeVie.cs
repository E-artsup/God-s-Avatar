using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDeVie : MonoBehaviour
{
    public int playerhp;
    public float timer;
    public float _timer;

    private void Start()
    {
        playerhp = 50;
    }

    public void Poisoned(int damage, int poisonDamage, float poisonDelay)
    {
        int _poisonDamage = poisonDamage;
        float _poisonDelay = poisonDelay;
        Debug.Log("Empoisonné");
        playerhp = playerhp + damage;
        new WaitForSeconds(poisonDelay);
        StartCoroutine(Poison(_poisonDamage, _poisonDelay));
    }

    IEnumerator Poison(int _poisonDamage, float _poisonDelay)
    {
        yield return new WaitForSeconds(_poisonDelay);
        playerhp = playerhp + _poisonDamage;
        Debug.Log("Dégats de poison");
        yield return new WaitForSeconds(_poisonDelay);
        playerhp = playerhp + _poisonDamage;
        Debug.Log("Dégats de poison");
        Debug.Log("fin du poison");
        yield return new WaitForSeconds(0f);
    }
}
