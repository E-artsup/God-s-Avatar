using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP_TO_DUNGEON : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.layer == playerMask)
        {
            Debug.Log("Player/Trigger");
            other.transform.position = new Vector3(343f, 2.7f, 11f);
        }
        Debug.Log("Collision/Trigger");
    }
}
