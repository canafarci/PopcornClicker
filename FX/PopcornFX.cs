using System.Collections;
using System.Collections.Generic;
using CartoonFX;
using UnityEngine;

public class PopcornFX : MonoBehaviour
{
    PopcornSound _sound;
    private void Awake()
    {
        _sound = GetComponent<PopcornSound>();
    }
    public void PlayFX()
    {
        PlayFXFromPool();
        _sound.PlayFX();
    }

    void PlayFXFromPool()
    {
        //get index array
        FXPool pool = GameManager.Instance.References.FXPool;
        //access fx array
        ParticleSystem particle = pool.GetParticle(GameManager.Instance.References.Manager.MoneyLevel);

        //move fx
        particle.transform.position = transform.position + new Vector3(0f, 0f, -2f) + new Vector3(
                                                                                            Random.Range(-0.50f, 0.50f),
                                                                                            Random.Range(-0.50f, 0.50f),
                                                                                            0f);

        //play fx
        particle.Stop();
        particle.Play();

        //return fx to pool

    }
}
