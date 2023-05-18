using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountUpgrade : Upgrade
{
    override public void OnUpgradeClicked()
    {
        int maxLevel = GameManager.Instance.References.GameConfig.CountUpgrades.Length;
        if (maxLevel == _level + 1) { return; }

        base.OnUpgradeClicked();
    }

    protected override void SetLevelValues(int level)
    {
        base.SetLevelValues(level);

        GameConfig config = GameManager.Instance.References.GameConfig;

        _moneyToUpgrade = config.CountUpgrades[_level].Cost;
        _manager.PopcornPerClick = config.CountUpgrades[_level].Count;
        _text.UpdateText(_moneyToUpgrade);
        _manager.UpdateText();

        int maxLevel = GameManager.Instance.References.GameConfig.CountUpgrades.Length;
        if (maxLevel == _level + 1) { OnMaxLevel(); }
    }
}
