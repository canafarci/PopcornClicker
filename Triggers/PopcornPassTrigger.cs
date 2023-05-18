using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopcornPassTrigger : MonoBehaviour
{
    EmptyContainer _container;
    Pooler _pooler;

    private void Awake()
    {
        _container = GetComponentInParent<EmptyContainer>();
        _pooler = FindObjectOfType<Pooler>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Popcorn")) { return; }

        StartCoroutine(DelayedDestroy(other));
        _container.OnPopcornPassTrigger();
    }

    IEnumerator DelayedDestroy(Collider other)
    {
        other.transform.parent = transform;
        other.GetComponent<Collider>().material = GameManager.Instance.References.GameConfig.OutPhysicMaterial;
        yield return new WaitForSeconds(2f);
        if (other.transform.parent != transform) { yield break; }
        Rigidbody rb = other.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
    }
}
