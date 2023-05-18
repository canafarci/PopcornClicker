using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FXPool : MonoBehaviour
{
    [SerializeField] FXRow[] _particlePool = new FXRow[12];
    int _index = 0;

    public ParticleSystem GetParticle(int levelIndex)
    {
        ParticleSystem[] arr = _particlePool[levelIndex].Pool;

        ParticleSystem ps = arr[_index];
        if (_index == 9)
            _index = 0;
        else
            _index++;

        return ps;
    }
    ParticleSystem[] GetArrayFromPool(int levelIndex)
    {
        return _particlePool[levelIndex].Pool;
    }
}

[System.Serializable]
public class FXRow
{
    public ParticleSystem[] Pool;
}
