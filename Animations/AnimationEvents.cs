using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    [SerializeField] ParticleSystem[] _FX;
    Spawner _spawner;

    private void Awake()
    {
        _spawner = transform.parent.parent.parent.GetComponentInChildren<Spawner>();
    }

    public void Spawn()
    {
        _spawner.Spawn();
    }


    public void PlayFX()
    {
        foreach (ParticleSystem PS in _FX)
        {
            PS.Play();
        }
    }
}
