using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] List<GameObject> _spawners;
    [SerializeField] AddForceTrigger _trigger;
    public float MoneyPerSpawn;
    public int PopcornPerClick = 1;
    public float Speed = 1f;
    int _spawnerCount;
    PassiveIncomeText _incomeText;
    PopcornCountText _countText;
    public int MoneyLevel = 0;


    private void Awake()
    {
        _incomeText = FindObjectOfType<PassiveIncomeText>();
        _countText = FindObjectOfType<PopcornCountText>();
    }

    public void SwitchSpawner(int level)
    {
        if (level == 0) { return; }

        for (int i = 0; i < level; i++)
        {
            _spawners[level - i - 1].SetActive(true);
        }
        FindObjectsOfType<HosePump>().ToList().ForEach(x => x.Speed = Speed);
        _spawnerCount = level;
    }

    public void UpdateText()
    {
        _incomeText.UpdateText(MoneyPerSpawn, PopcornPerClick, Speed, _spawnerCount);
        _countText.UpdateText(PopcornPerClick, Speed, _spawnerCount);
        _trigger.SetForce(PopcornPerClick, Speed, _spawnerCount);
    }
}
