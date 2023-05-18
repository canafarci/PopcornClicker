using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerUpgrade : Upgrade
{
    [SerializeField] ParticleSystem _fx;
    override public void OnUpgradeClicked()
    {
        int maxLevel = GameManager.Instance.References.GameConfig.SpawnerUpgrades.Length;
        if (maxLevel == _level + 1) { return; }
        _fx.Play();
        base.OnUpgradeClicked();
    }

    protected override void SetLevelValues(int level)
    {
        base.SetLevelValues(level);

        GameConfig config = GameManager.Instance.References.GameConfig;

        _moneyToUpgrade = config.SpawnerUpgrades[_level].Cost;
        _text.UpdateText(_moneyToUpgrade);
        _manager.SwitchSpawner(_level);
        _manager.UpdateText();

        int maxLevel = GameManager.Instance.References.GameConfig.SpawnerUpgrades.Length;
        if (maxLevel == _level + 1) { OnMaxLevel(); }
    }
}
