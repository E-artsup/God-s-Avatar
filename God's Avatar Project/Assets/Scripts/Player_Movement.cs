using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace GodAvatar
{
    public class Player_Movement : MonoBehaviour
    {

        [Header("Player Movement/Action")]
        [Range(1.0f,10.0f)]
        [SerializeField] private float _speed=1.0f;
        [SerializeField] private Transform _hitBox;

        [Header("Laser")]
        [SerializeField] private float _length;
        [SerializeField] private VisualEffect _laserVFX;

        private Vector3 _newVelocity;
        private int _comboCounter=0;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            Vector3 _moveInputVector = new Vector3(Comp_Playerinputs._instance.MoveAxisRightRaw, 0, Comp_Playerinputs._instance.MoveAxisForwardRaw);
            _newVelocity = _moveInputVector * _speed;
            transform.Translate(_newVelocity * Time.deltaTime, Space.World);

            if (Comp_Playerinputs._instance.Attack.PressedDown())
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

            if (Comp_Playerinputs._instance.Power.PressedDown())
            {
                _laserVFX.Play();

                if (Physics.Raycast(_hitBox.position, transform.forward, out RaycastHit _hitInfo, _length))
                {
                    if (_hitInfo.collider.gameObject.layer == 7)
                    {
                        //TODO Damage Enemy
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
