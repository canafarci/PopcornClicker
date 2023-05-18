using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    [SerializeField] Transform _spawnPoint;
    [SerializeField] Rigidbody _prefab;
    [SerializeField] int _maxObjectCount;
    Queue<Rigidbody> _pool = new Queue<Rigidbody>();

    private void Awake()
    {
        SetPopcorns();
    }

    public Rigidbody GetPopcorn()
    {
        Rigidbody popcorn;
        if (_pool.TryDequeue(out popcorn))
            return popcorn;
        else
            return null;
    }

    public void QueuePopcorn(Rigidbody popcorn)
    {
        popcorn.transform.parent = transform;
        popcorn.isKinematic = true;
        popcorn.useGravity = false;
        popcorn.transform.position = _spawnPoint.position;
        popcorn.GetComponent<Collider>().material = GameManager.Instance.References.GameConfig.BasePhysicMaterial;

        _pool.Enqueue(popcorn);
    }

    void SetPopcorns()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Rigidbody popcorn = transform.GetChild(i).GetComponentInChildren<Rigidbody>();
            Animator anim = popcorn.GetComponentInChildren<Animator>();
            anim.Play("PopcornPop", 0, 0);
            anim.enabled = false;

            _pool.Enqueue(popcorn);
        }
    }

}
