using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class MoveContainer : MonoBehaviour
{
    [SerializeField] Transform _container1, _container2, _target;
    [SerializeField] ParticleSystem _fx;
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] Animator _animator;
    Transform _currentContainer;
    Vector3 _mainPos, _spawnPos;
    int _cycleIndex = 0;
    bool _isMoving = false;
    Vector3 _startPos;
    UpgradeManager _manager;

    private void Awake()
    {
        _currentContainer = _container1;
        _mainPos = _currentContainer.position;
        _spawnPos = _container2.position;
        _startPos = _text.transform.position;
        _manager = FindObjectOfType<UpgradeManager>();
    }
    public void Move()
    {
        if (_isMoving) return;
        _isMoving = true;

        _fx.Play();
        float money = _manager.MoneyPerSpawn * 25f;
        _text.text = "$" + money.ToString() ;
        _animator.Play("TextAnim", 0, 0f);
        GameManager.Instance.Resources.OnMoneyChange(money);

        Transform container = _currentContainer;
        container.DOMove(_target.position, .50f).onComplete = () =>
        {
            container.position = _spawnPos;
            container.GetComponentInChildren<BoxMatChanger>().ChangeMaterial();
        };

        Transform second = _currentContainer == _container1 ? _container2 : _container1;
        second.DOMove(_mainPos, .51f).onComplete = () =>
        {
            _currentContainer = second;
            _isMoving = false;
        };
    }
}
