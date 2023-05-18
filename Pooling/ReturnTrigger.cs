using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnTrigger : MonoBehaviour
{
    Pooler _pooler;
    private void Awake()
    {
        _pooler = FindObjectOfType<Pooler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Popcorn"))
        {
            _pooler.QueuePopcorn(other.GetComponent<Rigidbody>());
        }
    }
}
