using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    [SerializeField] Transform _spawnPoint;
    [SerializeField] Vector3 _startVelocityMax, _startVelocityMin;
    [SerializeField] bool _mainSpawner;
    UpgradeManager _upgradeManager;
    Pooler _pooler;
    public event Action PopcornSpawnedHandler;


    private void Awake()
    {
        _upgradeManager = FindObjectOfType<UpgradeManager>();
        _pooler = FindObjectOfType<Pooler>();

    }
    public void Spawn() => SpawnPopcorns();
    private void SpawnPopcorns()
    {
        if (_mainSpawner)
        {
            for (int i = 0; i < _upgradeManager.PopcornPerClick; i++)
                SpawnPopcorn();
        }
        else
            SpawnPopcorn();

    }

    private void SpawnPopcorn()
    {

        Rigidbody popcorn = _pooler.GetPopcorn();
        if (popcorn == null) { return; }
        popcorn.GetComponentInChildren<Animator>().enabled = true;

        popcorn.transform.position = _spawnPoint.position;
        popcorn.isKinematic = false;
        popcorn.useGravity = true;

        popcorn.transform.GetComponentInChildren<PopcornFX>().PlayFX();
        popcorn.GetComponentInChildren<ParticleSystem>().Play();


        Vector3 spawnVelocity = new Vector3(
                                            UnityEngine.Random.Range(_startVelocityMin.x, _startVelocityMax.x),
                                            UnityEngine.Random.Range(_startVelocityMin.y, _startVelocityMax.y),
                                            UnityEngine.Random.Range(_startVelocityMin.z, _startVelocityMax.z)
                                            );
        popcorn.velocity = spawnVelocity;

        PopcornSpawnedHandler?.Invoke();

        float moneyGained = _upgradeManager.MoneyPerSpawn;
        GameManager.Instance.Resources.OnMoneyChange(moneyGained);
    }
}
