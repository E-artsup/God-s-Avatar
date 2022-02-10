using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GodAvatar
{
    public class Player_Movement : MonoBehaviour
    {
        [Range(1.0f,10.0f)]
        [SerializeField] private float _speed=1.0f;
        [SerializeField] private Transform _hitBox;

        private Comp_Playerinputs _inputs;
        private Vector3 _newVelocity;
        private int _comboCounter=0;


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

            if (_inputs.Attack.PressedDown())
            {

                Collider[] _colliders = Physics.OverlapBox(_hitBox.position, new Vector3(1f,0.5f,1f)); // Check if a Collider entered th hitbox Zone
                _comboCounter++;

                if (_comboCounter >3)
                {
                    _comboCounter = 0;
                }

                //Debug.Log(_comboCounter);

                if (_colliders != null)
                {
                    foreach (Collider collider in _colliders)
                    {
                        Debug.Log(collider);                    //TODO Decrease Ennemy Health HERE
                    }
                }
                
            }

        }

        //DEBUG ONLY
        private void OnDrawGizmos()
        {
            Gizmos.DrawCube(_hitBox.position, new Vector3(1f, 0.5f, 1f));
        }


    }
}

