using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GodAvatar
{
    public class Player_Movement : MonoBehaviour
    {
        [Range(1.0f,10.0f)]
        [SerializeField] private float _speed=1.0f;

        private Comp_Playerinputs _inputs;
        private Vector3 _newVelocity;


        // Start is called before the first frame update
        void Start()
        {
            _inputs = GetComponent<Comp_Playerinputs>();
        }

        // Update is called once per frame
        void Update()
        {

            Vector3 _moveInputVector = new Vector3(_inputs.MoveAxisRightRaw, 0, _inputs.MoveAxisForwardRaw);
            _newVelocity = _moveInputVector * _speed;
            transform.Translate(_newVelocity * Time.deltaTime, Space.World);




        }
    }
}

