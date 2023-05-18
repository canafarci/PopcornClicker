using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Config/New Game Config", order = 0)]
public class GameConfig : ScriptableObject
{
    public int StartMoney;
    public AudioConfig[] PopcornSounds;
    public MoneyUpgrades[] MoneyUpgrades;
    public CountUpgrades[] CountUpgrades;
    public SpeedUpgrades[] SpeedUpgrades;
    public SpawnerUpgrades[] SpawnerUpgrades;
    public PhysicMaterial OutPhysicMaterial, BasePhysicMaterial;
}

[System.Serializable]
public class AudioConfig
{
    public AudioClip Audio;
    public float Volume;
}
[System.Serializable]
public struct MoneyUpgrades
{
    public float MoneyPerSpawn;
    public int Cost;
}
[System.Serializable]
public struct CountUpgrades
{
    public int Count;
    public int Cost;
}
[System.Serializable]
public struct SpeedUpgrades
{
    public float Speed;
    public int Cost;
}
[System.Serializable]
public struct SpawnerUpgrades
{
    public int Cost;
}
