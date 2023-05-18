using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickReader : MonoBehaviour
{
    public float PumpSpeed;
    InputReader _reader;
    Coroutine _timeDecayRoutine;
    List<HosePump> _pumps = new List<HosePump>();
    bool _hasSpedUp = false;

    void Awake()
    {
        _reader = FindObjectOfType<InputReader>();
    }
    private void OnEnable() => _reader.ClickHandler += OnClick;
    private void OnDisable() => _reader.ClickHandler -= OnClick;

    public void AddPumpToList(HosePump pump)
    {
        _pumps.Add(pump);
    }
    private void OnClick()
    {

        if (_timeDecayRoutine != null)
            StopCoroutine(_timeDecayRoutine);

        _timeDecayRoutine = StartCoroutine(TimeDecay());
    }


    IEnumerator TimeDecay()
    {
        ChangeSpeed(true);
        yield return new WaitForSeconds(.25f);
        ChangeSpeed(false);
    }

    void ChangeSpeed(bool SpeedUp)
    {
        if (SpeedUp && !_hasSpedUp)
        {
            _hasSpedUp = true;
            _pumps.ForEach(x => x.Speed = PumpSpeed * 2f);
        }
        else if (!SpeedUp)
        {
            _hasSpedUp = false;
            _pumps.ForEach(x => x.Speed = PumpSpeed);
        }
        _timeDecayRoutine = null;
    }
}
