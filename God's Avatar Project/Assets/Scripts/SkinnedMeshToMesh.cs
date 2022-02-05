using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SkinnedMeshToMesh : MonoBehaviour
{

    public SkinnedMeshRenderer _skinnedMesh;
    public VisualEffect _vfxGraph;
    public float _refreshRate = 0.02f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateVFXGraph());
    }

    IEnumerator UpdateVFXGraph()
    {
        while (gameObject.activeSelf)
        {
            Mesh _mesh = new Mesh();
            _skinnedMesh.BakeMesh(_mesh);

            Vector3[] vertices = _mesh.vertices;
            Mesh _mesh2 = new Mesh();
            _mesh2.vertices = _mesh.vertices;

            _vfxGraph.SetMesh("Mesh", _mesh2);
            yield return new WaitForSeconds(_refreshRate);

        }
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
