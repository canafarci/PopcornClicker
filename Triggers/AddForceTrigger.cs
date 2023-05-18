using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceTrigger : MonoBehaviour
{
    [SerializeField] Vector3 _forceDirection;
    [SerializeField] ForceMode _mode;
    List<Rigidbody> _rigidbodies = new List<Rigidbody>();
    [SerializeField] float _multiplier;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Popcorn")) { return; }
        _rigidbodies.Add(other.GetComponent<Rigidbody>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Popcorn")) { return; }

        _rigidbodies.Remove(other.GetComponent<Rigidbody>());
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < _rigidbodies.Count; i++)
        {
            Rigidbody rb = _rigidbodies[i];
            if (rb == null)
            {
                _rigidbodies.RemoveAt(i);
                continue;
            }
            rb.AddForce(_forceDirection, _mode);
        }
    }

    public void SetForce(int popcornPerClick, float speed, int spawnerCount)
    {
        float magnitude = ((popcornPerClick * speed) + spawnerCount) * _multiplier * -10f;
        _forceDirection = new Vector3(0f, 0f, magnitude);
    }
}