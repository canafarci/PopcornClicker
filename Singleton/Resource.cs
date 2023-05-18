using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public float Money { get { return currentMoney; } }
    public event Action<float> MoneyChangeHandler;
    float currentMoney;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Money"))
        {
            PlayerPrefs.SetInt("Money", GameManager.Instance.References.GameConfig.StartMoney);
            currentMoney = PlayerPrefs.GetInt("Money");
        }
        else
            currentMoney = PlayerPrefs.GetInt("Money");
    }

    public void ZeroMoney()
    {
        PlayerPrefs.SetInt("Money", 0);
        currentMoney = 0;
        MoneyChangeHandler?.Invoke(currentMoney);
    }
    public void OnMoneyChange(float change)
    {
        currentMoney += change;
        PlayerPrefs.SetInt("Money", (int)currentMoney);
        MoneyChangeHandler?.Invoke(currentMoney);
    }
}
