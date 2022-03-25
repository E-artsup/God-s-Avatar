using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GodAvatar
{
    public class UseRayon : MonoBehaviour
    {
        [SerializeField] private Comp_Playerinputs _inputs;

        public bool _beamSelected = true;

        public Transform RayonLaser;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (_inputs.Power.PressedDown() && _beamSelected)
            {
                Instantiate(RayonLaser, gameObject.transform.position, transform.rotation, transform.parent);
                //Instantiate(RayonLaser, transform.parent);
            }
        }
    }
}

