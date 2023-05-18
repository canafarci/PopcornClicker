using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMatChanger : MonoBehaviour
{
    Renderer _renderer;
    Material _mat1;
    [SerializeField] Material[] _mats;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _mat1 = _renderer.materials[0];
    }

    public void ChangeMaterial()
    {
        int randInt = Random.Range(0, _mats.Length);
        Material mat2 = _mats[randInt];

        Material[] newMats = new Material[] { _mat1, mat2 };
        _renderer.materials = newMats;
    }
}
