using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


namespace GodAvatar
{
    public class Dissolving_Controler : MonoBehaviour
    {

        //public Animator _animator;
        public SkinnedMeshRenderer _skinnedMeshRenderer;
        public VisualEffect _vfxGraph;
        public float _dissolveRate = 0.02f;
        public float _refreshRate = 0.05f;
        public float _dieDelay = 0.2f;

        private Material[] _dissolveMaterials;
        private bool _isDying = false;
        // Start is called before the first frame update
        void Start()
        {
            if (_vfxGraph != null)
            {
                _vfxGraph.Stop();
                _vfxGraph.gameObject.SetActive(false);
            }

            if (_skinnedMeshRenderer != null)
            {
                _dissolveMaterials = _skinnedMeshRenderer.materials;
            }


        }

        // Update is called once per frame
        void Update()
        {

        }


        public void PlayVFX()
        {
            if (!_isDying)
            {
                StartCoroutine(Dissolve());
                _isDying = true;
            }

        }


        IEnumerator Dissolve()
        {
            //if (_animator != null)
            //{
            //    _animator.SetTrigger("Die");
            //    Debug.Log("Die");
            //}

            yield return new WaitForSeconds(_dieDelay);

            if (_vfxGraph != null)
            {
                _vfxGraph.gameObject.SetActive(true);
                _vfxGraph.Play();
            }

            float counter = 0f;

            if (_dissolveMaterials.Length > 0)
            {
                while (_dissolveMaterials[0].GetFloat("DissolveAmount_") < 1)
                {
                    counter += _dissolveRate;

                    for (int i = 0; i < _dissolveMaterials.Length; i++)
                    {
                        _dissolveMaterials[i].SetFloat("DissolveAmount_", counter);
                    }

                    yield return new WaitForSeconds(_refreshRate);
                }
            }

            Destroy(gameObject, 1);

        }


    }
}

