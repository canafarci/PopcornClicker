using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgrade : Upgrade
{
    override public void OnUpgradeClicked()
    {
        int maxLevel = GameManager.Instance.References.GameConfig.SpeedUpgrades.Length;
        if (maxLevel == _level + 1) { return; }

        base.OnUpgradeClicked();
    }

    protected override void SetLevelValues(int level)
    {
        base.SetLevelValues(level);

        GameConfig config = GameManager.Instance.References.GameConfig;

        _moneyToUpgrade = config.SpeedUpgrades[_level].Cost;
        _manager.Speed = config.SpeedUpgrades[_level].Speed;
        _text.UpdateText(_moneyToUpgrade);
        FindObjectOfType<HosePump>().Speed = _manager.Speed;
        _manager.UpdateText();

        ClickReader _reader = FindObjectOfType<ClickReader>();
        _reader.PumpSpeed = _manager.Speed;

        int maxLevel = GameManager.Instance.References.GameConfig.SpeedUpgrades.Length;
        if (maxLevel == _level + 1) { OnMaxLevel(); }
    }
}
