using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    InputReader _reader;
    Coroutine _timeDecayRoutine;
    float _multiplier = 10f;
    HingeJoint _joint;

    void Awake()
    {
        _reader = FindObjectOfType<InputReader>();
        _joint = GetComponent<HingeJoint>();
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
        _joint.useMotor = true;
        if (_joint.motor.targetVelocity < 500f)
        {
            JointMotor motor = new JointMotor();
            motor.targetVelocity = _joint.velocity + _multiplier;
            motor.force = 50f;

            _joint.motor = motor;
        }

        yield return new WaitForSeconds(3f);
        _joint.useMotor = false;

        JointMotor newMotor = new JointMotor();
        newMotor.force = 50f;
        newMotor.targetVelocity = 0f;
        _joint.motor = newMotor;
    }
}
