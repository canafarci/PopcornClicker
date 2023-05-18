using System;
using System.Collections;
using System.Collections.Generic;
using Lofelt.NiceVibrations;
using UnityEngine;

public class Haptics : MonoBehaviour
{
    InputReader _reader;
    private void Awake() => _reader = FindObjectOfType<InputReader>();
    private void OnEnable() => _reader.ClickHandler += OnClick;
    private void OnDisable() => _reader.ClickHandler -= OnClick;

    private void OnClick()
    {
        HapticPatterns.PlayPreset(HapticPatterns.PresetType.LightImpact);
    }
}
