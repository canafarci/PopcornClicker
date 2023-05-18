using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyUpgrade : Upgrade
{
    override public void OnUpgradeClicked()
    {
        int maxLevel = GameManager.Instance.References.GameConfig.MoneyUpgrades.Length;
        if (maxLevel == _level + 1) { return; }

        base.OnUpgradeClicked();
    }

    protected override void SetLevelValues(int level)
    {
        base.SetLevelValues(level);

        GameConfig config = GameManager.Instance.References.GameConfig;

        _moneyToUpgrade = config.MoneyUpgrades[_level].Cost;
        _manager.MoneyPerSpawn = config.MoneyUpgrades[_level].MoneyPerSpawn;
        _text.UpdateText(_moneyToUpgrade);
        _manager.UpdateText();
        _manager.MoneyLevel = _level;

        int maxLevel = GameManager.Instance.References.GameConfig.MoneyUpgrades.Length;
        if (maxLevel == _level + 1) { OnMaxLevel(); }
    }
}
