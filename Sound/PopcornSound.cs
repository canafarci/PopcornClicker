using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopcornSound : MonoBehaviour
{
    public void PlayFX()
    {
        AudioPlayer player = GameManager.Instance.AudioManager;
        AudioConfig[] configs = GameManager.Instance.References.GameConfig.PopcornSounds;
        AudioConfig config = configs[Random.Range(0, configs.Length)];

        player.PlayAudio(config.Audio, config.Volume);
    }


}
