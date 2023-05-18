using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyContainer : MonoBehaviour
{
    [SerializeField] int _maxPopcorns;
    int _popcornCount = 0;
    MoveContainer _mover;
    private void Awake()
    {
        _mover = GetComponent<MoveContainer>();
    }
    public void OnPopcornPassTrigger()
    {
        _popcornCount++;

        if (_popcornCount > _maxPopcorns)
        {
            _mover.Move();
            _popcornCount = 0;
        }
    }

}
