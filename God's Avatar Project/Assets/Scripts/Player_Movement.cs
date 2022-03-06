using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;



namespace GodAvatar
{
    public class Player_Movement : MonoBehaviour
    {
        [Range(1.0f,10.0f)]
        [SerializeField] private float _speed=1.0f;
        [SerializeField] private Transform _hitBox;


        [Header("Laser")]
        [SerializeField] private GameObject _laserBeam;
        [SerializeField] private Transform _beamStart;
        [SerializeField] private float _length;
        [SerializeField] private ParticleSystem _laserVFX;
        [SerializeField] private MenuCircularScript _CircularMenu;


        [Header("Artifact")]
        [SerializeField] private MagicCircle _artifact;

        private Vector3 _newVelocity;
        private int _comboCounter=0;
        private float _coolDown;
        

        // Start is called before the first frame update
        void Start()
        {
            Time.timeScale = 1f;
        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log(GetComponent<Open_CircularMenu>()._timer);

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
                        Debug.Log(collider);                 
                        if (collider.tag == "Ennemy") //TODO Decrease Ennemy Health HERE
                        {
                            collider.GetComponent<Dissolving_Controler>().PlayVFX();
                        }
                    }
                }
                
            }


            if (Comp_Playerinputs._instance.Power.PressedUp() && _CircularMenu.GetSelection() == 0 && GetComponent<Open_CircularMenu>()._timer < 180f)
            {
                
                if (_coolDown <= 0)
                {
                    StartCoroutine(LaserBeam());
                }
                
            }
            else if (Comp_Playerinputs._instance.Power.PressedUp() && _CircularMenu.GetSelection() == 1 && GetComponent<Open_CircularMenu>()._timer < 180f) 
            {
                _artifact.RingMovement();
            }

            if (_coolDown > 0)
            {
                _coolDown -= Time.deltaTime;
            }


            if (_laserBeam.activeInHierarchy)
            {
                if (Physics.Raycast(_beamStart.transform.position, transform.forward, out RaycastHit hitInfo, _length))
                {
                    if (hitInfo.collider.gameObject.layer == 9)
                    {
                        //TODO Damage Enemy
                        Debug.Log("BRULE");
                    }
                }
            }

            


        }


        IEnumerator LaserBeam()
        {
                _coolDown = 2f;
                _laserVFX.Play();
                _laserBeam.SetActive(true);
                yield return new WaitForSeconds(1);
                _laserBeam.SetActive(false);
        }
        

        //DEBUG ONLY
        //private void OnDrawGizmos()
        //{
        //    Gizmos.DrawCube(_hitBox.position, new Vector3(1f, 0.5f, 1f));
        //}


    }
}

