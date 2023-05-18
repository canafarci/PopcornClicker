using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeParticleMaterial : MonoBehaviour
{
    InputReader _reader;
    Coroutine _timeDecayRoutine;
    Renderer _renderer;
    [SerializeField] Material _idleMat, _clickmat;

    void Awake()
    {
        _reader = FindObjectOfType<InputReader>();
        _renderer = GetComponent<ParticleSystemRenderer>();
    }
    private void OnEnable() => _reader.ClickHandler += OnClick;
    private void OnDisable() => _reader.ClickHandler -= OnClick;
    private void OnClick()
    {
        if (_timeDecayRoutine != null)
            StopCoroutine(_timeDecayRoutine);

        _timeDecayRoutine = StartCoroutine(TimeDecay());
    }


    IEnumerator TimeDecay()
    {
        _renderer.material = _clickmat;
        yield return new WaitForSeconds(1f);
        _renderer.material = _idleMat;
    }

}
