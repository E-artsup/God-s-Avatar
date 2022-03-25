using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


namespace GodAvatar
{
    public class MagicCircle : MonoBehaviour
    {
        [SerializeField] private VisualEffect _vfx;
        [SerializeField] private VisualEffect _vfxEnemy;


        private Animator _animator;
        private bool _isActive = false;
        private bool _isPlaying= false;
        //private GameObject[] _enemyInRange;
        private List<GameObject> _enemyInRange = new List<GameObject>();
        private int _index=0;
        // Start is called before the first frame update
        void Start()
        {
            _animator = GetComponent<Animator>();
            _vfx.Stop();
        }

        // Update is called once per frame
        void Update()
        {
            if (_enemyInRange.Count != 0)
            {
                for (int i = 0; i < _enemyInRange.Count; i++)
                {
                    if (Vector3.Distance(transform.position, _enemyInRange[i].transform.position) > (6.2f*transform.localScale.x/0.02f)) 
                    {
                        _enemyInRange[i].SetActive(true);
                        _vfxEnemy.SetVector3("EnemyPosition",_enemyInRange[i].transform.position);
                        _vfxEnemy.Play();
                        _enemyInRange.Remove(_enemyInRange[i]);
                    }
                }
            }
        }



        public void RingMovement()
        {
            if (!_isActive)
            {
                _animator.SetBool("OpenCircle", true);
                _isActive = true;
                _isPlaying = true;
            }
            else
            {
                _animator.SetBool("OpenCircle", false);
                _isActive = false;
                _isPlaying = true;
                
            }

            if (transform.localScale == Vector3.zero)
            {
                if (_isPlaying) 
                {
                    _vfx.Play(); //Because of the very short time between the animation start and the if test
                    Debug.Log("PLAY");
                    _isPlaying = false;
                }
                
            }
            else
            {
                if (_isPlaying)
                {
                    _vfx.Stop();
                    Debug.Log("STOP");
                    _isPlaying = false;
                }
                
            }
        }

        private void OnTriggerEnter(Collider other) 
        {
            if (other.gameObject.layer == 9)
            {
                _enemyInRange.Add(other.gameObject);
                _vfxEnemy.SetVector3("EnemyPosition",other.gameObject.transform.position);
                _vfxEnemy.Play();
                other.gameObject.SetActive(false);
                Debug.Log(_enemyInRange);
            }
        }
    }
}

