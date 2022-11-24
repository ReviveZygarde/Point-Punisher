using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public AudioSource shootSoundEffect;
    public AudioSource lowHPsoundLoop;
    public AudioSource getStar;
    public AudioSource errorSound;
    public AudioSource deathSound;

    public void shootSoundPlayback()
    {
        shootSoundEffect.Play();
    }

    public void lowHPalarmPlayback()
    {
        if (lowHPsoundLoop.isPlaying == false)
        {
            lowHPsoundLoop.Play();
        }
    }

    public void lowHPalarmStop()
    {
        if (lowHPsoundLoop.isPlaying)
        {
            lowHPsoundLoop.Stop();
        }
    }

    public void deathSoundPlay()
    {
        deathSound.Play();
    }

    public void starSoundEffect()
    {
        getStar.Play();
    }

    public void errorPlay()
    {
        errorSound.Play();
    }


}
